using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;
using Guna.UI2.WinForms.Enums;
using System;

namespace WinFormsfinal
{
    partial class fLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // KHÔNG dùng target-typed new() để Designer parse ổn
            Guna.UI2.WinForms.Suite.CustomizableEdges ceA = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ceB = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges ce17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            guna2BorderlessForm1 = new Guna2BorderlessForm(components);

            // Card
            panelLogin       = new Guna2Panel();

            // A) Chọn vai trò
            panelRoleInline  = new Guna2Panel();
            btnRoleAdmin     = new Guna2Button();
            btnRoleCustomer  = new Guna2Button();
            lblChoose        = new Label();

            // B) Form login
            panelLoginFields = new Guna2Panel();
            btnBack          = new Guna2Button();
            lblTitle         = new Label();
            lblUser          = new Label();
            txtUser          = new Guna2TextBox();
            lblPass          = new Label();
            txtPass          = new Guna2TextBox();
            btnTogglePass    = new Guna2Button();
            btnLogin         = new Guna2Button();
            lblAuthError     = new Guna2HtmlLabel();
            btnRegister      = new Guna2Button();
            btnForgot        = new Guna2Button();

            // Control boxes
            controlBoxMin    = new Guna2ControlBox();
            controlBoxMax    = new Guna2ControlBox();
            controlBoxClose  = new Guna2ControlBox();

            SuspendLayout();

            // ===== Borderless =====
            guna2BorderlessForm1.BorderRadius = 16;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;

            // ===== Card =====
            panelLogin.BackColor = Color.Transparent;
            panelLogin.BorderRadius = 18;
            panelLogin.CustomizableEdges = ceA;
            panelLogin.FillColor = Color.FromArgb(238, 240, 243); // xám nhạt
            panelLogin.Location = new Point(235, 135);
            panelLogin.Name = "panelLogin";
            panelLogin.ShadowDecoration.BorderRadius = 18;
            panelLogin.ShadowDecoration.CustomizableEdges = ceB;
            panelLogin.ShadowDecoration.Depth = 12;
            panelLogin.ShadowDecoration.Enabled = true;
            panelLogin.ShadowDecoration.Shadow = new Padding(0, 0, 8, 8);
            panelLogin.Size = new Size(430, 310);
            panelLogin.TabIndex = 0;

            // ===== A) panelRoleInline =====
            panelRoleInline.Dock = DockStyle.Fill;
            panelRoleInline.FillColor = Color.Transparent;
            panelRoleInline.Name = "panelRoleInline";

            lblChoose.AutoSize = false;
            lblChoose.Dock = DockStyle.Top;
            lblChoose.Height = 64;
            lblChoose.TextAlign = ContentAlignment.MiddleCenter;
            lblChoose.Text = "Chọn phương thức đăng nhập";
            lblChoose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChoose.ForeColor = Color.FromArgb(33, 37, 41);

            btnRoleAdmin.BorderRadius = 10;
            btnRoleAdmin.CustomizableEdges = ce1;
            btnRoleAdmin.FillColor = Color.FromArgb(42, 167, 69);
            btnRoleAdmin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRoleAdmin.ForeColor = Color.White;
            btnRoleAdmin.Size = new Size(360, 50);
            btnRoleAdmin.Location = new Point(35, 95);
            btnRoleAdmin.Text = "Admin đăng nhập";
            btnRoleAdmin.Click += btnRoleAdmin_Click;

            btnRoleCustomer.BorderRadius = 10;
            btnRoleCustomer.CustomizableEdges = ce2;
            btnRoleCustomer.FillColor = Color.FromArgb(200, 69, 28);
            btnRoleCustomer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRoleCustomer.ForeColor = Color.White;
            btnRoleCustomer.Size = new Size(360, 50);
            btnRoleCustomer.Location = new Point(35, 155);
            btnRoleCustomer.Text = "Khách hàng đăng nhập";
            btnRoleCustomer.Click += btnRoleCustomer_Click;

            panelRoleInline.Controls.Add(btnRoleCustomer);
            panelRoleInline.Controls.Add(btnRoleAdmin);
            panelRoleInline.Controls.Add(lblChoose);

            // ===== B) panelLoginFields =====
            panelLoginFields.Dock = DockStyle.Fill;
            panelLoginFields.FillColor = Color.Transparent;
            panelLoginFields.Visible = false;

            // btnBack
            btnBack.BorderRadius = 8;
            btnBack.CustomizableEdges = ce3;

            // ĐỔI THÀNH STYLE NÀY:
            btnBack.FillColor = Color.White;
            btnBack.ForeColor = Color.Black;
            btnBack.BorderColor = Color.FromArgb(200, 200, 200);
            btnBack.BorderThickness = 1;
            btnBack.HoverState.FillColor = Color.FromArgb(245, 245, 245);
            btnBack.HoverState.BorderColor = Color.FromArgb(180, 180, 180);

            // GIỮ NGUYÊN MẤY DÒNG CÒN LẠI
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.Size = new Size(100, 28);
            btnBack.Location = new Point(12, 12);
            btnBack.Text = "← Quay lại";
            btnBack.Click += btnBack_Click;


            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(110, 12);
            lblTitle.Text = "Đăng nhập";

            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.FromArgb(73, 80, 87);
            lblUser.Location = new Point(61, 66);
            lblUser.Text = "Tài khoản";

            txtUser.BorderRadius = 10;
            txtUser.CustomizableEdges = ce4;
            txtUser.FillColor = Color.FromArgb(250, 250, 250);
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(61, 86);
            txtUser.PlaceholderText = "Nhập tài khoản...";
            txtUser.ShadowDecoration.CustomizableEdges = ce5;
            txtUser.Size = new Size(315, 30);

            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.FromArgb(73, 80, 87);
            lblPass.Location = new Point(61, 126);
            lblPass.Text = "Mật khẩu";
            lblPass.Click += lblPass_Click;

            txtPass.BorderRadius = 10;
            txtPass.CustomizableEdges = ce6;
            txtPass.FillColor = Color.FromArgb(250, 250, 250);
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.ForeColor = Color.Black;
            txtPass.Location = new Point(61, 146);
            txtPass.PasswordChar = '●';
            txtPass.PlaceholderText = "Nhập mật khẩu...";
            txtPass.ShadowDecoration.CustomizableEdges = ce7;
            txtPass.Size = new Size(315, 30);

            btnTogglePass.BorderRadius = 10;
            btnTogglePass.CustomizableEdges = ce8;
            btnTogglePass.FillColor = Color.FromArgb(250, 250, 250);
            btnTogglePass.Font = new Font("Segoe UI", 9F);
            btnTogglePass.ForeColor = Color.Black;
            btnTogglePass.HoverState.FillColor = Color.FromArgb(240, 240, 240);
            btnTogglePass.Location = new Point(341, 146);
            btnTogglePass.Name = "btnTogglePass";
            btnTogglePass.PressedColor = Color.FromArgb(230, 230, 230);
            btnTogglePass.ShadowDecoration.CustomizableEdges = ce9;
            btnTogglePass.Size = new Size(35, 30);
            btnTogglePass.Text = "👁";
            btnTogglePass.Click += btnTogglePass_Click;

            btnLogin.BorderRadius = 12;
            btnLogin.CustomizableEdges = ce10;
            btnLogin.FillColor = Color.FromArgb(0, 123, 255);
            btnLogin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(61, 190);
            btnLogin.ShadowDecoration.CustomizableEdges = ce11;
            btnLogin.Size = new Size(315, 34);
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;

            // dòng lỗi
            lblAuthError.BackColor = Color.Transparent;
            lblAuthError.ForeColor = Color.FromArgb(220, 53, 69); // đỏ
            lblAuthError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAuthError.AutoSize = false;
            lblAuthError.TextAlignment = ContentAlignment.MiddleCenter;
            lblAuthError.Size = new Size(315, 30);
            lblAuthError.Location = new Point(61, 232); // sẽ được canh lại ở code-behind
            lblAuthError.Visible = false;
            lblAuthError.Text = "";

            btnRegister.BorderRadius = 10;
            btnRegister.CustomizableEdges = ce12;
            btnRegister.FillColor = Color.FromArgb(40, 167, 69);
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(61, 232);
            btnRegister.ShadowDecoration.CustomizableEdges = ce13;
            btnRegister.Size = new Size(144, 28);
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;

            btnForgot.BorderRadius = 10;
            btnForgot.CustomizableEdges = ce14;
            btnForgot.FillColor = Color.FromArgb(108, 117, 125);
            btnForgot.Font = new Font("Segoe UI", 9F);
            btnForgot.ForeColor = Color.White;
            btnForgot.Location = new Point(232, 232);
            btnForgot.ShadowDecoration.CustomizableEdges = ce15;
            btnForgot.Size = new Size(144, 28);
            btnForgot.Text = "Quên mật khẩu";
            btnForgot.Click += btnForgot_Click;

            // add theo thứ tự hiển thị
            panelLoginFields.Controls.Add(btnBack);
            panelLoginFields.Controls.Add(lblTitle);
            panelLoginFields.Controls.Add(lblUser);
            panelLoginFields.Controls.Add(txtUser);
            panelLoginFields.Controls.Add(lblPass);
            panelLoginFields.Controls.Add(txtPass);
            panelLoginFields.Controls.Add(btnTogglePass);
            panelLoginFields.Controls.Add(btnLogin);
            panelLoginFields.Controls.Add(lblAuthError); // dưới nút đăng nhập
            panelLoginFields.Controls.Add(btnRegister);
            panelLoginFields.Controls.Add(btnForgot);

            // gắn 2 layer vào card
            panelLogin.Controls.Add(panelLoginFields);
            panelLogin.Controls.Add(panelRoleInline);

            // ===== Control boxes (góc phải) =====
            controlBoxMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMin.ControlBoxType = ControlBoxType.MinimizeBox;
            controlBoxMin.CustomizableEdges = ce16;
            controlBoxMin.FillColor = Color.Transparent;
            controlBoxMin.IconColor = Color.FromArgb(33, 37, 41);
            controlBoxMin.Location = new Point(769, 5);
            controlBoxMin.Size = new Size(35, 25);

            controlBoxMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxMax.ControlBoxType = ControlBoxType.MaximizeBox;
            controlBoxMax.CustomizableEdges = ce17;
            controlBoxMax.FillColor = Color.Transparent;
            controlBoxMax.IconColor = Color.FromArgb(33, 37, 41);
            controlBoxMax.Location = new Point(810, 5);
            controlBoxMax.Size = new Size(35, 25);

            controlBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBoxClose.FillColor = Color.Transparent;
            controlBoxClose.IconColor = Color.FromArgb(33, 37, 41);
            controlBoxClose.Location = new Point(851, 5);
            controlBoxClose.Size = new Size(35, 25);

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White; // nền trắng
            ClientSize = new Size(900, 550);
            Controls.Add(panelLogin);
            Controls.Add(controlBoxMin);
            Controls.Add(controlBoxMax);
            Controls.Add(controlBoxClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn phương thức đăng nhập";

            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm guna2BorderlessForm1;

        // Card
        private Guna2Panel panelLogin;

        // A) chọn vai trò
        private Guna2Panel panelRoleInline;
        private Guna2Button btnRoleAdmin;
        private Guna2Button btnRoleCustomer;
        private Label lblChoose;

        // B) form login
        private Guna2Panel panelLoginFields;
        private Guna2Button btnBack;
        private Label lblTitle;
        private Label lblUser;
        private Label lblPass;
        private Guna2TextBox txtUser;
        private Guna2TextBox txtPass;
        private Guna2Button btnTogglePass;
        private Guna2Button btnLogin;
        private Guna2HtmlLabel lblAuthError;
        private Guna2Button btnRegister;
        private Guna2Button btnForgot;

        // Control boxes
        private Guna2ControlBox controlBoxMin;
        private Guna2ControlBox controlBoxMax;
        private Guna2ControlBox controlBoxClose;
    }
}
