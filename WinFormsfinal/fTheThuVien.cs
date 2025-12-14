using System;
using System.IO;
using System.Drawing;                // THÊM
using System.Globalization;          // THÊM: để parse/format ngày
using System.Windows.Forms;
using System.Data.SQLite;            // ĐỔI: dùng System.Data.SQLite giống fLogin

namespace WinFormsfinal
{
    public partial class fTheThuVien : Form
    {
        private readonly string _username;

        public fTheThuVien(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;

            lblUserCaption.Text = "Tài khoản: " + _username;
            this.Load += fTheThuVien_Load;
        }

        // giống kiểu "Data Source=project_final.db;Version=3;"
        private string GetConnectionString()
        {
            // DB đặt cạnh file .exe
            string dbPath = "project_final.db";
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("KHÔNG tìm thấy file DB tại:\n" + Path.GetFullPath(dbPath),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return @"Data Source=project_final.db;Version=3;";
        }

        // BẢO ĐẢM có cột HinhAnh (an toàn khi DB cũ)
        private void EnsureNguoiDungHasImageColumn(SQLiteConnection conn)
        {
            try
            {
                bool hasCol = false;
                using (var cmd = new SQLiteCommand("PRAGMA table_info(NguoiDung);", conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        if (string.Equals(rd["name"]?.ToString(), "HinhAnh", StringComparison.OrdinalIgnoreCase))
                        {
                            hasCol = true; break;
                        }
                    }
                }
                if (!hasCol)
                {
                    using var alter = new SQLiteCommand("ALTER TABLE NguoiDung ADD COLUMN HinhAnh BLOB NULL;", conn);
                    alter.ExecuteNonQuery();
                }
            }
            catch { /* bỏ qua nếu đã có */ }
        }

        // Convert byte[] -> Image
        private static Image? BytesToImage(byte[]? data)
        {
            if (data == null || data.Length == 0) return null;
            using var ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        // Crop giữa ảnh thành hình vuông và scale về đúng cạnh edge (giống form thông tin cá nhân)
        private static Image MakeSquare(Image src, int edge)
        {
            int side = Math.Min(src.Width, src.Height);
            int x = (src.Width - side) / 2;
            int y = (src.Height - side) / 2;

            using var square = new Bitmap(side, side);
            using (var g = Graphics.FromImage(square))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(src, new Rectangle(0, 0, side, side), new Rectangle(x, y, side, side), GraphicsUnit.Pixel);
            }

            var bmp = new Bitmap(edge, edge);
            using (var g2 = Graphics.FromImage(bmp))
            {
                g2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g2.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g2.DrawImage(square, 0, 0, edge, edge);
            }
            return bmp;
        }

        // Helper: cố gắng parse chuỗi ngày theo nhiều định dạng, để hiển thị dd/MM/yyyy
        private static bool TryParseDateFlexible(string input, out DateTime d)
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

        private void fTheThuVien_Load(object? sender, EventArgs e)
        {
            try
            {
                using (var conn = new SQLiteConnection(GetConnectionString()))
                {
                    conn.Open();

                    EnsureNguoiDungHasImageColumn(conn);

                    string sql = @"
                        SELECT tk.TenDangNhap,
                               nd.MaNguoiDung,
                               nd.HoTen,
                               nd.MaSoThe,
                               nd.NgaySinh,
                               nd.SoDienThoai,
                               nd.Email,
                               nd.DiaChi,
                               nd.NgayTaoThe,
                               nd.NgayHetHanThe,
                               nd.TrangThai,
                               nd.HinhAnh                -- THÊM
                        FROM TaiKhoan tk
                        LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
                        WHERE tk.TenDangNhap = @user
                    ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", _username);

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                // Không có MaNguoiDung => chưa có thẻ
                                if (rd["MaNguoiDung"] == DBNull.Value ||
                                    string.IsNullOrWhiteSpace(rd["MaNguoiDung"].ToString()))
                                {
                                    MessageBox.Show(
                                        "Bạn chưa có thẻ thư viện.\n" +
                                        "Vui lòng vào mục 'Thông tin cá nhân' để cập nhật đầy đủ thông tin, " +
                                        "hệ thống sẽ tạo thẻ cho bạn.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    this.Close();
                                    return;
                                }

                                txtMaSoThe.Text = rd["MaSoThe"] as string ?? "";
                                txtHoTen.Text = rd["HoTen"] as string ?? "";

                                // ==== SỬA: Định dạng Ngày sinh thành dd/MM/yyyy ====
                                var nsVal = rd["NgaySinh"];
                                if (nsVal != DBNull.Value)
                                {
                                    var rawNS = nsVal.ToString();
                                    if (TryParseDateFlexible(rawNS!, out var dNS))
                                        txtNgaySinh.Text = dNS.ToString("dd/MM/yyyy");
                                    else
                                        txtNgaySinh.Text = rawNS ?? "";
                                }
                                else txtNgaySinh.Text = "";
                                // ================================================

                                txtSDT.Text = rd["SoDienThoai"] as string ?? "";
                                txtEmail.Text = rd["Email"] as string ?? "";
                                txtDiaChi.Text = rd["DiaChi"] as string ?? "";

                                // ==== Định dạng Ngày tạo thẻ & Ngày hết hạn thẻ thành dd/MM/yyyy nếu có thể ====
                                var ntVal = rd["NgayTaoThe"];
                                if (ntVal != DBNull.Value)
                                {
                                    var raw = ntVal.ToString();
                                    if (TryParseDateFlexible(raw!, out var d))
                                        txtNgayTao.Text = d.ToString("dd/MM/yyyy");
                                    else
                                        txtNgayTao.Text = raw ?? "";
                                }
                                else txtNgayTao.Text = "";

                                var nhhVal = rd["NgayHetHanThe"];
                                if (nhhVal != DBNull.Value)
                                {
                                    var raw = nhhVal.ToString();
                                    if (TryParseDateFlexible(raw!, out var d))
                                        txtNgayHetHan.Text = d.ToString("dd/MM/yyyy");
                                    else
                                        txtNgayHetHan.Text = raw ?? "";
                                }
                                else txtNgayHetHan.Text = "";

                                string trangThai = rd["TrangThai"] as string ?? "";
                                txtTrangThai.Text = trangThai;

                                btnThanhToan.Visible =
                                    string.Equals(trangThai, "BiKhoa", StringComparison.OrdinalIgnoreCase);

                                // ==== ẢNH THẺ ====
                                if (rd["HinhAnh"] != DBNull.Value)
                                {
                                    var bytes = (byte[])rd["HinhAnh"];
                                    var img = BytesToImage(bytes);
                                    picAvatar.Image = (img != null) ? MakeSquare(img, picAvatar.Width) : null;
                                }
                                else
                                {
                                    picAvatar.Image = null; // hoặc đặt ảnh mặc định
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
                MessageBox.Show("Lỗi khi tải thẻ thư viện: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Thẻ thư viện của bạn đang ở trạng thái BI KHÓA.\n\n" +
                "Vui lòng đến thư viện để thanh toán và mở khóa thẻ tại địa chỉ:\n\n" +
                "279 Nguyễn Tri Phương, Phường 5, Quận 10, TP. Hồ Chí Minh.",
                "Hướng dẫn thanh toán",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
