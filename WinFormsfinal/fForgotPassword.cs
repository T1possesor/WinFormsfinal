using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class fForgotPassword : Form
    {
        private readonly Form _loginForm;

        public fForgotPassword(Form loginForm)
        {
            InitializeComponent();

            _loginForm = loginForm;

            CenterForgotPanel();
            this.Resize += (s, e) => CenterForgotPanel();
        }

        private void CenterForgotPanel()
        {
            if (panelForgot == null) return;

            panelForgot.Left = (this.ClientSize.Width - panelForgot.Width) / 2;
            panelForgot.Top  = (this.ClientSize.Height - panelForgot.Height) / 2;
        }

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

        private void btnChange_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string email = txtEmail.Text.Trim();      // khách thì phải nhập, admin có thể để trống
            string newPass = txtNewPass.Text.Trim();
            string reNewPass = txtReNewPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(reNewPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tài khoản và mật khẩu mới!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != reNewPass)
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

                    using (var fkCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn))
                    {
                        fkCmd.ExecuteNonQuery();
                    }

                    // Lấy vai trò + email (nếu có) của tài khoản
                    string sqlCheck = @"
                SELECT tk.VaiTro, nd.Email
                FROM TaiKhoan tk
                LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
                WHERE tk.TenDangNhap = @user
            ";

                    string vaiTro = null;
                    string emailDb = null;

                    using (var cmdCheck = new SqliteCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@user", user);

                        using (var reader = cmdCheck.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                // Không tìm thấy user
                                MessageBox.Show("Tài khoản không tồn tại!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            vaiTro = reader["VaiTro"]?.ToString();
                            emailDb = reader["Email"] as string; // có thể NULL
                        }
                    }

                    // Nếu là khách hàng -> bắt buộc phải khớp email
                    if (!string.Equals(vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        if (string.IsNullOrWhiteSpace(email))
                        {
                            MessageBox.Show("Vui lòng nhập email đã đăng ký!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (string.IsNullOrEmpty(emailDb) ||
                            !string.Equals(emailDb, email, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Email không đúng với tài khoản này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    // Nếu là Admin: bỏ qua bước kiểm tra email (demo cho bài tập)

                    // Update mật khẩu
                    string sqlUpdate = @"
                UPDATE TaiKhoan
                SET MatKhau = @newPass
                WHERE TenDangNhap = @user
            ";

                    using (var cmdUpdate = new SqliteCommand(sqlUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@newPass", newPass);
                        cmdUpdate.Parameters.AddWithValue("@user", user);

                        int rows = cmdUpdate.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            string msg = "Đổi mật khẩu thành công! Hãy đăng nhập lại.";
                            if (string.Equals(vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
                                msg += "\n(Lưu ý: tài khoản Admin không cần email để khôi phục.)";

                            MessageBox.Show(msg,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ShowLoginAndClose();
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
