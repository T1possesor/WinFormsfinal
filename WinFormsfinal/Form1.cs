using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsfinal
{
    public partial class Form1 : Form
    {
        // Lưu vai trò của tài khoản đang đăng nhập
        private readonly string _vaiTro = string.Empty;


        // Constructor mặc định (dùng cho Designer)
        public Form1()
        {
            InitializeComponent();
            // đảm bảo thanh menu nằm trên panelContent
            guna2Panel1.BringToFront();
        }

        // Constructor nhận VaiTro từ form đăng nhập
        public Form1(string vaiTro) : this()
        {
            _vaiTro = vaiTro ?? string.Empty;
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

            // Chỉ cho Admin thấy nút Thống kê
            if (!string.Equals(_vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnThongKe.Visible = false;
            }
        }



        /// <summary>
        /// Trang chủ khách hàng: Giới thiệu + quy định làm thẻ thư viện
        /// </summary>
        private void ShowCustomerHome()
        {
            if (panelContent == null) return;

            panelContent.Controls.Clear();

            var card = new Guna2Panel
            {
                BorderRadius = 20,
                FillColor = Color.White,
                Size = new Size(900, 480),
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.BorderRadius = 20;
            card.ShadowDecoration.Shadow = new Padding(0, 0, 10, 10);

            // ----- Tiêu đề -----
            var lblHello = new Label
            {
                AutoSize = true,
                Text = "Xin chào khách hàng!",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 64, 175),
                Location = new Point(30, 25)
            };

            var lblTitle = new Label
            {
                AutoSize = true,
                Text = "Thẻ thư viện – Thư viện Alpha",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 0, 90),
                Location = new Point(30, 65)
            };

            // ----- Giới thiệu -----
            var lblIntro = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(840, 0),
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(30, 115),
                Text =
                    "Thẻ thư viện giúp bạn mượn sách, đặt phòng học nhóm và sử dụng toàn bộ dịch vụ " +
                    "tại Thư viện Alpha. Mỗi bạn đọc chỉ được sở hữu một thẻ duy nhất và thẻ " +
                    "được dùng để xác nhận thông tin khi giao dịch tại quầy."
            };

            // ----- Quy trình -----
            var lblStepTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 80, 160),
                Location = new Point(30, 175),
                Text = "Quy trình làm thẻ thư viện"
            };

            var lblSteps = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(840, 0),
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(45, 205),
                Text =
                    "• Bước 1: Đăng ký tài khoản trên hệ thống (bạn đã hoàn thành bước này).\n" +
                    "• Bước 2: Đến quầy thủ thư, xuất trình CMND/CCCD hoặc thẻ sinh viên để xác nhận.\n" +
                    "• Bước 3: Chụp ảnh thẻ và ký xác nhận thông tin cá nhân.\n" +
                    "• Bước 4: Nhận thẻ thư viện, thời hạn sử dụng tối đa 2–4 năm tùy đối tượng."
            };

            // ----- Quy định -----
            var lblRuleTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 80, 160),
                Location = new Point(30, 285),
                Text = "Quy định sử dụng thẻ"
            };

            var lblRules = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(840, 0),
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(45, 315),
                Text =
                    "• Thẻ là tài sản của thư viện, bạn có trách nhiệm bảo quản cẩn thận.\n" +
                    "• Không cho người khác mượn thẻ để mượn sách hoặc sử dụng dịch vụ.\n" +
                    "• Khi thẻ hư hỏng/mất, cần báo ngay cho thư viện để được cấp lại.\n" +
                    "• Mang thẻ khi vào thư viện, đặc biệt khi mượn – trả tài liệu hoặc đặt phòng.\n" +
                    "• Tuân thủ nội quy phòng đọc, giữ gìn trật tự và bảo vệ tài sản chung."
            };

            // ----- Nút hướng dẫn -----
            var btnHuongDan = new Guna2Button
            {
                BorderRadius = 12,
                FillColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(220, 36),
                Location = new Point(30, 425),
                Text = "Xem hướng dẫn chi tiết…"
            };
            btnHuongDan.Click += (s, e) =>
            {
                MessageBox.Show(
                    "Khi đến thư viện, bạn chỉ cần mang theo giấy tờ tùy thân (CMND/CCCD/thẻ SV)." +
                    "\nNhân viên thư viện sẽ hỗ trợ bạn hoàn tất thủ tục trong vài phút.",
                    "Hướng dẫn làm thẻ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            card.Controls.Add(lblHello);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblIntro);
            card.Controls.Add(lblStepTitle);
            card.Controls.Add(lblSteps);
            card.Controls.Add(lblRuleTitle);
            card.Controls.Add(lblRules);
            card.Controls.Add(btnHuongDan);

            panelContent.Controls.Add(card);
            CenterHomeCard(card);

            panelContent.Resize -= PanelContent_Resize;
            panelContent.Resize += PanelContent_Resize;
        }


        /// <summary>
        /// Trang chủ giới thiệu thư viện (hiển thị khi bấm vào logo)
        /// </summary>
        /// <summary>
        /// Trang chủ giới thiệu thư viện (full màn hình trong panelContent)
        /// </summary>
        /// <summary>
        /// Trang chủ giống giao diện web: banner trên + 3 thẻ dịch vụ bên dưới
        /// </summary>
        private void ShowLibraryHome()
        {
            panelContent.Controls.Clear();
            var home = new HomeControl();
            home.Dock = DockStyle.Fill;
            panelContent.Controls.Add(home);
        }











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

        // ================== CÁC SỰ KIỆN MENU CŨ ==================
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(btnSach, 0, btnSach.Height);
        }
        private void btnThongKe_Click(object sender, EventArgs e)
{
    // Chỉ Admin mới xem được
    if (!string.Equals(_vaiTro, "Admin", StringComparison.OrdinalIgnoreCase))
    {
        MessageBox.Show(
            "Chức năng thống kê chỉ dành cho tài khoản Admin.",
            "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        return;
    }

    // XÓA sạch các control cũ trong panelContent
    panelContent.Controls.Clear();

    // Tạo ThongKeControl và cho nó chiếm toàn bộ panelContent
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
        }

        private void btnNguoiDoc_Click(object sender, EventArgs e)
        {
        }

        // Nút "Làm thẻ thư viện"
        private void btnTheThuVien_Click(object sender, EventArgs e)
        {
            ShowCustomerHome();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ShowLibraryHome();
        }
    }
}
