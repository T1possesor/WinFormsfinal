using System.Windows.Forms;

namespace WinFormsfinal
{
    partial class ThongKeControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.panelChart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.panelBarContainer = new System.Windows.Forms.Panel();
            this.panelBarKhac = new System.Windows.Forms.Panel();
            this.lblKhac = new System.Windows.Forms.Label();
            this.panelBarKH = new System.Windows.Forms.Panel();
            this.lblKH = new System.Windows.Forms.Label();
            this.panelBarNN = new System.Windows.Forms.Panel();
            this.lblNN = new System.Windows.Forms.Label();
            this.panelBarKT = new System.Windows.Forms.Panel();
            this.lblKT = new System.Windows.Forms.Label();
            this.panelBarCN = new System.Windows.Forms.Panel();
            this.lblCN = new System.Windows.Forms.Label();
            this.panelCards = new System.Windows.Forms.Panel();
            this.cardPhong = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPhongValue = new System.Windows.Forms.Label();
            this.lblPhongTitle = new System.Windows.Forms.Label();
            this.cardDocGia = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDocGiaValue = new System.Windows.Forms.Label();
            this.lblDocGiaTitle = new System.Windows.Forms.Label();
            this.cardLuotMuon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLuotMuonValue = new System.Windows.Forms.Label();
            this.lblLuotMuonTitle = new System.Windows.Forms.Label();
            this.cardTongSach = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongSachValue = new System.Windows.Forms.Label();
            this.lblTongSachTitle = new System.Windows.Forms.Label();
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelRoot.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panelBarContainer.SuspendLayout();
            this.panelCards.SuspendLayout();
            this.cardPhong.SuspendLayout();
            this.cardDocGia.SuspendLayout();
            this.cardLuotMuon.SuspendLayout();
            this.cardTongSach.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRoot
            // 
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoot.FillColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.panelRoot.Controls.Add(this.panelChart);
            this.panelRoot.Controls.Add(this.panelCards);
            this.panelRoot.Controls.Add(this.panelHeader);
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Size = new System.Drawing.Size(1200, 650);
            this.panelRoot.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BorderRadius = 12;
            this.panelHeader.FillColor = System.Drawing.Color.White;
            this.panelHeader.Location = new System.Drawing.Point(30, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1140, 80);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(337, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ THƯ VIỆN";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSubTitle.Location = new System.Drawing.Point(28, 47);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(279, 19);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Tổng quan hoạt động mượn trả, độc giả, phòng";
            // 
            // panelCards
            // 
            this.panelCards.Location = new System.Drawing.Point(30, 115);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(1140, 140);
            this.panelCards.TabIndex = 1;
            this.panelCards.Controls.Add(this.cardPhong);
            this.panelCards.Controls.Add(this.cardDocGia);
            this.panelCards.Controls.Add(this.cardLuotMuon);
            this.panelCards.Controls.Add(this.cardTongSach);
            // 
            // cardTongSach
            // 
            this.cardTongSach.BorderRadius = 10;
            this.cardTongSach.FillColor = System.Drawing.Color.White;
            this.cardTongSach.Location = new System.Drawing.Point(0, 0);
            this.cardTongSach.Name = "cardTongSach";
            this.cardTongSach.Size = new System.Drawing.Size(270, 140);
            this.cardTongSach.TabIndex = 0;
            this.cardTongSach.ShadowDecoration.BorderRadius = 10;
            this.cardTongSach.ShadowDecoration.Enabled = true;
            this.cardTongSach.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardTongSach.Controls.Add(this.lblTongSachValue);
            this.cardTongSach.Controls.Add(this.lblTongSachTitle);
            // 
            // lblTongSachTitle
            // 
            this.lblTongSachTitle.AutoSize = true;
            this.lblTongSachTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongSachTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblTongSachTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTongSachTitle.Name = "lblTongSachTitle";
            this.lblTongSachTitle.Size = new System.Drawing.Size(131, 20);
            this.lblTongSachTitle.TabIndex = 0;
            this.lblTongSachTitle.Text = "TỔNG SỐ ĐẦU SÁCH";
            // 
            // lblTongSachValue
            // 
            this.lblTongSachValue.AutoSize = true;
            this.lblTongSachValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongSachValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTongSachValue.Location = new System.Drawing.Point(16, 60);
            this.lblTongSachValue.Name = "lblTongSachValue";
            this.lblTongSachValue.Size = new System.Drawing.Size(82, 37);
            this.lblTongSachValue.TabIndex = 1;
            this.lblTongSachValue.Text = "0.000";
            // 
            // cardLuotMuon
            // 
            this.cardLuotMuon.BorderRadius = 10;
            this.cardLuotMuon.FillColor = System.Drawing.Color.White;
            this.cardLuotMuon.Location = new System.Drawing.Point(290, 0);
            this.cardLuotMuon.Name = "cardLuotMuon";
            this.cardLuotMuon.Size = new System.Drawing.Size(270, 140);
            this.cardLuotMuon.TabIndex = 1;
            this.cardLuotMuon.ShadowDecoration.BorderRadius = 10;
            this.cardLuotMuon.ShadowDecoration.Enabled = true;
            this.cardLuotMuon.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardLuotMuon.Controls.Add(this.lblLuotMuonValue);
            this.cardLuotMuon.Controls.Add(this.lblLuotMuonTitle);
            // 
            // lblLuotMuonTitle
            // 
            this.lblLuotMuonTitle.AutoSize = true;
            this.lblLuotMuonTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblLuotMuonTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblLuotMuonTitle.Location = new System.Drawing.Point(18, 18);
            this.lblLuotMuonTitle.Name = "lblLuotMuonTitle";
            this.lblLuotMuonTitle.Size = new System.Drawing.Size(142, 20);
            this.lblLuotMuonTitle.TabIndex = 0;
            this.lblLuotMuonTitle.Text = "LƯỢT MƯỢN / THÁNG";
            // 
            // lblLuotMuonValue
            // 
            this.lblLuotMuonValue.AutoSize = true;
            this.lblLuotMuonValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLuotMuonValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblLuotMuonValue.Location = new System.Drawing.Point(16, 60);
            this.lblLuotMuonValue.Name = "lblLuotMuonValue";
            this.lblLuotMuonValue.Size = new System.Drawing.Size(82, 37);
            this.lblLuotMuonValue.TabIndex = 1;
            this.lblLuotMuonValue.Text = "0.000";
            // 
            // cardDocGia
            // 
            this.cardDocGia.BorderRadius = 10;
            this.cardDocGia.FillColor = System.Drawing.Color.White;
            this.cardDocGia.Location = new System.Drawing.Point(580, 0);
            this.cardDocGia.Name = "cardDocGia";
            this.cardDocGia.Size = new System.Drawing.Size(270, 140);
            this.cardDocGia.TabIndex = 2;
            this.cardDocGia.ShadowDecoration.BorderRadius = 10;
            this.cardDocGia.ShadowDecoration.Enabled = true;
            this.cardDocGia.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardDocGia.Controls.Add(this.lblDocGiaValue);
            this.cardDocGia.Controls.Add(this.lblDocGiaTitle);
            // 
            // lblDocGiaTitle
            // 
            this.lblDocGiaTitle.AutoSize = true;
            this.lblDocGiaTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDocGiaTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblDocGiaTitle.Location = new System.Drawing.Point(18, 18);
            this.lblDocGiaTitle.Name = "lblDocGiaTitle";
            this.lblDocGiaTitle.Size = new System.Drawing.Size(133, 20);
            this.lblDocGiaTitle.TabIndex = 0;
            this.lblDocGiaTitle.Text = "ĐỘC GIẢ HOẠT ĐỘNG";
            // 
            // lblDocGiaValue
            // 
            this.lblDocGiaValue.AutoSize = true;
            this.lblDocGiaValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDocGiaValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblDocGiaValue.Location = new System.Drawing.Point(16, 60);
            this.lblDocGiaValue.Name = "lblDocGiaValue";
            this.lblDocGiaValue.Size = new System.Drawing.Size(82, 37);
            this.lblDocGiaValue.TabIndex = 1;
            this.lblDocGiaValue.Text = "0.000";
            // 
            // cardPhong
            // 
            this.cardPhong.BorderRadius = 10;
            this.cardPhong.FillColor = System.Drawing.Color.White;
            this.cardPhong.Location = new System.Drawing.Point(870, 0);
            this.cardPhong.Name = "cardPhong";
            this.cardPhong.Size = new System.Drawing.Size(270, 140);
            this.cardPhong.TabIndex = 3;
            this.cardPhong.ShadowDecoration.BorderRadius = 10;
            this.cardPhong.ShadowDecoration.Enabled = true;
            this.cardPhong.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardPhong.Controls.Add(this.lblPhongValue);
            this.cardPhong.Controls.Add(this.lblPhongTitle);
            // 
            // lblPhongTitle
            // 
            this.lblPhongTitle.AutoSize = true;
            this.lblPhongTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPhongTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblPhongTitle.Location = new System.Drawing.Point(18, 18);
            this.lblPhongTitle.Name = "lblPhongTitle";
            this.lblPhongTitle.Size = new System.Drawing.Size(175, 20);
            this.lblPhongTitle.TabIndex = 0;
            this.lblPhongTitle.Text = "PHÒNG HỌC NHÓM ĐÃ ĐẶT";
            // 
            // lblPhongValue
            // 
            this.lblPhongValue.AutoSize = true;
            this.lblPhongValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPhongValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblPhongValue.Location = new System.Drawing.Point(16, 60);
            this.lblPhongValue.Name = "lblPhongValue";
            this.lblPhongValue.Size = new System.Drawing.Size(82, 37);
            this.lblPhongValue.TabIndex = 1;
            this.lblPhongValue.Text = "0 / 0";
            // 
            // panelChart
            // 
            this.panelChart.BorderRadius = 12;
            this.panelChart.FillColor = System.Drawing.Color.White;
            this.panelChart.Location = new System.Drawing.Point(30, 270);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(1140, 350);
            this.panelChart.TabIndex = 2;
            this.panelChart.Controls.Add(this.panelBarContainer);
            this.panelChart.Controls.Add(this.lblChartTitle);
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblChartTitle.Location = new System.Drawing.Point(20, 15);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(232, 21);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "LƯỢT MƯỢN THEO LOẠI TÀI LIỆU";
            // 
            // panelBarContainer
            // 
            this.panelBarContainer.Location = new System.Drawing.Point(60, 55);
            this.panelBarContainer.Name = "panelBarContainer";
            this.panelBarContainer.Size = new System.Drawing.Size(1000, 270);
            this.panelBarContainer.TabIndex = 1;
            this.panelBarContainer.BorderStyle = BorderStyle.None;
            this.panelBarContainer.Controls.Add(this.panelBarKhac);
            this.panelBarContainer.Controls.Add(this.lblKhac);
            this.panelBarContainer.Controls.Add(this.panelBarKH);
            this.panelBarContainer.Controls.Add(this.lblKH);
            this.panelBarContainer.Controls.Add(this.panelBarNN);
            this.panelBarContainer.Controls.Add(this.lblNN);
            this.panelBarContainer.Controls.Add(this.panelBarKT);
            this.panelBarContainer.Controls.Add(this.lblKT);
            this.panelBarContainer.Controls.Add(this.panelBarCN);
            this.panelBarContainer.Controls.Add(this.lblCN);
            // 
            // panelBarCN
            // 
            this.panelBarCN.BackColor = System.Drawing.Color.FromArgb(56, 133, 164);
            this.panelBarCN.Location = new System.Drawing.Point(40, 70);
            this.panelBarCN.Name = "panelBarCN";
            this.panelBarCN.Size = new System.Drawing.Size(60, 160);
            this.panelBarCN.TabIndex = 0;
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCN.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblCN.Location = new System.Drawing.Point(33, 235);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(72, 15);
            this.lblCN.TabIndex = 1;
            this.lblCN.Text = "Công nghệ";
            // 
            // panelBarKT
            // 
            this.panelBarKT.BackColor = System.Drawing.Color.FromArgb(56, 133, 164);
            this.panelBarKT.Location = new System.Drawing.Point(220, 90);
            this.panelBarKT.Name = "panelBarKT";
            this.panelBarKT.Size = new System.Drawing.Size(60, 140);
            this.panelBarKT.TabIndex = 2;
            // 
            // lblKT
            // 
            this.lblKT.AutoSize = true;
            this.lblKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKT.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblKT.Location = new System.Drawing.Point(217, 235);
            this.lblKT.Name = "lblKT";
            this.lblKT.Size = new System.Drawing.Size(48, 15);
            this.lblKT.TabIndex = 3;
            this.lblKT.Text = "Kinh tế";
            // 
            // panelBarNN
            // 
            this.panelBarNN.BackColor = System.Drawing.Color.FromArgb(56, 133, 164);
            this.panelBarNN.Location = new System.Drawing.Point(400, 110);
            this.panelBarNN.Name = "panelBarNN";
            this.panelBarNN.Size = new System.Drawing.Size(60, 120);
            this.panelBarNN.TabIndex = 4;
            // 
            // lblNN
            // 
            this.lblNN.AutoSize = true;
            this.lblNN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNN.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblNN.Location = new System.Drawing.Point(393, 235);
            this.lblNN.Name = "lblNN";
            this.lblNN.Size = new System.Drawing.Size(64, 15);
            this.lblNN.TabIndex = 5;
            this.lblNN.Text = "Ngoại ngữ";
            // 
            // panelBarKH
            // 
            this.panelBarKH.BackColor = System.Drawing.Color.FromArgb(56, 133, 164);
            this.panelBarKH.Location = new System.Drawing.Point(580, 130);
            this.panelBarKH.Name = "panelBarKH";
            this.panelBarKH.Size = new System.Drawing.Size(60, 100);
            this.panelBarKH.TabIndex = 6;
            // 
            // lblKH
            // 
            this.lblKH.AutoSize = true;
            this.lblKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKH.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblKH.Location = new System.Drawing.Point(576, 235);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(60, 15);
            this.lblKH.TabIndex = 7;
            this.lblKH.Text = "Khoa học";
            // 
            // panelBarKhac
            // 
            this.panelBarKhac.BackColor = System.Drawing.Color.FromArgb(56, 133, 164);
            this.panelBarKhac.Location = new System.Drawing.Point(760, 150);
            this.panelBarKhac.Name = "panelBarKhac";
            this.panelBarKhac.Size = new System.Drawing.Size(60, 80);
            this.panelBarKhac.TabIndex = 8;
            // 
            // lblKhac
            // 
            this.lblKhac.AutoSize = true;
            this.lblKhac.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhac.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblKhac.Location = new System.Drawing.Point(764, 235);
            this.lblKhac.Name = "lblKhac";
            this.lblKhac.Size = new System.Drawing.Size(34, 15);
            this.lblKhac.TabIndex = 9;
            this.lblKhac.Text = "Khác";
            // 
            // ThongKeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRoot);
            this.Name = "ThongKeControl";
            this.Size = new System.Drawing.Size(1200, 650);
            this.panelRoot.ResumeLayout(false);
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            this.panelBarContainer.ResumeLayout(false);
            this.panelBarContainer.PerformLayout();
            this.panelCards.ResumeLayout(false);
            this.cardPhong.ResumeLayout(false);
            this.cardPhong.PerformLayout();
            this.cardDocGia.ResumeLayout(false);
            this.cardDocGia.PerformLayout();
            this.cardLuotMuon.ResumeLayout(false);
            this.cardLuotMuon.PerformLayout();
            this.cardTongSach.ResumeLayout(false);
            this.cardTongSach.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelRoot;
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel panelCards;
        private Guna.UI2.WinForms.Guna2Panel cardTongSach;
        private Label lblTongSachValue;
        private Label lblTongSachTitle;
        private Guna.UI2.WinForms.Guna2Panel cardLuotMuon;
        private Label lblLuotMuonValue;
        private Label lblLuotMuonTitle;
        private Guna.UI2.WinForms.Guna2Panel cardDocGia;
        private Label lblDocGiaValue;
        private Label lblDocGiaTitle;
        private Guna.UI2.WinForms.Guna2Panel cardPhong;
        private Label lblPhongValue;
        private Label lblPhongTitle;
        private Guna.UI2.WinForms.Guna2Panel panelChart;
        private Label lblChartTitle;
        private Panel panelBarContainer;
        private Panel panelBarCN;
        private Label lblCN;
        private Panel panelBarKT;
        private Label lblKT;
        private Panel panelBarNN;
        private Label lblNN;
        private Panel panelBarKH;
        private Label lblKH;
        private Panel panelBarKhac;
        private Label lblKhac;
    }
}
