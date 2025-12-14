using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormQuanLyDocGia : Form
    {
        // ====== KẾT NỐI DATABASE (Microsoft.Data.Sqlite – style gọn, 1 chỗ) ======
        private static readonly string DbPath = Path.Combine(Application.StartupPath, "project_final.db");
        private static readonly string ConnectionString =
            new SqliteConnectionStringBuilder
            {
                DataSource = DbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true,
                Cache = SqliteCacheMode.Shared
            }.ToString();

        public FormQuanLyDocGia()
        {
            InitializeComponent();
            CaiDatSuKien();
        }

        // ====== BỎ DẤU, CHUẨN HÓA TÌM KIẾM ======
        private string LoaiBoDauTiengViet(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            // Normalize FormD -> bỏ NonSpacingMark -> về FormC -> lower
            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).ToLower();
        }

        // ====== PARSE NGÀY LINH HOẠT (để chuẩn hóa dd/MM/yyyy) ======
        private static bool TryParseDateFlexible(string input, out DateTime d)
        {
            d = default;
            if (string.IsNullOrWhiteSpace(input)) return false;

            var vi = CultureInfo.GetCultureInfo("vi-VN");
            string[] formats =
            {
                "dd/MM/yyyy", "d/M/yyyy",
                "dd-MM-yyyy", "d-M-yyyy",
                "yyyy-MM-dd", "yyyy/MM/dd",
                "MM/dd/yyyy", "M/d/yyyy"
            };

            return DateTime.TryParseExact(input, formats, vi, DateTimeStyles.None, out d)
                || DateTime.TryParse(input, vi, DateTimeStyles.None, out d)
                || DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        }

        // ====== SỰ KIỆN / WIRING ======
        private void CaiDatSuKien()
        {
            // Buttons
            buttonThem.Click += ButtonThem_Click;
            buttonSua.Click += ButtonSua_Click;
            buttonXoa.Click += ButtonXoa_Click;

            // Filter realtime
            textBoxTimKiem.TextChanged += (s, e) => TaiDanhSachDocGia();
            comboBoxTrangThai.SelectedIndexChanged += (s, e) => TaiDanhSachDocGia();

            // Context menu
            menuItemSua.Click += MenuItemSua_Click;
            menuItemXoa.Click += MenuItemXoa_Click;

            // Grid chọn dòng chuột phải
            gridViewDocGia.CellMouseDown += gridViewDocGia_CellMouseDown;

            // ESC thoát app (tuỳ ý)
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Application.Exit(); };

            // Load dữ liệu khi Form sẵn sàng
            Load += FormQuanLyDocGia_Load;

            // Khởi tạo combobox nếu Designer chưa set SelectedIndex
            if (comboBoxTrangThai.Items.Count == 0)
            {
                comboBoxTrangThai.Items.Add("Tất cả");
                comboBoxTrangThai.Items.Add("Hoạt động");
                comboBoxTrangThai.Items.Add("Bị khóa");
            }
            if (comboBoxTrangThai.SelectedIndex < 0) comboBoxTrangThai.SelectedIndex = 0;
        }

        private void FormQuanLyDocGia_Load(object? sender, EventArgs e)
        {
            // Lần đầu vào form -> tải dữ liệu
            TaiDanhSachDocGia();
        }

        // ====== HANDLER ĐƯỢC GÁN TỪ DESIGNER (ĐỂ KHỎI LỖI THIẾU) ======
        private void labelTieuDe_Click(object? sender, EventArgs e) { }
        private void comboBoxTrangThai_SelectedIndexChanged(object? sender, EventArgs e) { }

        private void gridViewDocGia_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                gridViewDocGia.ClearSelection();
                gridViewDocGia.Rows[e.RowIndex].Selected = true;
            }
        }

        private void MenuItemSua_Click(object? sender, EventArgs e) => ButtonSua_Click(sender, e);
        private void MenuItemXoa_Click(object? sender, EventArgs e) => ButtonXoa_Click(sender, e);

        // ====== TẢI DANH SÁCH ĐỘC GIẢ ======
        private void TaiDanhSachDocGia()
        {
            string tuKhoaGoc = textBoxTimKiem.Text?.Trim() ?? string.Empty;
            string tuKhoaChuanka = LoaiBoDauTiengViet(tuKhoaGoc);
            string? trangThaiLoc = comboBoxTrangThai.SelectedItem?.ToString();

            string sql = @"
SELECT MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, TrangThai
FROM NguoiDung
WHERE 1=1";

            bool locTrangThai = !string.IsNullOrEmpty(trangThaiLoc) && trangThaiLoc != "Tất cả";
            if (locTrangThai) sql += " AND TrangThai = @tt";

            try
            {
                gridViewDocGia.SuspendLayout();
                SuspendLayout();

                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                if (locTrangThai)
                {
                    string ttDb = trangThaiLoc == "Hoạt động" ? "HoatDong" : "BiKhoa";
                    cmd.Parameters.AddWithValue("@tt", ttDb);
                }

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                    dt.Load(reader);

                // Lọc keyword (bo dấu) trong RAM cho nhanh
                if (!string.IsNullOrEmpty(tuKhoaChuanka))
                {
                    var rows = dt.AsEnumerable().Where(r =>
                    {
                        string hoTen = LoaiBoDauTiengViet(r.Field<string>("HoTen") ?? "");
                        string maThe = LoaiBoDauTiengViet(r.Field<string>("MaSoThe") ?? "");
                        string sdt = LoaiBoDauTiengViet(r.Field<string>("SoDienThoai") ?? "");
                        return hoTen.Contains(tuKhoaChuanka)
                            || maThe.Contains(tuKhoaChuanka)
                            || sdt.Contains(tuKhoaChuanka);
                    });

                    dt = rows.Any() ? rows.CopyToDataTable() : dt.Clone();
                }

                // === CHUẨN HÓA HIỂN THỊ NGÀY SINH: dd/MM/yyyy ===
                foreach (DataRow r in dt.Rows)
                {
                    var raw = r["NgaySinh"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(raw) &&
                        TryParseDateFlexible(raw!, out var d))
                    {
                        r["NgaySinh"] = d.ToString("dd/MM/yyyy");
                    }
                }
                // ================================================

                gridViewDocGia.DataSource = dt;
                CauHinhCotGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                    "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridViewDocGia.ResumeLayout(true);
                ResumeLayout(true);
                gridViewDocGia.Refresh();
                gridViewDocGia.Update();
            }
        }

        private void CauHinhCotGrid()
        {
            var c1 = gridViewDocGia.Columns["MaNguoiDung"]; if (c1 != null) c1.HeaderText = "Mã độc giả";
            var c2 = gridViewDocGia.Columns["HoTen"]; if (c2 != null) c2.HeaderText = "Họ và tên";
            var c3 = gridViewDocGia.Columns["MaSoThe"]; if (c3 != null) c3.HeaderText = "Mã thẻ";
            var c4 = gridViewDocGia.Columns["NgaySinh"]; if (c4 != null) c4.HeaderText = "Ngày sinh";
            var c5 = gridViewDocGia.Columns["SoDienThoai"]; if (c5 != null) c5.HeaderText = "SĐT";
            var c6 = gridViewDocGia.Columns["TrangThai"]; if (c6 != null) c6.HeaderText = "Trạng thái";

            gridViewDocGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridViewDocGia.ColumnHeadersHeight = 40;
        }

        // ====== THÊM / SỬA / XÓA ======
        private void ButtonThem_Click(object? sender, EventArgs e)
        {
            using var frm = new FormChiTietDocGia(null); // Null = thêm mới
            if (frm.ShowDialog() == DialogResult.OK)
                TaiDanhSachDocGia();
        }

        private void ButtonSua_Click(object? sender, EventArgs e)
        {
            if (gridViewDocGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một độc giả để sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = gridViewDocGia.SelectedRows[0]
                        ?.Cells["MaNguoiDung"]
                        ?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Không lấy được mã độc giả.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var frm = new FormChiTietDocGia(id);
            if (frm.ShowDialog() == DialogResult.OK)
                TaiDanhSachDocGia();
        }

        private void ButtonXoa_Click(object? sender, EventArgs e)
        {
            if (gridViewDocGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một độc giả để xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = gridViewDocGia.SelectedRows[0]
                        ?.Cells["MaNguoiDung"]
                        ?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Không lấy được mã độc giả.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM NguoiDung WHERE MaNguoiDung = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                TaiDanhSachDocGia();
                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa độc giả này. Lỗi: " + ex.Message
                    + "\n(Có thể do độc giả đang mượn sách hoặc có ràng buộc khác)",
                    "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== OPTIONAL: LẤY ICON TỪ DB (nếu bạn muốn) ======
        private Image? LoadImageBlobFromDb(string key)
        {
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ImageBlob FROM AppAssets WHERE Key=@k";
                cmd.Parameters.AddWithValue("@k", key);
                var obj = cmd.ExecuteScalar();
                if (obj is byte[] bytes && bytes.Length > 0)
                {
                    using var ms = new MemoryStream(bytes);
                    return Image.FromStream(ms);
                }
            }
            catch { /* ignore */ }
            return null;
        }

        private void ApplySearchIconFromDb()
        {
            // textBoxTimKiem.IconLeft = LoadImageBlobFromDb("search_icon");
        }
    }
}
