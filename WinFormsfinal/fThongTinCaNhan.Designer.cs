using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fThongTinCaNhan
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelMain;

        private Label lblTitle;
        private Label lblUserCaption;

        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblEmail;
        private Label lblSDT;
        private Label lblDiaChi;

        private Guna2TextBox txtHoTen;
        private Guna2TextBox txtNgaySinh;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtSDT;
        private Guna2TextBox txtDiaChi;

        private GroupBox groupPass;
        private Label lblTenDangNhap;
        private Label lblPassCu;
        private Label lblPassMoi;
        private Label lblNhapLaiPassMoi;

        private Guna2TextBox txtTenDangNhap;
        private Guna2TextBox txtPassCu;
        private Guna2TextBox txtPassMoi;
        private Guna2TextBox txtNhapLaiPassMoi;

        private Guna2Button btnLuu;
        private Guna2Button btnDong;
        private Guna2HtmlLabel lblError;

        // Ảnh
        private Guna2CirclePictureBox picAvatar;
        private Guna2Button btnChonAnh;
        private Guna2Button btnXoaAnh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var cePanel = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceMain = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceBtn1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceBtn2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            guna2BorderlessForm1 = new Guna2BorderlessForm(components);
            panelMain = new Guna2Panel();

            lblTitle       = new Label();
            lblUserCaption = new Label();

            lblHoTen     = new Label();
            lblNgaySinh  = new Label();
            lblEmail     = new Label();
            lblSDT       = new Label();
            lblDiaChi    = new Label();

            txtHoTen     = new Guna2TextBox();
            txtNgaySinh  = new Guna2TextBox();
            txtEmail     = new Guna2TextBox();
            txtSDT       = new Guna2TextBox();
            txtDiaChi    = new Guna2TextBox();

            groupPass        = new GroupBox();
            lblTenDangNhap   = new Label();
            lblPassCu        = new Label();
            lblPassMoi       = new Label();
            lblNhapLaiPassMoi= new Label();

            txtTenDangNhap   = new Guna2TextBox();
            txtPassCu        = new Guna2TextBox();
            txtPassMoi       = new Guna2TextBox();
            txtNhapLaiPassMoi= new Guna2TextBox();

            btnLuu  = new Guna2Button();
            btnDong = new Guna2Button();
            lblError= new Guna2HtmlLabel();

            // Avatar & nút ảnh
            picAvatar = new Guna2CirclePictureBox();
            btnChonAnh = new Guna2Button();
            btnXoaAnh  = new Guna2Button();

            SuspendLayout();
            panelMain.SuspendLayout();
            groupPass.SuspendLayout();

            // ===== Borderless form =====
            guna2BorderlessForm1.BorderRadius = 14;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;

            // ===== panelMain (form to hơn) =====
            panelMain.BorderRadius = 16;
            panelMain.CustomizableEdges = cePanel;
            panelMain.FillColor = Color.White;
            panelMain.ShadowDecoration.BorderRadius = 16;
            panelMain.ShadowDecoration.CustomizableEdges = ceMain;
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelMain.Size = new Size(880, 560);
            panelMain.Location = new Point(20, 20);

            // ===== Title =====
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(310, 20);
            lblTitle.Text = "Thông tin cá nhân";

            lblUserCaption.AutoSize = true;
            lblUserCaption.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblUserCaption.ForeColor = Color.FromArgb(73, 80, 87);
            lblUserCaption.Location = new Point(30, 55);
            lblUserCaption.Text = "Tài khoản:";

            // ===== Layout các label/textbox thông tin cơ bản =====
            int leftLabel = 30;
            int leftInput = 180;
            int topFirst = 90;
            int lineHeight = 34;
            int gap = 8;

            // Họ tên (row 0)
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(leftLabel, topFirst);
            lblHoTen.Text = "Họ tên";

            txtHoTen.BorderRadius = 8;
            txtHoTen.CustomizableEdges = ceTxt1;
            txtHoTen.Location = new Point(leftInput, topFirst - 3);
            txtHoTen.Size = new Size(450, 28);
            txtHoTen.Font = new Font("Segoe UI", 10F);

            // Ngày sinh (row 1)
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 1);
            lblNgaySinh.Text = "Ngày sinh";

            txtNgaySinh.BorderRadius = 8;
            txtNgaySinh.CustomizableEdges = ceTxt2;
            txtNgaySinh.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 1 - 3);
            txtNgaySinh.Size = new Size(200, 28);
            txtNgaySinh.Font = new Font("Segoe UI", 10F);

            // Email (row 2)
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 2);
            lblEmail.Text = "Email";

            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = ceTxt3;
            txtEmail.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 2 - 3);
            txtEmail.Size = new Size(450, 28);
            txtEmail.Font = new Font("Segoe UI", 10F);

            // Số điện thoại (row 3)
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 10F);
            lblSDT.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 3);
            lblSDT.Text = "Số điện thoại";

            txtSDT.BorderRadius = 8;
            txtSDT.CustomizableEdges = ceTxt4;
            txtSDT.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 3 - 3);
            txtSDT.Size = new Size(250, 28);
            txtSDT.Font = new Font("Segoe UI", 10F);

            // Địa chỉ (row 4)
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 4);
            lblDiaChi.Text = "Địa chỉ";

            txtDiaChi.BorderRadius = 8;
            txtDiaChi.CustomizableEdges = ceTxt5;
            txtDiaChi.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 4 - 3);
            txtDiaChi.Size = new Size(450, 28);
            txtDiaChi.Font = new Font("Segoe UI", 10F);

            // ===== Group đổi mật khẩu =====
            groupPass.Text = "Đổi mật khẩu (không bắt buộc)";
            groupPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupPass.Location = new Point(25, 295);
            groupPass.Size = new Size(830, 180);

            int gLeftLabel = 15;
            int gLeftInput = 210;
            int gTopFirst = 25;

            // Tên đăng nhập
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 9F);
            lblTenDangNhap.Location = new Point(gLeftLabel, gTopFirst);
            lblTenDangNhap.Text = "Tên đăng nhập";

            txtTenDangNhap.BorderRadius = 8;
            txtTenDangNhap.CustomizableEdges = ceTxt6;
            txtTenDangNhap.Location = new Point(gLeftInput, gTopFirst - 3);
            txtTenDangNhap.Size = new Size(260, 26);
            txtTenDangNhap.Font = new Font("Segoe UI", 9F);
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.FillColor = Color.FromArgb(245, 245, 245);

            // Mật khẩu hiện tại
            lblPassCu.AutoSize = true;
            lblPassCu.Font = new Font("Segoe UI", 9F);
            lblPassCu.Location = new Point(gLeftLabel, gTopFirst + 32);
            lblPassCu.Text = "Mật khẩu hiện tại";

            txtPassCu.BorderRadius = 8;
            txtPassCu.CustomizableEdges = ceTxt7;
            txtPassCu.Location = new Point(gLeftInput, gTopFirst + 29);
            txtPassCu.Size = new Size(260, 26);
            txtPassCu.Font = new Font("Segoe UI", 9F);
            txtPassCu.PasswordChar = '●';

            // Mật khẩu mới
            lblPassMoi.AutoSize = true;
            lblPassMoi.Font = new Font("Segoe UI", 9F);
            lblPassMoi.Location = new Point(gLeftLabel, gTopFirst + 64);
            lblPassMoi.Text = "Mật khẩu mới";

            txtPassMoi.BorderRadius = 8;
            txtPassMoi.CustomizableEdges = ceTxt8;
            txtPassMoi.Location = new Point(gLeftInput, gTopFirst + 61);
            txtPassMoi.Size = new Size(260, 26);
            txtPassMoi.Font = new Font("Segoe UI", 9F);
            txtPassMoi.PasswordChar = '●';

            // Nhập lại mật khẩu mới
            lblNhapLaiPassMoi.AutoSize = true;
            lblNhapLaiPassMoi.Font = new Font("Segoe UI", 9F);
            lblNhapLaiPassMoi.Location = new Point(gLeftLabel, gTopFirst + 96);
            lblNhapLaiPassMoi.Text = "Nhập lại mật khẩu mới";

            txtNhapLaiPassMoi.BorderRadius = 8;
            txtNhapLaiPassMoi.CustomizableEdges = ceTxt9;
            txtNhapLaiPassMoi.Location = new Point(gLeftInput, gTopFirst + 93);
            txtNhapLaiPassMoi.Size = new Size(260, 26);
            txtNhapLaiPassMoi.Font = new Font("Segoe UI", 9F);
            txtNhapLaiPassMoi.PasswordChar = '●';

            groupPass.Controls.Add(lblTenDangNhap);
            groupPass.Controls.Add(txtTenDangNhap);
            groupPass.Controls.Add(lblPassCu);
            groupPass.Controls.Add(txtPassCu);
            groupPass.Controls.Add(lblPassMoi);
            groupPass.Controls.Add(txtPassMoi);
            groupPass.Controls.Add(lblNhapLaiPassMoi);
            groupPass.Controls.Add(txtNhapLaiPassMoi);

            // ===== Buttons & error =====
            btnLuu.BorderRadius = 10;
            btnLuu.CustomizableEdges = ceBtn1;
            btnLuu.FillColor = Color.FromArgb(0, 123, 255);
            btnLuu.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Size = new Size(130, 32);
            btnLuu.Location = new Point(410, 495);
            btnLuu.Text = "Lưu thay đổi";
            btnLuu.Click += btnLuu_Click;

            btnDong.BorderRadius = 10;
            btnDong.CustomizableEdges = ceBtn2;
            btnDong.FillColor = Color.FromArgb(108, 117, 125);
            btnDong.Font = new Font("Segoe UI", 10F);
            btnDong.ForeColor = Color.White;
            btnDong.Size = new Size(90, 32);
            btnDong.Location = new Point(560, 495);
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;

            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(220, 53, 69);
            lblError.AutoSize = false;
            lblError.TextAlignment = ContentAlignment.MiddleLeft;
            lblError.Location = new Point(25, 498);
            lblError.Size = new Size(320, 26);
            lblError.Visible = false;
            lblError.Text = "";

            // ====== Avatar + nút ảnh ======
            // Avatar
            picAvatar.ImageRotate = 0F;
            picAvatar.Size = new Size(120, 120);
            picAvatar.Location = new Point(710, 80); // cùng hàng Họ tên
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.FillColor = Color.FromArgb(245, 245, 245);

            // Nút Chọn ảnh
            btnChonAnh.BorderRadius = 8;
            btnChonAnh.FillColor = Color.FromArgb(25, 135, 84);
            btnChonAnh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Size = new Size(120, 30);
            btnChonAnh.Location = new Point(710, 210);
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.Click += btnChonAnh_Click;

            // Nút Xoá ảnh
            btnXoaAnh.BorderRadius = 8;
            btnXoaAnh.FillColor = Color.FromArgb(220, 53, 69);
            btnXoaAnh.Font = new Font("Segoe UI", 9F);
            btnXoaAnh.ForeColor = Color.White;
            btnXoaAnh.Size = new Size(120, 30);
            btnXoaAnh.Location = new Point(710, 245);
            btnXoaAnh.Text = "Xoá ảnh";
            btnXoaAnh.Click += btnXoaAnh_Click;

            // ===== Add vào panelMain =====
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblUserCaption);

            panelMain.Controls.Add(lblHoTen);
            panelMain.Controls.Add(txtHoTen);
            panelMain.Controls.Add(lblNgaySinh);
            panelMain.Controls.Add(txtNgaySinh);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblSDT);
            panelMain.Controls.Add(txtSDT);
            panelMain.Controls.Add(lblDiaChi);
            panelMain.Controls.Add(txtDiaChi);

            // Avatar + nút ảnh
            panelMain.Controls.Add(picAvatar);
            panelMain.Controls.Add(btnChonAnh);
            panelMain.Controls.Add(btnXoaAnh);

            panelMain.Controls.Add(groupPass);
            panelMain.Controls.Add(btnLuu);
            panelMain.Controls.Add(btnDong);
            panelMain.Controls.Add(lblError);

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 250);
            ClientSize = new Size(920, 600);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fThongTinCaNhan";
            Text = "Thông tin cá nhân";
            StartPosition = FormStartPosition.CenterParent;

            groupPass.ResumeLayout(false);
            groupPass.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
