using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fRegister
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelRegister;

        private Label lblTitle;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblSoDienThoai;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblUser;
        private Label lblPass;
        private Label lblRePass;

        private Guna2TextBox txtHoTen;
        private Guna2DateTimePicker dtpNgaySinh;
        private Guna2TextBox txtSoDienThoai;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtDiaChi;

        private Guna2TextBox txtUser;
        private Guna2TextBox txtPass;
        private Guna2TextBox txtRePass;

        private Guna2Button btnRegister;
        private Guna2Button btnCancel;

        private Guna2Button btnTogglePassReg;
        private Guna2Button btnToggleRePassReg;

        private Guna2ControlBox controlBoxMin;
        private Guna2ControlBox controlBoxMax;
        private Guna2ControlBox controlBoxClose;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna2BorderlessForm(components);
            panelRegister = new Guna2Panel();
            lblTitle = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();
            lblSoDienThoai = new Label();
            lblEmail = new Label();
            lblDiaChi = new Label();
            lblUser = new Label();
            lblPass = new Label();
            lblRePass = new Label();
            txtHoTen = new Guna2TextBox();
            dtpNgaySinh = new Guna2DateTimePicker();
            txtSoDienThoai = new Guna2TextBox();
            txtEmail = new Guna2TextBox();
            txtDiaChi = new Guna2TextBox();
            txtUser = new Guna2TextBox();
            txtPass = new Guna2TextBox();
            txtRePass = new Guna2TextBox();
            btnTogglePassReg = new Guna2Button();
            btnToggleRePassReg = new Guna2Button();
            btnRegister = new Guna2Button();
            btnCancel = new Guna2Button();
            controlBoxMin = new Guna2ControlBox();
            controlBoxMax = new Guna2ControlBox();
            controlBoxClose = new Guna2ControlBox();
            panelRegister.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelRegister
            // 
            panelRegister.BackColor = Color.Transparent;
            panelRegister.BorderRadius = 20;
            panelRegister.Controls.Add(lblTitle);
            panelRegister.Controls.Add(lblHoTen);
            panelRegister.Controls.Add(lblNgaySinh);
            panelRegister.Controls.Add(lblSoDienThoai);
            panelRegister.Controls.Add(lblEmail);
            panelRegister.Controls.Add(lblDiaChi);
            panelRegister.Controls.Add(lblUser);
            panelRegister.Controls.Add(lblPass);
            panelRegister.Controls.Add(lblRePass);
            panelRegister.Controls.Add(txtHoTen);
            panelRegister.Controls.Add(dtpNgaySinh);
            panelRegister.Controls.Add(txtSoDienThoai);
            panelRegister.Controls.Add(txtEmail);
            panelRegister.Controls.Add(txtDiaChi);
            panelRegister.Controls.Add(txtUser);
            panelRegister.Controls.Add(txtPass);
            panelRegister.Controls.Add(txtRePass);
            panelRegister.Controls.Add(btnTogglePassReg);
            panelRegister.Controls.Add(btnToggleRePassReg);
            panelRegister.Controls.Add(btnRegister);
            panelRegister.Controls.Add(btnCancel);
            panelRegister.CustomizableEdges = customizableEdges25;
            panelRegister.FillColor = Color.FromArgb(30, 33, 40);
            panelRegister.Location = new Point(150, 100);
            panelRegister.Name = "panelRegister";
            panelRegister.ShadowDecoration.BorderRadius = 20;
            panelRegister.ShadowDecoration.CustomizableEdges = customizableEdges26;
            panelRegister.ShadowDecoration.Enabled = true;
            panelRegister.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            panelRegister.Size = new Size(600, 400);
            panelRegister.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(240, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(108, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng ký";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.ForeColor = Color.Gainsboro;
            lblHoTen.Location = new Point(40, 60);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(51, 19);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.ForeColor = Color.Gainsboro;
            lblNgaySinh.Location = new Point(40, 115);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(70, 19);
            lblNgaySinh.TabIndex = 3;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            lblSoDienThoai.ForeColor = Color.Gainsboro;
            lblSoDienThoai.Location = new Point(322, 60);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(89, 19);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.Gainsboro;
            lblEmail.Location = new Point(40, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.ForeColor = Color.Gainsboro;
            lblDiaChi.Location = new Point(322, 115);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(50, 19);
            lblDiaChi.TabIndex = 6;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Gainsboro;
            lblUser.Location = new Point(40, 225);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(66, 19);
            lblUser.TabIndex = 7;
            lblUser.Text = "Tài khoản";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.Gainsboro;
            lblPass.Location = new Point(322, 170);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(68, 19);
            lblPass.TabIndex = 8;
            lblPass.Text = "Mật khẩu";
            // 
            // lblRePass
            // 
            lblRePass.AutoSize = true;
            lblRePass.Font = new Font("Segoe UI", 10F);
            lblRePass.ForeColor = Color.Gainsboro;
            lblRePass.Location = new Point(322, 225);
            lblRePass.Name = "lblRePass";
            lblRePass.Size = new Size(121, 19);
            lblRePass.TabIndex = 9;
            lblRePass.Text = "Nhập lại mật khẩu";
            // 
            // txtHoTen
            // 
            txtHoTen.BorderRadius = 8;
            txtHoTen.CustomizableEdges = customizableEdges1;
            txtHoTen.DefaultText = "";
            txtHoTen.FillColor = Color.FromArgb(33, 38, 45);
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.ForeColor = Color.White;
            txtHoTen.Location = new Point(40, 80);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Nhập họ tên...";
            txtHoTen.SelectedText = "";
            txtHoTen.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtHoTen.Size = new Size(240, 26);
            txtHoTen.TabIndex = 10;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.BorderRadius = 8;
            dtpNgaySinh.Checked = true;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.CustomizableEdges = customizableEdges3;
            dtpNgaySinh.FillColor = Color.FromArgb(33, 38, 45);
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.ForeColor = Color.White;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(40, 135);
            dtpNgaySinh.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpNgaySinh.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpNgaySinh.Size = new Size(240, 26);
            dtpNgaySinh.TabIndex = 12;
            dtpNgaySinh.Value = new DateTime(2025, 11, 18, 17, 6, 14, 654);
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BorderRadius = 8;
            txtSoDienThoai.CustomizableEdges = customizableEdges5;
            txtSoDienThoai.DefaultText = "";
            txtSoDienThoai.FillColor = Color.FromArgb(33, 38, 45);
            txtSoDienThoai.Font = new Font("Segoe UI", 10F);
            txtSoDienThoai.ForeColor = Color.White;
            txtSoDienThoai.Location = new Point(322, 80);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại...";
            txtSoDienThoai.SelectedText = "";
            txtSoDienThoai.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSoDienThoai.Size = new Size(240, 26);
            txtSoDienThoai.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges7;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.FromArgb(33, 38, 45);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(40, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtEmail.Size = new Size(240, 26);
            txtEmail.TabIndex = 14;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderRadius = 8;
            txtDiaChi.CustomizableEdges = customizableEdges9;
            txtDiaChi.DefaultText = "";
            txtDiaChi.FillColor = Color.FromArgb(33, 38, 45);
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.ForeColor = Color.White;
            txtDiaChi.Location = new Point(322, 135);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Nhập địa chỉ...";
            txtDiaChi.SelectedText = "";
            txtDiaChi.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtDiaChi.Size = new Size(240, 26);
            txtDiaChi.TabIndex = 15;
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 8;
            txtUser.CustomizableEdges = customizableEdges11;
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.FromArgb(33, 38, 45);
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(40, 245);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtUser.Size = new Size(240, 26);
            txtUser.TabIndex = 16;
            // 
            // txtPass
            // 
            txtPass.BorderRadius = 8;
            txtPass.CustomizableEdges = customizableEdges13;
            txtPass.DefaultText = "";
            txtPass.FillColor = Color.FromArgb(33, 38, 45);
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.ForeColor = Color.White;
            txtPass.Location = new Point(322, 190);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Nhập mật khẩu...";
            txtPass.SelectedText = "";
            txtPass.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtPass.Size = new Size(240, 26);
            txtPass.TabIndex = 17;
            // 
            // txtRePass
            // 
            txtRePass.BorderRadius = 8;
            txtRePass.CustomizableEdges = customizableEdges15;
            txtRePass.DefaultText = "";
            txtRePass.FillColor = Color.FromArgb(33, 38, 45);
            txtRePass.Font = new Font("Segoe UI", 10F);
            txtRePass.ForeColor = Color.White;
            txtRePass.Location = new Point(322, 245);
            txtRePass.Name = "txtRePass";
            txtRePass.PasswordChar = '●';
            txtRePass.PlaceholderText = "Nhập lại mật khẩu...";
            txtRePass.SelectedText = "";
            txtRePass.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtRePass.Size = new Size(240, 26);
            txtRePass.TabIndex = 18;
            // 
            // btnTogglePassReg
            // 
            btnTogglePassReg.BorderRadius = 8;
            btnTogglePassReg.CustomizableEdges = customizableEdges17;
            btnTogglePassReg.FillColor = Color.Transparent;
            btnTogglePassReg.Font = new Font("Segoe UI", 9F);
            btnTogglePassReg.ForeColor = Color.White;
            btnTogglePassReg.Location = new Point(0, 0);
            btnTogglePassReg.Name = "btnTogglePassReg";
            btnTogglePassReg.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnTogglePassReg.Size = new Size(24, 24);
            btnTogglePassReg.TabIndex = 19;
            btnTogglePassReg.Text = "👁";
            btnTogglePassReg.Click += btnTogglePassReg_Click;
            // 
            // btnToggleRePassReg
            // 
            btnToggleRePassReg.BorderRadius = 8;
            btnToggleRePassReg.CustomizableEdges = customizableEdges19;
            btnToggleRePassReg.FillColor = Color.Transparent;
            btnToggleRePassReg.Font = new Font("Segoe UI", 9F);
            btnToggleRePassReg.ForeColor = Color.White;
            btnToggleRePassReg.Location = new Point(0, 0);
            btnToggleRePassReg.Name = "btnToggleRePassReg";
            btnToggleRePassReg.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnToggleRePassReg.Size = new Size(24, 24);
            btnToggleRePassReg.TabIndex = 20;
            btnToggleRePassReg.Text = "👁";
            btnToggleRePassReg.Click += btnToggleRePassReg_Click;
            // 
            // btnRegister
            // 
            btnRegister.BorderRadius = 10;
            btnRegister.CustomizableEdges = customizableEdges21;
            btnRegister.FillColor = Color.FromArgb(0, 120, 215);
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(160, 340);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnRegister.Size = new Size(130, 32);
            btnRegister.TabIndex = 21;
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 10;
            btnCancel.CustomizableEdges = customizableEdges23;
            btnCancel.FillColor = Color.FromArgb(108, 117, 125);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnCancel.Size = new Size(130, 32);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // controlBoxMin
            // 
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            controlBoxMin.CustomizableEdges = customizableEdges27;
            controlBoxMin.FillColor = Color.Transparent;
            controlBoxMin.IconColor = Color.White;
            controlBoxMin.Location = new Point(769, 5);
            controlBoxMin.Name = "controlBoxMin";
            controlBoxMin.ShadowDecoration.CustomizableEdges = customizableEdges28;
            controlBoxMin.Size = new Size(35, 25);
            controlBoxMin.TabIndex = 1;
            // 
            // controlBoxMax
            // 
            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            controlBoxMax.CustomizableEdges = customizableEdges29;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.White;
            controlBoxMax.Location = new Point(810, 5);
            controlBoxMax.Name = "controlBoxMax";
            controlBoxMax.ShadowDecoration.CustomizableEdges = customizableEdges30;
            controlBoxMax.Size = new Size(35, 25);
            controlBoxMax.TabIndex = 2;
            // 
            // controlBoxClose
            // 
            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.CustomizableEdges = customizableEdges31;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.White;
            controlBoxClose.Location = new Point(851, 5);
            controlBoxClose.Name = "controlBoxClose";
            controlBoxClose.ShadowDecoration.CustomizableEdges = customizableEdges32;
            controlBoxClose.Size = new Size(35, 25);
            controlBoxClose.TabIndex = 3;
            // 
            // fRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 34);
            ClientSize = new Size(900, 550);
            Controls.Add(panelRegister);
            Controls.Add(controlBoxMin);
            Controls.Add(controlBoxMax);
            Controls.Add(controlBoxClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            panelRegister.ResumeLayout(false);
            panelRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
