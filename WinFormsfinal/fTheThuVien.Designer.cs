using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fTheThuVien
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelMain;

        private Label lblTitle;
        private Label lblUserCaption;

        private Label lblMaSoThe;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblNgayTao;
        private Label lblNgayHetHan;
        private Label lblTrangThai;

        private Guna2TextBox txtMaSoThe;
        private Guna2TextBox txtHoTen;
        private Guna2TextBox txtNgaySinh;
        private Guna2TextBox txtSDT;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtDiaChi;
        private Guna2TextBox txtNgayTao;
        private Guna2TextBox txtNgayHetHan;
        private Guna2TextBox txtTrangThai;

        private Guna2Button btnThanhToan;
        private Guna2Button btnDong;

        // ===== THÊM: khung ảnh thẻ =====
        private Guna2PictureBox picAvatar;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna2BorderlessForm(components);
            panelMain = new Guna2Panel();
            lblTitle = new Label();
            lblUserCaption = new Label();
            lblMaSoThe = new Label();
            txtMaSoThe = new Guna2TextBox();
            lblHoTen = new Label();
            txtHoTen = new Guna2TextBox();
            lblNgaySinh = new Label();
            txtNgaySinh = new Guna2TextBox();
            lblSDT = new Label();
            txtSDT = new Guna2TextBox();
            lblEmail = new Label();
            txtEmail = new Guna2TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new Guna2TextBox();
            lblNgayTao = new Label();
            txtNgayTao = new Guna2TextBox();
            lblNgayHetHan = new Label();
            txtNgayHetHan = new Guna2TextBox();
            lblTrangThai = new Label();
            txtTrangThai = new Guna2TextBox();
            picAvatar = new Guna2PictureBox();
            btnThanhToan = new Guna2Button();
            btnDong = new Guna2Button();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 14;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.BorderRadius = 16;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblUserCaption);
            panelMain.Controls.Add(lblMaSoThe);
            panelMain.Controls.Add(txtMaSoThe);
            panelMain.Controls.Add(lblHoTen);
            panelMain.Controls.Add(txtHoTen);
            panelMain.Controls.Add(lblNgaySinh);
            panelMain.Controls.Add(txtNgaySinh);
            panelMain.Controls.Add(lblSDT);
            panelMain.Controls.Add(txtSDT);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblDiaChi);
            panelMain.Controls.Add(txtDiaChi);
            panelMain.Controls.Add(lblNgayTao);
            panelMain.Controls.Add(txtNgayTao);
            panelMain.Controls.Add(lblNgayHetHan);
            panelMain.Controls.Add(txtNgayHetHan);
            panelMain.Controls.Add(lblTrangThai);
            panelMain.Controls.Add(txtTrangThai);
            panelMain.Controls.Add(picAvatar);
            panelMain.Controls.Add(btnThanhToan);
            panelMain.Controls.Add(btnDong);
            panelMain.CustomizableEdges = customizableEdges25;
            panelMain.FillColor = Color.White;
            panelMain.Location = new Point(29, 33);
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.BorderRadius = 16;
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges26;
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelMain.Size = new Size(1000, 833);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(329, 30);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thẻ thư viện của bạn";
            // 
            // lblUserCaption
            // 
            lblUserCaption.AutoSize = true;
            lblUserCaption.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblUserCaption.ForeColor = Color.FromArgb(73, 80, 87);
            lblUserCaption.Location = new Point(43, 92);
            lblUserCaption.Margin = new Padding(4, 0, 4, 0);
            lblUserCaption.Name = "lblUserCaption";
            lblUserCaption.Size = new Size(103, 28);
            lblUserCaption.TabIndex = 1;
            lblUserCaption.Text = "Tài khoản:";
            // 
            // lblMaSoThe
            // 
            lblMaSoThe.AutoSize = true;
            lblMaSoThe.Font = new Font("Segoe UI", 10F);
            lblMaSoThe.Location = new Point(43, 150);
            lblMaSoThe.Margin = new Padding(4, 0, 4, 0);
            lblMaSoThe.Name = "lblMaSoThe";
            lblMaSoThe.Size = new Size(98, 28);
            lblMaSoThe.TabIndex = 2;
            lblMaSoThe.Text = "Mã số thẻ";
            // 
            // txtMaSoThe
            // 
            txtMaSoThe.BorderRadius = 8;
            txtMaSoThe.CustomizableEdges = customizableEdges1;
            txtMaSoThe.DefaultText = "";
            txtMaSoThe.FillColor = Color.FromArgb(245, 245, 245);
            txtMaSoThe.Font = new Font("Segoe UI", 10F);
            txtMaSoThe.Location = new Point(243, 150);
            txtMaSoThe.Margin = new Padding(6, 8, 6, 8);
            txtMaSoThe.Name = "txtMaSoThe";
            txtMaSoThe.PlaceholderText = "";
            txtMaSoThe.ReadOnly = true;
            txtMaSoThe.SelectedText = "";
            txtMaSoThe.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMaSoThe.Size = new Size(257, 47);
            txtMaSoThe.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(43, 150);
            lblHoTen.Margin = new Padding(4, 0, 4, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(71, 28);
            lblHoTen.TabIndex = 4;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.BorderRadius = 8;
            txtHoTen.CustomizableEdges = customizableEdges3;
            txtHoTen.DefaultText = "";
            txtHoTen.FillColor = Color.FromArgb(245, 245, 245);
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(243, 150);
            txtHoTen.Margin = new Padding(6, 8, 6, 8);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "";
            txtHoTen.ReadOnly = true;
            txtHoTen.SelectedText = "";
            txtHoTen.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtHoTen.Size = new Size(443, 47);
            txtHoTen.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(43, 150);
            lblNgaySinh.Margin = new Padding(4, 0, 4, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(99, 28);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // txtNgaySinh
            // 
            txtNgaySinh.BorderRadius = 8;
            txtNgaySinh.CustomizableEdges = customizableEdges5;
            txtNgaySinh.DefaultText = "";
            txtNgaySinh.FillColor = Color.FromArgb(245, 245, 245);
            txtNgaySinh.Font = new Font("Segoe UI", 10F);
            txtNgaySinh.Location = new Point(243, 150);
            txtNgaySinh.Margin = new Padding(6, 8, 6, 8);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.PlaceholderText = "";
            txtNgaySinh.ReadOnly = true;
            txtNgaySinh.SelectedText = "";
            txtNgaySinh.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNgaySinh.Size = new Size(257, 47);
            txtNgaySinh.TabIndex = 7;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 10F);
            lblSDT.Location = new Point(43, 150);
            lblSDT.Margin = new Padding(4, 0, 4, 0);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(128, 28);
            lblSDT.TabIndex = 8;
            lblSDT.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.BorderRadius = 8;
            txtSDT.CustomizableEdges = customizableEdges7;
            txtSDT.DefaultText = "";
            txtSDT.FillColor = Color.FromArgb(245, 245, 245);
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.Location = new Point(243, 150);
            txtSDT.Margin = new Padding(6, 8, 6, 8);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "";
            txtSDT.ReadOnly = true;
            txtSDT.SelectedText = "";
            txtSDT.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSDT.Size = new Size(257, 47);
            txtSDT.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(43, 150);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 28);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges9;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.FromArgb(245, 245, 245);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(243, 150);
            txtEmail.Margin = new Padding(6, 8, 6, 8);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.ReadOnly = true;
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtEmail.Size = new Size(443, 47);
            txtEmail.TabIndex = 11;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(43, 150);
            lblDiaChi.Margin = new Padding(4, 0, 4, 0);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(71, 28);
            lblDiaChi.TabIndex = 12;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderRadius = 8;
            txtDiaChi.CustomizableEdges = customizableEdges11;
            txtDiaChi.DefaultText = "";
            txtDiaChi.FillColor = Color.FromArgb(245, 245, 245);
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(243, 150);
            txtDiaChi.Margin = new Padding(6, 8, 6, 8);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.SelectedText = "";
            txtDiaChi.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtDiaChi.Size = new Size(443, 47);
            txtDiaChi.TabIndex = 13;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new Font("Segoe UI", 10F);
            lblNgayTao.Location = new Point(43, 150);
            lblNgayTao.Margin = new Padding(4, 0, 4, 0);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(126, 28);
            lblNgayTao.TabIndex = 14;
            lblNgayTao.Text = "Ngày tạo thẻ";
            // 
            // txtNgayTao
            // 
            txtNgayTao.BorderRadius = 8;
            txtNgayTao.CustomizableEdges = customizableEdges13;
            txtNgayTao.DefaultText = "";
            txtNgayTao.FillColor = Color.FromArgb(245, 245, 245);
            txtNgayTao.Font = new Font("Segoe UI", 10F);
            txtNgayTao.Location = new Point(243, 150);
            txtNgayTao.Margin = new Padding(6, 8, 6, 8);
            txtNgayTao.Name = "txtNgayTao";
            txtNgayTao.PlaceholderText = "";
            txtNgayTao.ReadOnly = true;
            txtNgayTao.SelectedText = "";
            txtNgayTao.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtNgayTao.Size = new Size(257, 47);
            txtNgayTao.TabIndex = 15;
            // 
            // lblNgayHetHan
            // 
            lblNgayHetHan.AutoSize = true;
            lblNgayHetHan.Font = new Font("Segoe UI", 10F);
            lblNgayHetHan.Location = new Point(43, 150);
            lblNgayHetHan.Margin = new Padding(4, 0, 4, 0);
            lblNgayHetHan.Name = "lblNgayHetHan";
            lblNgayHetHan.Size = new Size(129, 28);
            lblNgayHetHan.TabIndex = 16;
            lblNgayHetHan.Text = "Ngày hết hạn";
            // 
            // txtNgayHetHan
            // 
            txtNgayHetHan.BorderRadius = 8;
            txtNgayHetHan.CustomizableEdges = customizableEdges15;
            txtNgayHetHan.DefaultText = "";
            txtNgayHetHan.FillColor = Color.FromArgb(245, 245, 245);
            txtNgayHetHan.Font = new Font("Segoe UI", 10F);
            txtNgayHetHan.Location = new Point(243, 150);
            txtNgayHetHan.Margin = new Padding(6, 8, 6, 8);
            txtNgayHetHan.Name = "txtNgayHetHan";
            txtNgayHetHan.PlaceholderText = "";
            txtNgayHetHan.ReadOnly = true;
            txtNgayHetHan.SelectedText = "";
            txtNgayHetHan.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtNgayHetHan.Size = new Size(257, 47);
            txtNgayHetHan.TabIndex = 17;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 10F);
            lblTrangThai.Location = new Point(43, 150);
            lblTrangThai.Margin = new Padding(4, 0, 4, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(98, 28);
            lblTrangThai.TabIndex = 18;
            lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            txtTrangThai.BorderRadius = 8;
            txtTrangThai.CustomizableEdges = customizableEdges17;
            txtTrangThai.DefaultText = "";
            txtTrangThai.FillColor = Color.FromArgb(245, 245, 245);
            txtTrangThai.Font = new Font("Segoe UI", 10F);
            txtTrangThai.Location = new Point(243, 150);
            txtTrangThai.Margin = new Padding(6, 8, 6, 8);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.PlaceholderText = "";
            txtTrangThai.ReadOnly = true;
            txtTrangThai.SelectedText = "";
            txtTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtTrangThai.Size = new Size(257, 47);
            txtTrangThai.TabIndex = 19;
            // 
            // picAvatar
            // 
            picAvatar.BorderRadius = 8;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.CustomizableEdges = customizableEdges19;
            picAvatar.FillColor = Color.FromArgb(245, 245, 245);
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(771, 150);
            picAvatar.Margin = new Padding(4, 5, 4, 5);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            picAvatar.Size = new Size(171, 199);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 20;
            picAvatar.TabStop = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BorderRadius = 10;
            btnThanhToan.CustomizableEdges = customizableEdges21;
            btnThanhToan.FillColor = Color.FromArgb(0, 123, 255);
            btnThanhToan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(571, 742);
            btnThanhToan.Margin = new Padding(4, 5, 4, 5);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnThanhToan.Size = new Size(171, 53);
            btnThanhToan.TabIndex = 21;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Visible = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnDong
            // 
            btnDong.BorderRadius = 10;
            btnDong.CustomizableEdges = customizableEdges23;
            btnDong.FillColor = Color.FromArgb(108, 117, 125);
            btnDong.Font = new Font("Segoe UI", 10F);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(771, 742);
            btnDong.Margin = new Padding(4, 5, 4, 5);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnDong.Size = new Size(143, 53);
            btnDong.TabIndex = 22;
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;
            // 
            // fTheThuVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 250);
            ClientSize = new Size(1057, 900);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fTheThuVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thẻ thư viện";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
