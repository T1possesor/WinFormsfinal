using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

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

        // dòng lỗi dưới nút Đăng ký
        private Guna2HtmlLabel lblRegError;

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
            lblRegError = new Guna2HtmlLabel();
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
            panelRegister.FillColor = Color.FromArgb(240, 240, 240); // xám nhạt giống card login
            panelRegister.Location = new Point(150, 90);
            panelRegister.Name = "panelRegister";
            panelRegister.Size = new Size(600, 420);
            panelRegister.ShadowDecoration.BorderRadius = 20;
            panelRegister.ShadowDecoration.Enabled = true;
            panelRegister.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelRegister.TabIndex = 0;
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
            panelRegister.Controls.Add(lblRegError);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(235, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(108, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng ký";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.ForeColor = Color.Black;
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
            lblNgaySinh.ForeColor = Color.Black;
            lblNgaySinh.Location = new Point(40, 115);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(70, 19);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            lblSoDienThoai.ForeColor = Color.Black;
            lblSoDienThoai.Location = new Point(322, 60);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(89, 19);
            lblSoDienThoai.TabIndex = 3;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(40, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.ForeColor = Color.Black;
            lblDiaChi.Location = new Point(322, 115);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(50, 19);
            lblDiaChi.TabIndex = 5;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Black;
            lblUser.Location = new Point(40, 225);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(66, 19);
            lblUser.TabIndex = 6;
            lblUser.Text = "Tài khoản";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.Black;
            lblPass.Location = new Point(322, 170);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(68, 19);
            lblPass.TabIndex = 7;
            lblPass.Text = "Mật khẩu";
            // 
            // lblRePass
            // 
            lblRePass.AutoSize = true;
            lblRePass.Font = new Font("Segoe UI", 10F);
            lblRePass.ForeColor = Color.Black;
            lblRePass.Location = new Point(322, 225);
            lblRePass.Name = "lblRePass";
            lblRePass.Size = new Size(121, 19);
            lblRePass.TabIndex = 8;
            lblRePass.Text = "Nhập lại mật khẩu";
            // 
            // txtHoTen
            // 
            txtHoTen.BorderRadius = 8;
            txtHoTen.DefaultText = "";
            txtHoTen.FillColor = Color.White;
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.ForeColor = Color.Black;
            txtHoTen.Location = new Point(40, 80);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Nhập họ tên...";
            txtHoTen.SelectedText = "";
            txtHoTen.Size = new Size(240, 26);
            txtHoTen.TabIndex = 10;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.BorderRadius = 8;
            dtpNgaySinh.Checked = true;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.FillColor = Color.White;
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.ForeColor = Color.Black;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(40, 135);
            dtpNgaySinh.MaxDate = new DateTime(9998, 12, 31);
            dtpNgaySinh.MinDate = new DateTime(1753, 1, 1);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(240, 26);
            dtpNgaySinh.TabIndex = 11;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BorderRadius = 8;
            txtSoDienThoai.DefaultText = "";
            txtSoDienThoai.FillColor = Color.White;
            txtSoDienThoai.Font = new Font("Segoe UI", 10F);
            txtSoDienThoai.ForeColor = Color.Black;
            txtSoDienThoai.Location = new Point(322, 80);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại...";
            txtSoDienThoai.SelectedText = "";
            txtSoDienThoai.Size = new Size(240, 26);
            txtSoDienThoai.TabIndex = 12;
            txtSoDienThoai.KeyPress += txtSoDienThoai_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(40, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.SelectedText = "";
            txtEmail.Size = new Size(240, 26);
            txtEmail.TabIndex = 13;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderRadius = 8;
            txtDiaChi.DefaultText = "";
            txtDiaChi.FillColor = Color.White;
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.ForeColor = Color.Black;
            txtDiaChi.Location = new Point(322, 135);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Nhập địa chỉ...";
            txtDiaChi.SelectedText = "";
            txtDiaChi.Size = new Size(240, 26);
            txtDiaChi.TabIndex = 14;
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 8;
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.White;
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(40, 245);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.Size = new Size(240, 26);
            txtUser.TabIndex = 15;
            // 
            // txtPass
            // 
            txtPass.BorderRadius = 8;
            txtPass.DefaultText = "";
            txtPass.FillColor = Color.White;
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.ForeColor = Color.Black;
            txtPass.Location = new Point(322, 190);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Nhập mật khẩu...";
            txtPass.SelectedText = "";
            txtPass.Size = new Size(240, 26);
            txtPass.TabIndex = 16;
            // 
            // txtRePass
            // 
            txtRePass.BorderRadius = 8;
            txtRePass.DefaultText = "";
            txtRePass.FillColor = Color.White;
            txtRePass.Font = new Font("Segoe UI", 10F);
            txtRePass.ForeColor = Color.Black;
            txtRePass.Location = new Point(322, 245);
            txtRePass.Name = "txtRePass";
            txtRePass.PasswordChar = '●';
            txtRePass.PlaceholderText = "Nhập lại mật khẩu...";
            txtRePass.SelectedText = "";
            txtRePass.Size = new Size(240, 26);
            txtRePass.TabIndex = 17;
            // 
            // btnTogglePassReg
            // 
            btnTogglePassReg.BorderRadius = 8;
            btnTogglePassReg.FillColor = Color.White;
            btnTogglePassReg.Font = new Font("Segoe UI", 9F);
            btnTogglePassReg.ForeColor = Color.Black;
            btnTogglePassReg.Location = new Point(322 + 240 - 28, 190);
            btnTogglePassReg.Name = "btnTogglePassReg";
            btnTogglePassReg.Size = new Size(24, 24);
            btnTogglePassReg.TabIndex = 18;
            btnTogglePassReg.Text = "👁";
            btnTogglePassReg.Click += btnTogglePassReg_Click;
            // 
            // btnToggleRePassReg
            // 
            btnToggleRePassReg.BorderRadius = 8;
            btnToggleRePassReg.FillColor = Color.White;
            btnToggleRePassReg.Font = new Font("Segoe UI", 9F);
            btnToggleRePassReg.ForeColor = Color.Black;
            btnToggleRePassReg.Location = new Point(322 + 240 - 28, 245);
            btnToggleRePassReg.Name = "btnToggleRePassReg";
            btnToggleRePassReg.Size = new Size(24, 24);
            btnToggleRePassReg.TabIndex = 19;
            btnToggleRePassReg.Text = "👁";
            btnToggleRePassReg.Click += btnToggleRePassReg_Click;
            // 
            // btnRegister
            // 
            btnRegister.BorderRadius = 10;
            btnRegister.FillColor = Color.FromArgb(0, 120, 215);
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(160, 320);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(130, 32);
            btnRegister.TabIndex = 20;
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 10;
            btnCancel.FillColor = Color.FromArgb(108, 117, 125);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 32);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblRegError
            // 
            lblRegError.BackColor = Color.Transparent;
            lblRegError.ForeColor = Color.FromArgb(255, 114, 118);
            lblRegError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegError.Location = new Point(140, 360);
            lblRegError.Name = "lblRegError";
            lblRegError.Size = new Size(320, 20);
            lblRegError.TabIndex = 22;
            lblRegError.Text = "";
            lblRegError.TextAlignment = ContentAlignment.MiddleCenter;
            lblRegError.AutoSize = false;
            lblRegError.Visible = false;
            // 
            // controlBoxMin
            // 
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = ControlBoxType.MinimizeBox;
            controlBoxMin.FillColor = Color.Transparent;
            controlBoxMin.IconColor = Color.Black;
            controlBoxMin.Location = new Point(769, 5);
            controlBoxMin.Name = "controlBoxMin";
            controlBoxMin.Size = new Size(35, 25);
            controlBoxMin.TabIndex = 1;
            // 
            // controlBoxMax
            // 
            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = ControlBoxType.MaximizeBox;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.Black;
            controlBoxMax.Location = new Point(810, 5);
            controlBoxMax.Name = "controlBoxMax";
            controlBoxMax.Size = new Size(35, 25);
            controlBoxMax.TabIndex = 2;
            // 
            // controlBoxClose
            // 
            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.Black;
            controlBoxClose.Location = new Point(851, 5);
            controlBoxClose.Name = "controlBoxClose";
            controlBoxClose.Size = new Size(35, 25);
            controlBoxClose.TabIndex = 3;
            // 
            // fRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White; // nền trắng giống login
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
