using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Data.Sqlite;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    public partial class fRegister : Form
    {
        // form đăng nhập (fLogin) để quay lại
        private readonly Form _loginForm;

        // trạng thái hiển thị mật khẩu
        private bool isPassVisible = false;
        private bool isRePassVisible = false;

        // bong bóng cảnh báo cho từng ô (như trước)
        private Guna2Panel? _bubbleHoTen;
        private Guna2Panel? _bubbleEmail;
        private Guna2Panel? _bubbleUser;
        private Guna2Panel? _bubblePass;
        private Guna2Panel? _bubbleRePass;
        private Guna2Panel? _bubblePhone;

        // ==== Vị trí gốc để relayout khi show/hide lỗi inline ====
        private int _baseY_lblUser, _baseY_txtUser;
        private int _baseY_lblPass, _baseY_txtPass;
        private int _baseY_lblRePass, _baseY_txtRePass;
        private int _baseY_btnRegister, _baseY_btnCancel, _baseY_lblRegError;

        public fRegister(Form loginForm)
        {
            InitializeComponent();

            _loginForm = loginForm;

            // căn giữa panel đăng ký
            CenterRegisterPanel();
            this.Resize += (s, e) => CenterRegisterPanel();

            // cấu hình nút con mắt cho 2 textbox mật khẩu
            SetupEyeButtons();

            // ====== Ghi lại vị trí gốc sau khi designer set ======
            _baseY_lblUser      = lblUser.Top;
            _baseY_txtUser      = txtUser.Top;
            _baseY_lblPass      = lblPass.Top;
            _baseY_txtPass      = txtPass.Top;
            _baseY_lblRePass    = lblRePass.Top;
            _baseY_txtRePass    = txtRePass.Top;
            _baseY_btnRegister  = btnRegister.Top;
            _baseY_btnCancel    = btnCancel.Top;
            _baseY_lblRegError  = lblRegError.Top;

            // gõ chữ thì ẩn lỗi & bong bóng, rồi relayout
            txtHoTen.TextChanged      += (_, __) => { HideBubble(_bubbleHoTen); HideBottomError(); };
            txtEmail.TextChanged      += (_, __) => { HideBubble(_bubbleEmail); HideBottomError(); lblEmailInlineErr.Visible = false; RelayoutUnderEmailAndUser(); };
            txtUser.TextChanged       += (_, __) => { HideBubble(_bubbleUser); HideBottomError(); lblUserInlineErr.Visible  = false; RelayoutUnderEmailAndUser(); };
            txtPass.TextChanged       += (_, __) => { HideBubble(_bubblePass); HideBottomError(); };
            txtRePass.TextChanged     += (_, __) => { HideBubble(_bubbleRePass); HideBottomError(); };
            txtSoDienThoai.TextChanged+= (_, __) => { HideBubble(_bubblePhone); HideBottomError(); };

            // lần đầu canh label lỗi inline đúng vị trí dưới textbox
            PositionInlineErrorLabels();
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

        /// Đặt 2 label lỗi ngay dưới txtEmail/txtUser (gọi lúc khởi tạo và khi đổi size nếu cần)
        private void PositionInlineErrorLabels()
        {
            lblEmailInlineErr.Location = new Point(txtEmail.Left, txtEmail.Bottom + 4);
            lblEmailInlineErr.Width    = txtEmail.Width;

            lblUserInlineErr.Location  = new Point(txtUser.Left, txtUser.Bottom + 4);
            lblUserInlineErr.Width     = txtUser.Width;
        }

        /// Đẩy layout bên dưới email & user khi một trong hai lỗi hiển thị
        private void RelayoutUnderEmailAndUser()
        {
            // luôn đặt 2 label lỗi ngay dưới ô
            PositionInlineErrorLabels();

            int offsetAfterEmail = lblEmailInlineErr.Visible ? (lblEmailInlineErr.Height + 6) : 0;

            // đẩy cặp "Tài khoản" (label + textbox) theo offset của email
            lblUser.Top = _baseY_lblUser + offsetAfterEmail;
            txtUser.Top = _baseY_txtUser + offsetAfterEmail;
            lblUserInlineErr.Location = new Point(txtUser.Left, txtUser.Bottom + 4);

            // tiếp tục, nếu user có lỗi thì cộng thêm offset
            int offsetAfterUser = offsetAfterEmail + (lblUserInlineErr.Visible ? (lblUserInlineErr.Height + 6) : 0);

            // đẩy khối mật khẩu bên phải + các nút
            lblPass.Top     = _baseY_lblPass + offsetAfterUser;
            txtPass.Top     = _baseY_txtPass + offsetAfterUser;
            btnTogglePassReg.Top = txtPass.Top + (txtPass.Height - btnTogglePassReg.Height) / 2;

            lblRePass.Top   = _baseY_lblRePass + offsetAfterUser;
            txtRePass.Top   = _baseY_txtRePass + offsetAfterUser;
            btnToggleRePassReg.Top = txtRePass.Top + (txtRePass.Height - btnToggleRePassReg.Height) / 2;

            btnRegister.Top = _baseY_btnRegister + offsetAfterUser;
            btnCancel.Top   = _baseY_btnCancel + offsetAfterUser;
            lblRegError.Top = _baseY_lblRegError + offsetAfterUser;
        }

        /// <summary>Đưa 2 nút mắt vào trong txtPass và txtRePass</summary>
        private void SetupEyeButtons()
        {
            if (btnTogglePassReg != null && txtPass != null)
            {
                btnTogglePassReg.Parent = txtPass;
                btnTogglePassReg.BringToFront();

                btnTogglePassReg.Text = "👁";
                btnTogglePassReg.FillColor = Color.Transparent;
                btnTogglePassReg.BorderThickness = 0;
                btnTogglePassReg.HoverState.FillColor = Color.Transparent;
                btnTogglePassReg.PressedColor = Color.Transparent;

                btnTogglePassReg.Size = new Size(30, txtPass.Height - 4);
                btnTogglePassReg.Location = new Point(txtPass.Width - btnTogglePassReg.Width - 2, 2);
                btnTogglePassReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            if (btnToggleRePassReg != null && txtRePass != null)
            {
                btnToggleRePassReg.Parent = txtRePass;
                btnToggleRePassReg.BringToFront();

                btnToggleRePassReg.Text = "👁";
                btnToggleRePassReg.FillColor = Color.Transparent;
                btnToggleRePassReg.BorderThickness = 0;
                btnToggleRePassReg.HoverState.FillColor = Color.Transparent;
                btnToggleRePassReg.PressedColor = Color.Transparent;

                btnToggleRePassReg.Size = new Size(30, txtRePass.Height - 4);
                btnToggleRePassReg.Location = new Point(txtRePass.Width - btnToggleRePassReg.Width - 2, 2);
                btnToggleRePassReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }
        }

        // ẩn dòng lỗi dưới nút
        private void HideBottomError()
        {
            if (lblRegError != null)
            {
                lblRegError.Visible = false;
                lblRegError.Text = string.Empty;
            }
        }

        // ẩn bong bóng
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

                panelRegister.Controls.Add(bubble);
            }

            var label = (Label)bubble.Tag!;
            label.Text = "⚠  " + message;

            // đặt ngay dưới control target
            var ptScreen = target.Parent.PointToScreen(new Point(target.Left, target.Bottom));
            var ptInPanel = panelRegister.PointToClient(ptScreen);
            bubble.Location = new Point(ptInPanel.X, ptInPanel.Y + 6);
            bubble.BringToFront();
            bubble.Visible = true;

            // auto ẩn sau 2.5s
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

        // ========= CÁC HÀM SINH MÃ & CHECK DB =========
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
                if (string.IsNullOrEmpty(result)) return "TK001";
                string numberPart = result.Substring(2);
                if (!int.TryParse(numberPart, out int num)) num = 0;
                num++;
                return "TK" + num.ToString("D3");
            }
        }

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
                if (string.IsNullOrEmpty(result)) return "ND001";
                string numberPart = result.Substring(2);
                if (!int.TryParse(numberPart, out int num)) num = 0;
                num++;
                return "ND" + num.ToString("D3");
            }
        }

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
                if (string.IsNullOrEmpty(result)) return "TV0001";
                string numberPart = result.Substring(2);
                if (!int.TryParse(numberPart, out int num)) num = 0;
                num++;
                return "TV" + num.ToString("D4");
            }
        }

        private bool IsUserExists(SqliteConnection conn, string username)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @user";
            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                long count = Convert.ToInt64(cmd.ExecuteScalar() ?? 0);
                return count > 0;
            }
        }

        private bool IsEmailExists(SqliteConnection conn, string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @mail";
            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@mail", email);
                long count = Convert.ToInt64(cmd.ExecuteScalar() ?? 0);
                return count > 0;
            }
        }

        private bool IsValidEmail(string email)
            => !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10) return false;
            foreach (char c in phone) if (!char.IsDigit(c)) return false;
            return true;
        }

        // chặn gõ chữ trong textbox số điện thoại
        private void txtSoDienThoai_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HideBottomError(); // clear lỗi dòng dưới nút

            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            string rePass = txtRePass.Text.Trim();

            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ShowBubbleError(txtHoTen, ref _bubbleHoTen, "Vui lòng nhập họ tên.");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowBubbleError(txtEmail, ref _bubbleEmail, "Vui lòng nhập email.");
                hasError = true;
            }
            else if (!IsValidEmail(email))
            {
                ShowBubbleError(txtEmail, ref _bubbleEmail, "Email không hợp lệ.");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                ShowBubbleError(txtUser, ref _bubbleUser, "Vui lòng nhập tài khoản.");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                ShowBubbleError(txtPass, ref _bubblePass, "Vui lòng nhập mật khẩu.");
                hasError = true;
            }
            else if (pass.Length < 6)
            {
                ShowBubbleError(txtPass, ref _bubblePass, "Mật khẩu phải có ít nhất 6 ký tự.");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(rePass))
            {
                ShowBubbleError(txtRePass, ref _bubbleRePass, "Vui lòng nhập lại mật khẩu.");
                hasError = true;
            }
            else if (rePass != pass)
            {
                ShowBubbleError(txtRePass, ref _bubbleRePass, "Mật khẩu nhập lại không khớp.");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                ShowBubbleError(txtSoDienThoai, ref _bubblePhone, "Vui lòng nhập số điện thoại.");
                hasError = true;
            }
            else if (!IsValidPhone(sdt))
            {
                ShowBubbleError(txtSoDienThoai, ref _bubblePhone, "Số điện thoại phải gồm 10 chữ số.");
                hasError = true;
            }

            if (hasError) return;

            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (var fkCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn))
                        fkCmd.ExecuteNonQuery();

                    // ====== check trùng và HIỂN THỊ LỖI INLINE + ĐẨY LAYOUT ======
                    bool anyInline = false;

                    if (IsEmailExists(conn, email))
                    {
                        lblEmailInlineErr.Text = "Email đã được sử dụng.";
                        lblEmailInlineErr.Visible = true;
                        anyInline = true;
                    }
                    else
                    {
                        lblEmailInlineErr.Visible = false;
                    }

                    if (IsUserExists(conn, user))
                    {
                        lblUserInlineErr.Text = "Tên đăng nhập đã được dùng.";
                        lblUserInlineErr.Visible = true;
                        anyInline = true;
                    }
                    else
                    {
                        lblUserInlineErr.Visible = false;
                    }

                    if (anyInline)
                    {
                        RelayoutUnderEmailAndUser();
                        return; // dừng tại đây, chưa insert
                    }

                    string maTk = GenerateNewMaTaiKhoan(conn);
                    string maNguoiDung = GenerateNewMaNguoiDung(conn);
                    string maSoThe = GenerateNewMaSoThe(conn);

                    using (var tran = conn.BeginTransaction())
                    {
                        // 1) NguoiDung
                        string sqlNguoi = @"
INSERT INTO NguoiDung 
    (MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, Email, DiaChi, NgayTaoThe, NgayHetHanThe, TrangThai)
VALUES 
    (@maNguoi, @hoTen, @maSoThe, @ngaySinh, @sdt, @mail, @diaChi, DATE('now'), DATE('now','+1 year'), 'BiKhoa');
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

                        // 2) TaiKhoan
                        string sqlTk = @"
INSERT INTO TaiKhoan
    (MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, MaNguoiDung, NgayTao)
VALUES
    (@ma, @user, @pass, @vaiTro, @maNguoi, DATE('now'));
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
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTogglePassReg_Click(object sender, EventArgs e)
        {
            isPassVisible = !isPassVisible;
            if (isPassVisible) { txtPass.PasswordChar = '\0'; btnTogglePassReg.Text = "🙈"; }
            else { txtPass.PasswordChar = '●'; btnTogglePassReg.Text = "👁"; }
        }

        private void btnToggleRePassReg_Click(object sender, EventArgs e)
        {
            isRePassVisible = !isRePassVisible;
            if (isRePassVisible) { txtRePass.PasswordChar = '\0'; btnToggleRePassReg.Text = "🙈"; }
            else { txtRePass.PasswordChar = '●'; btnToggleRePassReg.Text = "👁"; }
        }

        private void btnCancel_Click(object sender, EventArgs e) => ShowLoginAndClose();

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
