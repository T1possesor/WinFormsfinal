using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace WinFormsfinal
{
    public partial class Form1 : Form
    {
        // Lưu vai trò và tài khoản đang đăng nhập
        private readonly string _vaiTro = string.Empty;
        private readonly string _username = string.Empty;

        // ====== PALETTE cho Admin (màu hài hòa) ======
        private static readonly Color AdminBg = Color.FromArgb(246, 248, 252);
        private static readonly Color SectionHeaderColor = Color.FromArgb(30, 83, 214);
        private static readonly Color SectionHeaderHover = Color.FromArgb(22, 66, 178);
        private static readonly Color SectionBodyColor = Color.White;
        private static readonly Color ChildBtnColor = Color.FromArgb(59, 130, 246);
        private static readonly Color ChildBtnHover = Color.FromArgb(37, 99, 235);

        // ================== CLASS PHỤ ĐỂ ANIMATION ACCORDION (ADMIN) ==================
        private class AccordionSectionInfo
        {
            public Panel Body { get; set; } = null!;
            public Guna2Panel Section { get; set; } = null!;
            public int ExpandedHeight { get; set; }
            public int CollapsedHeight { get; set; }
            public bool IsExpanded { get; set; }
            public System.Windows.Forms.Timer Timer { get; set; } = null!;
        }

        // ================== FIELD CHO BANNER KHÁCH HÀNG ==================
        private PictureBox? _bannerPictureBox;
        private Guna2Button? _btnPrevBanner;
        private Guna2Button? _btnNextBanner;
        private Guna2Button[]? _dotButtons;
        private System.Windows.Forms.Timer? _bannerTimer;
        private Image[]? _bannerImages;
        private int _currentBannerIndex = 0;

        // Để căn giữa dots + reposition arrow khi resize
        private Guna2Panel? _bannerRootPanel;
        private Guna2Panel? _bannerContainer;
        private Panel? _dotsPanel;

        // ================== CÁC ẢNH GIỚI THIỆU TÀI LIỆU MỚI ==================
        private Image[]? _bookImages;

        // ================== CÁC ẢNH TIN TỨC THƯ VIỆN ==================
        private Image[]? _newsImages;

        // Constructor mặc định (Designer dùng)
        public Form1()
        {
            InitializeComponent();
            guna2Panel1.BringToFront();
        }

        // Constructor nhận username + vai trò từ form đăng nhập
        public Form1(string username, string vaiTro) : this()
        {
            _username = username ?? string.Empty;
            _vaiTro = vaiTro ?? string.Empty;
        }

        private void NewsCard_Click(object? sender, EventArgs e)
        {
            if (sender is not Control control) return;
            if (control.Tag is not int newsId) return;

            using (var frm = new fNewsDetail(newsId))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.Equals(_vaiTro, "KhachHang", StringComparison.OrdinalIgnoreCase))
            {
                label2.Text = "Xin chào bạn đọc Thư viện Alpha";
            }
            else if (string.Equals(_vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                label2.Text = "Khu vực quản trị hệ thống";
            }

            bool isAdmin = string.Equals(_vaiTro, "Admin", StringComparison.OrdinalIgnoreCase);
            bool isCustomer = string.Equals(_vaiTro, "KhachHang", StringComparison.OrdinalIgnoreCase);

            // Chỉ admin
            btnThongKe.Visible = isAdmin;
            btnNguoiDoc.Visible = isAdmin;
            btnKho.Visible = isAdmin;
            btnPhong.Visible = isAdmin;
            btnSach.Visible = isAdmin;

            // Chỉ khách hàng
            btnThongTinCN.Visible = isCustomer;
            btnTheThuVien.Visible = isCustomer;

            // Trang chủ lúc mới đăng nhập
            if (isCustomer)
                ShowCustomerHome();   // khách hàng: banner slider + giới thiệu tài liệu mới + tin tức thư viện
            else
                ShowLibraryHome();    // admin: accordion 2 cột đẹp hơn
        }

        // =====================================================================
        //        TRANG CHỦ KHÁCH HÀNG – BANNER + GIỚI THIỆU TÀI LIỆU MỚI + TIN TỨC
        // =====================================================================
        private void ShowCustomerHome()
        {
            if (panelContent == null) return;

            // tắt animation cũ, dọn panel
            _bannerTimer?.Stop();
            panelContent.Resize -= PanelContent_Resize;
            panelContent.Controls.Clear();
            panelContent.AutoScroll = true;          // cho phép scroll nếu màn hình nhỏ
            panelContent.Padding = new Padding(0);

            // ---------- 1. ẢNH BANNER (SLIDER) ----------
            if (_bannerImages == null)
            {
                _bannerImages = new[]
                {
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\banner_thu_vien.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\H3.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\Thuviendientu.png"),
                };
            }

            _bannerRootPanel = new Guna2Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FillColor = Color.FromArgb(240, 243, 250),
                Padding = new Padding(60, 40, 60, 40)
            };

            // Panel chứa ảnh banner
            _bannerContainer = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 360,
                BorderRadius = 20,
                FillColor = Color.Black,
            };
            _bannerContainer.ShadowDecoration.Enabled = true;
            _bannerContainer.ShadowDecoration.BorderRadius = 20;
            _bannerContainer.ShadowDecoration.Shadow = new Padding(0, 0, 10, 10);
            _bannerContainer.Resize += BannerContainer_Resize;

            _bannerPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Black
            };
            _bannerContainer.Controls.Add(_bannerPictureBox);

            // Nút mũi tên trái
            _btnPrevBanner = new Guna2Button
            {
                Width = 40,
                Height = 40,
                BorderRadius = 20,
                FillColor = Color.FromArgb(0, 0, 0, 120),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "◀",
                Cursor = Cursors.Hand,
                ShadowDecoration = { Enabled = false }
            };
            _btnPrevBanner.Click += BtnPrevBanner_Click;
            _bannerContainer.Controls.Add(_btnPrevBanner);

            // Nút mũi tên phải
            _btnNextBanner = new Guna2Button
            {
                Width = 40,
                Height = 40,
                BorderRadius = 20,
                FillColor = Color.FromArgb(0, 0, 0, 120),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "▶",
                Cursor = Cursors.Hand,
                ShadowDecoration = { Enabled = false }
            };
            _btnNextBanner.Click += BtnNextBanner_Click;
            _bannerContainer.Controls.Add(_btnNextBanner);

            // Panel chứa 3 nút tròn (dot)
            _dotsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(0, 10, 0, 0)
            };
            if (_bannerRootPanel != null)
                _bannerRootPanel.Resize += Root_Resize;

            _dotButtons = new Guna2Button[3];
            for (int i = 0; i < 3; i++)
            {
                var dot = new Guna2Button
                {
                    Width = 14,
                    Height = 14,
                    BorderRadius = 7,
                    FillColor = Color.Silver,
                    Text = string.Empty,
                    Cursor = Cursors.Hand,
                    Tag = i,
                    ShadowDecoration = { Enabled = false }
                };
                dot.Click += Dot_Click;
                _dotButtons[i] = dot;
                _dotsPanel.Controls.Add(dot);
            }
            LayoutDots(); // căn giữa lần đầu

            // ---------- 2. PHẦN "GIỚI THIỆU TÀI LIỆU MỚI" -----------
            var booksSection = CreateNewBooksSection();

            // ---------- 3. PHẦN "TIN TỨC THƯ VIỆN" -----------
            var newsSection = CreateNewsSection();

            // ---------- 4. FOOTER -----------
            var footerSection = CreateFooterSection();

            // Thêm vào root: trên cùng là banner, rồi dots, sách mới, tin tức, footer ở dưới cùng
            _bannerRootPanel.Controls.Add(footerSection);    // dưới cùng
            _bannerRootPanel.Controls.Add(newsSection);
            _bannerRootPanel.Controls.Add(booksSection);
            _bannerRootPanel.Controls.Add(_dotsPanel);
            _bannerRootPanel.Controls.Add(_bannerContainer); // trên cùng

            panelContent.Controls.Add(_bannerRootPanel);
            panelContent.AutoScroll = true;

            // Khởi tạo timer auto slide
            if (_bannerTimer == null)
            {
                _bannerTimer = new System.Windows.Forms.Timer
                {
                    Interval = 4000 // 4 giây đổi banner
                };
                _bannerTimer.Tick += BannerTimer_Tick;
            }
            _bannerTimer.Start();

            // Hiển thị banner đầu tiên
            _currentBannerIndex = 0;
            UpdateBannerUI();
            BannerContainer_Resize(_bannerContainer, EventArgs.Empty);
        }

        // ======================= GIỚI THIỆU TÀI LIỆU MỚI =======================
        private Panel CreateNewBooksSection()
        {
            // DÙNG ẢNH THẬT
            if (_bookImages == null)
            {
                _bookImages = new[]
                {
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\book1.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\book2.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\book3.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\book4.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\book5.jpg"),
                };
            }

            var section = new Panel
            {
                Dock = DockStyle.Top,
                Height = 420,
                BackColor = Color.FromArgb(240, 243, 250),
                Padding = new Padding(0, 40, 0, 0)
            };

            var lblTitle = new Label
            {
                Text = "GIỚI THIỆU TÀI LIỆU MỚI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 64, 175),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var underline = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                FillColor = Color.FromArgb(209, 213, 219),
                Margin = new Padding(200, 0, 200, 0)
            };

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                // Padding LEFT = 120 để cả dãy hình dịch sang phải
                Padding = new Padding(120, 15, 10, 10),
                BackColor = Color.Transparent
            };

            string[] titles =
            {
                "Tên sách 1", "Tên sách 2", "Tên sách 3",
                "Tên sách 4", "Tên sách 5", "Tên sách 6"
            };

            for (int i = 0; i < _bookImages.Length && i < titles.Length; i++)
            {
                var card = CreateBookCard(_bookImages[i], titles[i]);
                flow.Controls.Add(card);
            }

            section.Controls.Add(flow);
            section.Controls.Add(underline);
            section.Controls.Add(lblTitle);

            return section;
        }

        // Tạo 1 card tài liệu (CHỈ CÓ HÌNH, KHÔNG CÓ CHỮ, KHÔNG BÓNG)
        private Control CreateBookCard(Image img, string title)
        {
            var card = new Guna2Panel
            {
                Width = 290,
                Height = 330,
                BorderRadius = 12,
                FillColor = Color.White,
                Margin = new Padding(15, 10, 15, 10)
            };
            card.ShadowDecoration.Enabled = false;

            var pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = img,
                BackColor = Color.White
            };

            card.Controls.Add(pic);
            return card;
        }

        // ======================= TIN TỨC THƯ VIỆN (3 HÌNH LỚN) =======================
        private Panel CreateNewsSection()
        {
            if (_newsImages == null)
            {
                _newsImages = new[]
                {
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\new_1.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\new_2.jpg"),
                    Image.FromFile(@"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\new_3.jpg"),
                };
            }

            var section = new Panel
            {
                Dock = DockStyle.Top,
                Height = 360,
                BackColor = Color.FromArgb(240, 243, 250),
                Padding = new Padding(0, 35, 0, 0)
            };

            var lblTitle = new Label
            {
                Text = "TIN TỨC THƯ VIỆN",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var underline = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                FillColor = Color.FromArgb(209, 213, 219),
                Margin = new Padding(260, 0, 260, 0)
            };

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(365, 15, 10, 10),
                BackColor = Color.Transparent
            };

            string[] newsTitles =
            {
                "Khai trương không gian đọc mới\ncủa Thư viện tư nhân Alpha",
                "Ngày hội đổi sách cuối tuần\ncho bạn đọc thân thiết",
                "Workshop hướng dẫn kỹ năng\ntruy tìm tài liệu khoa học"
            };

            for (int i = 0; i < _newsImages.Length && i < newsTitles.Length; i++)
            {
                var card = CreateNewsCard(_newsImages[i], newsTitles[i], i + 1);
                flow.Controls.Add(card);
            }

            section.Controls.Add(flow);
            section.Controls.Add(underline);
            section.Controls.Add(lblTitle);

            return section;
        }

        private Control CreateNewsCard(Image img, string title, int newsId)
        {
            var card = new Guna2Panel
            {
                Width = 320,
                Height = 290,
                BorderRadius = 12,
                FillColor = Color.White,
                Margin = new Padding(15, 10, 15, 10),
                Tag = newsId,
                Cursor = Cursors.Hand
            };
            card.ShadowDecoration.Enabled = false;

            var pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 220,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = img,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = newsId
            };

            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                Text = title,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(55, 65, 81),
                TextAlign = ContentAlignment.TopCenter,
                Cursor = Cursors.Hand,
                Tag = newsId
            };

            card.Click += NewsCard_Click;
            pic.Click += NewsCard_Click;
            lbl.Click += NewsCard_Click;

            card.Controls.Add(lbl);
            card.Controls.Add(pic);

            return card;
        }

        // =====================================================================
        //                    CÁC HÀM HỖ TRỢ BANNER
        // =====================================================================
        private void BannerContainer_Resize(object? sender, EventArgs e)
        {
            if (_bannerContainer == null) return;

            int centerY = _bannerContainer.Height / 2 - 20;

            if (_btnPrevBanner != null)
                _btnPrevBanner.Location = new Point(15, centerY);

            if (_btnNextBanner != null)
                _btnNextBanner.Location = new Point(_bannerContainer.Width - 15 - _btnNextBanner.Width, centerY);
        }

        private void Root_Resize(object? sender, EventArgs e) => LayoutDots();

        private void LayoutDots()
        {
            if (_dotsPanel == null || _dotButtons == null || _dotButtons.Length == 0) return;

            int dotSize = _dotButtons[0].Width;
            int gap = 12;
            int totalWidth = _dotButtons.Length * dotSize + (_dotButtons.Length - 1) * gap;
            int startX = (_dotsPanel.Width - totalWidth) / 2;
            int y = 10;

            for (int i = 0; i < _dotButtons.Length; i++)
                _dotButtons[i].Location = new Point(startX + i * (dotSize + gap), y);
        }

        private Image CreateBookPlaceholder(Color bg, string text)
        {
            var bmp = new Bitmap(220, 300);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(bg);
                using var brush = new SolidBrush(Color.White);
                using var font = new Font("Segoe UI", 11, FontStyle.Bold);
                var size = g.MeasureString(text, font);
                g.DrawString(text, font, brush,
                    (bmp.Width - size.Width) / 2,
                    (bmp.Height - size.Height) / 2);
            }
            return bmp;
        }

        // ======================= FOOTER TRANG CHỦ KHÁCH HÀNG =======================
        private Panel CreateFooterSection()
        {
            var footer = new Panel
            {
                Dock = DockStyle.Top,
                Height = 260,
                BackColor = Color.White,
                Padding = new Padding(60, 20, 60, 20)
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));

            // Cột 1: địa chỉ + map
            var leftPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            var lblAddressTitle = new Label
            {
                AutoSize = true,
                Text = "Cơ sở 1",
                Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
            };

            var lblAddress = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(0, 35),
                Text =
                    "Tòa nhà sách tư nhân Alpha,\n" +
                    "279 Nguyễn Tri Phương,\n" +
                    "Phường 8, Quận 10,\n" +
                    "TP. Hồ Chí Minh"
            };

            var mapView = new WebView2
            {
                Location = new Point(0, 120),
                Size = new Size(260, 130),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            leftPanel.Controls.Add(lblAddressTitle);
            leftPanel.Controls.Add(lblAddress);
            leftPanel.Controls.Add(mapView);

            mapView.CoreWebView2InitializationCompleted += (s, e) =>
            {
                if (e.IsSuccess)
                {
                    string html = @"
<html>
  <head><meta charset='UTF-8'></head>
  <body style='margin:0; padding:0;'>
    <iframe width='100%' height='100%' style='border:0;'
      src='https://www.google.com/maps?q=279+Nguyen+Tri+Phuong,+Quan+10,+TP+Ho+Chi+Minh&output=embed'
      allowfullscreen loading='lazy'></iframe>
  </body>
</html>";
                    mapView.CoreWebView2.NavigateToString(html);
                }
            };
            _ = mapView.EnsureCoreWebView2Async(null);

            // Cột 2: liên hệ
            var middlePanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            var lblContactTitle = new Label
            {
                AutoSize = true,
                Text = "Liên hệ nhà sách",
                Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            var lblEmailCaption = new Label
            {
                AutoSize = true,
                Text = "Email:",
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(0, 40)
            };

            var linkEmail = new LinkLabel
            {
                AutoSize = true,
                Text = "thuvienTuNhan@gmail.com",
                Font = new Font("Segoe UI", 13F, FontStyle.Underline),
                LinkColor = Color.FromArgb(37, 99, 235),
                ActiveLinkColor = Color.FromArgb(37, 99, 235),
                VisitedLinkColor = Color.FromArgb(37, 99, 235),
                Location = new Point(60, 40)
            };

            var lblPhoneCaption = new Label
            {
                AutoSize = true,
                Text = "Điện thoại:",
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(0, 70)
            };

            var lblPhone = new Label
            {
                AutoSize = true,
                Text = "028 7306 1976",
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(80, 70)
            };

            middlePanel.Controls.Add(lblContactTitle);
            middlePanel.Controls.Add(lblEmailCaption);
            middlePanel.Controls.Add(linkEmail);
            middlePanel.Controls.Add(lblPhoneCaption);
            middlePanel.Controls.Add(lblPhone);

            // Cột 3: các link
            var rightPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent
            };
            rightPanel.Controls.Add(CreateFooterLink("➤ Quy định mở cửa", "rules"));
            rightPanel.Controls.Add(CreateFooterLink("➤ Thời gian mở cửa", "hours"));
            rightPanel.Controls.Add(CreateFooterLink("➤ Không gian thư viện", "space"));
            rightPanel.Controls.Add(CreateFooterLink("➤ Hướng dẫn sử dụng thư viện", "guide"));

            layout.Controls.Add(leftPanel, 0, 0);
            layout.Controls.Add(middlePanel, 1, 0);
            layout.Controls.Add(rightPanel, 2, 0);

            footer.Controls.Add(layout);
            return footer;
        }

        private LinkLabel CreateFooterLink(string text, string tag)
        {
            var link = new LinkLabel
            {
                AutoSize = true,
                Text = text,
                Font = new Font("Segoe UI", 13F),
                LinkBehavior = LinkBehavior.NeverUnderline,
                LinkColor = Color.FromArgb(55, 65, 81),
                ActiveLinkColor = Color.FromArgb(37, 99, 235),
                VisitedLinkColor = Color.FromArgb(55, 65, 81),
                Margin = new Padding(0, 5, 0, 5),
                Tag = tag,
                Cursor = Cursors.Hand
            };
            link.LinkClicked += FooterLink_LinkClicked;
            return link;
        }

        private void FooterLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is not LinkLabel link || link.Tag is not string key) return;

            string title = "Thông tin nhà sách";
            string message;

            switch (key)
            {
                case "rules":
                    message =
@"QUY ĐỊNH MỞ CỬA / SỬ DỤNG KHÔNG GIAN

- Vui lòng gửi balo, túi xách lớn tại quầy gửi đồ.
- Không mang thức ăn, thức uống vào khu vực kệ sách và khu đọc.
- Giữ trật tự, hạn chế nói chuyện lớn tiếng.
- Không tự ý sắp xếp lại sách đã lấy khỏi kệ, hãy đặt vào xe đẩy để nhân viên xử lý.
- Giữ gìn tài sản chung, không ghi vẽ lên sách, bàn ghế và trang thiết bị.";
                    break;

                case "hours":
                    message =
@"THỜI GIAN MỞ CỬA

- Thứ 2 đến Thứ 6: 08:00 – 21:00
- Thứ 7, Chủ nhật: 08:00 – 22:00

Nhà sách vẫn phục vụ các ngày lễ,
trừ kỳ nghỉ Tết Nguyên Đán (sẽ thông báo cụ thể trên trang chủ).";
                    break;

                case "space":
                    message =
@"KHÔNG GIAN THƯ VIỆN / NHÀ SÁCH

- Khu vực kệ sách tổng hợp và sách thiếu nhi.
- Khu đọc yên tĩnh dành cho bạn đọc ngồi lại đọc sách.
- Góc tra cứu máy tính và truy cập Internet miễn phí.
- Một số bàn nhóm nhỏ dành cho học nhóm, thảo luận.";
                    break;

                case "guide":
                    message =
@"HƯỚNG DẪN SỬ DỤNG THƯ VIỆN

- Đăng ký làm thẻ thư viện để được mượn sách mang về.
- Hỏi nhân viên quầy thông tin nếu bạn cần gợi ý sách theo chủ đề.
- Sử dụng mục tra cứu trên máy tính để tìm sách theo tên, tác giả hoặc chủ đề.
- Tôn trọng không gian chung, hỗ trợ nhân viên giữ gìn trật tự và vệ sinh.";
                    break;

                default:
                    message = "Nội dung đang được cập nhật.";
                    break;
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void BannerTimer_Tick(object? sender, EventArgs e)
        {
            if (_bannerImages == null) return;
            ChangeBanner((_currentBannerIndex + 1) % _bannerImages.Length);
        }

        private void BtnPrevBanner_Click(object? sender, EventArgs e)
        {
            if (_bannerImages == null) return;
            ChangeBanner((_currentBannerIndex + _bannerImages.Length - 1) % _bannerImages.Length);
        }

        private void BtnNextBanner_Click(object? sender, EventArgs e)
        {
            if (_bannerImages == null) return;
            ChangeBanner((_currentBannerIndex + 1) % _bannerImages.Length);
        }

        private void Dot_Click(object? sender, EventArgs e)
        {
            if (sender is not Guna2Button dot) return;
            if (dot.Tag is not int idx) return;
            ChangeBanner(idx);
        }

        private void ChangeBanner(int newIndex)
        {
            if (_bannerImages == null || _bannerImages.Length == 0) return;
            if (_bannerPictureBox == null) return;

            if (newIndex < 0 || newIndex >= _bannerImages.Length) return;

            _currentBannerIndex = newIndex;
            _bannerPictureBox.Image = _bannerImages[_currentBannerIndex];

            _bannerTimer?.Stop();
            _bannerTimer?.Start();

            if (_dotButtons != null)
            {
                for (int i = 0; i < _dotButtons.Length; i++)
                    _dotButtons[i].FillColor = (i == _currentBannerIndex)
                        ? Color.FromArgb(26, 86, 219)
                        : Color.Silver;
            }
        }

        private void UpdateBannerUI()
        {
            if (_bannerImages == null || _bannerImages.Length == 0) return;
            if (_bannerPictureBox == null) return;

            _bannerPictureBox.Image = _bannerImages[_currentBannerIndex];

            if (_dotButtons != null)
            {
                for (int i = 0; i < _dotButtons.Length; i++)
                    _dotButtons[i].FillColor = (i == _currentBannerIndex)
                        ? Color.FromArgb(26, 86, 219)
                        : Color.Silver;
            }
        }

        // =====================================================================
        //                    TRANG CHỦ ADMIN – 2 CỘT HÀI HÒA
        // =====================================================================
        private void ShowLibraryHome()
        {
            if (panelContent == null) return;

            _bannerTimer?.Stop();

            panelContent.Resize -= PanelContent_Resize;
            panelContent.Controls.Clear();
            panelContent.AutoScroll = true;
            panelContent.BackColor = AdminBg;
            panelContent.Padding = new Padding(60, 120, 60, 40);

            // Lưới 2 cột
            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = AdminBg
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            var leftCol = CreateColumnStackPanel(); // Sách + Phòng
            var rightCol = CreateColumnStackPanel(); // Kho + Người đọc + Thống kê

            // Sections
            // Sections (mỗi thanh một màu riêng)
            var sectionSach = CreateSectionPanel(
                "SÁCH",
                new (string, EventHandler)[] {
        ("Đầu sách", OpenDauSach),
        ("Mượn sách", OpenMuonSach),
        ("Trả sách", OpenTraSach)
                },
                headerColor: Color.FromArgb(144, 213, 255) // xanh lam đậm
            );

            var sectionPhong = CreateSectionPanel(
                "PHÒNG",
                new (string, EventHandler)[] {
        ("Thông tin phòng", OpenThongTinPhong),
        ("Đơn đặt phòng", OpenDonDatPhong)
                },
                headerColor: Color.FromArgb(144, 213, 255) // royal blue
            );

            var sectionKho = CreateSectionPanel(
                "KHO",
                new (string, EventHandler)[] { ("Kho", OpenKho) },
                headerColor: Color.FromArgb(144, 213, 255) // tím
            );

            var sectionNguoiDoc = CreateSectionPanel(
                "NGƯỜI ĐỌC",
                new (string, EventHandler)[] { ("Người đọc", OpenNguoiDoc) },
                headerColor: Color.FromArgb(144, 213, 255)  // brand blue
            );

            var sectionThongKe = CreateSectionPanel(
                "THỐNG KÊ",
                new (string, EventHandler)[] { ("Thống kê", OpenThongKe) },
                headerColor: Color.FromArgb(144, 213, 255)  // xanh thiên thanh
            );


            // Đặt vào 2 cột
            leftCol.Controls.Add(sectionSach);
            leftCol.Controls.Add(CreateSpacer(24));
            leftCol.Controls.Add(sectionPhong);

            rightCol.Controls.Add(sectionKho);
            rightCol.Controls.Add(CreateSpacer(24));
            rightCol.Controls.Add(sectionNguoiDoc);
            rightCol.Controls.Add(CreateSpacer(24));
            rightCol.Controls.Add(sectionThongKe);

            grid.Controls.Add(leftCol, 0, 0);
            grid.Controls.Add(rightCol, 1, 0);

            var wrapper = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = AdminBg
            };
            wrapper.Controls.Add(grid);

            panelContent.Controls.Add(wrapper);
        }

        private FlowLayoutPanel CreateColumnStackPanel() =>
            new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = AdminBg,
                Margin = new Padding(0, 0, 20, 0)
            };

        private Control CreateSpacer(int h) =>
            new Panel { Width = 10, Height = h, BackColor = AdminBg, Margin = new Padding(0) };

        private Guna2Panel CreateSectionPanel(
    string title,
    (string text, EventHandler onClick)[] childButtons,
    Color? headerColor = null  // truyền màu riêng cho từng thanh
)
        {
            var section = new Guna2Panel
            {
                Width = 720,
                BorderRadius = 16,
                FillColor = AdminBg,
                Margin = new Padding(0),
                Padding = new Padding(0),
                Height = 56
            };
            section.ShadowDecoration.Enabled = false;
            section.ShadowDecoration.BorderRadius = 16;
            section.ShadowDecoration.Shadow = new Padding(0, 0, 8, 8);

            var header = new Guna2Button
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 56,
                BorderRadius = 16,
                Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Left,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand,
                FillColor = headerColor ?? SectionHeaderColor
            };
            header.HoverState.FillColor = headerColor ?? SectionHeaderHover;
            header.PressedColor = header.HoverState.FillColor;

            var body = new Panel
            {
                Dock = DockStyle.Top,
                Visible = false,
                BackColor = SectionBodyColor,
                Padding = new Padding(18, 12, 18, 18)
            };

            int top = 0;
            foreach (var (text, onClick) in childButtons)
            {
                var btn = new Guna2Button
                {
                    Text = text,
                    Width = 220,
                    Height = 38,
                    BorderRadius = 10,
                    FillColor = ChildBtnColor,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(10, top),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 10, 10)
                };
                btn.HoverState.FillColor = ChildBtnHover;
                btn.Click += onClick;
                body.Controls.Add(btn);
                top += 46;
            }
            body.Height = top + 6;

            var info = new AccordionSectionInfo
            {
                Body = body,
                Section = section,
                CollapsedHeight = header.Height,
                ExpandedHeight = header.Height + body.Height,
                IsExpanded = false,
                Timer = new System.Windows.Forms.Timer { Interval = 5 }
            };
            info.Timer.Tick += (s, e) => AnimateAccordion(info);

            header.Tag = info;
            header.Click += SectionHeader_Click;

            section.Controls.Add(body);
            section.Controls.Add(header);
            section.Height = info.CollapsedHeight;

            return section;
        }


        private void SectionHeader_Click(object? sender, EventArgs e)
        {
            if (sender is not Guna2Button header) return;
            if (header.Tag is not AccordionSectionInfo info) return;

            if (info.Timer.Enabled) return;

            info.IsExpanded = !info.IsExpanded;

            if (info.IsExpanded)
            {
                info.Body.Visible = true;
                info.Section.FillColor = Color.White;
                info.Section.ShadowDecoration.Enabled = true;
            }

            info.Timer.Start();
        }

        private void AnimateAccordion(AccordionSectionInfo info)
        {
            int step = 50; // càng nhỏ càng mượt, càng lớn càng nhanh

            if (info.IsExpanded)
            {
                if (info.Section.Height < info.ExpandedHeight)
                {
                    info.Section.Height = Math.Min(info.Section.Height + step, info.ExpandedHeight);
                }
                else
                {
                    info.Section.Height = info.ExpandedHeight;
                    info.Timer.Stop();
                }
            }
            else
            {
                if (info.Section.Height > info.CollapsedHeight)
                {
                    info.Section.Height = Math.Max(info.Section.Height - step, info.CollapsedHeight);
                }
                else
                {
                    info.Section.Height = info.CollapsedHeight;
                    info.Body.Visible = false;
                    info.Section.FillColor = AdminBg; // đồng bộ nền khi thu gọn
                    info.Section.ShadowDecoration.Enabled = false;
                    info.Timer.Stop();
                }
            }
        }

        // ================== HỖ TRỢ CARD CŨ (CHO FORM KHÁC NẾU CẦN) ==================
        private void PanelContent_Resize(object? sender, EventArgs e)
        {
            if (panelContent.Controls.Count > 0)
                CenterHomeCard(panelContent.Controls[0]);
        }

        private void CenterHomeCard(Control card)
        {
            if (card == null) return;

            int x = (panelContent.ClientSize.Width - card.Width) / 2;
            int y = (panelContent.ClientSize.Height - card.Height) / 2;
            if (y < 20) y = 20;

            card.Location = new Point(x, y);
        }

        // ================== CÁC NÚT THANH TRÊN – GIỮ NGUYÊN ==================
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(btnSach, 0, btnSach.Height);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (!string.Equals(_vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Chức năng thống kê chỉ dành cho tài khoản Admin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            panelContent.Controls.Clear();
            var tk = new ThongKeControl();
            tk.Dock = DockStyle.Fill;
            panelContent.Controls.Add(tk);
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnPhong, 0, btnPhong.Height);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // mở form kho nếu muốn
        }

        private void btnNguoiDoc_Click(object sender, EventArgs e)
        {
            // mở người đọc nếu muốn
        }

        private void btnTheThuVien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_username))
            {
                MessageBox.Show("Không xác định được tài khoản đang đăng nhập.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var frm = new fTheThuVien(_username))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        // Logo
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (string.Equals(_vaiTro, "KhachHang", StringComparison.OrdinalIgnoreCase))
                ShowCustomerHome();
            else
                ShowLibraryHome();
        }

        // Chữ "Thư viện Alpha"
        private void label1_Click(object sender, EventArgs e)
        {
            if (string.Equals(_vaiTro, "KhachHang", StringComparison.OrdinalIgnoreCase))
                ShowCustomerHome();
            else
                ShowLibraryHome();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var loginForm = new fLogin();
                loginForm.Show();
                this.Close();
            }
        }

        // ================== FORM CON – THÔNG TIN CÁ NHÂN ==================
        private void btnThongTinCN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_username))
            {
                MessageBox.Show("Không xác định được tài khoản đang đăng nhập.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var frm = new fThongTinCaNhan(_username))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        // =============== HÀM STUB CHO CÁC NÚT CON TRONG ACCORDION ===============
        private void OpenDauSach(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình Đầu sách (bạn gắn form thật vào đây).");
        }

        private void OpenMuonSach(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình Mượn sách (bạn gắn form thật vào đây).");
        }

        private void OpenTraSach(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình Trả sách (bạn gắn form thật vào đây).");
        }

        private void OpenThongTinPhong(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình Thông tin phòng (bạn gắn form thật vào đây).");
        }

        private void OpenDonDatPhong(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình Đơn đặt phòng (bạn gắn form thật vào đây).");
        }

        private void OpenKho(object? sender, EventArgs e)
        {
            guna2Button1_Click_1(btnKho, EventArgs.Empty);
        }

        private void OpenNguoiDoc(object? sender, EventArgs e)
        {
            btnNguoiDoc_Click(btnNguoiDoc, EventArgs.Empty);
        }

        private void OpenThongKe(object? sender, EventArgs e)
        {
            btnThongKe_Click(btnThongKe, EventArgs.Empty);
        }
    }
}
