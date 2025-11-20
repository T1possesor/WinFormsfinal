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

        // bong bóng cảnh báo cho từng ô
        private Guna2Panel? _bubbleHoTen;
        private Guna2Panel? _bubbleEmail;
        private Guna2Panel? _bubbleUser;
        private Guna2Panel? _bubblePass;
        private Guna2Panel? _bubbleRePass;
        private Guna2Panel? _bubblePhone;

        public fRegister(Form loginForm)
        {
            InitializeComponent();

            _loginForm = loginForm;

            // căn giữa panel đăng ký
            CenterRegisterPanel();
            this.Resize += (s, e) => CenterRegisterPanel();

            // cấu hình nút con mắt cho 2 textbox mật khẩu
            SetupEyeButtons();

            // gõ chữ thì ẩn lỗi & bong bóng
            txtHoTen.TextChanged += (_, __) => { HideBubble(_bubbleHoTen); HideBottomError(); };
            txtEmail.TextChanged += (_, __) => { HideBubble(_bubbleEmail); HideBottomError(); };
            txtUser.TextChanged += (_, __) => { HideBubble(_bubbleUser); HideBottomError(); };
            txtPass.TextChanged += (_, __) => { HideBubble(_bubblePass); HideBottomError(); };
            txtRePass.TextChanged += (_, __) => { HideBubble(_bubbleRePass); HideBottomError(); };
            txtSoDienThoai.TextChanged += (_, __) => { HideBubble(_bubblePhone); HideBottomError(); };
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
            panelRegister.Top = (this.ClientSize.Height - panelRegister.Height) / 2;
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
                btnTogglePassReg.FillColor = Color.Transparent;
                btnTogglePassReg.BorderThickness = 0;
                btnTogglePassReg.HoverState.FillColor = Color.Transparent;
                btnTogglePassReg.PressedColor = Color.Transparent;

                btnTogglePassReg.Size = new Size(30, txtPass.Height - 4);
                btnTogglePassReg.Location = new Point(
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
                btnToggleRePassReg.FillColor = Color.Transparent;
                btnToggleRePassReg.BorderThickness = 0;
                btnToggleRePassReg.HoverState.FillColor = Color.Transparent;
                btnToggleRePassReg.PressedColor = Color.Transparent;

                btnToggleRePassReg.Size = new Size(30, txtRePass.Height - 4);
                btnToggleRePassReg.Location = new Point(
                    txtRePass.Width - btnToggleRePassReg.Width - 2,
                    2
                );
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
                t.Stop();
                t.Dispose();
            };
            t.Start();

            target.Focus();
        }

        // ========= CÁC HÀM SINH MÃ & CHECK DB =========

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
                int num;
                if (!int.TryParse(numberPart, out num))
                    num = 0;

                num++;
                return "TK" + num.ToString("D3");
            }
        }

        // tạo mã người dùng mới dạng ND001, ND002, ...
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

                string numberPart = result.Substring(2);
                int num;
                if (!int.TryParse(numberPart, out num))
                    num = 0;

                num++;
                return "ND" + num.ToString("D3");
            }
        }

        // tạo mã số thẻ mới dạng TV0001, TV0002,...
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

                string numberPart = result.Substring(2);
                int num;
                if (!int.TryParse(numberPart, out num))
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
                var result = cmd.ExecuteScalar();
                long count = Convert.ToInt64(result ?? 0);
                return count > 0;
            }
        }

        // kiểm tra email trùng
        private bool IsEmailExists(SqliteConnection conn, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @mail";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@mail", email);
                var result = cmd.ExecuteScalar();
                long count = Convert.ToInt64(result ?? 0);
                return count > 0;
            }
        }

        // kiểm tra đơn giản: có @ và có .
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }

        // số điện thoại phải 10 chữ số
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            if (phone.Length != 10) return false;
            foreach (char c in phone)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        // ====== EVENTS ======

        // chặn gõ chữ trong textbox số điện thoại
        private void txtSoDienThoai_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HideBottomError(); // clear lỗi cũ

            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            string rePass = txtRePass.Text.Trim();

            // thông tin người dùng
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

            bool hasError = false;

            // Họ tên bắt buộc
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ShowBubbleError(txtHoTen, ref _bubbleHoTen, "Vui lòng nhập họ tên.");
                hasError = true;
            }

            // Email bắt buộc + định dạng
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

            // Tài khoản bắt buộc
            if (string.IsNullOrWhiteSpace(user))
            {
                ShowBubbleError(txtUser, ref _bubbleUser, "Vui lòng nhập tài khoản.");
                hasError = true;
            }

            // Mật khẩu bắt buộc + tối thiểu 6 kí tự
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

            // Nhập lại mật khẩu
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

            // Số điện thoại bắt buộc + 10 số
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

                    // bật foreign key
                    using (var fkCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn))
                    {
                        fkCmd.ExecuteNonQuery();
                    }

                    // kiểm tra trùng username
                    if (IsUserExists(conn, user))
                    {
                        lblRegError.Text = "Tài khoản đã tồn tại, vui lòng chọn tên khác.";
                        lblRegError.ForeColor = Color.FromArgb(255, 114, 118);
                        lblRegError.Visible = true;
                        return;
                    }

                    // kiểm tra trùng email
                    if (IsEmailExists(conn, email))
                    {
                        lblRegError.Text = "Email đã được sử dụng.";
                        lblRegError.ForeColor = Color.FromArgb(255, 114, 118);
                        lblRegError.Visible = true;
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
        (@maNguoi, @hoTen, @maSoThe, @ngaySinh, @sdt, @mail, @diaChi, DATE('now'), DATE('now','+1 year'), 'BiKhoa')
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
