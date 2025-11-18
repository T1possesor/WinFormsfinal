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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            panelForgot.Controls.Add(lblTitle);
            panelForgot.Controls.Add(lblUser);
            panelForgot.Controls.Add(lblEmail);
            panelForgot.Controls.Add(lblNewPass);
            panelForgot.Controls.Add(lblReNewPass);
            panelForgot.Controls.Add(txtUser);
            panelForgot.Controls.Add(txtEmail);
            panelForgot.Controls.Add(txtNewPass);
            panelForgot.Controls.Add(txtReNewPass);
            panelForgot.Controls.Add(btnChange);
            panelForgot.Controls.Add(btnCancel);
            panelForgot.CustomizableEdges = customizableEdges13;
            panelForgot.FillColor = Color.FromArgb(30, 33, 40);
            panelForgot.Location = new Point(250, 140);
            panelForgot.Name = "panelForgot";
            panelForgot.ShadowDecoration.BorderRadius = 20;
            panelForgot.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelForgot.ShadowDecoration.Enabled = true;
            panelForgot.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            panelForgot.Size = new Size(400, 266);
            panelForgot.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(120, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quên mật khẩu";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Gainsboro;
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
            lblEmail.ForeColor = Color.Gainsboro;
            lblEmail.Location = new Point(40, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 10F);
            lblNewPass.ForeColor = Color.Gainsboro;
            lblNewPass.Location = new Point(40, 150);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(95, 19);
            lblNewPass.TabIndex = 3;
            lblNewPass.Text = "Mật khẩu mới";
            // 
            // lblReNewPass
            // 
            lblReNewPass.AutoSize = true;
            lblReNewPass.Font = new Font("Segoe UI", 10F);
            lblReNewPass.ForeColor = Color.Gainsboro;
            lblReNewPass.Location = new Point(40, 195);
            lblReNewPass.Name = "lblReNewPass";
            lblReNewPass.Size = new Size(121, 19);
            lblReNewPass.TabIndex = 4;
            lblReNewPass.Text = "Nhập lại mật khẩu";
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 8;
            txtUser.CustomizableEdges = customizableEdges1;
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.FromArgb(33, 38, 45);
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(170, 57);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUser.Size = new Size(190, 24);
            txtUser.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = Color.FromArgb(33, 38, 45);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(170, 102);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(190, 24);
            txtEmail.TabIndex = 6;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderRadius = 8;
            txtNewPass.CustomizableEdges = customizableEdges5;
            txtNewPass.DefaultText = "";
            txtNewPass.FillColor = Color.FromArgb(33, 38, 45);
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.Location = new Point(170, 147);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderText = "Mật khẩu mới...";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPass.Size = new Size(190, 24);
            txtNewPass.TabIndex = 7;
            // 
            // txtReNewPass
            // 
            txtReNewPass.BorderRadius = 8;
            txtReNewPass.CustomizableEdges = customizableEdges7;
            txtReNewPass.DefaultText = "";
            txtReNewPass.FillColor = Color.FromArgb(33, 38, 45);
            txtReNewPass.Font = new Font("Segoe UI", 10F);
            txtReNewPass.ForeColor = Color.White;
            txtReNewPass.Location = new Point(170, 192);
            txtReNewPass.Name = "txtReNewPass";
            txtReNewPass.PasswordChar = '●';
            txtReNewPass.PlaceholderText = "Nhập lại mật khẩu...";
            txtReNewPass.SelectedText = "";
            txtReNewPass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtReNewPass.Size = new Size(190, 24);
            txtReNewPass.TabIndex = 8;
            // 
            // btnChange
            // 
            btnChange.BorderRadius = 10;
            btnChange.CustomizableEdges = customizableEdges9;
            btnChange.FillColor = Color.FromArgb(0, 120, 215);
            btnChange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(70, 225);
            btnChange.Name = "btnChange";
            btnChange.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnChange.Size = new Size(120, 30);
            btnChange.TabIndex = 9;
            btnChange.Text = "Đổi mật khẩu";
            btnChange.Click += btnChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 10;
            btnCancel.CustomizableEdges = customizableEdges11;
            btnCancel.FillColor = Color.FromArgb(108, 117, 125);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(210, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // controlBoxMin
            // 
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            controlBoxMin.CustomizableEdges = customizableEdges15;
            controlBoxMin.FillColor = Color.Transparent;
            controlBoxMin.IconColor = Color.White;
            controlBoxMin.Location = new Point(769, 5);
            controlBoxMin.Name = "controlBoxMin";
            controlBoxMin.ShadowDecoration.CustomizableEdges = customizableEdges16;
            controlBoxMin.Size = new Size(35, 25);
            controlBoxMin.TabIndex = 1;
            // 
            // controlBoxMax
            // 
            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            controlBoxMax.CustomizableEdges = customizableEdges17;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.White;
            controlBoxMax.Location = new Point(810, 5);
            controlBoxMax.Name = "controlBoxMax";
            controlBoxMax.ShadowDecoration.CustomizableEdges = customizableEdges18;
            controlBoxMax.Size = new Size(35, 25);
            controlBoxMax.TabIndex = 2;
            // 
            // controlBoxClose
            // 
            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.CustomizableEdges = customizableEdges19;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.White;
            controlBoxClose.Location = new Point(851, 5);
            controlBoxClose.Name = "controlBoxClose";
            controlBoxClose.ShadowDecoration.CustomizableEdges = customizableEdges20;
            controlBoxClose.Size = new Size(35, 25);
            controlBoxClose.TabIndex = 3;
            // 
            // fForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 34);
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
