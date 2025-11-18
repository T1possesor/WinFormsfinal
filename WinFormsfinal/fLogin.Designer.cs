using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;
using Guna.UI2.WinForms.Enums;
using System;

namespace WinFormsfinal
{
    partial class fLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            guna2BorderlessForm1 = new Guna2BorderlessForm(components);
            panelLogin = new Guna2Panel();
            lblTitle = new Label();
            lblUser = new Label();
            txtUser = new Guna2TextBox();
            lblPass = new Label();
            btnTogglePass = new Guna2Button();
            txtPass = new Guna2TextBox();
            btnLogin = new Guna2Button();
            btnRegister = new Guna2Button();
            btnForgot = new Guna2Button();
            controlBoxMin = new Guna2ControlBox();
            controlBoxMax = new Guna2ControlBox();
            controlBoxClose = new Guna2ControlBox();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.Transparent;
            panelLogin.BorderRadius = 20;
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Controls.Add(lblUser);
            panelLogin.Controls.Add(txtUser);
            panelLogin.Controls.Add(lblPass);
            panelLogin.Controls.Add(btnTogglePass);
            panelLogin.Controls.Add(txtPass);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(btnRegister);
            panelLogin.Controls.Add(btnForgot);
            panelLogin.CustomizableEdges = customizableEdges13;
            panelLogin.FillColor = Color.FromArgb(30, 33, 40);
            panelLogin.Location = new Point(214, 131);
            panelLogin.Name = "panelLogin";
            panelLogin.ShadowDecoration.BorderRadius = 20;
            panelLogin.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelLogin.ShadowDecoration.Depth = 10;
            panelLogin.ShadowDecoration.Enabled = true;
            panelLogin.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            panelLogin.Size = new Size(430, 270);
            panelLogin.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(140, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(139, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.Gainsboro;
            lblUser.Location = new Point(61, 71);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(66, 19);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tài khoản";
            // 
            // txtUser
            // 
            txtUser.BorderRadius = 10;
            txtUser.CustomizableEdges = customizableEdges1;
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.FromArgb(33, 38, 45);
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(61, 90);
            txtUser.Margin = new Padding(3, 2, 3, 2);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.SelectedText = "";
            txtUser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUser.Size = new Size(315, 27);
            txtUser.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.Gainsboro;
            lblPass.Location = new Point(61, 125);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(68, 19);
            lblPass.TabIndex = 3;
            lblPass.Text = "Mật khẩu";
            lblPass.Click += lblPass_Click;
            // 
            // btnTogglePass
            // 
            btnTogglePass.BorderRadius = 10;
            btnTogglePass.CustomizableEdges = customizableEdges3;
            btnTogglePass.FillColor = Color.FromArgb(33, 38, 45);
            btnTogglePass.Font = new Font("Segoe UI", 9F);
            btnTogglePass.ForeColor = Color.White;
            btnTogglePass.HoverState.FillColor = Color.FromArgb(40, 45, 55);
            btnTogglePass.Location = new Point(341, 146);
            btnTogglePass.Margin = new Padding(0);
            btnTogglePass.Name = "btnTogglePass";
            btnTogglePass.PressedColor = Color.FromArgb(50, 50, 60);
            btnTogglePass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTogglePass.Size = new Size(35, 27);
            btnTogglePass.TabIndex = 5;
            btnTogglePass.Text = "👁";
            btnTogglePass.Click += btnTogglePass_Click;
            // 
            // txtPass
            // 
            txtPass.BorderRadius = 10;
            txtPass.CustomizableEdges = customizableEdges5;
            txtPass.DefaultText = "";
            txtPass.FillColor = Color.FromArgb(33, 38, 45);
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.ForeColor = Color.White;
            txtPass.Location = new Point(61, 146);
            txtPass.Margin = new Padding(3, 2, 3, 2);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Nhập mật khẩu...";
            txtPass.SelectedText = "";
            txtPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPass.Size = new Size(315, 27);
            txtPass.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 12;
            btnLogin.CustomizableEdges = customizableEdges7;
            btnLogin.FillColor = Color.FromArgb(0, 120, 215);
            btnLogin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(61, 188);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLogin.Size = new Size(315, 30);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BorderRadius = 10;
            btnRegister.CustomizableEdges = customizableEdges9;
            btnRegister.FillColor = Color.FromArgb(40, 167, 69);
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(61, 225);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRegister.Size = new Size(144, 26);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnForgot
            // 
            btnForgot.BorderRadius = 10;
            btnForgot.CustomizableEdges = customizableEdges11;
            btnForgot.FillColor = Color.FromArgb(108, 117, 125);
            btnForgot.Font = new Font("Segoe UI", 9F);
            btnForgot.ForeColor = Color.White;
            btnForgot.Location = new Point(232, 225);
            btnForgot.Margin = new Padding(3, 2, 3, 2);
            btnForgot.Name = "btnForgot";
            btnForgot.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnForgot.Size = new Size(144, 26);
            btnForgot.TabIndex = 7;
            btnForgot.Text = "Quên mật khẩu";
            btnForgot.Click += btnForgot_Click;
            // 
            // controlBoxMin
            // 
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = ControlBoxType.MinimizeBox;
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
            controlBoxMax.ControlBoxType = ControlBoxType.MaximizeBox;
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
            controlBoxClose.ShadowDecoration.CustomizableEdges = customizableEdges3;
            controlBoxClose.Size = new Size(35, 25);
            controlBoxClose.TabIndex = 3;
            // 
            // fLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 34);
            ClientSize = new Size(900, 550);
            Controls.Add(panelLogin);
            Controls.Add(controlBoxMin);
            Controls.Add(controlBoxMax);
            Controls.Add(controlBoxClose);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "fLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelLogin;
        private Label lblTitle;
        private Label lblUser;
        private Label lblPass;
        private Guna2TextBox txtUser;
        private Guna2TextBox txtPass;
        private Guna2Button btnTogglePass;
        private Guna2Button btnLogin;
        private Guna2Button btnRegister;
        private Guna2Button btnForgot;

        // 3 nút điều khiển Guna2
        private Guna2ControlBox controlBoxMin;
        private Guna2ControlBox controlBoxMax;
        private Guna2ControlBox controlBoxClose;
    }
}
