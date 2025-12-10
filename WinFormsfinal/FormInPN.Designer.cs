namespace QLNhapSach_new
{
    partial class FormInPN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInPN));
            PanelTieuDe = new Panel();
            lblTieuDe = new Label();
            PanelND = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnIn = new Guna.UI2.WinForms.Guna2Button();
            btnDong = new Guna.UI2.WinForms.Guna2Button();
            cboMaPN = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMaPNIn = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PanelTieuDe.SuspendLayout();
            PanelND.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTieuDe
            // 
            PanelTieuDe.BackColor = SystemColors.ControlLight;
            PanelTieuDe.Controls.Add(lblTieuDe);
            PanelTieuDe.Dock = DockStyle.Top;
            PanelTieuDe.Location = new Point(0, 0);
            PanelTieuDe.Name = "PanelTieuDe";
            PanelTieuDe.Size = new Size(625, 65);
            PanelTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTieuDe.Location = new Point(36, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(296, 37);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tham số in phiếu nhập";
            // 
            // PanelND
            // 
            PanelND.BackColor = SystemColors.Window;
            PanelND.Controls.Add(btnIn);
            PanelND.Controls.Add(btnDong);
            PanelND.Controls.Add(cboMaPN);
            PanelND.Controls.Add(lblMaPNIn);
            PanelND.CustomizableEdges = customizableEdges7;
            PanelND.Dock = DockStyle.Fill;
            PanelND.Location = new Point(0, 65);
            PanelND.Name = "PanelND";
            PanelND.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PanelND.Size = new Size(625, 296);
            PanelND.TabIndex = 1;
            // 
            // btnIn
            // 
            btnIn.CustomizableEdges = customizableEdges1;
            btnIn.DisabledState.BorderColor = Color.DarkGray;
            btnIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnIn.Font = new Font("Segoe UI", 9F);
            btnIn.ForeColor = Color.White;
            btnIn.Location = new Point(466, 213);
            btnIn.Name = "btnIn";
            btnIn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnIn.Size = new Size(125, 46);
            btnIn.TabIndex = 3;
            btnIn.Text = "Đồng ý";
            btnIn.Click += btnIn_Click;
            // 
            // btnDong
            // 
            btnDong.CustomizableEdges = customizableEdges3;
            btnDong.DisabledState.BorderColor = Color.DarkGray;
            btnDong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDong.Font = new Font("Segoe UI", 9F);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(310, 213);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDong.Size = new Size(125, 46);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;
            // 
            // cboMaPN
            // 
            cboMaPN.BackColor = Color.Transparent;
            cboMaPN.CustomizableEdges = customizableEdges5;
            cboMaPN.DrawMode = DrawMode.OwnerDrawFixed;
            cboMaPN.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaPN.FocusedColor = Color.FromArgb(94, 148, 255);
            cboMaPN.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboMaPN.Font = new Font("Segoe UI", 10F);
            cboMaPN.ForeColor = Color.FromArgb(68, 88, 112);
            cboMaPN.ItemHeight = 30;
            cboMaPN.Location = new Point(258, 68);
            cboMaPN.Name = "cboMaPN";
            cboMaPN.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboMaPN.Size = new Size(280, 36);
            cboMaPN.TabIndex = 1;
            // 
            // lblMaPNIn
            // 
            lblMaPNIn.AutoSize = true;
            lblMaPNIn.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblMaPNIn.Location = new Point(41, 63);
            lblMaPNIn.Name = "lblMaPNIn";
            lblMaPNIn.Size = new Size(196, 37);
            lblMaPNIn.TabIndex = 0;
            lblMaPNIn.Text = "Mã phiếu nhập";
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // FormInPN
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 361);
            Controls.Add(PanelND);
            Controls.Add(PanelTieuDe);
            Name = "FormInPN";
            Text = "FormInPN";
            Load += FormInPN_Load;
            PanelTieuDe.ResumeLayout(false);
            PanelTieuDe.PerformLayout();
            PanelND.ResumeLayout(false);
            PanelND.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTieuDe;
        private Label lblTieuDe;
        private Guna.UI2.WinForms.Guna2GradientPanel PanelND;
        private Guna.UI2.WinForms.Guna2Button btnIn;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2ComboBox cboMaPN;
        private Label lblMaPNIn;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}