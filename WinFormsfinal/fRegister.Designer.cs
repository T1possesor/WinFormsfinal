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

        // dòng lỗi dưới nút Đăng ký (giữ nguyên)
        private Guna2HtmlLabel lblRegError;

        // ==== 2 label lỗi inline mới ====
        private Guna2HtmlLabel lblEmailInlineErr;
        private Guna2HtmlLabel lblUserInlineErr;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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

            // dòng lỗi chung
            lblRegError = new Guna2HtmlLabel();

            // ===== label lỗi inline =====
            lblEmailInlineErr = new Guna2HtmlLabel();
            lblUserInlineErr  = new Guna2HtmlLabel();

            controlBoxMin = new Guna2ControlBox();
            controlBoxMax = new Guna2ControlBox();
            controlBoxClose = new Guna2ControlBox();

            panelRegister.SuspendLayout();
            SuspendLayout();

            // Borderless
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;

            // panelRegister
            panelRegister.BackColor = Color.Transparent;
            panelRegister.BorderRadius = 20;
            panelRegister.FillColor = Color.FromArgb(240, 240, 240);
            panelRegister.Location = new Point(150, 90);
            panelRegister.Name = "panelRegister";
            panelRegister.Size = new Size(600, 450);
            panelRegister.ShadowDecoration.BorderRadius = 20;
            panelRegister.ShadowDecoration.Enabled = true;
            panelRegister.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelRegister.TabIndex = 0;

            // ===== Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(235, 15);
            lblTitle.Text = "Đăng ký";

            // ===== Left column
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(40, 60);
            lblHoTen.Text = "Họ tên";

            txtHoTen.BorderRadius = 8; txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.FillColor = Color.White; txtHoTen.PlaceholderText = "Nhập họ tên...";
            txtHoTen.Location = new Point(40, 80); txtHoTen.Size = new Size(240, 26);

            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(40, 115);
            lblNgaySinh.Text = "Ngày sinh";

            dtpNgaySinh.BorderRadius = 8; dtpNgaySinh.Checked = true;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.FillColor = Color.White; dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(40, 135);
            dtpNgaySinh.Size = new Size(240, 26);

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(40, 170);
            lblEmail.Text = "Email";

            txtEmail.BorderRadius = 8; txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.FillColor = Color.White; txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.Location = new Point(40, 190); txtEmail.Size = new Size(240, 26);

            // label lỗi inline dưới email
            lblEmailInlineErr.BackColor = Color.Transparent;
            lblEmailInlineErr.ForeColor = Color.FromArgb(255, 114, 118);
            lblEmailInlineErr.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmailInlineErr.AutoSize = false;
            lblEmailInlineErr.Size = new Size(240, 20);
            lblEmailInlineErr.TextAlignment = ContentAlignment.MiddleLeft;
            lblEmailInlineErr.Visible = false;
            // vị trí sẽ set ở runtime

            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.Location = new Point(40, 225);
            lblUser.Text = "Tài khoản";

            txtUser.BorderRadius = 8; txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.FillColor = Color.White; txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.Location = new Point(40, 245); txtUser.Size = new Size(240, 26);

            // label lỗi inline dưới user
            lblUserInlineErr.BackColor = Color.Transparent;
            lblUserInlineErr.ForeColor = Color.FromArgb(255, 114, 118);
            lblUserInlineErr.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserInlineErr.AutoSize = false;
            lblUserInlineErr.Size = new Size(240, 20);
            lblUserInlineErr.TextAlignment = ContentAlignment.MiddleLeft;
            lblUserInlineErr.Visible = false;
            // vị trí sẽ set ở runtime

            // ===== Right column
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            lblSoDienThoai.Location = new Point(322, 60);
            lblSoDienThoai.Text = "Số điện thoại";

            txtSoDienThoai.BorderRadius = 8; txtSoDienThoai.Font = new Font("Segoe UI", 10F);
            txtSoDienThoai.FillColor = Color.White; txtSoDienThoai.PlaceholderText = "Nhập số điện thoại...";
            txtSoDienThoai.Location = new Point(322, 80); txtSoDienThoai.Size = new Size(240, 26);
            txtSoDienThoai.KeyPress += txtSoDienThoai_KeyPress;

            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(322, 115);
            lblDiaChi.Text = "Địa chỉ";

            txtDiaChi.BorderRadius = 8; txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.FillColor = Color.White; txtDiaChi.PlaceholderText = "Nhập địa chỉ...";
            txtDiaChi.Location = new Point(322, 135); txtDiaChi.Size = new Size(240, 26);

            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.Location = new Point(322, 170);
            lblPass.Text = "Mật khẩu";

            txtPass.BorderRadius = 8; txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.FillColor = Color.White; txtPass.PlaceholderText = "Nhập mật khẩu...";
            txtPass.Location = new Point(322, 190); txtPass.Size = new Size(240, 26);
            txtPass.PasswordChar = '●';

            btnTogglePassReg.BorderRadius = 8;
            btnTogglePassReg.FillColor = Color.White;
            btnTogglePassReg.Font = new Font("Segoe UI", 9F);
            btnTogglePassReg.ForeColor = Color.Black;
            btnTogglePassReg.Size = new Size(24, 24);
            btnTogglePassReg.Location = new Point(322 + 240 - 28, 190);
            btnTogglePassReg.Text = "👁";
            btnTogglePassReg.Click += btnTogglePassReg_Click;

            lblRePass.AutoSize = true;
            lblRePass.Font = new Font("Segoe UI", 10F);
            lblRePass.Location = new Point(322, 225);
            lblRePass.Text = "Nhập lại mật khẩu";

            txtRePass.BorderRadius = 8; txtRePass.Font = new Font("Segoe UI", 10F);
            txtRePass.FillColor = Color.White; txtRePass.PlaceholderText = "Nhập lại mật khẩu...";
            txtRePass.Location = new Point(322, 245); txtRePass.Size = new Size(240, 26);
            txtRePass.PasswordChar = '●';

            btnToggleRePassReg.BorderRadius = 8;
            btnToggleRePassReg.FillColor = Color.White;
            btnToggleRePassReg.Font = new Font("Segoe UI", 9F);
            btnToggleRePassReg.ForeColor = Color.Black;
            btnToggleRePassReg.Size = new Size(24, 24);
            btnToggleRePassReg.Location = new Point(322 + 240 - 28, 245);
            btnToggleRePassReg.Text = "👁";
            btnToggleRePassReg.Click += btnToggleRePassReg_Click;

            // Buttons + error
            btnRegister.BorderRadius = 10;
            btnRegister.FillColor = Color.FromArgb(0, 120, 215);
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(160, 330);
            btnRegister.Size = new Size(130, 32);
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;

            btnCancel.BorderRadius = 10;
            btnCancel.FillColor = Color.FromArgb(108, 117, 125);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 330);
            btnCancel.Size = new Size(130, 32);
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;

            lblRegError.BackColor = Color.Transparent;
            lblRegError.ForeColor = Color.FromArgb(255, 114, 118);
            lblRegError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegError.Location = new Point(140, 370);
            lblRegError.AutoSize = false;
            lblRegError.Size = new Size(320, 20);
            lblRegError.Text = "";
            lblRegError.TextAlignment = ContentAlignment.MiddleCenter;
            lblRegError.Visible = false;

            // Control boxes
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = ControlBoxType.MinimizeBox;
            controlBoxMin.FillColor = Color.Transparent;
            controlBoxMin.IconColor = Color.Black;
            controlBoxMin.Location = new Point(769, 5); controlBoxMin.Size = new Size(35, 25);

            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = ControlBoxType.MaximizeBox;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.Black;
            controlBoxMax.Location = new Point(810, 5); controlBoxMax.Size = new Size(35, 25);

            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.Black;
            controlBoxClose.Location = new Point(851, 5); controlBoxClose.Size = new Size(35, 25);

            // add controls to panel
            panelRegister.Controls.Add(lblTitle);

            panelRegister.Controls.Add(lblHoTen);
            panelRegister.Controls.Add(txtHoTen);
            panelRegister.Controls.Add(lblNgaySinh);
            panelRegister.Controls.Add(dtpNgaySinh);
            panelRegister.Controls.Add(lblEmail);
            panelRegister.Controls.Add(txtEmail);
            panelRegister.Controls.Add(lblEmailInlineErr);   // << thêm
            panelRegister.Controls.Add(lblUser);
            panelRegister.Controls.Add(txtUser);
            panelRegister.Controls.Add(lblUserInlineErr);    // << thêm

            panelRegister.Controls.Add(lblSoDienThoai);
            panelRegister.Controls.Add(txtSoDienThoai);
            panelRegister.Controls.Add(lblDiaChi);
            panelRegister.Controls.Add(txtDiaChi);
            panelRegister.Controls.Add(lblPass);
            panelRegister.Controls.Add(txtPass);
            panelRegister.Controls.Add(btnTogglePassReg);
            panelRegister.Controls.Add(lblRePass);
            panelRegister.Controls.Add(txtRePass);
            panelRegister.Controls.Add(btnToggleRePassReg);

            panelRegister.Controls.Add(btnRegister);
            panelRegister.Controls.Add(btnCancel);
            panelRegister.Controls.Add(lblRegError);

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
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
