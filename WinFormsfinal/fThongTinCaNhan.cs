using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;   // dùng cho MakeSquare
using System.Globalization;       // << thêm để parse/format ngày sinh
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class fThongTinCaNhan : Form
    {
        private readonly string _username;
        private string _maNguoiDung = string.Empty;
        private string _matKhauHienTai = string.Empty;

        // ====== Ảnh đại diện ======
        private byte[]? _hinhAnhCurrent = null;  // ảnh hiện có trong DB
        private byte[]? _hinhAnhPending = null;  // ảnh người dùng vừa chọn (chưa lưu)
        private bool _clearImage = false;        // người dùng chọn xoá ảnh

        // ====== Nút con mắt show/hide mật khẩu ======
        private Guna2Button _eyeCu = null!;
        private Guna2Button _eyeMoi = null!;
        private Guna2Button _eyeMoi2 = null!;
        private bool _isCuVisible = false, _isMoiVisible = false, _isMoi2Visible = false;

        public fThongTinCaNhan(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;

            lblUserCaption.Text = "Tài khoản: " + _username;

            // load dữ liệu khi form mở
            this.Load += fThongTinCaNhan_Load;

            // setup nút con mắt cho 3 ô mật khẩu
            SetupPasswordEyes();
        }

        // ====== DB ======
        private string GetConnectionString()
        {
            string dbPath = @"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\project_final.db";
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("KHÔNG tìm thấy file DB tại:\n" + dbPath,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return $"Data Source={dbPath}";
        }

        // Đảm bảo có cột HinhAnh trong bảng NguoiDung (migration an toàn)
        private void EnsureNguoiDungHasImageColumn(SqliteConnection conn)
        {
            try
            {
                bool hasCol = false;
                using (var cmd = new SqliteCommand("PRAGMA table_info(NguoiDung);", conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var colName = rd["name"]?.ToString();
                        if (string.Equals(colName, "HinhAnh", StringComparison.OrdinalIgnoreCase))
                        {
                            hasCol = true;
                            break;
                        }
                    }
                }

                if (!hasCol)
                {
                    using (var alter = new SqliteCommand("ALTER TABLE NguoiDung ADD COLUMN HinhAnh BLOB NULL;", conn))
                    {
                        alter.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Bỏ qua nếu không thể alter (ví dụ đã có cột)
            }
        }

        private void fThongTinCaNhan_Load(object? sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();

                    // Đảm bảo có cột HinhAnh
                    EnsureNguoiDungHasImageColumn(conn);

                    string sql = @"
                        SELECT tk.MaTaiKhoan,
                               tk.MaNguoiDung,
                               tk.MatKhau,
                               nd.HoTen,
                               nd.MaSoThe,
                               nd.NgaySinh,
                               nd.SoDienThoai,
                               nd.Email,
                               nd.DiaChi,
                               nd.HinhAnh
                        FROM TaiKhoan tk
                        LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
                        WHERE tk.TenDangNhap = @user
                    ";

                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", _username);

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                _maNguoiDung = rd["MaNguoiDung"] as string ?? string.Empty;

                                txtHoTen.Text  = rd["HoTen"]       as string ?? "";
                                txtEmail.Text  = rd["Email"]       as string ?? "";
                                txtSDT.Text    = rd["SoDienThoai"] as string ?? "";
                                txtDiaChi.Text = rd["DiaChi"]      as string ?? "";

                                // ==== Ngày sinh: cố gắng hiển thị dd/MM/yyyy, không parse được thì để nguyên ====
                                var nsVal = rd["NgaySinh"];
                                if (nsVal != DBNull.Value)
                                {
                                    var raw = nsVal.ToString();
                                    if (TryParseNgaySinh(raw!, out var dNs))
                                        txtNgaySinh.Text = dNs.ToString("dd/MM/yyyy");
                                    else
                                        txtNgaySinh.Text = raw ?? "";
                                }
                                else
                                {
                                    txtNgaySinh.Text = "";
                                }

                                txtTenDangNhap.Text = _username;
                                _matKhauHienTai     = rd["MatKhau"] as string ?? "";

                                // ==== Ảnh đại diện ====
                                if (rd["HinhAnh"] != DBNull.Value)
                                {
                                    _hinhAnhCurrent = (byte[])rd["HinhAnh"];
                                    var img = BytesToImage(_hinhAnhCurrent);
                                    picAvatar.Image = (img != null) ? MakeSquare(img, picAvatar.Width) : null;
                                }
                                else
                                {
                                    _hinhAnhCurrent = null;
                                    picAvatar.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }

        // ====== Parse ngày để hiển thị dd/MM/yyyy khi load ======
        private static bool TryParseNgaySinh(string input, out DateTime d)
        {
            d = default;
            if (string.IsNullOrWhiteSpace(input)) return false;

            var vi = CultureInfo.GetCultureInfo("vi-VN");
            string[] formats =
            {
                "dd/MM/yyyy", "d/M/yyyy",
                "dd-MM-yyyy", "d-M-yyyy",
                "yyyy-MM-dd", "yyyy/MM/dd",
                "MM/dd/yyyy", "M/d/yyyy"
            };

            return DateTime.TryParseExact(input, formats, vi, DateTimeStyles.None, out d)
                || DateTime.TryParse(input, vi, DateTimeStyles.None, out d)
                || DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        }

        // ====== Convert ảnh <-> bytes ======
        private static byte[] ImageToBytes(Image img)
        {
            using var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        private static Image? BytesToImage(byte[]? data)
        {
            if (data == null || data.Length == 0) return null;
            using var ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        // ====== Cắt ảnh vuông & scale cho khung ======
        private static Image MakeSquare(Image src, int edge)
        {
            int side = Math.Min(src.Width, src.Height);
            int x = (src.Width - side) / 2;
            int y = (src.Height - side) / 2;

            using var square = new Bitmap(side, side);
            using (var g = Graphics.FromImage(square))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode     = SmoothingMode.AntiAlias;
                g.PixelOffsetMode   = PixelOffsetMode.HighQuality;
                g.DrawImage(src, new Rectangle(0, 0, side, side),
                                new Rectangle(x, y, side, side), GraphicsUnit.Pixel);
            }

            var bmp = new Bitmap(edge, edge);
            using (var g2 = Graphics.FromImage(bmp))
            {
                g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g2.SmoothingMode     = SmoothingMode.AntiAlias;
                g2.PixelOffsetMode   = PixelOffsetMode.HighQuality;
                g2.DrawImage(square, 0, 0, edge, edge);
            }
            return bmp;
        }

        // ====== Chọn ảnh mới ======
        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Ảnh (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fi = new FileInfo(ofd.FileName);
                    if (fi.Length > 2 * 1024 * 1024)
                    {
                        MessageBox.Show("Ảnh vượt quá 2MB, vui lòng chọn ảnh nhỏ hơn.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    using var img = Image.FromStream(fs);

                    // Cắt vuông & scale theo khung hiển thị
                    var showImg = MakeSquare(img, picAvatar.Width);
                    picAvatar.Image = showImg;

                    // Lưu bytes ảnh đã chuẩn hoá vào DB
                    _hinhAnhPending = ImageToBytes(showImg);
                    _clearImage = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đọc ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ====== Xoá ảnh ======
        private void btnXoaAnh_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xoá ảnh đại diện?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            picAvatar.Image = null;
            _hinhAnhPending = null;
            _clearImage = true;
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            string matKhauCu = txtPassCu.Text.Trim();
            string matKhauMoi = txtPassMoi.Text.Trim();
            string matKhauMoi2 = txtNhapLaiPassMoi.Text.Trim();

            // ---- validate thông tin cơ bản ----
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ShowError("Vui lòng nhập Họ tên.");
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                ShowError("Email không hợp lệ.");
                txtEmail.Focus();
                return;
            }

            // Ngày sinh: KHÔNG kiểm tra; lưu nguyên văn chuỗi người dùng nhập (hoặc null nếu trống)
            string? ngaySinhSave = string.IsNullOrWhiteSpace(ngaySinhText) ? null : ngaySinhText;

            // ---- kiểm tra đổi mật khẩu (nếu có nhập) ----
            bool doiMatKhau = !string.IsNullOrEmpty(matKhauCu)
                              || !string.IsNullOrEmpty(matKhauMoi)
                              || !string.IsNullOrEmpty(matKhauMoi2);

            if (doiMatKhau)
            {
                if (string.IsNullOrEmpty(matKhauCu) ||
                    string.IsNullOrEmpty(matKhauMoi) ||
                    string.IsNullOrEmpty(matKhauMoi2))
                {
                    ShowError("Vui lòng nhập đầy đủ 3 ô mật khẩu.");
                    return;
                }

                if (!string.Equals(matKhauCu, _matKhauHienTai))
                {
                    ShowError("Mật khẩu hiện tại không đúng.");
                    txtPassCu.Focus();
                    return;
                }

                if (matKhauMoi.Length < 6)
                {
                    ShowError("Mật khẩu mới phải có ít nhất 6 ký tự.");
                    txtPassMoi.Focus();
                    return;
                }

                if (matKhauMoi != matKhauMoi2)
                {
                    ShowError("Mật khẩu mới nhập lại không khớp.");
                    txtNhapLaiPassMoi.Focus();
                    return;
                }
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn lưu thay đổi?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // ---------- 1) Cập nhật / tạo bản ghi NguoiDung ----------
                        if (!string.IsNullOrEmpty(_maNguoiDung))
                        {
                            // Đã có MaNguoiDung -> UPDATE
                            // Build SQL động cho phần ảnh
                            string sqlUpdateND = @"
                                UPDATE NguoiDung
                                SET HoTen       = @hoten,
                                    NgaySinh    = @ngaysinh,
                                    Email       = @email,
                                    SoDienThoai = @sdt,
                                    DiaChi      = @diachi";

                            if (_clearImage)
                            {
                                sqlUpdateND += ", HinhAnh = NULL";
                            }
                            else if (_hinhAnhPending != null)
                            {
                                sqlUpdateND += ", HinhAnh = @hinhAnh";
                            }

                            sqlUpdateND += " WHERE MaNguoiDung = @id;";

                            using (var cmdND = new SqliteCommand(sqlUpdateND, conn, tran))
                            {
                                cmdND.Parameters.AddWithValue("@hoten", hoTen);
                                cmdND.Parameters.AddWithValue("@ngaysinh",
                                    (object?)ngaySinhSave ?? DBNull.Value);
                                cmdND.Parameters.AddWithValue("@email", email);
                                cmdND.Parameters.AddWithValue("@sdt", sdt);
                                cmdND.Parameters.AddWithValue("@diachi", diaChi);
                                cmdND.Parameters.AddWithValue("@id", _maNguoiDung);

                                if (!_clearImage && _hinhAnhPending != null)
                                {
                                    cmdND.Parameters.Add("@hinhAnh", SqliteType.Blob).Value = _hinhAnhPending;
                                }

                                cmdND.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Chưa có NguoiDung, tạo mới 1 mã ND tạm
                            string newId = "ND_" + _username;

                            string sqlInsertND = @"
                                INSERT INTO NguoiDung
                                    (MaNguoiDung, HoTen, MaSoThe, NgaySinh,
                                     SoDienThoai, Email, DiaChi, NgayTaoThe,
                                     NgayHetHanThe, TrangThai, HinhAnh)
                                VALUES
                                    (@id, @hoten, 'TVTEMP', @ngaysinh,
                                     @sdt, @email, @diachi, date('now'),
                                     date('now','+1 year'), 'BiKhoa', @hinhAnh)
                            ";

                            using (var cmdND = new SqliteCommand(sqlInsertND, conn, tran))
                            {
                                cmdND.Parameters.AddWithValue("@id", newId);
                                cmdND.Parameters.AddWithValue("@hoten", hoTen);
                                cmdND.Parameters.AddWithValue("@ngaysinh",
                                    (object?)ngaySinhSave ?? DBNull.Value);
                                cmdND.Parameters.AddWithValue("@sdt", sdt);
                                cmdND.Parameters.AddWithValue("@email", email);
                                cmdND.Parameters.AddWithValue("@diachi", diaChi);

                                if (_hinhAnhPending != null)
                                    cmdND.Parameters.Add("@hinhAnh", SqliteType.Blob).Value = _hinhAnhPending;
                                else
                                    cmdND.Parameters.AddWithValue("@hinhAnh", DBNull.Value);

                                cmdND.ExecuteNonQuery();
                            }

                            // Gắn lại cho tài khoản hiện tại
                            string sqlUpdateTK_ND = @"
                                UPDATE TaiKhoan
                                SET MaNguoiDung = @id
                                WHERE TenDangNhap = @user
                            ";

                            using (var cmdTkNd = new SqliteCommand(sqlUpdateTK_ND, conn, tran))
                            {
                                cmdTkNd.Parameters.AddWithValue("@id", newId);
                                cmdTkNd.Parameters.AddWithValue("@user", _username);
                                cmdTkNd.ExecuteNonQuery();
                            }

                            _maNguoiDung = newId;
                        }

                        // ---------- 2) Nếu đổi mật khẩu -> UPDATE TaiKhoan ----------
                        if (doiMatKhau)
                        {
                            string sqlUpdatePass = @"
                                UPDATE TaiKhoan
                                SET MatKhau = @pass
                                WHERE TenDangNhap = @user
                            ";

                            using (var cmdPass = new SqliteCommand(sqlUpdatePass, conn, tran))
                            {
                                cmdPass.Parameters.AddWithValue("@pass", matKhauMoi);
                                cmdPass.Parameters.AddWithValue("@user", _username);
                                cmdPass.ExecuteNonQuery();
                            }

                            _matKhauHienTai = matKhauMoi;
                        }

                        tran.Commit();
                    }
                }

                // Sau khi lưu thành công -> cập nhật trạng thái ảnh bộ nhớ
                _hinhAnhCurrent = _clearImage ? null : (_hinhAnhPending ?? _hinhAnhCurrent);
                _hinhAnhPending = null;
                _clearImage = false;

                MessageBox.Show("Lưu thông tin thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPassCu.Text = txtPassMoi.Text = txtNhapLaiPassMoi.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void btnDong_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // ====== Con mắt show/hide mật khẩu ======
        private void SetupPasswordEyes()
        {
            // mặc định ẩn
            txtPassCu.PasswordChar         = '●';
            txtPassMoi.PasswordChar        = '●';
            txtNhapLaiPassMoi.PasswordChar = '●';

            _eyeCu   = CreateEyeOnTextbox(txtPassCu, ToggleEyeGeneric);
            _eyeMoi  = CreateEyeOnTextbox(txtPassMoi, ToggleEyeGeneric);
            _eyeMoi2 = CreateEyeOnTextbox(txtNhapLaiPassMoi, ToggleEyeGeneric);
        }

        private Guna2Button CreateEyeOnTextbox(Guna2TextBox txt, EventHandler onClick)
        {
            var btn = new Guna2Button
            {
                Parent                 = txt,
                Text                   = "👁",
                Font                   = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor              = Color.Black,
                FillColor              = Color.Transparent,
                BorderThickness        = 0,
                Cursor                 = Cursors.Hand,
                UseTransparentBackground = true,
                Size                   = new Size(28, Math.Max(22, txt.Height - 6)),
                Visible                = true,
                TabStop                = false
            };

            btn.HoverState.FillColor = Color.Transparent;
            btn.PressedColor         = Color.Transparent;
            btn.Anchor               = AnchorStyles.Top | AnchorStyles.Right;
            btn.Click               += onClick;

            // đặt bên phải & canh giữa dọc trong textbox
            btn.Location = new Point(txt.Width - btn.Width - 4, (txt.Height - btn.Height) / 2);

            // canh lại khi textbox đổi kích thước
            txt.SizeChanged += (_, __) =>
            {
                btn.Size     = new Size(28, Math.Max(22, txt.Height - 6));
                btn.Location = new Point(txt.Width - btn.Width - 4, (txt.Height - btn.Height) / 2);
                btn.BringToFront();
            };

            btn.BringToFront();
            return btn;
        }

        /// <summary>
        /// Handler dùng chung: click con mắt -> ẩn/hiện mật khẩu + đổi icon
        /// </summary>
        private void ToggleEyeGeneric(object? sender, EventArgs e)
        {
            if (sender is not Guna2Button btn) return;
            if (btn.Parent is not Guna2TextBox txt) return;

            bool isVisible = (txt.PasswordChar == '\0');
            txt.PasswordChar = isVisible ? '●' : '\0';
            btn.Text         = isVisible ? "👁" : "🙈";
        }
    }
}
