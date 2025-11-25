using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormChiTietSach : Form
    {
       
        private string maSachCanXem; // Biến lưu mã sách được truyền vào

        // Constructor bắt buộc phải nhận vào Mã sách để biết cần hiển thị sách nào
        public FormChiTietSach(string maSach)
        {
            InitializeComponent();
            this.maSachCanXem = maSach;

            // Đăng ký sự kiện click cho nút Đóng
            btnDong.Click += (s, e) => this.Close();
            // Đăng ký sự kiện Load form để tải dữ liệu
            this.Load += FormChiTietSach_Load;
        }

        private void FormChiTietSach_Load(object sender, EventArgs e)
        {
            // Chỉ tải thông tin nếu mã sách hợp lệ
            if (!string.IsNullOrEmpty(maSachCanXem))
            {
                TaiThongTinChiTiet(maSachCanXem);
            }
        }

        // Hàm chính để tải và hiển thị toàn bộ thông tin chi tiết của sách
        private void TaiThongTinChiTiet(string maSach)
        {
            try
            {
                // Sử dụng chuỗi kết nối chung từ Program.cs
                using (var conn = new SqliteConnection("Data Source=project_final.db"))
                {
                    conn.Open();
                    // Truy vấn LẤY TẤT CẢ thông tin (*) từ bảng Sach theo Mã sách
                    var cmd = new SqliteCommand("SELECT * FROM Sach WHERE MaSach = @id", conn);
                    cmd.Parameters.AddWithValue("@id", maSach);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy sách
                        {
                            // Gán tên sách vào tiêu đề lớn
                            lblTenSach.Text = reader["TenSach"].ToString();

                            // Gán từng trường thông tin vào các label riêng biệt
                            // Sử dụng thẻ <b> của HTML để in đậm phần tiêu đề
                            lblMaSach.Text = $"<b>Mã sách:</b> {reader["MaSach"]}";
                            lblTacGia.Text = $"<b>Tác giả:</b> {reader["TacGia"]}";
                            // Kết hợp NXB và Năm XB vào một dòng
                            lblNhaXuatBan.Text = $"<b>Nhà xuất bản:</b> {reader["NhaXuatBan"]} ({reader["NamXuatBan"]})";
                            lblTheLoai.Text = $"<b>Thể loại:</b> {reader["TheLoai"]}";
                            lblViTri.Text = $"<b>Vị trí kệ:</b> {reader["ViTriKeSach"]}";
                            lblSoLuong.Text = $"<b>Số lượng còn lại:</b> {reader["SoLuongConLai"]}";

                            // Xử lý và hiển thị trạng thái
                            string trangThai = reader["TrangThaiMuon"].ToString();
                            lblTrangThai.Text = $"<b>Trạng thái:</b> {trangThai}";
                            // Đổi màu chữ trạng thái: Xanh nếu "Có sẵn", Đỏ nếu khác
                            lblTrangThai.ForeColor = (trangThai == "Sẵn có") ? Color.Green : Color.Red;

                            // Gán mô tả vào Label tự động giãn dòng.
                            // Thay thế ký tự xuống dòng (\n) bằng thẻ <br/> của HTML để hiển thị đúng.
                            lblMoTaChiTiet.Text = reader["MoTa"].ToString().Replace("\n", "<br/>");
                            lblMoTaChiTiet.MaximumSize = new Size(400, 0);

                            // Gọi hàm để tải và hiển thị ảnh bìa
                            HienThiAnhBia(reader["AnhBiaURL"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải chi tiết sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý việc tải ảnh bìa từ đường dẫn
        private void HienThiAnhBia(string relativePath)
        {
            // Nếu không có đường dẫn ảnh trong DB, xóa ảnh hiện tại
            if (string.IsNullOrEmpty(relativePath))
            {
                pbAnhBia.Image = null; // Có thể thay bằng ảnh mặc định "No Image" nếu muốn
                return;
            }

            try
            {
                // Tạo đường dẫn tuyệt đối bằng cách kết hợp thư mục chạy ứng dụng với đường dẫn tương đối
                string fullPath = Path.Combine(Application.StartupPath, relativePath);

                // Kiểm tra xem file ảnh có thực sự tồn tại ở đường dẫn đó không
                if (File.Exists(fullPath))
                {
                    // Sử dụng FileStream để đọc ảnh. Cách này giúp không bị khóa file ảnh trên đĩa.
                    using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        pbAnhBia.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    pbAnhBia.Image = null; // File không tồn tại
                }
            }
            catch
            {
                // Nếu có bất kỳ lỗi gì khi nạp ảnh (file hỏng, lỗi quyền truy cập...), thì không hiện ảnh
                pbAnhBia.Image = null;
            }
        }
    }

}
