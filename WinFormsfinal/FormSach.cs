using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;   // <— dùng System.Data.SQLite

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormSach : Form
    {
        private ContextMenuStrip ctxMenuSach;
        private ToolStripMenuItem mnuXemChiTiet;

        // Kết nối SQLite
        private readonly string connectionString = @"Data Source=project_final.db;Version=3;";

        public FormSach()
        {
            InitializeComponent();
            CaiDatSuKien();
            KhoiTaoContextMenu();
        }

        private void KhoiTaoContextMenu()
        {
            ctxMenuSach = new ContextMenuStrip();
            mnuXemChiTiet = new ToolStripMenuItem { Text = "Xem chi tiết sách này" };
            mnuXemChiTiet.Click += MnuXemChiTiet_Click;
            ctxMenuSach.Items.Add(mnuXemChiTiet);
        }

        private void CaiDatSuKien()
        {
            Load += FormSach_Load;
            txtTimKiem.TextChanged += (s, e) => TaiDanhSachSach();
            cmbTheLoai.SelectedIndexChanged += (s, e) => TaiDanhSachSach();
            dgvSach.CellDoubleClick += DgvSach_CellDoubleClick;
            dgvSach.CellMouseDown += DgvSach_CellMouseDown;
        }

        private void DgvSach_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvSach.ClearSelection();
                dgvSach.Rows[e.RowIndex].Selected = true;
                ctxMenuSach.Show(Cursor.Position);
            }
        }

        private void MnuXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSach.SelectedRows[0];
                string maSach = Convert.ToString(selectedRow.Cells["MaSach"].Value);
                var frm = new FormChiTietSach(maSach);
                frm.ShowDialog();
            }
        }

        private void FormSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxTheLoai();
            TaiDanhSachSach();
        }

        // Tải danh sách thể loại
        private void LoadComboBoxTheLoai()
        {
            cmbTheLoai.Items.Clear();
            cmbTheLoai.Items.Add("Tất cả");
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(
                        "SELECT DISTINCT TheLoai FROM Sach WHERE TheLoai IS NOT NULL AND TheLoai <> '' ORDER BY TheLoai", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbTheLoai.Items.Add(reader["TheLoai"].ToString());
                        }
                    }
                }
            }
            catch
            {
                // có thể log nếu cần
            }
            cmbTheLoai.SelectedIndex = 0;
        }

        // Bỏ dấu tiếng Việt và về chữ thường
        private string LoaiBoDauTiengViet(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark) sb.Append(c);
            }
            // về FormC và lower
            return sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
        }

        private void TaiDanhSachSach()
        {
            string tuKhoaGoc = txtTimKiem.Text.Trim();
            string tuKhoaChuanHoa = LoaiBoDauTiengViet(tuKhoaGoc);
            string theLoaiLoc = cmbTheLoai.SelectedItem?.ToString();

            string query = @"SELECT MaSach, TenSach, TacGia, TheLoai, NamXuatBan, ViTriKeSach, TrangThaiMuon 
                             FROM Sach WHERE 1=1";
            bool coLocTheLoai = !string.IsNullOrEmpty(theLoaiLoc) && theLoaiLoc != "Tất cả";
            if (coLocTheLoai) query += " AND TheLoai = @tl";

            try
            {
                dgvSach.SuspendLayout();

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        if (coLocTheLoai) cmd.Parameters.AddWithValue("@tl", theLoaiLoc);

                        var dt = new DataTable();
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        // Lọc trong bộ nhớ theo từ khóa (bắt đầu bằng, không dấu)
                        if (!string.IsNullOrEmpty(tuKhoaChuanHoa))
                        {
                            var rows = dt.AsEnumerable().Where(r =>
                            {
                                string ten = LoaiBoDauTiengViet(r.Field<string>("TenSach"));
                                string tg = LoaiBoDauTiengViet(r.Field<string>("TacGia"));
                                return ten.StartsWith(tuKhoaChuanHoa) || tg.StartsWith(tuKhoaChuanHoa);
                            });

                            dt = rows.Any() ? rows.CopyToDataTable() : dt.Clone();
                        }

                        dgvSach.DataSource = dt;
                        CauHinhCotGrid();
                    }
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

        private void CauHinhCotGrid()
        {
            if (dgvSach.Columns["MaSach"] != null)
            {
                dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvSach.Columns["MaSach"].Width = 80;
            }
            if (dgvSach.Columns["TenSach"] != null)
            {
                dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSach.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvSach.Columns["TacGia"] != null)
            {
                dgvSach.Columns["TacGia"].HeaderText = "Tác Giả";
                dgvSach.Columns["TacGia"].Width = 150;
            }
            if (dgvSach.Columns["TheLoai"] != null) dgvSach.Columns["TheLoai"].HeaderText = "Thể Loại";
            if (dgvSach.Columns["NamXuatBan"] != null) dgvSach.Columns["NamXuatBan"].HeaderText = "Năm XB";
            if (dgvSach.Columns["ViTriKeSach"] != null) dgvSach.Columns["ViTriKeSach"].HeaderText = "Vị Trí";
            if (dgvSach.Columns["TrangThaiMuon"] != null) dgvSach.Columns["TrangThaiMuon"].HeaderText = "Trạng Thái Mượn";
        }

        private void DgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSach = Convert.ToString(dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value);
                var frm = new FormChiTietSach(maSach);
                frm.ShowDialog();
            }
        }
    }
}
