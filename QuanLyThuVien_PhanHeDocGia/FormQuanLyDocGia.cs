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
using System.Globalization;


namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormQuanLyDocGia : Form
    {
        private string connectionString;
        // Hàm hỗ trợ: Chuyển chuỗi tiếng Việt có dấu thành không dấu và chữ thường
        private string LoaiBoDauTiengViet(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            // Chuẩn hóa chuỗi sang dạng FormD và dùng StringBuilder
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Chuẩn hóa lại về FormC và chuyển sang chữ thường
            return stringBuilder.ToString().Normalize(NormalizationForm.FormD).ToLower();
        }
        public FormQuanLyDocGia()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Application.StartupPath, "project_final.db");
            connectionString = $"Data Source={dbPath};";

            CaiDatSuKien();
            //TaiDanhSachDocGia();
        }

        private void labelTieuDe_Click(object sender, EventArgs e)
        {

        }
        private void FormQuanLyDocGia_Load(object sender, EventArgs e)
        {
            // Gọi tải dữ liệu khi Form đã hoàn tất quá trình khởi tạo và sẵn sàng hiển thị
            TaiDanhSachDocGia();
        }
        private void CaiDatSuKien()
        {
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;
            textBoxTimKiem.TextChanged += (s, e) => TaiDanhSachDocGia();
            comboBoxTrangThai.SelectedIndexChanged += (s, e) => TaiDanhSachDocGia();

            // Xử lý phím tắt
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Application.Exit(); };
            menuItemSua.Click += MenuItemSua_Click;
            menuItemXoa.Click += MenuItemXoa_Click;
            this.Load += FormQuanLyDocGia_Load;
            // Quan trọng: Chọn dòng khi click chuột phải
            gridViewDocGia.CellMouseDown += gridViewDocGia_CellMouseDown;

            // Khởi tạo comboBoxTrangThai với các lựa chọn tiếng Việt
            comboBoxTrangThai.Items.Clear();
            comboBoxTrangThai.Items.Add("Tất cả");
            comboBoxTrangThai.Items.Add("Hoạt động");
            comboBoxTrangThai.Items.Add("Bị khóa");
            comboBoxTrangThai.SelectedIndex = 0; // Chọn "Tất cả" mặc định
        }
        private void gridViewDocGia_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Chọn dòng hiện tại khi click chuột phải
                gridViewDocGia.ClearSelection(); // Bỏ chọn các dòng khác
                gridViewDocGia.Rows[e.RowIndex].Selected = true; // Chọn dòng click chuột phải
                                                                 // Không cần hiện contextMenuDocGia.Show() ở đây, vì nó đã được gán cho DataGridView rồi.
                                                                 // DataGridView sẽ tự động hiển thị context menu khi chuột phải.
            }
        }

        private void MenuItemSua_Click(object sender, EventArgs e)
        {
            // Tái sử dụng logic của buttonSua_Click
            ButtonSua_Click(sender, e);
        }

        private void MenuItemXoa_Click(object sender, EventArgs e)
        {
            // Tái sử dụng logic của buttonXoa_Click
            ButtonXoa_Click(sender, e);
        }

        private void TaiDanhSachDocGia()
        {
            // 1. CHUẨN HÓA TỪ KHÓA TÌM KIẾM NGAY TỪ ĐẦU
            string tuKhoaGoc = textBoxTimKiem.Text.Trim();
            // Chuyển từ khóa sang dạng không dấu, chữ thường (ví dụ: "Nguyễn" -> "nguyen")
            string tuKhoaChuanHoa = LoaiBoDauTiengViet(tuKhoaGoc);

            string trangThaiLoc = comboBoxTrangThai.SelectedItem?.ToString();

            // 2. CÂU TRUY VẤN SQL: CHỈ CÒN LỌC THEO TRẠNG THÁI
            // (Đã loại bỏ phần tìm kiếm LIKE @kw trong SQL)
            string query = "SELECT MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, TrangThai FROM NguoiDung WHERE 1=1 ";

            // Phần lọc trạng thái giữ nguyên vì nó là so sánh chính xác
            if (!string.IsNullOrEmpty(trangThaiLoc) && trangThaiLoc != "Tất cả")
            {
                query += " AND TrangThai = @tt";
            }

            try
            {
                gridViewDocGia.SuspendLayout();
                this.SuspendLayout();
                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqliteCommand(query, conn);

                    // (Đã bỏ dòng thêm parameter @kw)

                    if (!string.IsNullOrEmpty(trangThaiLoc) && trangThaiLoc != "Tất cả")
                    {
                        string trangThaiDB = trangThaiLoc == "Hoạt động" ? "HoatDong" : "BiKhoa";
                        cmd.Parameters.AddWithValue("@tt", trangThaiDB);
                    }

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    // 3. THỰC HIỆN TÌM KIẾM TRONG BỘ NHỚ (C#) BẰNG LINQ
                    // Chỉ thực hiện nếu có từ khóa tìm kiếm
                    if (!string.IsNullOrEmpty(tuKhoaChuanHoa))
                    {
                        var rowsDaLoc = dt.AsEnumerable().Where(row =>
                        {
                            // Lấy dữ liệu từ các cột cần tìm và chuẩn hóa chúng
                            // Sử dụng (?? "") để đảm bảo không bị lỗi nếu dữ liệu trong DB là null
                            string hoTenNorm = LoaiBoDauTiengViet(row.Field<string>("HoTen") ?? "");
                            string maSoTheNorm = LoaiBoDauTiengViet(row.Field<string>("MaSoThe") ?? "");
                            string sdtNorm = LoaiBoDauTiengViet(row.Field<string>("SoDienThoai") ?? "");

                            // Kiểm tra xem có cột nào CHỨA từ khóa đã chuẩn hóa không
                            // Dùng .Contains() để tìm kiểu "chứa trong" (tương tự %...%)
                            return hoTenNorm.Contains(tuKhoaChuanHoa) ||
                                   maSoTheNorm.Contains(tuKhoaChuanHoa) ||
                                   sdtNorm.Contains(tuKhoaChuanHoa);
                        });

                        // Tạo một DataTable mới từ các dòng đã lọc được
                        if (rowsDaLoc.Any())
                        {
                            dt = rowsDaLoc.CopyToDataTable();
                        }
                        else
                        {
                            // Nếu không tìm thấy dòng nào thì xóa trắng bảng
                            dt.Rows.Clear();
                        }
                    }

                    // Gán DataTable (đã lọc hoặc chưa lọc) vào grid
                    gridViewDocGia.DataSource = dt;
                    CauHinhCotGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridViewDocGia.ResumeLayout(true);
                this.ResumeLayout(true);
                // Các lệnh Refresh/Update này đôi khi không cần thiết nếu đã dùng ResumeLayout(true), 
                // nhưng giữ lại cũng không sao.
                gridViewDocGia.Refresh();
                gridViewDocGia.Update();
            }
        }
        private void CauHinhCotGrid()
        {
            // Đổi tên cột hiển thị cho đẹp
            if (gridViewDocGia.Columns["MaNguoiDung"] != null) gridViewDocGia.Columns["MaNguoiDung"].HeaderText = "Mã độc giả";
            if (gridViewDocGia.Columns["HoTen"] != null) gridViewDocGia.Columns["HoTen"].HeaderText = "Họ và tên";
            if (gridViewDocGia.Columns["MaSoThe"] != null) gridViewDocGia.Columns["MaSoThe"].HeaderText = "Mã thẻ";
            if (gridViewDocGia.Columns["NgaySinh"] != null) gridViewDocGia.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (gridViewDocGia.Columns["SoDienThoai"] != null) gridViewDocGia.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (gridViewDocGia.Columns["TrangThai"] != null) gridViewDocGia.Columns["TrangThai"].HeaderText = "Trạng thái";
            gridViewDocGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridViewDocGia.ColumnHeadersHeight = 40;

        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            FormChiTietDocGia frm = new FormChiTietDocGia(null); // Null để thêm mới
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TaiDanhSachDocGia(); // Tải lại danh sách sau khi thêm
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            if (gridViewDocGia.SelectedRows.Count > 0)
            {
                string id = gridViewDocGia.SelectedRows[0].Cells["MaNguoiDung"].Value.ToString();
                FormChiTietDocGia frm = new FormChiTietDocGia(id); // Truyền ID để sửa
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TaiDanhSachDocGia();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một độc giả để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            if (gridViewDocGia.SelectedRows.Count > 0)
            {
                string id = gridViewDocGia.SelectedRows[0].Cells["MaNguoiDung"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new SqliteConnection(connectionString))
                        {
                            conn.Open();
                            //Nếu DB có Trigger chặn xóa khi đang mượn sách, nó sẽ quăng lỗi ở đây.
                            var cmd = new SqliteCommand("DELETE FROM NguoiDung WHERE MaNguoiDung = @id", conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();

                            TaiDanhSachDocGia();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa độc giả này. Lỗi: " + ex.Message + "\n(Có thể do độc giả đang mượn sách hoặc có ràng buộc khác)", "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một độc giả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBoxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
