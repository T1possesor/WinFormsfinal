using Guna.UI2.WinForms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsfinal
{
    public partial class fForgotPassword : Form
    {
        private readonly Form _loginForm;

        private readonly string connectionString = @"Data Source=project_final.db;Version=3;";

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
            SetupEyeIcons();
            
        }

        // ====== Eye buttons giống fLogin ======
        private void SetupEyeIcons()
        {
            // --- Mật khẩu mới ---
            txtNewPass.PasswordChar = '●';
            txtNewPass.IconRight = Properties.Resources.eye_closed;
            txtNewPass.IconRightCursor = Cursors.Hand;

            txtNewPass.IconRightClick += (s, e) =>
            {
                _isNewPassVisible = !_isNewPassVisible;
                txtNewPass.PasswordChar = _isNewPassVisible ? '\0' : '●';
                txtNewPass.IconRight = _isNewPassVisible
                    ? Properties.Resources.eye_open
                    : Properties.Resources.eye_closed;
            };

            // --- Nhập lại mật khẩu ---
            txtReNewPass.PasswordChar = '●';
            txtReNewPass.IconRight = Properties.Resources.eye_closed;
            txtReNewPass.IconRightCursor = Cursors.Hand;

            txtReNewPass.IconRightClick += (s, e) =>
            {
                _isReNewPassVisible = !_isReNewPassVisible;
                txtReNewPass.PasswordChar = _isReNewPassVisible ? '\0' : '●';
                txtReNewPass.IconRight = _isReNewPassVisible
                    ? Properties.Resources.eye_open
                    : Properties.Resources.eye_closed;
            };
        }


        private void CenterForgotPanel()
        {
            if (panelForgot == null) return;
            panelForgot.Left = (this.ClientSize.Width - panelForgot.Width) / 2;
            panelForgot.Top  = (this.ClientSize.Height - panelForgot.Height) / 2;
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
            lblForgotError.AutoSize = true;                 // cho tự tính chiều cao
            lblForgotError.MaximumSize = new Size(txtReNewPass.Width, 0); // giới hạn chiều rộng

            lblForgotError.Text = message;
            lblForgotError.ForeColor = Color.FromArgb(255, 80, 80);
            lblForgotError.BackColor = Color.Transparent;

            // đặt dưới ô nhập lại
            lblForgotError.Location = new Point(
                txtReNewPass.Left,
                txtReNewPass.Bottom + 4
            );

            lblForgotError.Visible = true;
            lblForgotError.BringToFront();

            // dời nút xuống theo chiều cao thực tế của label
            int newTop = lblForgotError.Bottom + 20;
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
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (var fkCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                        fkCmd.ExecuteNonQuery();

                    // 1) Lấy email theo tài khoản
                    string sqlGetEmail = @"
        SELECT nd.Email
        FROM TaiKhoan tk
        LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
        WHERE tk.TenDangNhap = @user
    ";

                    string? emailDb = null;

                    using (var cmdGet = new SQLiteCommand(sqlGetEmail, conn))
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

                    using (var cmdUpdate = new SQLiteCommand(sqlUpdate, conn))
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

        
        
    }
}
