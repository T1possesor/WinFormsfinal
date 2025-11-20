using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class fLogin : Form
    {
        private bool isPasswordVisible = false;

        // Chế độ hiển thị trong card
        private enum LoginMode { None, KhachHang, Admin }
        private LoginMode currentMode = LoginMode.None;

        // Bong bóng cảnh báo (runtime)
        private Guna2Panel? _bubbleUser;
        private Guna2Panel? _bubblePass;

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
                if (_bubbleUser != null) _bubbleUser.Visible = false;
                lblAuthError.Visible = false;
                RelayoutBottom();
            };
            txtPass.TextChanged += (_, __) =>
            {
                if (_bubblePass != null) _bubblePass.Visible = false;
                lblAuthError.Visible = false;
                RelayoutBottom();
            };
        }

        // ====== Chuyển giữa 2 màn trong card ======
        private void ShowRolePanelInCard()
        {
            currentMode = LoginMode.None;
            panelRoleInline.Visible = true;
            panelLoginFields.Visible = false;
            this.Text = "Chọn phương thức đăng nhập";
            CenterLoginPanel();
        }

        private void ShowLoginPanelInCard(LoginMode mode)
        {
            currentMode = mode;

            bool isAdmin = (mode == LoginMode.Admin);
            btnRegister.Visible = !isAdmin;
            btnForgot.Visible   = !isAdmin;

            lblTitle.Text = isAdmin ? "Đăng nhập (Admin)" : "Đăng nhập (Khách hàng)";
            this.Text     = lblTitle.Text;

            lblAuthError.Visible = false;
            panelRoleInline.Visible  = false;
            panelLoginFields.Visible = true;

            CenterLoginPanel();
            RelayoutBottom();
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
            btnTogglePass.Parent = txtPass;
            btnTogglePass.BringToFront();

            btnTogglePass.Text = "👁";
            btnTogglePass.FillColor = Color.Transparent;
            btnTogglePass.BorderThickness = 0;
            btnTogglePass.HoverState.FillColor = Color.Transparent;
            btnTogglePass.PressedColor = Color.Transparent;

            btnTogglePass.Size = new Size(30, txtPass.Height - 4);
            btnTogglePass.Location = new Point(txtPass.Width - btnTogglePass.Width - 2, 2);
            btnTogglePass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        // ====== Bong bóng cảnh báo (bo tròn, tự ẩn) ======
        private void ShowBubbleError(Control target, ref Guna2Panel? bubble, string message)
        {
            if (bubble == null)
            {
                bubble = new Guna2Panel
                {
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(52, 58, 64),
                    BackColor = Color.Transparent,
                    Size = new Size(260, 34),
                };
                bubble.ShadowDecoration.Enabled = true;
                bubble.ShadowDecoration.BorderRadius = 10;
                bubble.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);

                var lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 2, 8, 2),
                };
                bubble.Tag = lbl;
                bubble.Controls.Add(lbl);

                panelLoginFields.Controls.Add(bubble);
            }

            var label = (Label)bubble.Tag!;
            label.Text = "⚠  " + message;

            // đặt ngay dưới textbox
            var ptScreen = target.Parent.PointToScreen(new Point(target.Left, target.Bottom));
            var ptInPanel = panelLoginFields.PointToClient(ptScreen);
            bubble.Location = new Point(ptInPanel.X, ptInPanel.Y + 6);
            bubble.BringToFront();
            bubble.Visible = true;

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
        private string GetConnectionString()
        {
            // Sửa đường dẫn DB theo máy bạn
            string dbPath = @"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\project_final.db";
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("KHÔNG tìm thấy file DB tại:\n" + dbPath,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return $"Data Source={dbPath}";
        }

        private bool CheckLoginFromDb(string username, string password, out string? vaiTro)
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

            // Thiếu trường -> bong bóng tiếng Việt
            bool missing = false;
            if (string.IsNullOrWhiteSpace(user))
            {
                ShowBubbleError(txtUser, ref _bubbleUser, "Vui lòng điền trường này.");
                missing = true;
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                if (missing)
                    BeginInvoke(new Action(() => ShowBubbleError(txtPass, ref _bubblePass, "Vui lòng điền trường này.")));
                else
                    ShowBubbleError(txtPass, ref _bubblePass, "Vui lòng điền trường này.");
                missing = true;
            }
            if (missing) return;

            // Kiểm tra DB
            if (CheckLoginFromDb(user, pass, out string? vaiTro))
            {
                bool isAdminAcc = string.Equals(vaiTro, "Admin", StringComparison.OrdinalIgnoreCase);

                // kiểm tra đúng cửa
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

                // OK
                lblAuthError.Visible = false;
                RelayoutBottom();
                var main = new Form1(vaiTro!);
                main.Show();
                this.Hide();
            }
            else
            {
                // Sai tài khoản hoặc mật khẩu
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
            txtPass.PasswordChar = isPasswordVisible ? '\0' : '●';
            btnTogglePass.Text   = isPasswordVisible ? "🙈" : "👁";
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
