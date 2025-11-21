using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class ThongKeControl
    {
        private System.ComponentModel.IContainer components = null;

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
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            ChartArea chartArea4 = new ChartArea();
            Legend legend4 = new Legend();
            this.panelRoot = new Guna2Panel();
            this.panelSectionTinhTrangSach = new Guna2Panel();
            this.chartTinhTrangSach = new Chart();
            this.lblTinhTrangSachTitle = new Label();
            this.panelSectionThanhToan = new Guna2Panel();
            this.chartThanhToan = new Chart();
            this.lblThanhToanTitle = new Label();
            this.panelSectionTrangThaiThe = new Guna2Panel();
            this.chartTrangThaiThe = new Chart();
            this.lblTrangThaiTheTitle = new Label();
            this.panelSectionMucDich = new Guna2Panel();
            this.chartMucDich = new Chart();
            this.lblMucDichTitle = new Label();
            this.panelCards = new Panel();
            this.cardPhong = new Guna2Panel();
            this.lblPhongValue = new Label();
            this.lblPhongTitle = new Label();
            this.cardDocGia = new Guna2Panel();
            this.lblDocGiaValue = new Label();
            this.lblDocGiaTitle = new Label();
            this.cardLuotMuon = new Guna2Panel();
            this.lblLuotMuonValue = new Label();
            this.lblLuotMuonTitle = new Label();
            this.cardTongSach = new Guna2Panel();
            this.lblTongSachValue = new Label();
            this.lblTongSachTitle = new Label();
            this.panelHeader = new Guna2Panel();
            this.lblSubTitle = new Label();
            this.lblTitle = new Label();
            this.panelRoot.SuspendLayout();
            this.panelSectionTinhTrangSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTinhTrangSach)).BeginInit();
            this.panelSectionThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThanhToan)).BeginInit();
            this.panelSectionTrangThaiThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThaiThe)).BeginInit();
            this.panelSectionMucDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMucDich)).BeginInit();
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
            this.panelRoot.Dock = DockStyle.Fill;
            this.panelRoot.FillColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Size = new System.Drawing.Size(1200, 650);
            this.panelRoot.AutoScroll = true;                   // bật scroll
            this.panelRoot.TabIndex = 0;
            this.panelRoot.Controls.Add(this.panelSectionTinhTrangSach);
            this.panelRoot.Controls.Add(this.panelSectionThanhToan);
            this.panelRoot.Controls.Add(this.panelSectionTrangThaiThe);
            this.panelRoot.Controls.Add(this.panelSectionMucDich);
            this.panelRoot.Controls.Add(this.panelCards);
            this.panelRoot.Controls.Add(this.panelHeader);
            // 
            // panelSectionTinhTrangSach
            // 
            this.panelSectionTinhTrangSach.BorderRadius = 12;
            this.panelSectionTinhTrangSach.FillColor = System.Drawing.Color.White;
            this.panelSectionTinhTrangSach.Location = new System.Drawing.Point(30, 770);  // dưới cùng
            this.panelSectionTinhTrangSach.Name = "panelSectionTinhTrangSach";
            this.panelSectionTinhTrangSach.Padding = new Padding(20, 30, 20, 10);
            this.panelSectionTinhTrangSach.Size = new System.Drawing.Size(1140, 160);   // cao 160
            this.panelSectionTinhTrangSach.TabIndex = 5;
            this.panelSectionTinhTrangSach.ShadowDecoration.BorderRadius = 12;
            this.panelSectionTinhTrangSach.ShadowDecoration.Enabled = true;
            this.panelSectionTinhTrangSach.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.panelSectionTinhTrangSach.Controls.Add(this.chartTinhTrangSach);
            this.panelSectionTinhTrangSach.Controls.Add(this.lblTinhTrangSachTitle);
            // 
            // chartTinhTrangSach
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTinhTrangSach.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTinhTrangSach.Legends.Add(legend1);
            this.chartTinhTrangSach.Dock = DockStyle.Fill;
            this.chartTinhTrangSach.Location = new System.Drawing.Point(20, 30);
            this.chartTinhTrangSach.Margin = new Padding(0);
            this.chartTinhTrangSach.Name = "chartTinhTrangSach";
            this.chartTinhTrangSach.Size = new System.Drawing.Size(1100, 120); // 160 - 30 - 10
            this.chartTinhTrangSach.TabIndex = 1;
            this.chartTinhTrangSach.Text = "chart4";
            // 
            // lblTinhTrangSachTitle
            // 
            this.lblTinhTrangSachTitle.AutoSize = true;
            this.lblTinhTrangSachTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrangSachTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTinhTrangSachTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTinhTrangSachTitle.Name = "lblTinhTrangSachTitle";
            this.lblTinhTrangSachTitle.Size = new System.Drawing.Size(195, 19);
            this.lblTinhTrangSachTitle.TabIndex = 0;
            this.lblTinhTrangSachTitle.Text = "TÌNH TRẠNG SÁCH KHI MƯỢN/TRẢ";
            // 
            // panelSectionThanhToan
            // 
            this.panelSectionThanhToan.BorderRadius = 12;
            this.panelSectionThanhToan.FillColor = System.Drawing.Color.White;
            this.panelSectionThanhToan.Location = new System.Drawing.Point(30, 600);
            this.panelSectionThanhToan.Name = "panelSectionThanhToan";
            this.panelSectionThanhToan.Padding = new Padding(20, 30, 20, 10);
            this.panelSectionThanhToan.Size = new System.Drawing.Size(1140, 160);
            this.panelSectionThanhToan.TabIndex = 4;
            this.panelSectionThanhToan.ShadowDecoration.BorderRadius = 12;
            this.panelSectionThanhToan.ShadowDecoration.Enabled = true;
            this.panelSectionThanhToan.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.panelSectionThanhToan.Controls.Add(this.chartThanhToan);
            this.panelSectionThanhToan.Controls.Add(this.lblThanhToanTitle);
            // 
            // chartThanhToan
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThanhToan.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThanhToan.Legends.Add(legend2);
            this.chartThanhToan.Dock = DockStyle.Fill;
            this.chartThanhToan.Location = new System.Drawing.Point(20, 30);
            this.chartThanhToan.Margin = new Padding(0);
            this.chartThanhToan.Name = "chartThanhToan";
            this.chartThanhToan.Size = new System.Drawing.Size(1100, 120);
            this.chartThanhToan.TabIndex = 1;
            this.chartThanhToan.Text = "chart3";
            // 
            // lblThanhToanTitle
            // 
            this.lblThanhToanTitle.AutoSize = true;
            this.lblThanhToanTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhToanTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblThanhToanTitle.Location = new System.Drawing.Point(20, 8);
            this.lblThanhToanTitle.Name = "lblThanhToanTitle";
            this.lblThanhToanTitle.Size = new System.Drawing.Size(214, 19);
            this.lblThanhToanTitle.TabIndex = 0;
            this.lblThanhToanTitle.Text = "HÌNH THỨC THANH TOÁN TIỀN CỌC";
            // 
            // panelSectionTrangThaiThe
            // 
            this.panelSectionTrangThaiThe.BorderRadius = 12;
            this.panelSectionTrangThaiThe.FillColor = System.Drawing.Color.White;
            this.panelSectionTrangThaiThe.Location = new System.Drawing.Point(30, 430);
            this.panelSectionTrangThaiThe.Name = "panelSectionTrangThaiThe";
            this.panelSectionTrangThaiThe.Padding = new Padding(20, 30, 20, 10);
            this.panelSectionTrangThaiThe.Size = new System.Drawing.Size(1140, 160);
            this.panelSectionTrangThaiThe.TabIndex = 3;
            this.panelSectionTrangThaiThe.ShadowDecoration.BorderRadius = 12;
            this.panelSectionTrangThaiThe.ShadowDecoration.Enabled = true;
            this.panelSectionTrangThaiThe.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.panelSectionTrangThaiThe.Controls.Add(this.chartTrangThaiThe);
            this.panelSectionTrangThaiThe.Controls.Add(this.lblTrangThaiTheTitle);
            // 
            // chartTrangThaiThe
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTrangThaiThe.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTrangThaiThe.Legends.Add(legend3);
            this.chartTrangThaiThe.Dock = DockStyle.Fill;
            this.chartTrangThaiThe.Location = new System.Drawing.Point(20, 30);
            this.chartTrangThaiThe.Margin = new Padding(0);
            this.chartTrangThaiThe.Name = "chartTrangThaiThe";
            this.chartTrangThaiThe.Size = new System.Drawing.Size(1100, 120);
            this.chartTrangThaiThe.TabIndex = 1;
            this.chartTrangThaiThe.Text = "chart2";
            // 
            // lblTrangThaiTheTitle
            // 
            this.lblTrangThaiTheTitle.AutoSize = true;
            this.lblTrangThaiTheTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiTheTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTrangThaiTheTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTrangThaiTheTitle.Name = "lblTrangThaiTheTitle";
            this.lblTrangThaiTheTitle.Size = new System.Drawing.Size(170, 19);
            this.lblTrangThaiTheTitle.TabIndex = 0;
            this.lblTrangThaiTheTitle.Text = "TRẠNG THÁI THẺ ĐỘC GIẢ";
            // 
            // panelSectionMucDich
            // 
            this.panelSectionMucDich.BorderRadius = 12;
            this.panelSectionMucDich.FillColor = System.Drawing.Color.White;
            this.panelSectionMucDich.Location = new System.Drawing.Point(30, 260);
            this.panelSectionMucDich.Name = "panelSectionMucDich";
            this.panelSectionMucDich.Padding = new Padding(20, 30, 20, 10);
            this.panelSectionMucDich.Size = new System.Drawing.Size(1140, 160);
            this.panelSectionMucDich.TabIndex = 2;
            this.panelSectionMucDich.ShadowDecoration.BorderRadius = 12;
            this.panelSectionMucDich.ShadowDecoration.Enabled = true;
            this.panelSectionMucDich.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.panelSectionMucDich.Controls.Add(this.chartMucDich);
            this.panelSectionMucDich.Controls.Add(this.lblMucDichTitle);
            // 
            // chartMucDich
            // 
            chartArea4.Name = "ChartArea1";
            this.chartMucDich.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartMucDich.Legends.Add(legend4);
            this.chartMucDich.Dock = DockStyle.Fill;
            this.chartMucDich.Location = new System.Drawing.Point(20, 30);
            this.chartMucDich.Margin = new Padding(0);
            this.chartMucDich.Name = "chartMucDich";
            this.chartMucDich.Size = new System.Drawing.Size(1100, 120);
            this.chartMucDich.TabIndex = 1;
            this.chartMucDich.Text = "chart1";
            // 
            // lblMucDichTitle
            // 
            this.lblMucDichTitle.AutoSize = true;
            this.lblMucDichTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblMucDichTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblMucDichTitle.Location = new System.Drawing.Point(20, 8);
            this.lblMucDichTitle.Name = "lblMucDichTitle";
            this.lblMucDichTitle.Size = new System.Drawing.Size(235, 19);
            this.lblMucDichTitle.TabIndex = 0;
            this.lblMucDichTitle.Text = "MỤC ĐÍCH ĐẶT PHÒNG HỌC NHÓM";
            // 
            // panelCards
            // 
            this.panelCards.Location = new System.Drawing.Point(30, 115);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(1140, 130);
            this.panelCards.TabIndex = 1;
            this.panelCards.Controls.Add(this.cardPhong);
            this.panelCards.Controls.Add(this.cardDocGia);
            this.panelCards.Controls.Add(this.cardLuotMuon);
            this.panelCards.Controls.Add(this.cardTongSach);
            // 
            // cardPhong
            // 
            this.cardPhong.BorderRadius = 10;
            this.cardPhong.FillColor = System.Drawing.Color.White;
            this.cardPhong.Location = new System.Drawing.Point(870, 0);
            this.cardPhong.Name = "cardPhong";
            this.cardPhong.Size = new System.Drawing.Size(270, 130);
            this.cardPhong.TabIndex = 3;
            this.cardPhong.ShadowDecoration.BorderRadius = 10;
            this.cardPhong.ShadowDecoration.Enabled = true;
            this.cardPhong.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardPhong.Controls.Add(this.lblPhongValue);
            this.cardPhong.Controls.Add(this.lblPhongTitle);
            // 
            // lblPhongValue
            // 
            this.lblPhongValue.AutoSize = true;
            this.lblPhongValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPhongValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblPhongValue.Location = new System.Drawing.Point(16, 60);
            this.lblPhongValue.Name = "lblPhongValue";
            this.lblPhongValue.Size = new System.Drawing.Size(46, 37);
            this.lblPhongValue.TabIndex = 1;
            this.lblPhongValue.Text = "0";
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
            // cardDocGia
            // 
            this.cardDocGia.BorderRadius = 10;
            this.cardDocGia.FillColor = System.Drawing.Color.White;
            this.cardDocGia.Location = new System.Drawing.Point(580, 0);
            this.cardDocGia.Name = "cardDocGia";
            this.cardDocGia.Size = new System.Drawing.Size(270, 130);
            this.cardDocGia.TabIndex = 2;
            this.cardDocGia.ShadowDecoration.BorderRadius = 10;
            this.cardDocGia.ShadowDecoration.Enabled = true;
            this.cardDocGia.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardDocGia.Controls.Add(this.lblDocGiaValue);
            this.cardDocGia.Controls.Add(this.lblDocGiaTitle);
            // 
            // lblDocGiaValue
            // 
            this.lblDocGiaValue.AutoSize = true;
            this.lblDocGiaValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDocGiaValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblDocGiaValue.Location = new System.Drawing.Point(16, 60);
            this.lblDocGiaValue.Name = "lblDocGiaValue";
            this.lblDocGiaValue.Size = new System.Drawing.Size(46, 37);
            this.lblDocGiaValue.TabIndex = 1;
            this.lblDocGiaValue.Text = "0";
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
            // cardLuotMuon
            // 
            this.cardLuotMuon.BorderRadius = 10;
            this.cardLuotMuon.FillColor = System.Drawing.Color.White;
            this.cardLuotMuon.Location = new System.Drawing.Point(290, 0);
            this.cardLuotMuon.Name = "cardLuotMuon";
            this.cardLuotMuon.Size = new System.Drawing.Size(270, 130);
            this.cardLuotMuon.TabIndex = 1;
            this.cardLuotMuon.ShadowDecoration.BorderRadius = 10;
            this.cardLuotMuon.ShadowDecoration.Enabled = true;
            this.cardLuotMuon.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardLuotMuon.Controls.Add(this.lblLuotMuonValue);
            this.cardLuotMuon.Controls.Add(this.lblLuotMuonTitle);
            // 
            // lblLuotMuonValue
            // 
            this.lblLuotMuonValue.AutoSize = true;
            this.lblLuotMuonValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLuotMuonValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblLuotMuonValue.Location = new System.Drawing.Point(16, 60);
            this.lblLuotMuonValue.Name = "lblLuotMuonValue";
            this.lblLuotMuonValue.Size = new System.Drawing.Size(46, 37);
            this.lblLuotMuonValue.TabIndex = 1;
            this.lblLuotMuonValue.Text = "0";
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
            // cardTongSach
            // 
            this.cardTongSach.BorderRadius = 10;
            this.cardTongSach.FillColor = System.Drawing.Color.White;
            this.cardTongSach.Location = new System.Drawing.Point(0, 0);
            this.cardTongSach.Name = "cardTongSach";
            this.cardTongSach.Size = new System.Drawing.Size(270, 130);
            this.cardTongSach.TabIndex = 0;
            this.cardTongSach.ShadowDecoration.BorderRadius = 10;
            this.cardTongSach.ShadowDecoration.Enabled = true;
            this.cardTongSach.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.cardTongSach.Controls.Add(this.lblTongSachValue);
            this.cardTongSach.Controls.Add(this.lblTongSachTitle);
            // 
            // lblTongSachValue
            // 
            this.lblTongSachValue.AutoSize = true;
            this.lblTongSachValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongSachValue.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTongSachValue.Location = new System.Drawing.Point(16, 60);
            this.lblTongSachValue.Name = "lblTongSachValue";
            this.lblTongSachValue.Size = new System.Drawing.Size(46, 37);
            this.lblTongSachValue.TabIndex = 1;
            this.lblTongSachValue.Text = "0";
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
            // panelHeader
            // 
            this.panelHeader.BorderRadius = 12;
            this.panelHeader.FillColor = System.Drawing.Color.White;
            this.panelHeader.Location = new System.Drawing.Point(30, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1140, 80);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.ShadowDecoration.BorderRadius = 12;
            this.panelHeader.ShadowDecoration.Enabled = true;
            this.panelHeader.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.lblTitle);
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
            // ThongKeControl
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.panelRoot);
            this.Name = "ThongKeControl";
            this.Size = new System.Drawing.Size(1200, 650);
            this.panelRoot.ResumeLayout(false);
            this.panelSectionTinhTrangSach.ResumeLayout(false);
            this.panelSectionTinhTrangSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTinhTrangSach)).EndInit();
            this.panelSectionThanhToan.ResumeLayout(false);
            this.panelSectionThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThanhToan)).EndInit();
            this.panelSectionTrangThaiThe.ResumeLayout(false);
            this.panelSectionTrangThaiThe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThaiThe)).EndInit();
            this.panelSectionMucDich.ResumeLayout(false);
            this.panelSectionMucDich.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMucDich)).EndInit();
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

        private Guna2Panel panelRoot;
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel panelCards;
        private Guna2Panel cardTongSach;
        private Label lblTongSachValue;
        private Label lblTongSachTitle;
        private Guna2Panel cardLuotMuon;
        private Label lblLuotMuonValue;
        private Label lblLuotMuonTitle;
        private Guna2Panel cardDocGia;
        private Label lblDocGiaValue;
        private Label lblDocGiaTitle;
        private Guna2Panel cardPhong;
        private Label lblPhongValue;
        private Label lblPhongTitle;
        private Guna2Panel panelSectionMucDich;
        private Label lblMucDichTitle;
        private Chart chartMucDich;
        private Guna2Panel panelSectionTrangThaiThe;
        private Label lblTrangThaiTheTitle;
        private Chart chartTrangThaiThe;
        private Guna2Panel panelSectionThanhToan;
        private Label lblThanhToanTitle;
        private Chart chartThanhToan;
        private Guna2Panel panelSectionTinhTrangSach;
        private Label lblTinhTrangSachTitle;
        private Chart chartTinhTrangSach;
    }
}
