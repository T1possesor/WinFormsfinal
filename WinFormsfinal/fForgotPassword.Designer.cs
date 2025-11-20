using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fForgotPassword
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelForgot;

        private Label lblTitle;
        private Label lblUser;
        private Label lblEmail;
        private Label lblNewPass;
        private Label lblReNewPass;

        private Guna2TextBox txtUser;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtNewPass;
        private Guna2TextBox txtReNewPass;

        private Guna2Button btnChange;
        private Guna2Button btnCancel;

        private Guna2ControlBox controlBoxMin;
        private Guna2ControlBox controlBoxMax;
        private Guna2ControlBox controlBoxClose;

        private Guna2HtmlLabel lblForgotError;

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
            panelForgot = new Guna2Panel();
            lblTitle = new Label();
            lblUser = new Label();
            lblEmail = new Label();
            lblNewPass = new Label();
            lblReNewPass = new Label();
            txtUser = new Guna2TextBox();
            txtEmail = new Guna2TextBox();
            txtNewPass = new Guna2TextBox();
            txtReNewPass = new Guna2TextBox();
            btnChange = new Guna2Button();
            btnCancel = new Guna2Button();
            lblForgotError = new Guna2HtmlLabel();
            controlBoxMin = new Guna2ControlBox();
            controlBoxMax = new Guna2ControlBox();
            controlBoxClose = new Guna2ControlBox();
            panelForgot.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelForgot
            // 
            panelForgot.BackColor = Color.Transparent;
            panelForgot.BorderRadius = 20;
            panelForgot.FillColor = Color.FromArgb(240, 240, 240);
            panelForgot.Location = new Point(250, 120);
            panelForgot.Name = "panelForgot";
            panelForgot.ShadowDecoration.BorderRadius = 20;
            panelForgot.ShadowDecoration.Enabled = true;
            panelForgot.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelForgot.Size = new Size(400, 310);
            panelForgot.TabIndex = 0;
            panelForgot.Controls.Add(lblTitle);
            panelForgot.Controls.Add(lblUser);
            panelForgot.Controls.Add(lblEmail);
            panelForgot.Controls.Add(lblNewPass);
            panelForgot.Controls.Add(lblReNewPass);
            panelForgot.Controls.Add(txtUser);
            panelForgot.Controls.Add(txtEmail);
            panelForgot.Controls.Add(txtNewPass);
            panelForgot.Controls.Add(txtReNewPass);
            panelForgot.Controls.Add(lblForgotError);
            panelForgot.Controls.Add(btnChange);
            panelForgot.Controls.Add(btnCancel);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(115, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quên mật khẩu";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Black;
            lblUser.Location = new Point(40, 60);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(66, 19);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tài khoản";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(40, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 10F);
            lblNewPass.ForeColor = Color.Black;
            lblNewPass.Location = new Point(40, 140);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(95, 19);
            lblNewPass.TabIndex = 3;
            lblNewPass.Text = "Mật khẩu mới";
            // 
            // lblReNewPass
            // 
            lblReNewPass.AutoSize = true;
            lblReNewPass.Font = new Font("Segoe UI", 10F);
            lblReNewPass.ForeColor = Color.Black;
            lblReNewPass.Location = new Point(40, 180);
            lblReNewPass.Name = "lblReNewPass";
            lblReNewPass.Size = new Size(121, 19);
            lblReNewPass.TabIndex = 4;
            lblReNewPass.Text = "Nhập lại mật khẩu";
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 8;
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.White;
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(170, 58);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.Size = new Size(190, 26);
            txtUser.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(170, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.SelectedText = "";
            txtEmail.Size = new Size(190, 26);
            txtEmail.TabIndex = 6;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderRadius = 8;
            txtNewPass.DefaultText = "";
            txtNewPass.FillColor = Color.White;
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.Black;
            txtNewPass.Location = new Point(170, 138);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderText = "Mật khẩu mới...";
            txtNewPass.SelectedText = "";
            txtNewPass.Size = new Size(190, 26);
            txtNewPass.TabIndex = 7;
            // 
            // txtReNewPass
            // 
            txtReNewPass.BorderRadius = 8;
            txtReNewPass.DefaultText = "";
            txtReNewPass.FillColor = Color.White;
            txtReNewPass.Font = new Font("Segoe UI", 10F);
            txtReNewPass.ForeColor = Color.Black;
            txtReNewPass.Location = new Point(170, 178);
            txtReNewPass.Name = "txtReNewPass";
            txtReNewPass.PasswordChar = '●';
            txtReNewPass.PlaceholderText = "Nhập lại mật khẩu...";
            txtReNewPass.SelectedText = "";
            txtReNewPass.Size = new Size(190, 26);
            txtReNewPass.TabIndex = 8;
            // 
            // lblForgotError
            // 
            lblForgotError.BackColor = Color.Transparent;
            lblForgotError.ForeColor = Color.FromArgb(255, 80, 80);
            lblForgotError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblForgotError.Location = new Point(170, 210); // vị trí tạm, sẽ override trong code
            lblForgotError.Name = "lblForgotError";
            lblForgotError.Size = new Size(190, 26);
            lblForgotError.TabIndex = 11;
            lblForgotError.Text = "";
            lblForgotError.TextAlignment = ContentAlignment.MiddleCenter;
            lblForgotError.AutoSize = false;
            lblForgotError.Visible = false;
            // 
            // btnChange
            // 
            btnChange.BorderRadius = 10;
            btnChange.FillColor = Color.FromArgb(0, 120, 215);
            btnChange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(70, 240);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(120, 30);
            btnChange.TabIndex = 9;
            btnChange.Text = "Đổi mật khẩu";
            btnChange.Click += btnChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 10;
            btnCancel.FillColor = Color.FromArgb(108, 117, 125);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(210, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // controlBoxMin
            // 
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
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
            controlBoxMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
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
            // fForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 550);
            Controls.Add(panelForgot);
            Controls.Add(controlBoxMin);
            Controls.Add(controlBoxMax);
            Controls.Add(controlBoxClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu";
            panelForgot.ResumeLayout(false);
            panelForgot.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
