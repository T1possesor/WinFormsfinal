using System;
using System.Data;
using System.Drawing;
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

        public fThongTinCaNhan(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;

            lblUserCaption.Text = "Tài khoản: " + _username;

            // load dữ liệu khi form mở
            this.Load += fThongTinCaNhan_Load;
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

        private void fThongTinCaNhan_Load(object? sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();

                    string sql = @"
                        SELECT tk.MaTaiKhoan,
                               tk.MaNguoiDung,
                               tk.MatKhau,
                               nd.HoTen,
                               nd.MaSoThe,
                               nd.NgaySinh,
                               nd.SoDienThoai,
                               nd.Email,
                               nd.DiaChi
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

                                // ==== Ngày sinh ====
                                var nsVal = rd["NgaySinh"];
                                if (nsVal != DBNull.Value &&
                                    DateTime.TryParse(nsVal.ToString(), out var dNs))
                                {
                                    txtNgaySinh.Text = dNs.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txtNgaySinh.Text = nsVal?.ToString() ?? "";
                                }

                                txtTenDangNhap.Text = _username;
                                _matKhauHienTai     = rd["MatKhau"] as string ?? "";
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

            // Ngày sinh: cho phép bỏ trống, nếu nhập thì phải đúng
            string? ngaySinhSave = null;
            if (!string.IsNullOrWhiteSpace(ngaySinhText))
            {
                if (DateTime.TryParse(ngaySinhText, out var d))
                {
                    // Lưu dạng yyyy-MM-dd cho dễ xử lý
                    ngaySinhSave = d.ToString("yyyy-MM-dd");
                }
                else
                {
                    ShowError("Ngày sinh không hợp lệ (thử dạng dd/MM/yyyy hoặc yyyy-MM-dd).");
                    txtNgaySinh.Focus();
                    return;
                }
            }

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
                            string sqlUpdateND = @"
                                UPDATE NguoiDung
                                SET HoTen      = @hoten,
                                    NgaySinh   = @ngaysinh,
                                    Email      = @email,
                                    SoDienThoai= @sdt,
                                    DiaChi     = @diachi
                                WHERE MaNguoiDung = @id
                            ";

                            using (var cmdND = new SqliteCommand(sqlUpdateND, conn, tran))
                            {
                                cmdND.Parameters.AddWithValue("@hoten", hoTen);
                                cmdND.Parameters.AddWithValue("@ngaysinh",
                                    (object?)ngaySinhSave ?? DBNull.Value);
                                cmdND.Parameters.AddWithValue("@email", email);
                                cmdND.Parameters.AddWithValue("@sdt", sdt);
                                cmdND.Parameters.AddWithValue("@diachi", diaChi);
                                cmdND.Parameters.AddWithValue("@id", _maNguoiDung);
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
                                     NgayHetHanThe, TrangThai)
                                VALUES
                                    (@id, @hoten, 'TVTEMP', @ngaysinh,
                                     @sdt, @email, @diachi, date('now'),
                                     date('now','+1 year'), 'BiKhoa')
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
    }
}
