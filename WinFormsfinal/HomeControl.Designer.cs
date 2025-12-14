namespace WinFormsfinal
{
    partial class HomeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bannerBackground = new System.Windows.Forms.Panel();
            this.bannerInner = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDots = new System.Windows.Forms.Label();
            this.lblBannerRight = new System.Windows.Forms.Label();
            this.lblBannerSub = new System.Windows.Forms.Label();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.lblArrowLeft = new System.Windows.Forms.Label();
            this.lblArrowRight = new System.Windows.Forms.Label();
            this.areaPanel = new System.Windows.Forms.Panel();
            this.cardsHost = new System.Windows.Forms.Panel();
            this.cardHoTro = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMoreHoTro = new Guna.UI2.WinForms.Guna2Button();
            this.lblHoTroList = new System.Windows.Forms.Label();
            this.lblHoTroTitle = new System.Windows.Forms.Label();
            this.cardTaiNguyen = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMoreTaiNguyen = new Guna.UI2.WinForms.Guna2Button();
            this.lblTaiNguyenList = new System.Windows.Forms.Label();
            this.lblTaiNguyenTitle = new System.Windows.Forms.Label();
            this.cardDichVu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMoreDichVu = new Guna.UI2.WinForms.Guna2Button();
            this.lblDichVuList = new System.Windows.Forms.Label();
            this.lblDichVuTitle = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Panel();
            this.bannerBackground.SuspendLayout();
            this.bannerInner.SuspendLayout();
            this.areaPanel.SuspendLayout();
            this.cardsHost.SuspendLayout();
            this.cardHoTro.SuspendLayout();
            this.cardTaiNguyen.SuspendLayout();
            this.cardDichVu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bannerBackground
            // 
            this.bannerBackground.BackColor = System.Drawing.Color.Silver;
            this.bannerBackground.Controls.Add(this.bannerInner);
            this.bannerBackground.Controls.Add(this.lblArrowLeft);
            this.bannerBackground.Controls.Add(this.lblArrowRight);
            this.bannerBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this.bannerBackground.Location = new System.Drawing.Point(0, 0);
            this.bannerBackground.Name = "bannerBackground";
            this.bannerBackground.Size = new System.Drawing.Size(1200, 260);
            this.bannerBackground.TabIndex = 0;
            this.bannerBackground.Resize += new System.EventHandler(this.bannerBackground_Resize);
            // 
            // bannerInner
            // 
            this.bannerInner.BorderRadius = 20;
            this.bannerInner.Controls.Add(this.lblDots);
            this.bannerInner.Controls.Add(this.lblBannerRight);
            this.bannerInner.Controls.Add(this.lblBannerSub);
            this.bannerInner.Controls.Add(this.lblBannerTitle);
            this.bannerInner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(133)))), ((int)(((byte)(164)))));
            this.bannerInner.Location = new System.Drawing.Point(125, 15);
            this.bannerInner.Name = "bannerInner";
            this.bannerInner.ShadowDecoration.BorderRadius = 20;
            this.bannerInner.ShadowDecoration.Enabled = true;
            this.bannerInner.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.bannerInner.Size = new System.Drawing.Size(950, 230);
            this.bannerInner.TabIndex = 0;
            // 
            // lblDots
            // 
            this.lblDots.AutoSize = true;
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDots.ForeColor = System.Drawing.Color.White;
            this.lblDots.Location = new System.Drawing.Point(445, 190);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(32, 19);
            this.lblDots.TabIndex = 3;
            this.lblDots.Text = "● ○ ○";
            // 
            // lblBannerRight
            // 
            this.lblBannerRight.AutoSize = true;
            this.lblBannerRight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBannerRight.ForeColor = System.Drawing.Color.White;
            this.lblBannerRight.Location = new System.Drawing.Point(600, 80);
            this.lblBannerRight.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblBannerRight.Name = "lblBannerRight";
            this.lblBannerRight.Size = new System.Drawing.Size(270, 40);
            this.lblBannerRight.TabIndex = 2;
            this.lblBannerRight.Text = "Bạn đọc có thể gửi yêu cầu tài liệu\r\ntrực tuyến thông qua hệ thống thư viện.";
            // 
            // lblBannerSub
            // 
            this.lblBannerSub.AutoSize = true;
            this.lblBannerSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBannerSub.ForeColor = System.Drawing.Color.White;
            this.lblBannerSub.Location = new System.Drawing.Point(40, 90);
            this.lblBannerSub.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblBannerSub.Name = "lblBannerSub";
            this.lblBannerSub.Size = new System.Drawing.Size(411, 42);
            this.lblBannerSub.TabIndex = 1;
            this.lblBannerSub.Text = "Đối tượng: Sinh viên / học viên sau đại học,\r\ncán bộ giảng viên, người lao động.";
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblBannerTitle.Location = new System.Drawing.Point(40, 30);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(355, 41);
            this.lblBannerTitle.TabIndex = 0;
            this.lblBannerTitle.Text = "PHIẾU YÊU CẦU TÀI LIỆU";
            // 
            // lblArrowLeft
            // 
            this.lblArrowLeft.AutoSize = true;
            this.lblArrowLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblArrowLeft.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblArrowLeft.ForeColor = System.Drawing.Color.White;
            this.lblArrowLeft.Location = new System.Drawing.Point(10, 110);
            this.lblArrowLeft.Name = "lblArrowLeft";
            this.lblArrowLeft.Size = new System.Drawing.Size(27, 32);
            this.lblArrowLeft.TabIndex = 1;
            this.lblArrowLeft.Text = "<";
            // 
            // lblArrowRight
            // 
            this.lblArrowRight.AutoSize = true;
            this.lblArrowRight.BackColor = System.Drawing.Color.Transparent;
            this.lblArrowRight.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblArrowRight.ForeColor = System.Drawing.Color.White;
            this.lblArrowRight.Location = new System.Drawing.Point(1160, 110);
            this.lblArrowRight.Name = "lblArrowRight";
            this.lblArrowRight.Size = new System.Drawing.Size(27, 32);
            this.lblArrowRight.TabIndex = 2;
            this.lblArrowRight.Text = ">";
            // 
            // areaPanel
            // 
            this.areaPanel.BackColor = System.Drawing.Color.White;
            this.areaPanel.Controls.Add(this.cardsHost);
            this.areaPanel.Controls.Add(this.line);
            this.areaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areaPanel.Location = new System.Drawing.Point(0, 260);
            this.areaPanel.Name = "areaPanel";
            this.areaPanel.Size = new System.Drawing.Size(1200, 390);
            this.areaPanel.TabIndex = 1;
            this.areaPanel.Resize += new System.EventHandler(this.areaPanel_Resize);
            // 
            // cardsHost
            // 
            this.cardsHost.Controls.Add(this.cardHoTro);
            this.cardsHost.Controls.Add(this.cardTaiNguyen);
            this.cardsHost.Controls.Add(this.cardDichVu);
            this.cardsHost.Location = new System.Drawing.Point(150, 80);
            this.cardsHost.Name = "cardsHost";
            this.cardsHost.Size = new System.Drawing.Size(900, 260);
            this.cardsHost.TabIndex = 1;
            // 
            // cardHoTro
            // 
            this.cardHoTro.BorderRadius = 10;
            this.cardHoTro.Controls.Add(this.btnMoreHoTro);
            this.cardHoTro.Controls.Add(this.lblHoTroList);
            this.cardHoTro.Controls.Add(this.lblHoTroTitle);
            this.cardHoTro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.cardHoTro.Location = new System.Drawing.Point(610, 0);
            this.cardHoTro.Name = "cardHoTro";
            this.cardHoTro.ShadowDecoration.BorderRadius = 10;
            this.cardHoTro.ShadowDecoration.Enabled = true;
            this.cardHoTro.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.cardHoTro.Size = new System.Drawing.Size(280, 260);
            this.cardHoTro.TabIndex = 2;
            // 
            // btnMoreHoTro
            // 
            this.btnMoreHoTro.BorderRadius = 8;
            this.btnMoreHoTro.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreHoTro.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreHoTro.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoreHoTro.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoreHoTro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMoreHoTro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoreHoTro.ForeColor = System.Drawing.Color.White;
            this.btnMoreHoTro.Location = new System.Drawing.Point(20, 215);
            this.btnMoreHoTro.Name = "btnMoreHoTro";
            this.btnMoreHoTro.Size = new System.Drawing.Size(90, 30);
            this.btnMoreHoTro.TabIndex = 2;
            this.btnMoreHoTro.Text = "Xem thêm";
            // 
            // lblHoTroList
            // 
            this.lblHoTroList.AutoSize = true;
            this.lblHoTroList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoTroList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblHoTroList.Location = new System.Drawing.Point(22, 50);
            this.lblHoTroList.MaximumSize = new System.Drawing.Size(240, 0);
            this.lblHoTroList.Name = "lblHoTroList";
            this.lblHoTroList.Size = new System.Drawing.Size(226, 119);
            this.lblHoTroList.TabIndex = 1;
            this.lblHoTroList.Text = "• Tra cứu tài liệu khoa học\r\n• Hướng dẫn trích dẫn, chống đạo văn\r\n• Công cụ quản" +
            " lý tài liệu tham khảo\r\n• Tư vấn tìm kiếm tài liệu chuyên sâu\r\n• Các buổi tập hu" +
            "ấn kỹ năng";
            // 
            // lblHoTroTitle
            // 
            this.lblHoTroTitle.AutoSize = true;
            this.lblHoTroTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblHoTroTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.lblHoTroTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHoTroTitle.Name = "lblHoTroTitle";
            this.lblHoTroTitle.Size = new System.Drawing.Size(158, 21);
            this.lblHoTroTitle.TabIndex = 0;
            this.lblHoTroTitle.Text = "HỖ TRỢ NGHIÊN CỨU";
            // 
            // cardTaiNguyen
            // 
            this.cardTaiNguyen.BorderRadius = 10;
            this.cardTaiNguyen.Controls.Add(this.btnMoreTaiNguyen);
            this.cardTaiNguyen.Controls.Add(this.lblTaiNguyenList);
            this.cardTaiNguyen.Controls.Add(this.lblTaiNguyenTitle);
            this.cardTaiNguyen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.cardTaiNguyen.Location = new System.Drawing.Point(305, 0);
            this.cardTaiNguyen.Name = "cardTaiNguyen";
            this.cardTaiNguyen.ShadowDecoration.BorderRadius = 10;
            this.cardTaiNguyen.ShadowDecoration.Enabled = true;
            this.cardTaiNguyen.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.cardTaiNguyen.Size = new System.Drawing.Size(280, 260);
            this.cardTaiNguyen.TabIndex = 1;
            // 
            // btnMoreTaiNguyen
            // 
            this.btnMoreTaiNguyen.BorderRadius = 8;
            this.btnMoreTaiNguyen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreTaiNguyen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreTaiNguyen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoreTaiNguyen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoreTaiNguyen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMoreTaiNguyen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoreTaiNguyen.ForeColor = System.Drawing.Color.White;
            this.btnMoreTaiNguyen.Location = new System.Drawing.Point(20, 215);
            this.btnMoreTaiNguyen.Name = "btnMoreTaiNguyen";
            this.btnMoreTaiNguyen.Size = new System.Drawing.Size(90, 30);
            this.btnMoreTaiNguyen.TabIndex = 2;
            this.btnMoreTaiNguyen.Text = "Xem thêm";
            // 
            // lblTaiNguyenList
            // 
            this.lblTaiNguyenList.AutoSize = true;
            this.lblTaiNguyenList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaiNguyenList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTaiNguyenList.Location = new System.Drawing.Point(22, 50);
            this.lblTaiNguyenList.MaximumSize = new System.Drawing.Size(240, 0);
            this.lblTaiNguyenList.Name = "lblTaiNguyenList";
            this.lblTaiNguyenList.Size = new System.Drawing.Size(211, 119);
            this.lblTaiNguyenList.TabIndex = 1;
            this.lblTaiNguyenList.Text = "• Cơ sở dữ liệu điện tử\r\n• Giáo trình, luận văn, luận án\r\n• Bộ sưu tập tài liệu" +
            " số\r\n• Tài liệu tham khảo theo môn học\r\n• Nguồn tài liệu mở";
            // 
            // lblTaiNguyenTitle
            // 
            this.lblTaiNguyenTitle.AutoSize = true;
            this.lblTaiNguyenTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTaiNguyenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.lblTaiNguyenTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTaiNguyenTitle.Name = "lblTaiNguyenTitle";
            this.lblTaiNguyenTitle.Size = new System.Drawing.Size(167, 21);
            this.lblTaiNguyenTitle.TabIndex = 0;
            this.lblTaiNguyenTitle.Text = "TÀI NGUYÊN THÔNG TIN";
            // 
            // cardDichVu
            // 
            this.cardDichVu.BorderRadius = 10;
            this.cardDichVu.Controls.Add(this.btnMoreDichVu);
            this.cardDichVu.Controls.Add(this.lblDichVuList);
            this.cardDichVu.Controls.Add(this.lblDichVuTitle);
            this.cardDichVu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.cardDichVu.Location = new System.Drawing.Point(0, 0);
            this.cardDichVu.Name = "cardDichVu";
            this.cardDichVu.ShadowDecoration.BorderRadius = 10;
            this.cardDichVu.ShadowDecoration.Enabled = true;
            this.cardDichVu.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.cardDichVu.Size = new System.Drawing.Size(280, 260);
            this.cardDichVu.TabIndex = 0;
            // 
            // btnMoreDichVu
            // 
            this.btnMoreDichVu.BorderRadius = 8;
            this.btnMoreDichVu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreDichVu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoreDichVu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoreDichVu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoreDichVu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMoreDichVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoreDichVu.ForeColor = System.Drawing.Color.White;
            this.btnMoreDichVu.Location = new System.Drawing.Point(20, 215);
            this.btnMoreDichVu.Name = "btnMoreDichVu";
            this.btnMoreDichVu.Size = new System.Drawing.Size(90, 30);
            this.btnMoreDichVu.TabIndex = 2;
            this.btnMoreDichVu.Text = "Xem thêm";
            // 
            // lblDichVuList
            // 
            this.lblDichVuList.AutoSize = true;
            this.lblDichVuList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDichVuList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDichVuList.Location = new System.Drawing.Point(22, 50);
            this.lblDichVuList.MaximumSize = new System.Drawing.Size(240, 0);
            this.lblDichVuList.Name = "lblDichVuList";
            this.lblDichVuList.Size = new System.Drawing.Size(235, 119);
            this.lblDichVuList.TabIndex = 1;
            this.lblDichVuList.Text = "• Đặt phòng học nhóm\r\n• Dịch vụ lưu hành tài liệu\r\n• Dịch vụ đặt mượn liên thư v" +
            "iện\r\n• Dịch vụ in ấn, sao chụp tài liệu\r\n• Dịch vụ tư vấn – hỗ trợ tại quầy";
            // 
            // lblDichVuTitle
            // 
            this.lblDichVuTitle.AutoSize = true;
            this.lblDichVuTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDichVuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.lblDichVuTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDichVuTitle.Name = "lblDichVuTitle";
            this.lblDichVuTitle.Size = new System.Drawing.Size(156, 21);
            this.lblDichVuTitle.TabIndex = 0;
            this.lblDichVuTitle.Text = "DỊCH VỤ VÀ TIỆN ÍCH";
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.line.Location = new System.Drawing.Point(450, 40);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(300, 2);
            this.line.TabIndex = 0;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.areaPanel);
            this.Controls.Add(this.bannerBackground);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1200, 650);
            this.bannerBackground.ResumeLayout(false);
            this.bannerBackground.PerformLayout();
            this.bannerInner.ResumeLayout(false);
            this.bannerInner.PerformLayout();
            this.areaPanel.ResumeLayout(false);
            this.cardsHost.ResumeLayout(false);
            this.cardHoTro.ResumeLayout(false);
            this.cardHoTro.PerformLayout();
            this.cardTaiNguyen.ResumeLayout(false);
            this.cardTaiNguyen.PerformLayout();
            this.cardDichVu.ResumeLayout(false);
            this.cardDichVu.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel bannerBackground;
        private Guna.UI2.WinForms.Guna2Panel bannerInner;
        private System.Windows.Forms.Label lblDots;
        private System.Windows.Forms.Label lblBannerRight;
        private System.Windows.Forms.Label lblBannerSub;
        private System.Windows.Forms.Label lblBannerTitle;
        private System.Windows.Forms.Label lblArrowLeft;
        private System.Windows.Forms.Label lblArrowRight;
        private System.Windows.Forms.Panel areaPanel;
        private System.Windows.Forms.Panel cardsHost;
        private Guna.UI2.WinForms.Guna2Panel cardHoTro;
        private Guna.UI2.WinForms.Guna2Button btnMoreHoTro;
        private System.Windows.Forms.Label lblHoTroList;
        private System.Windows.Forms.Label lblHoTroTitle;
        private Guna.UI2.WinForms.Guna2Panel cardTaiNguyen;
        private Guna.UI2.WinForms.Guna2Button btnMoreTaiNguyen;
        private System.Windows.Forms.Label lblTaiNguyenList;
        private System.Windows.Forms.Label lblTaiNguyenTitle;
        private Guna.UI2.WinForms.Guna2Panel cardDichVu;
        private Guna.UI2.WinForms.Guna2Button btnMoreDichVu;
        private System.Windows.Forms.Label lblDichVuList;
        private System.Windows.Forms.Label lblDichVuTitle;
        private System.Windows.Forms.Panel line;

        #endregion
    }
}
