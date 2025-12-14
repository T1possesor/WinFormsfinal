using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace WinFormsfinal
{
    public partial class fNewsDetail : Form
    {
        private readonly int _newsId;

        public fNewsDetail(int newsId)
        {
            _newsId = newsId;
            InitializeComponent();
            LoadNews();
        }

        private void LoadNews()
        {
            string title = "";
            string date = "";
            string content = "";

            switch (_newsId)
            {
                case 1:
                    title = "Khai trương không gian đọc mới";
                    date = "Ngày đăng: 10/10/2024";
                    content =
@"Thư viện tư nhân Alpha chính thức khai trương không gian đọc mới hiện đại, 
thân thiện và gần gũi với bạn đọc.

Không gian mới được thiết kế mở, tận dụng tối đa ánh sáng tự nhiên, 
kết hợp khu đọc sách yên tĩnh với khu trao đổi.";

                    picNews.Image = Properties.Resources.new_1;
                    break;

                case 2:
                    title = "Ngày hội đổi sách cuối tuần";
                    date = "Ngày đăng: 15/10/2024";
                    content =
@"Nhằm khuyến khích văn hóa đọc, Thư viện Alpha tổ chức 
'Ngày hội đổi sách' cho toàn bộ bạn đọc.";

                    picNews.Image = Properties.Resources.new_2;
                    break;

                case 3:
                    title = "Workshop kỹ năng truy tìm tài liệu khoa học";
                    date = "Ngày đăng: 20/10/2024";
                    content =
@"Workshop kỹ năng truy tìm tài liệu khoa học 
dành cho sinh viên và học viên cao học.";

                    picNews.Image = Properties.Resources.new_3;
                    break;

                default:
                    title = "Tin tức thư viện";
                    content = "Không tìm thấy tin tức.";
                    picNews.Image = null;
                    break;
            }

            this.Text = title;
            lblTitle.Text = title;
            lblDate.Text = date;
            txtContent.Text = content;

            if (picNews.Image != null)
                picNews.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
