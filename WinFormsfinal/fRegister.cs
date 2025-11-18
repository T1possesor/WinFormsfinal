using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class fRegister : Form
    {
        // form đăng nhập (fLogin) để quay lại
        private readonly Form _loginForm;

        // trạng thái hiển thị mật khẩu
        private bool isPassVisible = false;
        private bool isRePassVisible = false;

        public fRegister(Form loginForm)
        {
            InitializeComponent();

            _loginForm = loginForm;

            // căn giữa panel đăng ký
            CenterRegisterPanel();
            this.Resize += (s, e) => CenterRegisterPanel();

            // cấu hình nút con mắt cho 2 textbox mật khẩu
            SetupEyeButtons();
        }

        // dùng cùng connection string với fLogin
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

        private void CenterRegisterPanel()
        {
            if (panelRegister == null) return;

            panelRegister.Left = (this.ClientSize.Width - panelRegister.Width) / 2;
            panelRegister.Top  = (this.ClientSize.Height - panelRegister.Height) / 2;
        }

        /// <summary>
        /// Đưa 2 nút mắt vào trong txtPass và txtRePass
        /// </summary>
        private void SetupEyeButtons()
        {
            if (btnTogglePassReg != null && txtPass != null)
            {
                btnTogglePassReg.Parent = txtPass;
                btnTogglePassReg.BringToFront();

                btnTogglePassReg.Text = "👁";
                btnTogglePassReg.FillColor = System.Drawing.Color.Transparent;
                btnTogglePassReg.BorderThickness = 0;
                btnTogglePassReg.HoverState.FillColor = System.Drawing.Color.Transparent;
                btnTogglePassReg.PressedColor = System.Drawing.Color.Transparent;

                btnTogglePassReg.Size = new System.Drawing.Size(30, txtPass.Height - 4);
                btnTogglePassReg.Location = new System.Drawing.Point(
                    txtPass.Width - btnTogglePassReg.Width - 2,
                    2
                );
                btnTogglePassReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            if (btnToggleRePassReg != null && txtRePass != null)
            {
                btnToggleRePassReg.Parent = txtRePass;
                btnToggleRePassReg.BringToFront();

                btnToggleRePassReg.Text = "👁";
                btnToggleRePassReg.FillColor = System.Drawing.Color.Transparent;
                btnToggleRePassReg.BorderThickness = 0;
                btnToggleRePassReg.HoverState.FillColor = System.Drawing.Color.Transparent;
                btnToggleRePassReg.PressedColor = System.Drawing.Color.Transparent;

                btnToggleRePassReg.Size = new System.Drawing.Size(30, txtRePass.Height - 4);
                btnToggleRePassReg.Location = new System.Drawing.Point(
                    txtRePass.Width - btnToggleRePassReg.Width - 2,
                    2
                );
                btnToggleRePassReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }
        }

        // tạo mã TK mới dạng TK001, TK002, ...
        private string GenerateNewMaTaiKhoan(SqliteConnection conn)
        {
            string sql = @"
                SELECT MaTaiKhoan
                FROM TaiKhoan
                ORDER BY MaTaiKhoan DESC
                LIMIT 1
            ";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                var result = cmd.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(result))
                    return "TK001";

                string numberPart = result.Substring(2); // "001" từ "TK001"
                if (!int.TryParse(numberPart, out int num))
                    num = 0;

                num++;
                return "TK" + num.ToString("D3");
            }
        }

        // tạo mã người dùng mới dạng ND001, ND002, ... lấy theo bảng NguoiDung
        private string GenerateNewMaNguoiDung(SqliteConnection conn)
        {
            string sql = @"
                SELECT MaNguoiDung
                FROM NguoiDung
                ORDER BY MaNguoiDung DESC
                LIMIT 1
            ";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                var result = cmd.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(result))
                    return "ND001";

                string numberPart = result.Substring(2); // "001" từ "ND001"
                if (!int.TryParse(numberPart, out int num))
                    num = 0;

                num++;
                return "ND" + num.ToString("D3");
            }
        }

        // tạo mã số thẻ mới dạng TV0001, TV0002,... lấy theo bảng NguoiDung
        private string GenerateNewMaSoThe(SqliteConnection conn)
        {
            string sql = @"
                SELECT MaSoThe
                FROM NguoiDung
                ORDER BY MaSoThe DESC
                LIMIT 1
            ";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                var result = cmd.ExecuteScalar() as string;

                if (string.IsNullOrEmpty(result))
                    return "TV0001";

                string numberPart = result.Substring(2); // "0001" từ "TV0001"
                if (!int.TryParse(numberPart, out int num))
                    num = 0;

                num++;
                return "TV" + num.ToString("D4"); // 4 chữ số
            }
        }

        // kiểm tra tài khoản đã tồn tại chưa
        private bool IsUserExists(SqliteConnection conn, string username)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @user";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // kiểm tra email trùng (nếu bạn muốn)
        private bool IsEmailExists(SqliteConnection conn, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @mail";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@mail", email);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            string rePass = txtRePass.Text.Trim();

            // thông tin người dùng
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

            // kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(rePass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Họ tên, Tài khoản, Mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != rePass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();

                    // bật foreign key
                    using (var fkCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn))
                    {
                        fkCmd.ExecuteNonQuery();
                    }

                    // kiểm tra trùng username
                    if (IsUserExists(conn, user))
                    {
                        MessageBox.Show("Tài khoản đã tồn tại, vui lòng chọn tên khác!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // kiểm tra trùng email (nếu nhập)
                    if (!string.IsNullOrWhiteSpace(email) && IsEmailExists(conn, email))
                    {
                        MessageBox.Show("Email đã được sử dụng!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string maTk = GenerateNewMaTaiKhoan(conn);
                    string maNguoiDung = GenerateNewMaNguoiDung(conn);
                    string maSoThe = GenerateNewMaSoThe(conn);

                    using (var tran = conn.BeginTransaction())
                    {
                        // 1) Thêm vào bảng NguoiDung
                        string sqlNguoi = @"
                            INSERT INTO NguoiDung 
                                (MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, Email, DiaChi, NgayTaoThe, NgayHetHanThe, TrangThai)
                            VALUES 
                                (@maNguoi, @hoTen, @maSoThe, @ngaySinh, @sdt, @mail, @diaChi, DATE('now'), DATE('now','+1 year'), 'HoatDong')
                        ";

                        using (var cmdNguoi = new SqliteCommand(sqlNguoi, conn, tran))
                        {
                            cmdNguoi.Parameters.AddWithValue("@maNguoi", maNguoiDung);
                            cmdNguoi.Parameters.AddWithValue("@hoTen", hoTen);
                            cmdNguoi.Parameters.AddWithValue("@maSoThe", maSoThe);
                            cmdNguoi.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                            cmdNguoi.Parameters.AddWithValue("@sdt", sdt);
                            cmdNguoi.Parameters.AddWithValue("@mail", (object)email ?? DBNull.Value);
                            cmdNguoi.Parameters.AddWithValue("@diaChi", (object)diaChi ?? DBNull.Value);

                            cmdNguoi.ExecuteNonQuery();
                        }

                        // 2) Thêm vào bảng TaiKhoan
                        string sqlTk = @"
                            INSERT INTO TaiKhoan
                                (MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, MaNguoiDung, NgayTao)
                            VALUES
                                (@ma, @user, @pass, @vaiTro, @maNguoi, DATE('now'))
                        ";

                        using (var cmdTk = new SqliteCommand(sqlTk, conn, tran))
                        {
                            cmdTk.Parameters.AddWithValue("@ma", maTk);
                            cmdTk.Parameters.AddWithValue("@user", user);
                            cmdTk.Parameters.AddWithValue("@pass", pass);
                            cmdTk.Parameters.AddWithValue("@vaiTro", "KhachHang");
                            cmdTk.Parameters.AddWithValue("@maNguoi", maNguoiDung);

                            int rows = cmdTk.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                tran.Commit();

                                MessageBox.Show(
                                    $"Đăng ký thành công!\nMã thẻ của bạn: {maSoThe}",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                ShowLoginAndClose();
                            }
                            else
                            {
                                tran.Rollback();
                                MessageBox.Show("Đăng ký thất bại.",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTogglePassReg_Click(object sender, EventArgs e)
        {
            isPassVisible = !isPassVisible;

            if (isPassVisible)
            {
                txtPass.PasswordChar = '\0';
                btnTogglePassReg.Text = "🙈";
            }
            else
            {
                txtPass.PasswordChar = '●';
                btnTogglePassReg.Text = "👁";
            }
        }

        private void btnToggleRePassReg_Click(object sender, EventArgs e)
        {
            isRePassVisible = !isRePassVisible;

            if (isRePassVisible)
            {
                txtRePass.PasswordChar = '\0';
                btnToggleRePassReg.Text = "🙈";
            }
            else
            {
                txtRePass.PasswordChar = '●';
                btnToggleRePassReg.Text = "👁";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowLoginAndClose();
        }

        private void ShowLoginAndClose()
        {
            if (_loginForm != null && !_loginForm.IsDisposed)
            {
                _loginForm.Show();
                _loginForm.Activate();
            }

            this.Close();
        }
    }
}
