using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Data.Sqlite;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    public partial class fForgotPassword : Form
    {
        private readonly Form _loginForm;

        // bong bóng cảnh báo cho từng ô
        private Guna2Panel? _bubbleUser;
        private Guna2Panel? _bubbleEmail;
        private Guna2Panel? _bubbleNewPass;
        private Guna2Panel? _bubbleReNewPass;

        // lưu vị trí gốc của 2 nút
        private int _btnChangeBaseTop;
        private int _btnCancelBaseTop;

        // trạng thái hiển/ẩn 2 ô mật khẩu (giống fLogin)
        private bool _isNewPassVisible = false;
        private bool _isReNewPassVisible = false;

        public fForgotPassword(Form loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;

            // lưu vị trí ban đầu của 2 nút
            _btnChangeBaseTop = btnChange.Top;
            _btnCancelBaseTop = btnCancel.Top;

            CenterForgotPanel();
            this.Resize += (s, e) => CenterForgotPanel();

            // gõ chữ thì ẩn lỗi & bong bóng
            txtUser.TextChanged      += (_, __) => { HideBubble(_bubbleUser); HideBottomError(); };
            txtEmail.TextChanged     += (_, __) => { HideBubble(_bubbleEmail); HideBottomError(); };
            txtNewPass.TextChanged   += (_, __) => { HideBubble(_bubbleNewPass); HideBottomError(); };
            txtReNewPass.TextChanged += (_, __) => { HideBubble(_bubbleReNewPass); HideBottomError(); };

            // thiết lập 2 nút con mắt giống fLogin
            SetupEyeButtons();

            // nếu textbox thay đổi kích thước -> reposition icon con mắt
            txtNewPass.SizeChanged   += (_, __) =>
                btnToggleNewPass.Location = new Point(txtNewPass.Width - btnToggleNewPass.Width - 2, 2);
            txtReNewPass.SizeChanged += (_, __) =>
                btnToggleReNewPass.Location = new Point(txtReNewPass.Width - btnToggleReNewPass.Width - 2, 2);
        }

        // ====== Eye buttons giống fLogin ======
        private void SetupEyeButtons()
        {
            // con mắt cho "Mật khẩu mới"
            btnToggleNewPass.Parent = txtNewPass;
            btnToggleNewPass.BringToFront();

            btnToggleNewPass.Text = "👁";
            btnToggleNewPass.FillColor = Color.Transparent;
            btnToggleNewPass.BorderThickness = 0;
            btnToggleNewPass.HoverState.FillColor = Color.Transparent;
            btnToggleNewPass.PressedColor = Color.Transparent;

            btnToggleNewPass.Size = new Size(30, txtNewPass.Height - 4);
            btnToggleNewPass.Location = new Point(txtNewPass.Width - btnToggleNewPass.Width - 2, 2);
            btnToggleNewPass.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // con mắt cho "Nhập lại mật khẩu"
            btnToggleReNewPass.Parent = txtReNewPass;
            btnToggleReNewPass.BringToFront();

            btnToggleReNewPass.Text = "👁";
            btnToggleReNewPass.FillColor = Color.Transparent;
            btnToggleReNewPass.BorderThickness = 0;
            btnToggleReNewPass.HoverState.FillColor = Color.Transparent;
            btnToggleReNewPass.PressedColor = Color.Transparent;

            btnToggleReNewPass.Size = new Size(30, txtReNewPass.Height - 4);
            btnToggleReNewPass.Location = new Point(txtReNewPass.Width - btnToggleReNewPass.Width - 2, 2);
            btnToggleReNewPass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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

        // ====== HIDE / SHOW ERROR & MOVE BUTTON ======
        private void HideBottomError()
        {
            if (lblForgotError != null)
            {
                lblForgotError.Visible = false;
                lblForgotError.Text = string.Empty;
            }
            btnChange.Top = _btnChangeBaseTop;
            btnCancel.Top = _btnCancelBaseTop;
        }

        private void ShowBottomError(string message)
        {
            // style label lỗi
            lblForgotError.AutoSize = false;
            lblForgotError.Height   = 26;
            lblForgotError.Width    = txtReNewPass.Width;

            lblForgotError.Text      = message;
            lblForgotError.ForeColor = Color.FromArgb(255, 80, 80);
            lblForgotError.BackColor = Color.Transparent;

            // đặt ngay dưới ô nhập lại
            lblForgotError.Location = new Point(
                txtReNewPass.Left,
                txtReNewPass.Bottom + 4
            );

            lblForgotError.Visible = true;
            lblForgotError.BringToFront();

            // dời 2 nút xuống
            int newTop = lblForgotError.Bottom + 8;
            btnChange.Top = newTop;
            btnCancel.Top = newTop;
        }

        private void HideBubble(Guna2Panel? bubble)
        {
            if (bubble != null) bubble.Visible = false;
        }

        // ====== Bong bóng cảnh báo (trắng, viền đen, tự ẩn) ======
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
                    Size = new Size(260, 34),
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

                panelForgot.Controls.Add(bubble);
            }

            var label = (Label)bubble.Tag!;
            label.Text = "⚠  " + message;

            // đặt ngay dưới control target
            var ptScreen = target.Parent.PointToScreen(new Point(target.Left, target.Bottom));
            var ptInPanel = panelForgot.PointToClient(ptScreen);
            bubble.Location = new Point(ptInPanel.X, ptInPanel.Y + 6);
            bubble.BringToFront();
            bubble.Visible = true;

            // auto ẩn
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

        // ====== VALIDATE EMAIL đơn giản ======
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            HideBottomError(); // clear lỗi cũ

            string user = txtUser.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string reNewPass = txtReNewPass.Text.Trim();

            bool hasError = false;

            // Tài khoản bắt buộc
            if (string.IsNullOrWhiteSpace(user))
            {
                ShowBubbleError(txtUser, ref _bubbleUser, "Vui lòng nhập tài khoản.");
                hasError = true;
            }

            // Email bắt buộc + định dạng
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowBubbleError(txtEmail, ref _bubbleEmail, "Vui lòng nhập email đã đăng ký.");
                hasError = true;
            }
            else if (!IsValidEmail(email))
            {
                ShowBubbleError(txtEmail, ref _bubbleEmail, "Email không hợp lệ.");
                hasError = true;
            }

            // Mật khẩu mới
            if (string.IsNullOrWhiteSpace(newPass))
            {
                ShowBubbleError(txtNewPass, ref _bubbleNewPass, "Vui lòng nhập mật khẩu mới.");
                hasError = true;
            }
            else if (newPass.Length < 6)
            {
                ShowBubbleError(txtNewPass, ref _bubbleNewPass, "Mật khẩu phải có ít nhất 6 ký tự.");
                hasError = true;
            }

            // Nhập lại
            if (string.IsNullOrWhiteSpace(reNewPass))
            {
                ShowBubbleError(txtReNewPass, ref _bubbleReNewPass, "Vui lòng nhập lại mật khẩu.");
                hasError = true;
            }
            else if (reNewPass != newPass)
            {
                ShowBubbleError(txtReNewPass, ref _bubbleReNewPass, "Mật khẩu nhập lại không khớp.");
                hasError = true;
            }

            if (hasError) return; // chỉ bong bóng, không hiển thị dòng đỏ

            // ====== Kiểm tra DB & cập nhật ======
            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();

                    using (var fkCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn))
                        fkCmd.ExecuteNonQuery();

                    // 1) Lấy email theo tài khoản
                    string sqlGetEmail = @"
                        SELECT nd.Email
                        FROM TaiKhoan tk
                        LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
                        WHERE tk.TenDangNhap = @user
                    ";

                    string? emailDb = null;

                    using (var cmdGet = new SqliteCommand(sqlGetEmail, conn))
                    {
                        cmdGet.Parameters.AddWithValue("@user", user);

                        using (var reader = cmdGet.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ShowBottomError("Tài khoản không tồn tại!");
                                return;
                            }
                            emailDb = reader["Email"] as string;
                        }
                    }

                    // 2) So khớp email
                    if (string.IsNullOrEmpty(emailDb) ||
                        !string.Equals(emailDb, email, StringComparison.OrdinalIgnoreCase))
                    {
                        ShowBottomError("Email không đúng với tài khoản này!");
                        return;
                    }

                    // 3) Cập nhật mật khẩu
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
                            MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.",
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

        // ====== CLICK của 2 nút con mắt ======
        private void btnToggleNewPass_Click(object? sender, EventArgs e)
        {
            _isNewPassVisible = !_isNewPassVisible;
            txtNewPass.PasswordChar = _isNewPassVisible ? '\0' : '●';
            btnToggleNewPass.Text   = _isNewPassVisible ? "🙈" : "👁";
        }

        private void btnToggleReNewPass_Click(object? sender, EventArgs e)
        {
            _isReNewPassVisible = !_isReNewPassVisible;
            txtReNewPass.PasswordChar = _isReNewPassVisible ? '\0' : '●';
            btnToggleReNewPass.Text   = _isReNewPassVisible ? "🙈" : "👁";
        }
    }
}
