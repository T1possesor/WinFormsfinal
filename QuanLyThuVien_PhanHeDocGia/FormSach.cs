using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormSach : Form
    {
        private ContextMenuStrip ctxMenuSach;
        // Khai báo cái mục "Xem chi tiết" nằm trên menu
        private ToolStripMenuItem mnuXemChiTiet;
       
        public FormSach()
        {
            InitializeComponent();
            // Đăng ký các sự kiện ngay khi khởi tạo form
            CaiDatSuKien();
            KhoiTaoContextMenu();
        }
        private void KhoiTaoContextMenu()
        {
            // 1. Khởi tạo 2 món đồ đã khai báo ở Bước 1
            ctxMenuSach = new ContextMenuStrip();
            mnuXemChiTiet = new ToolStripMenuItem();

            // 2. Đặt tên hiển thị cho mục menu
            mnuXemChiTiet.Text = "Xem chi tiết sách này";

            // 3. Quan trọng: Gán sự kiện Click.
            // Nghĩa là: khi bấm vào mục này thì chạy hàm MnuXemChiTiet_Click (sẽ viết ở bước 4)
            mnuXemChiTiet.Click += MnuXemChiTiet_Click;

            // 4. Bỏ mục menu vào trong cái thực đơn chứa
            ctxMenuSach.Items.Add(mnuXemChiTiet);
        }

        // Hàm tập trung đăng ký các sự kiện
        private void CaiDatSuKien()
        {
            this.Load += FormSach_Load;
            // Tự động tải lại danh sách khi nhập từ khóa tìm kiếm
            txtTimKiem.TextChanged += (s, e) => TaiDanhSachSach();
            // Tự động tải lại danh sách khi chọn thể loại khác
            cmbTheLoai.SelectedIndexChanged += (s, e) => TaiDanhSachSach();
            // Sự kiện double click vào dòng để xem chi tiết
            dgvSach.CellDoubleClick += DgvSach_CellDoubleClick;
            dgvSach.CellMouseDown += DgvSach_CellMouseDown;
        }
        private void DgvSach_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // e.Button: Nút chuột nào được nhấn?
            // e.RowIndex: Chỉ số dòng (nếu < 0 nghĩa là nhấn vào tiêu đề cột)
            // e.ColumnIndex: Chỉ số cột

            // Kiểm tra 3 điều kiện:
            // 1. Phải là nút chuột PHẢI (Right)
            // 2. Phải nhấn vào dòng dữ liệu (RowIndex >= 0) chứ không phải tiêu đề
            // 3. Phải nhấn vào vùng cột hợp lệ (ColumnIndex >= 0)
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
               
                dgvSach.ClearSelection(); // Bỏ chọn cũ
                dgvSach.Rows[e.RowIndex].Selected = true; // Chọn dòng vừa nhấn chuột phải

                // Lệnh quan trọng: Hiện menu tại vị trí con trỏ chuột trên màn hình
                ctxMenuSach.Show(Cursor.Position);
            }
        }
        private void MnuXemChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra cho chắc là có dòng nào đó đang được chọn
            if (dgvSach.SelectedRows.Count > 0)
            {
                // 1. Lấy dòng đang chọn (dòng đầu tiên trong danh sách chọn)
                DataGridViewRow selectedRow = dgvSach.SelectedRows[0];

                // 2. Lấy giá trị của ô ở cột "MaSach" trong dòng đó
                string maSach = selectedRow.Cells["MaSach"].Value.ToString();

                // 3. Tạo và mở form chi tiết
                FormChiTietSach frm = new FormChiTietSach(maSach);
                frm.ShowDialog();
            }
        }
        private void FormSach_Load(object sender, EventArgs e)
        {
            // Khi form load, tải dữ liệu cho combobox và lưới
            LoadComboBoxTheLoai();
            TaiDanhSachSach();
        }

        // Tải danh sách các thể loại duy nhất vào ComboBox để lọc
        private void LoadComboBoxTheLoai()
        {
            cmbTheLoai.Items.Clear();
            cmbTheLoai.Items.Add("Tất cả"); // Mục mặc định
            try
            {
                // Sử dụng chuỗi kết nối chung từ Program.cs
                using (var conn = new SqliteConnection("Data Source=project_final.db"))
                {
                    conn.Open();
                    // Lấy các thể loại không trùng lặp, không null và không rỗng
                    var cmd = new SqliteCommand("SELECT DISTINCT TheLoai FROM Sach WHERE TheLoai IS NOT NULL AND TheLoai != '' ORDER BY TheLoai", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) cmbTheLoai.Items.Add(reader["TheLoai"].ToString());
                    }
                }
            }
            catch { /* Có thể log lỗi ở đây nếu cần, nhưng không nên hiện messagebox làm phiền người dùng */ }
            cmbTheLoai.SelectedIndex = 0; // Chọn mục "Tất cả" ban đầu
        }

        // Hàm hỗ trợ: Chuyển chuỗi tiếng Việt có dấu thành không dấu và chữ thường
        // Hàm hỗ trợ: Chuyển chuỗi tiếng Việt có dấu thành không dấu và chữ thường (ĐÃ SỬA LỖI)
        private string LoaiBoDauTiengViet(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            // Chuẩn hóa chuỗi sang dạng FormD (tách ký tự và dấu)
            // ĐÃ SỬA: Thêm System.Text. trước NormalizingForm
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            ;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                // Lọc bỏ các ký tự là dấu
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Chuẩn hóa lại về FormC và chuyển sang chữ thường
            // ĐÃ SỬA: Thêm System.Text. trước NormalizingForm
            return stringBuilder.ToString().Normalize(NormalizationForm.FormD).ToLower();
        }

        private void TaiDanhSachSach()
        {
            // 1. Lấy và chuẩn hóa từ khóa tìm kiếm (ví dụ: "Lập" -> "lap")
            string tuKhoaGoc = txtTimKiem.Text.Trim();
            string tuKhoaChuanHoa = LoaiBoDauTiengViet(tuKhoaGoc);

            string theLoaiLoc = cmbTheLoai.SelectedItem?.ToString();

            // 2. Tạo câu truy vấn SQL cơ bản (CHỈ LỌC THEO THỂ LOẠI TRONG SQL)
            string query = "SELECT MaSach, TenSach, TacGia, TheLoai, NamXuatBan, ViTriKeSach, TrangThaiMuon FROM Sach WHERE 1=1 ";

            // Nếu có chọn thể loại thì thêm điều kiện vào SQL
            bool coLocTheLoai = !string.IsNullOrEmpty(theLoaiLoc) && theLoaiLoc != "Tất cả";
            if (coLocTheLoai)
            {
                query += " AND TheLoai = @tl";
            }

            try
            {
                dgvSach.SuspendLayout();
                using (var conn = new SqliteConnection("Data Source=project_final.db"))
                {
                    conn.Open();
                    var cmd = new SqliteCommand(query, conn);

                    if (coLocTheLoai)
                    {
                        cmd.Parameters.AddWithValue("@tl", theLoaiLoc);
                    }

                    // 3. Tải dữ liệu từ DB vào DataTable
                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    // 4. LỌC DỮ LIỆU TRONG BỘ NHỚ (C#) NẾU CÓ TỪ KHÓA TÌM KIẾM
                    if (!string.IsNullOrEmpty(tuKhoaChuanHoa))
                    {
                        // Sử dụng LINQ để lọc
                        var rowsDaLoc = dt.AsEnumerable()
                            .Where(row =>
                            {
                                // Lấy tên sách và tác giả, chuẩn hóa chúng
                                string tenSachChuanHoa = LoaiBoDauTiengViet(row.Field<string>("TenSach"));
                                string tacGiaChuanHoa = LoaiBoDauTiengViet(row.Field<string>("TacGia"));

                                // Kiểm tra xem có BẮT ĐẦU BẰNG từ khóa đã chuẩn hóa không
                                return tenSachChuanHoa.StartsWith(tuKhoaChuanHoa) ||
                                       tacGiaChuanHoa.StartsWith(tuKhoaChuanHoa);
                            });

                        // Tạo bảng mới từ kết quả lọc
                        if (rowsDaLoc.Any())
                        {
                            dt = rowsDaLoc.CopyToDataTable();
                        }
                        else
                        {
                            // Không tìm thấy thì xóa hết dòng trong bảng
                            dt.Rows.Clear();
                        }
                    }

                    // 5. Gán dữ liệu đã lọc lên lưới
                    dgvSach.DataSource = dt;
                    CauHinhCotGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvSach.ResumeLayout();
            }
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSach.ColumnHeadersHeight = 40;
        }

        // Cấu hình tiêu đề và độ rộng cho các cột trên DataGridView
        private void CauHinhCotGrid()
        {
            // Kiểm tra null để tránh lỗi nếu cột chưa được tạo
            if (dgvSach.Columns["MaSach"] != null) { dgvSach.Columns["MaSach"].HeaderText = "Mã Sách"; dgvSach.Columns["MaSach"].Width = 80; }
            if (dgvSach.Columns["TenSach"] != null) { dgvSach.Columns["TenSach"].HeaderText = "Tên Sách"; dgvSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } // Tên sách tự giãn
            if (dgvSach.Columns["TacGia"] != null) { dgvSach.Columns["TacGia"].HeaderText = "Tác Giả"; dgvSach.Columns["TacGia"].Width = 150; }
            if (dgvSach.Columns["TheLoai"] != null) dgvSach.Columns["TheLoai"].HeaderText = "Thể Loại";
            if (dgvSach.Columns["NamXuatBan"] != null) dgvSach.Columns["NamXuatBan"].HeaderText = "Năm XB";
            if (dgvSach.Columns["ViTriKeSach"] != null) dgvSach.Columns["ViTriKeSach"].HeaderText = "Vị Trí";
            if (dgvSach.Columns["TrangThaiMuon"] != null) dgvSach.Columns["TrangThaiMuon"].HeaderText = "Trạng Thái Mượn";
        }

        // Xử lý sự kiện double-click vào một dòng trên lưới
        private void DgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào dòng dữ liệu hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy mã sách từ cột "MaSach" của dòng được chọn
                string maSach = dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                // Tạo và mở form chi tiết, truyền mã sách qua
                FormChiTietSach frm = new FormChiTietSach(maSach);
                frm.ShowDialog(); // Mở dưới dạng dialog (cửa sổ con)
            }
        }
    }
}
