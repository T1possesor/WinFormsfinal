using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Data.SQLite;

namespace WinFormsfinal
{
    public partial class fLogin : Form
    {
        private bool isPasswordVisible = false;

        private readonly string connectionString = @"Data Source=project_final.db;Version=3;";

        // Chế độ hiển thị trong card
        private enum LoginMode { None, KhachHang, Admin }
        private LoginMode currentMode = LoginMode.None;

        // Bong bóng cảnh báo (runtime)
        private Guna2Panel? _bubbleUser;
        private Guna2Panel? _bubblePass;
        // Ẩn bong bóng
        private void HideBubble(Guna2Panel? bubble)
        {
            if (bubble != null) bubble.Visible = false;
        }


        public fLogin()
        {
            InitializeComponent();

            // canh lại dòng lỗi theo vị trí nút đăng nhập
            RelayoutBottom();


            // mặc định: màn chọn vai trò trong card
            ShowRolePanelInCard();

            // resize -> canh giữa & relayout
            this.Resize += (s, e) => { CenterLoginPanel(); RelayoutBottom(); };

            // nút con mắt trong textbox mật khẩu
            SetupEyeButton();


            // gõ chữ -> ẩn lỗi và relayout
            txtUser.TextChanged += (_, __) =>
            {
                HideBubble(_bubbleUser);
                lblAuthError.Visible = false;
                RelayoutBottom();
            };

            txtPass.TextChanged += (_, __) =>
            {
                HideBubble(_bubblePass);
                lblAuthError.Visible = false;
                RelayoutBottom();
            };

        }

        // ====== Chuyển giữa 2 màn trong card ======
        private void ShowRolePanelInCard()
        {
            currentMode = LoginMode.None;

            // ✨ reset luôn dữ liệu đăng nhập
            ResetLoginFields();

            panelRoleInline.Visible = true;
            panelLoginFields.Visible = false;
            this.Text = "Chọn phương thức đăng nhập";
            CenterLoginPanel();
        }

        // Xoá sạch dữ liệu và lỗi trên form đăng nhập
        private void ResetLoginFields()
        {
            // clear text
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;

            // reset trạng thái hiện/ẩn mật khẩu
            isPasswordVisible = false;
            txtPass.PasswordChar = '●';
            btnTogglePass.Text = "👁";

            // ẩn bong bóng cảnh báo nếu còn
            // ẩn bong bóng cảnh báo nếu còn
            HideBubble(_bubbleUser);
            HideBubble(_bubblePass);


            // ẩn dòng báo lỗi đỏ dưới nút đăng nhập
            lblAuthError.Visible = false;
        }

        private void ShowLoginPanelInCard(LoginMode mode)
        {
            currentMode = mode;

            // ✨ mỗi lần vào màn login → xóa sạch dữ liệu cũ
            ResetLoginFields();

            bool isAdmin = (mode == LoginMode.Admin);
            btnRegister.Visible = !isAdmin;
            btnForgot.Visible   = !isAdmin;

            lblTitle.Text = isAdmin ? "Đăng nhập (Admin)" : "Đăng nhập (Khách hàng)";
            this.Text     = lblTitle.Text;

            panelRoleInline.Visible  = false;
            panelLoginFields.Visible = true;

            CenterLoginPanel();
            txtUser.Focus();
        }


        private void btnRoleAdmin_Click(object sender, EventArgs e) => ShowLoginPanelInCard(LoginMode.Admin);
        private void btnRoleCustomer_Click(object sender, EventArgs e) => ShowLoginPanelInCard(LoginMode.KhachHang);
        private void btnBack_Click(object sender, EventArgs e) => ShowRolePanelInCard();

        // ====== Canh card giữa form ======
        private void CenterLoginPanel()
        {
            panelLogin.Left = (ClientSize.Width  - panelLogin.Width)  / 2;
            panelLogin.Top  = (ClientSize.Height - panelLogin.Height) / 2;
        }

        // ====== Canh lại vùng dưới nút đăng nhập ======
        private void RelayoutBottom()
        {
            // đặt dòng lỗi ngay dưới nút
            lblAuthError.Location = new Point(btnLogin.Left, btnLogin.Bottom + 8);
            lblAuthError.Width    = btnLogin.Width;

            // dời 2 nút Đăng ký/Quên mật khẩu xuống nếu đang có lỗi
            int nextY = lblAuthError.Visible
                ? lblAuthError.Bottom + 10
                : btnLogin.Bottom + 10;

            btnRegister.Top = nextY;
            btnForgot.Top   = nextY;
        }

        // ====== Nút con mắt trong textbox mật khẩu ======
        private void SetupEyeButton()
        {
            txtPass.IconRight = Properties.Resources.eye_closed;
            txtPass.IconRightCursor = Cursors.Hand;

            txtPass.IconRightClick += (s, e) =>
            {
                isPasswordVisible = !isPasswordVisible;
                txtPass.PasswordChar = isPasswordVisible ? '\0' : '●';
                txtPass.IconRight = isPasswordVisible
                    ? Properties.Resources.eye_open
                    : Properties.Resources.eye_closed;
            };
        }



        // ====== Bong bóng cảnh báo (bo tròn, tự ẩn) ======
        // ====== Bong bóng cảnh báo (nền trắng, viền đen, tự ẩn) ======
        // ====== Bong bóng cảnh báo (trắng, viền đen, tự ẩn) giống fRegister ======
        private void ShowBubbleError(Control target, ref Guna2Panel? bubble, string message)
        {
            if (bubble == null)
            {
                bubble = new Guna2Panel
                {
                    BorderRadius = 8,
                    FillColor = Color.White,
                    BorderColor = Color.Black,
                    BorderThickness = 1,
                    BackColor = Color.Transparent,
                    Size = new Size(300, 34),
                };
                bubble.ShadowDecoration.Enabled = true;
                bubble.ShadowDecoration.BorderRadius = 8;
                bubble.ShadowDecoration.Shadow = new Padding(0, 0, 4, 4);

                var lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 9F),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 2, 8, 2),
                };
                bubble.Tag = lbl;
                bubble.Controls.Add(lbl);

                // thêm vào panel chứa các ô login
                panelLoginFields.Controls.Add(bubble);
            }

            var label = (Label)bubble.Tag!;
            label.Text = "⚠  " + message;

            // đặt ngay dưới control target
            var ptScreen = target.Parent.PointToScreen(new Point(target.Left, target.Bottom));
            var ptInPanel = panelLoginFields.PointToClient(ptScreen);
            bubble.Location = new Point(ptInPanel.X, ptInPanel.Y + 6);
            bubble.BringToFront();
            bubble.Visible = true;

            // tự ẩn sau 2.5s
            var bubbleLocal = bubble;
            var t = new System.Windows.Forms.Timer { Interval = 2500 };
            t.Tick += (s, e) =>
            {
                if (bubbleLocal != null) bubbleLocal.Visible = false;
                t.Stop(); t.Dispose();
            };
            t.Start();

            target.Focus();
        }



        // ====== DATABASE ======


        private bool CheckLoginFromDb(string username, string password, out string? vaiTro)
        {
            vaiTro = null;

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT VaiTro
            FROM TaiKhoan
            WHERE TenDangNhap = @user AND MatKhau = @pass
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    object? result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        vaiTro = result.ToString();
                        return true;
                    }
                    return false;
                }
            }
        }


        // ====== EVENTS ======
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            // ----- 1. Kiểm tra bỏ trống các ô -----
            bool missing = false;

            if (string.IsNullOrWhiteSpace(user))
            {
                ShowBubbleError(txtUser, ref _bubbleUser, "Vui lòng điền tài khoản.");
                missing = true;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                // Nếu cả user và pass đều trống thì để bubble không bị chồng nhau
                if (missing)
                    BeginInvoke(new Action(() =>
                        ShowBubbleError(txtPass, ref _bubblePass, "Vui lòng điền mật khẩu.")
                    ));
                else
                    ShowBubbleError(txtPass, ref _bubblePass, "Vui lòng điền mật khẩu.");

                missing = true;
            }


            if (missing) return;   // thiếu ô nào thì không kiểm tra DB nữa


            // ----- 2. Kiểm tra tài khoản trong DB -----
            if (CheckLoginFromDb(user, pass, out string? vaiTro))
            {
                bool isAdminAcc = string.Equals(vaiTro, "Admin", StringComparison.OrdinalIgnoreCase);

                // 2.1. Đăng nhập sai chế độ (ví dụ dùng TK KH vào cửa Admin)
                if (currentMode == LoginMode.Admin && !isAdminAcc)
                {
                    lblAuthError.ForeColor = Color.FromArgb(220, 53, 69);
                    lblAuthError.Text = "Tài khoản này không phải Admin.";
                    lblAuthError.Visible = true;
                    lblAuthError.BringToFront();
                    RelayoutBottom();
                    return;
                }

                if (currentMode == LoginMode.KhachHang && isAdminAcc)
                {
                    lblAuthError.ForeColor = Color.FromArgb(220, 53, 69);
                    lblAuthError.Text = "Đây là tài khoản Admin. Vui lòng bấm Quay lại và chọn 'Admin'.";
                    lblAuthError.Visible = true;
                    lblAuthError.BringToFront();
                    RelayoutBottom();
                    return;
                }

                // ----- 3. Đăng nhập hợp lệ -----
                lblAuthError.Visible = false;
                RelayoutBottom();

                // Tạo form chính
                var main = new Form1(user, vaiTro!);

                // KHI Form1 ĐÓNG (logout / bấm X) ⇒ quay lại màn chọn phương thức đăng nhập
                main.FormClosed += (s, args) =>
                {
                    // hiện lại form login
                    this.Show();
                    this.WindowState = FormWindowState.Normal;

                    // quay về màn chọn Admin / Khách hàng + xóa data, ẩn lỗi
                    ShowRolePanelInCard();
                    ResetLoginFields();
                };

                this.Hide();   // Ẩn form login
                main.Show();   // Hiển thị form chính
            }
            else
            {
                // ----- 4. Sai tài khoản hoặc mật khẩu -----
                lblAuthError.ForeColor = Color.FromArgb(220, 53, 69);
                lblAuthError.Text = "Sai tài khoản hoặc mật khẩu.";
                lblAuthError.Visible = true;
                lblAuthError.BringToFront();
                RelayoutBottom();
            }
        }



        private void btnTogglePass_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            // Đổi chế độ hiển thị mật khẩu
            txtPass.PasswordChar = isPasswordVisible ? '\0' : '●';

            // Đổi icon theo trạng thái
            if (isPasswordVisible)
            {
                // Đang HIỆN mật khẩu → dùng icon "mắt mở"
                btnTogglePass.Image = Properties.Resources.eye_open;   // ví dụ
            }
            else
            {
                // Đang ẨN mật khẩu → dùng icon "mắt đóng"
                btnTogglePass.Image = Properties.Resources.eye_closed;
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new fRegister(this);
            regForm.Show();
            this.Hide();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            var forgotForm = new fForgotPassword(this);
            forgotForm.Show();
            this.Hide();
        }

        private void lblPass_Click(object sender, EventArgs e) { }
    }
}
