using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.IO;
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
            // Đường dẫn thư mục chứa ảnh
            // NHỚ chỉnh cho đúng với đường dẫn thật trong máy bạn
            string basePath = @"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database";

            string title = "";
            string date = "";
            string content = "";
            string imageFile = "";

            switch (_newsId)
            {
                case 1:
                    title = "Khai trương không gian đọc mới";
                    date = "Ngày đăng: 10/10/2024";
                    imageFile = "new_1.jpg";
                    content =
@"Thư viện tư nhân Alpha chính thức khai trương không gian đọc mới hiện đại, 
thân thiện và gần gũi với bạn đọc.

Không gian mới được thiết kế mở, tận dụng tối đa ánh sáng tự nhiên, 
kết hợp khu đọc sách yên tĩnh với khu trao đổi, thảo luận nhóm.

Một số điểm nổi bật:
- Hơn 2.000 đầu sách mới được bổ sung
- Khu vực đọc sách cho thiếu nhi
- Góc đọc truyện tranh – manga/graphic novel
- Khu tự học với ổ cắm điện và Wi-Fi tốc độ cao

Trong tuần lễ khai trương, bạn đọc đến tham quan và làm thẻ thư viện 
sẽ được miễn phí phí làm thẻ và tặng kèm một bookmark xinh xắn.";
                    break;

                case 2:
                    title = "Ngày hội đổi sách cuối tuần";
                    date = "Ngày đăng: 15/10/2024";
                    imageFile = "new_2.jpg";
                    content =
@"Nhằm khuyến khích văn hóa đọc và chia sẻ tri thức, Thư viện Alpha tổ chức 
'Ngày hội đổi sách' dành cho tất cả bạn đọc thân thiết.

Thời gian:
- 8h00 – 17h00, Chủ nhật ngày 20/10/2024

Địa điểm:
- Sảnh chính Thư viện tư nhân Alpha

Nội dung chính:
- Bạn mang từ 1–5 cuốn sách còn tốt (không rách, không mất trang)
- Nhận lại phiếu đổi sách tương ứng
- Dùng phiếu để đổi những cuốn sách do bạn đọc khác mang đến
- Khu vực giới thiệu sách hay, best-seller và sách kỹ năng sống

Đây là dịp để sách cũ tìm được chủ nhân mới, và bạn đọc có thể khám phá 
nhiều đầu sách thú vị mà không tốn thêm chi phí.";
                    break;

                case 3:
                    title = "Workshop kỹ năng truy tìm tài liệu khoa học";
                    date = "Ngày đăng: 20/10/2024";
                    imageFile = "new_3.jpg";
                    content =
@"Workshop 'Kỹ năng truy tìm tài liệu khoa học' giúp bạn đọc, đặc biệt là 
sinh viên và học viên cao học, biết cách tìm kiếm tài liệu một cách 
nhanh chóng và chính xác.

Một số nội dung chính:
- Phân biệt các loại tài liệu: sách, bài báo khoa học, luận văn, luận án...
- Cách sử dụng từ khóa (keywords) hiệu quả
- Giới thiệu các cơ sở dữ liệu tài liệu khoa học miễn phí và trả phí
- Kỹ năng đánh giá độ tin cậy của tài liệu
- Thực hành tìm kiếm trực tiếp trên máy tính tại phòng tra cứu

Sau buổi workshop, người tham dự sẽ nắm được quy trình cơ bản để tự tìm kiếm 
và trích dẫn tài liệu khoa học phục vụ học tập và nghiên cứu.";
                    break;

                default:
                    title = "Tin tức thư viện";
                    date = "";
                    imageFile = "";
                    content = "Không tìm thấy nội dung tin tức tương ứng.";
                    break;
            }

            this.Text = title;
            lblTitle.Text = title;
            lblDate.Text = date;
            txtContent.Text = content;

            // Load ảnh nếu có
            try
            {
                if (!string.IsNullOrEmpty(imageFile))
                {
                    string fullPath = Path.Combine(basePath, imageFile);
                    if (File.Exists(fullPath))
                    {
                        picNews.Image = Image.FromFile(fullPath);
                    }
                }
            }
            catch
            {
                // Nếu lỗi load ảnh thì bỏ qua, giữ trống
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
