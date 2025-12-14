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
            if (disposing && (components != null)) components.Dispose();
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
            lblForgotError = new Guna2HtmlLabel();
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
            panelForgot.Controls.Add(lblForgotError);
            panelForgot.Controls.Add(btnChange);
            panelForgot.Controls.Add(btnCancel);
            panelForgot.CustomizableEdges = customizableEdges13;
            panelForgot.FillColor = Color.FromArgb(240, 240, 240);
            panelForgot.Location = new Point(357, 200);
            panelForgot.Margin = new Padding(4, 5, 4, 5);
            panelForgot.Name = "panelForgot";
            panelForgot.ShadowDecoration.BorderRadius = 20;
            panelForgot.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelForgot.ShadowDecoration.Enabled = true;
            panelForgot.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelForgot.Size = new Size(571, 517);
            panelForgot.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(164, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quên mật khẩu";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Black;
            lblUser.Location = new Point(57, 100);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 28);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tài khoản";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(57, 167);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 28);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 10F);
            lblNewPass.ForeColor = Color.Black;
            lblNewPass.Location = new Point(57, 233);
            lblNewPass.Margin = new Padding(4, 0, 4, 0);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(133, 28);
            lblNewPass.TabIndex = 3;
            lblNewPass.Text = "Mật khẩu mới";
            // 
            // lblReNewPass
            // 
            lblReNewPass.AutoSize = true;
            lblReNewPass.Font = new Font("Segoe UI", 10F);
            lblReNewPass.ForeColor = Color.Black;
            lblReNewPass.Location = new Point(57, 300);
            lblReNewPass.Margin = new Padding(4, 0, 4, 0);
            lblReNewPass.Name = "lblReNewPass";
            lblReNewPass.Size = new Size(171, 28);
            lblReNewPass.TabIndex = 4;
            lblReNewPass.Text = "Nhập lại mật khẩu";
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 8;
            txtUser.CustomizableEdges = customizableEdges1;
            txtUser.DefaultText = "";
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(243, 97);
            txtUser.Margin = new Padding(6, 8, 6, 8);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUser.Size = new Size(271, 43);
            txtUser.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(243, 163);
            txtEmail.Margin = new Padding(6, 8, 6, 8);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(271, 43);
            txtEmail.TabIndex = 6;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderRadius = 8;
            txtNewPass.CustomizableEdges = customizableEdges5;
            txtNewPass.DefaultText = "";
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.Black;
            txtNewPass.Location = new Point(243, 230);
            txtNewPass.Margin = new Padding(6, 8, 6, 8);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderText = "Mật khẩu mới...";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPass.Size = new Size(271, 43);
            txtNewPass.TabIndex = 7;
            // 
            // txtReNewPass
            // 
            txtReNewPass.BorderRadius = 8;
            txtReNewPass.CustomizableEdges = customizableEdges7;
            txtReNewPass.DefaultText = "";
            txtReNewPass.Font = new Font("Segoe UI", 10F);
            txtReNewPass.ForeColor = Color.Black;
            txtReNewPass.Location = new Point(243, 297);
            txtReNewPass.Margin = new Padding(6, 8, 6, 8);
            txtReNewPass.Name = "txtReNewPass";
            txtReNewPass.PasswordChar = '●';
            txtReNewPass.PlaceholderText = "Nhập lại mật khẩu...";
            txtReNewPass.SelectedText = "";
            txtReNewPass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtReNewPass.Size = new Size(271, 43);
            txtReNewPass.TabIndex = 8;
            // 
            // lblForgotError
            // 
            lblForgotError.AutoSize = false;
            lblForgotError.BackColor = Color.Transparent;
            lblForgotError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblForgotError.ForeColor = Color.FromArgb(255, 80, 80);
            lblForgotError.Location = new Point(243, 350);
            lblForgotError.Margin = new Padding(4, 5, 4, 5);
            lblForgotError.Name = "lblForgotError";
            lblForgotError.Size = new Size(4, 3);
            lblForgotError.TabIndex = 11;
            lblForgotError.TextAlignment = ContentAlignment.MiddleCenter;
            lblForgotError.Visible = false;
            // 
            // btnChange
            // 
            btnChange.BorderRadius = 10;
            btnChange.CustomizableEdges = customizableEdges9;
            btnChange.FillColor = Color.FromArgb(0, 120, 215);
            btnChange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(100, 400);
            btnChange.Margin = new Padding(4, 5, 4, 5);
            btnChange.Name = "btnChange";
            btnChange.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnChange.Size = new Size(171, 50);
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
            btnCancel.Location = new Point(300, 400);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnCancel.Size = new Size(171, 50);
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
            controlBoxMin.IconColor = Color.Black;
            controlBoxMin.Location = new Point(1099, 8);
            controlBoxMin.Margin = new Padding(4, 5, 4, 5);
            controlBoxMin.Name = "controlBoxMin";
            controlBoxMin.ShadowDecoration.CustomizableEdges = customizableEdges16;
            controlBoxMin.Size = new Size(50, 42);
            controlBoxMin.TabIndex = 1;
            // 
            // controlBoxMax
            // 
            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            controlBoxMax.CustomizableEdges = customizableEdges17;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.Black;
            controlBoxMax.Location = new Point(1157, 8);
            controlBoxMax.Margin = new Padding(4, 5, 4, 5);
            controlBoxMax.Name = "controlBoxMax";
            controlBoxMax.ShadowDecoration.CustomizableEdges = customizableEdges18;
            controlBoxMax.Size = new Size(50, 42);
            controlBoxMax.TabIndex = 2;
            // 
            // controlBoxClose
            // 
            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.CustomizableEdges = customizableEdges19;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.Black;
            controlBoxClose.Location = new Point(1216, 8);
            controlBoxClose.Margin = new Padding(4, 5, 4, 5);
            controlBoxClose.Name = "controlBoxClose";
            controlBoxClose.ShadowDecoration.CustomizableEdges = customizableEdges20;
            controlBoxClose.Size = new Size(50, 42);
            controlBoxClose.TabIndex = 3;
            // 
            // fForgotPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1286, 917);
            Controls.Add(panelForgot);
            Controls.Add(controlBoxMin);
            Controls.Add(controlBoxMax);
            Controls.Add(controlBoxClose);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
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
