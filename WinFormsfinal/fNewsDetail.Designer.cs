using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fNewsDetail
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel guna2PanelTop;
        private Label lblTitle;
        private Label lblDate;
        private PictureBox picNews;
        private TextBox txtContent;
        private Guna2Button btnClose;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new();
            components = new System.ComponentModel.Container();

            this.guna2PanelTop = new Guna2Panel();
            this.btnClose = new Guna2Button();
            this.lblTitle = new Label();
            this.lblDate = new Label();
            this.picNews = new PictureBox();
            this.txtContent = new TextBox();

            this.guna2PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNews)).BeginInit();
            this.SuspendLayout();

            // 
            // guna2PanelTop
            // 
            this.guna2PanelTop.CustomizableEdges = customizableEdges1;
            this.guna2PanelTop.Dock = DockStyle.Top;
            this.guna2PanelTop.FillColor = this.BackColor;  // hoặc Color.White

            this.guna2PanelTop.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelTop.Name = "guna2PanelTop";
            this.guna2PanelTop.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.guna2PanelTop.Size = new System.Drawing.Size(900, 70);
            this.guna2PanelTop.TabIndex = 0;
            this.guna2PanelTop.Controls.Add(this.btnClose);
            this.guna2PanelTop.Controls.Add(this.lblTitle);

            // 
            // btnClose
            // 
            this.btnClose.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnClose.CustomizableEdges = customizableEdges3;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(820, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.btnClose.Size = new System.Drawing.Size(70, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(780, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tiêu đề tin tức";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblDate.Location = new System.Drawing.Point(24, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(138, 19);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Ngày đăng: 01/01/2024";

            // 
            // picNews
            // 
            this.picNews.Location = new System.Drawing.Point(24, 110);
            this.picNews.Name = "picNews";
            this.picNews.Size = new System.Drawing.Size(380, 250);
            this.picNews.SizeMode = PictureBoxSizeMode.Zoom;
            this.picNews.TabIndex = 2;
            this.picNews.TabStop = false;
            this.picNews.BackColor = System.Drawing.Color.White;

            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(420, 110);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(460, 380);
            this.txtContent.TabIndex = 3;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.BackColor = System.Drawing.Color.White;

            // 
            // fNewsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.picNews);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.guna2PanelTop);
            this.Name = "fNewsDetail";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chi tiết tin tức";

            this.guna2PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
