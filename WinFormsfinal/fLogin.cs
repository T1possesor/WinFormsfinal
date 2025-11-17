using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System.IO;
namespace WinFormsfinal
{
    public partial class fLogin : Form
    {
        private bool isPasswordVisible = false;

        public fLogin()
        {
            InitializeComponent();

            // căn giữa panel
            CenterLoginPanel();
            this.Resize += (s, e) => CenterLoginPanel();

            // cấu hình nút con mắt
            SetupEyeButton();
        }


        private string GetConnectionString()
        {
            // Dùng đường dẫn tuyệt đối của bạn
            string dbPath = @"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\project_final.db";

            // Kiểm tra file có tồn tại không (debug)
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("KHÔNG tìm thấy file DB tại:\n" + dbPath,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return $"Data Source={dbPath}";
        }


        private bool CheckLoginFromDb(string username, string password, out string vaiTro)
        {
            vaiTro = null;

            using (var conn = new SqliteConnection(GetConnectionString()))
            {
                conn.Open();

                string sql = @"
            SELECT VaiTro
            FROM TaiKhoan
            WHERE TenDangNhap = @user AND MatKhau = @pass
        ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        vaiTro = result.ToString();   // lấy cột VaiTro
                        return true;                  // đăng nhập đúng
                    }
                    else
                    {
                        return false;                 // sai tài khoản / mật khẩu
                    }
                }
            }
        }

        private void CenterLoginPanel()
        {
            if (panelLogin == null) return;

            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top  = (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        /// <summary>
        /// Đưa nút mắt vào bên trong txtPass (góc phải)
        /// </summary>
        private void SetupEyeButton()
        {
            // đặt parent là txtPass => toạ độ tính theo txtPass
            btnTogglePass.Parent = txtPass;
            btnTogglePass.BringToFront();

            // style cho nút mắt
            btnTogglePass.Text = "👁";
            btnTogglePass.FillColor = System.Drawing.Color.Transparent;
            btnTogglePass.BorderThickness = 0;
            btnTogglePass.HoverState.FillColor = System.Drawing.Color.Transparent;
            btnTogglePass.PressedColor = System.Drawing.Color.Transparent;

            // kích thước & vị trí: dính mép phải, nằm trong ô
            btnTogglePass.Size = new System.Drawing.Size(30, txtPass.Height - 4);
            btnTogglePass.Location = new System.Drawing.Point(
                txtPass.Width - btnTogglePass.Width - 2,
                2
            );

            // để khi txtPass resize thì nút mắt vẫn bám mép phải
            btnTogglePass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Gọi SQLite để kiểm tra
            if (CheckLoginFromDb(user, pass, out string vaiTro))
            {
                // Đăng nhập thành công
                MessageBox.Show($"Đăng nhập thành công! Vai trò: {vaiTro}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Form1 main = new Form1();
                // main.Tag = vaiTro; // nếu sau này bạn muốn truyền role sang form chính
                main.Show();
                this.Hide();
            }
            else
            {
                // Sai tài khoản hoặc mật khẩu
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btnTogglePass_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPass.PasswordChar = '\0';
                btnTogglePass.Text = "🙈";
            }
            else
            {
                txtPass.PasswordChar = '●';
                btnTogglePass.Text = "👁";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sau này sẽ mở form Đăng ký.", "Thông báo");
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sau này sẽ mở form Quên mật khẩu.", "Thông báo");
        }

        private void lblPass_Click(object sender, EventArgs e)
        {
        }
    }
}
