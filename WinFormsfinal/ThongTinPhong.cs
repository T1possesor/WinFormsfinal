using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DataGridViewAutoFilter;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    public partial class ThongTinPhong : Form
    {
        //string connectionString = "Data Source=project_final.db;Version=3;";
        string connectionString = @"Data Source=project_final.db;Version=3;";

        DataTable dtPhong = new DataTable();

        DataTable dtDon = new DataTable();

        public ThongTinPhong()
        {
            InitializeComponent();
            this.Resize += Form_Resize;
        }

        private void LoadDataPhong()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "select MaPhong, TenPhong, SucChua, CoSoVatChat, TrangThai, DonGiaGio from Phong;";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                dtPhong.Clear();
                da.Fill(dtPhong);
                dgvThongTinPhong.DataSource = dtPhong;
            }

            // Cấu hình DataGridView
            dgvThongTinPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvThongTinPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvThongTinPhong.Columns["SucChua"].HeaderText = "Sức chứa";
            dgvThongTinPhong.Columns["CoSoVatChat"].HeaderText = "Cơ sở vật chất";
            dgvThongTinPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvThongTinPhong.Columns["DonGiaGio"].HeaderText = "Đơn giá/giờ";


        }

        private void Form_Resize(object sender, EventArgs e)
        {
            panelMainPhong.Left = (this.ClientSize.Width - panelMainPhong.Width) / 2;
            panelMainPhong.Top = 20;
        }
        private void dgvThongTinPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Chọn dòng vừa double-click
            dgvThongTinPhong.ClearSelection();
            dgvThongTinPhong.Rows[e.RowIndex].Selected = true;

            // Gọi lại logic fill dữ liệu đã viết sẵn
            dgvThongTinPhong_SelectionChanged(sender, EventArgs.Empty);
        }

        private void FormQLPhong_Load(object sender, EventArgs e)
        {
            // Load dữ liệu phòng + checkbox
            LoadDataPhong();
            AddCheckBoxColumn();

            // ❌ Không cho hiện dòng trống cuối cùng
            dgvThongTinPhong.AllowUserToAddRows = false;
            dgvThongTinPhong.RowHeadersVisible = false;   // nếu muốn ẩn luôn cột STT bên trái

            dgvThongTinPhong.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvThongTinPhong.Columns)
            {
                col.ReadOnly = col.Name != "Chon";   // chỉ cột Chon được sửa (tick)
            }

            dgvThongTinPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongTinPhong.MultiSelect = false;
            dgvThongTinPhong.SelectionChanged += dgvThongTinPhong_SelectionChanged;
            dgvThongTinPhong.CellDoubleClick += dgvThongTinPhong_CellDoubleClick;
            dgvThongTinPhong.CurrentCellDirtyStateChanged += dgvThongTinPhong_CurrentCellDirtyStateChanged;

            // combobox + clb
            cbbSucChua.Items.AddRange(new object[] { "5", "10", "12" });
            cbbSucChua.SelectedIndex = 0;
            cbbTrangThai.Items.AddRange(new object[] { "Hoạt động", "Bảo trì" });
            cbbTrangThai.SelectedIndex = 0;
            clbCSVC.Items.AddRange(new object[] { "Wifi", "Máy lạnh", "Máy chiếu" });

            dgvThongTinPhong.ContextMenuStrip = contextMenuStripRightClick;
            dgvDonDatPhong.ContextMenuStrip = contextMenuDon;

            // Đơn đặt phòng
            LoadDataDonDatPhong();
            dgvDonDatPhong.AllowUserToAddRows = false;    // tắt dòng trống ở grid này luôn
            dgvDonDatPhong.RowHeadersVisible = false;
            dgvDonDatPhong.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvDonDatPhong.Columns)
            {
                col.ReadOnly = col.Name != "Chon";
            }
            dgvDonDatPhong.CurrentCellDirtyStateChanged += dgvDonDatPhong_CurrentCellDirtyStateChanged;
        }



        //tab thông tin phòng
        #region tab thông tin phòng

        private void AddCheckBoxColumn()
        {
            if (!dgvThongTinPhong.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "Chon";
                chk.Width = 30;
                dgvThongTinPhong.Columns.Insert(0, chk);
            }
        }

        // search với keyword không dấu
        // hàm bỏ dâu
        private string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = RemoveDiacritics(txtSearch.Text.Trim().ToLower());

            foreach (DataGridViewRow row in dgvThongTinPhong.Rows)
            {
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellText = RemoveDiacritics(cell.Value?.ToString().ToLower() ?? "");
                    if (cellText.Contains(keyword))
                    {
                        match = true;
                        break;
                    }
                }

                // Highlight nếu match
                if (match && !string.IsNullOrEmpty(keyword))
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        //hiện danh sách csvc đã chọn
        private void txtCSVC_Click(object sender, EventArgs e)
        {
            clbCSVC.Location = new Point(txtCSVC.Left, txtCSVC.Bottom);
            clbCSVC.Width = txtCSVC.Width;
            clbCSVC.Visible = true;
            clbCSVC.BringToFront();
        }

        //ẩn danh sách khi click ra ngoài
        private void ThongTinPhong_Click(object sender, EventArgs e)
        {
            if (!clbCSVC.Bounds.Contains(PointToClient(MousePosition)))
                clbCSVC.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // KHÔNG lấy tên phòng do người dùng nhập nữa
            string csvc = txtCSVC.Text.Trim();
            int succhua = int.Parse(cbbSucChua.Text);
            string trangthai = cbbTrangThai.Text.Trim();

            // Sinh mã phòng + tên phòng tự động từ sức chứa
            string tenPhongMoi;
            string ma = SinhMaPhong(succhua, out tenPhongMoi);

            // Hiển thị lại tên phòng cho người dùng thấy
            txtTenPhong.Text = tenPhongMoi;

            // Kiểm tra trùng mã
            if (dtPhong.AsEnumerable().Any(r => r.Field<string>("MaPhong") == ma))
            {
                MessageBox.Show("Mã phòng bị trùng!", "Cảnh báo");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Phong 
                        (MaPhong, TenPhong, SucChua, CoSoVatChat, TrangThai, DonGiaGio) 
                        VALUES (@ma, @ten, @suc, @csvc, @trangthai, @dongia)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", tenPhongMoi);
                    cmd.Parameters.AddWithValue("@suc", succhua);
                    cmd.Parameters.AddWithValue("@csvc", csvc);
                    cmd.Parameters.AddWithValue("@trangthai", trangthai);
                    cmd.Parameters.AddWithValue("@dongia", txtDonGia.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadDataPhong();
        }


        //hàm sinh mã phòng tự động
        // Sinh mã phòng dựa trên SỨC CHỨA:
        // Ví dụ: SucChua = 5  -> P501, P502,...
        //        SucChua = 10 -> P1001, P1002,...
        //        SucChua = 12 -> P1201, P1202,...
        private string SinhMaPhong(int sucChua, out string tenPhong)
        {
            string prefixMa = "P" + sucChua.ToString();  // dùng đúng tên biến

            // Tìm các mã phòng hiện có cùng prefix để lấy STT lớn nhất
            var maxIndex = dtPhong.AsEnumerable()
                .Select(r => r.Field<string>("MaPhong"))
                .Where(m => m != null && m.StartsWith(prefixMa))
                .Select(m =>
                {
                    // Lấy phần số thứ tự sau prefix, ví dụ "P501" -> "01"
                    string suffix = m.Substring(prefixMa.Length);
                    return int.TryParse(suffix, out int n) ? n : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            int nextIndex = maxIndex + 1;                // STT tiếp theo
            string suffixStr = nextIndex.ToString("D2"); // 01, 02, 03...

            tenPhong = sucChua.ToString() + suffixStr;   // "501", "1001", "1201"
            string maPhong = "P" + tenPhong;            // "P501", "P1001", "P1201"

            return maPhong;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // chú ý: dùng ?? false để tránh lỗi khi Value = null
            var rows = dgvThongTinPhong.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Chon"].Value ?? false))
                .ToList();

            if (rows.Count == 0)
            {
                MessageBox.Show("Hãy chọn ít nhất 1 dòng để xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Xóa {rows.Count} dòng đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                foreach (var row in rows)
                {
                    string ma = row.Cells["MaPhong"].Value.ToString();
                    string query = "DELETE FROM Phong WHERE MaPhong = @ma";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadDataPhong();
        }

        private void dgvThongTinPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThongTinPhong.SelectedRows.Count == 0) return;

            var row = dgvThongTinPhong.SelectedRows[0];

            txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString();
            cbbSucChua.Text = row.Cells["SucChua"].Value?.ToString();
            txtDonGia.Text = row.Cells["DonGiaGio"].Value?.ToString();
            cbbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();

            // Cơ sở vật chất
            string csvc = row.Cells["CoSoVatChat"].Value?.ToString() ?? "";
            txtCSVC.Text = csvc;

            // Tick lại các checkbox trong clbCSVC
            for (int i = 0; i < clbCSVC.Items.Count; i++)
            {
                clbCSVC.SetItemChecked(i, false);
            }

            var list = csvc.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => x.Trim());

            foreach (string item in list)
            {
                int idx = clbCSVC.Items.IndexOf(item);
                if (idx >= 0) clbCSVC.SetItemChecked(idx, true);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongTinPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn dòng để sửa!");
                return;
            }

            DialogResult dr = MessageBox.Show("Xác nhận sửa thông tin phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            var row = dgvThongTinPhong.SelectedRows[0];
            string ma = row.Cells["MaPhong"].Value.ToString();
            string ten = txtTenPhong.Text.Trim();
            int succhua = int.Parse(cbbSucChua.Text);
            string csvc = txtCSVC.Text.Trim();
            string trangthai = cbbTrangThai.Text.Trim();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Phong 
                         SET TenPhong=@ten, 
                             SucChua=@suc, 
                             CoSoVatChat=@csvc, 
                             TrangThai=@trangthai, 
                             DonGiaGio=@dongia 
                         WHERE MaPhong=@ma";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);          // <-- dùng 'ten' ở đây
                    cmd.Parameters.AddWithValue("@suc", succhua);
                    cmd.Parameters.AddWithValue("@csvc", csvc);
                    cmd.Parameters.AddWithValue("@trangthai", trangthai);
                    cmd.Parameters.AddWithValue("@dongia", txtDonGia.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadDataPhong();
        }



        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenPhong.Clear();
            txtCSVC.Clear();
            foreach (int i in Enumerable.Range(0, clbCSVC.Items.Count))
                clbCSVC.SetItemChecked(i, false);
            cbbSucChua.SelectedIndex = 0;
            txtSearch.Clear();

            LoadDataPhong();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        //check để chọn csvc
        private void clbCSVC_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.BeginInvoke((MethodInvoker)delegate
            {
                var selected = new List<string>();

                foreach (var item in clbCSVC.CheckedItems)
                    selected.Add(item.ToString());

                // Nếu vừa check thêm mục mới (vì CheckedItems chưa chứa mục đó trong thời điểm này)
                if (e.NewValue == CheckState.Checked && !selected.Contains(clbCSVC.Items[e.Index].ToString()))
                    selected.Add(clbCSVC.Items[e.Index].ToString());

                txtCSVC.Text = string.Join(", ", selected);
            });
        }

        private void dgvThongTinPhong_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvThongTinPhong.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvThongTinPhong.ClearSelection();
                    dgvThongTinPhong.Rows[hit.RowIndex].Selected = true;
                    dgvThongTinPhong.CurrentCell = dgvThongTinPhong.Rows[hit.RowIndex].Cells[0];
                }
            }
        }


        private void xóaDòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvThongTinPhong.SelectedRows.Count == 0) return;

            var row = dgvThongTinPhong.SelectedRows[0];
            string maPhong = row.Cells["MaPhong"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng {maPhong} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Phong WHERE MaPhong = @ma";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maPhong);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadDataPhong();
            }
        }
        #endregion 

        // tab đơn đặt phòng
        #region tab đơn đặt phòng
        private void LoadDataDonDatPhong()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                //string query = @"SELECT MaDatPhong, MaPhong, MaTheThuVien, NgayDat, GioBatDau, GioKetThuc, 
                //                MucDich, GhiChu, TienCoc, NgayTao
                //         FROM DonDatPhongHocNhom;";
                string query = @"
                    SELECT 
                     MaDatPhong,
                     MaPhong,
                     MaSoThe,
                     date(NgayDat) AS NgayDat,
                     time(GioBatDau) AS GioBatDau,
                     time(GioKetThuc) AS GioKetThuc,
                     MucDich,
                     GhiChu,
                     TienCoc,
                     NgayTao,
                    SoThanhVienThamGia
                    FROM DonDatPhongHocNhom;";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                dtDon.Clear();
                da.Fill(dtDon);
                dgvDonDatPhong.DataSource = dtDon;
            }

            dgvDonDatPhong.Columns["MaDatPhong"].HeaderText = "Mã đặt phòng";
            dgvDonDatPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvDonDatPhong.Columns["MaSoThe"].HeaderText = "Mã thẻ TV";

            dgvDonDatPhong.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvDonDatPhong.Columns["GioBatDau"].HeaderText = "Giờ bắt đầu";
            dgvDonDatPhong.Columns["GioKetThuc"].HeaderText = "Giờ kết thúc";
            dgvDonDatPhong.Columns["MucDich"].HeaderText = "Mục đích";
            dgvDonDatPhong.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvDonDatPhong.Columns["TienCoc"].HeaderText = "Tiền cọc";
            dgvDonDatPhong.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvDonDatPhong.Columns["SoThanhVienThamGia"].HeaderText = "Số thành viên tham gia";


            AddCheckBoxDonDatPhong();
        }

        private void AddCheckBoxDonDatPhong()
        {
            if (!dgvDonDatPhong.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "Chon";
                chk.Width = 30;
                dgvDonDatPhong.Columns.Insert(0, chk);
            }
        }
        private void txtSearchDDP_TextChanged(object sender, EventArgs e)
        {
            string keyword = RemoveDiacritics(txtSearchDDP.Text.Trim().ToLower());

            foreach (DataGridViewRow row in dgvDonDatPhong.Rows)
            {
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string val = RemoveDiacritics(cell.Value?.ToString().ToLower() ?? "");
                    if (val.Contains(keyword)) { match = true; break; }
                }

                row.DefaultCellStyle.BackColor = match && keyword != "" ? Color.LightYellow : Color.White;
            }
        }
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvDonDatPhong.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Chon"].Value ?? false))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một đơn để hủy.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy {selectedRows.Count} đơn này không?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                foreach (var row in selectedRows)
                {
                    string ma = row.Cells["MaDatPhong"].Value.ToString();
                    string query = "DELETE FROM DonDatPhongHocNhom WHERE MaDatPhong = @ma";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadDataDonDatPhong();
        }

        private void dgvThongTinPhong_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvThongTinPhong.IsCurrentCellDirty)
            {
                dgvThongTinPhong.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvDonDatPhong_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDonDatPhong.IsCurrentCellDirty)
            {
                dgvDonDatPhong.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnSuaDon_Click(object sender, EventArgs e)
        {
            if (dgvDonDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn để sửa!");
                return;
            }

            // Lấy mã đơn đặt phòng từ dòng được chọn
            string ma = dgvDonDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value.ToString();

            // Mở form sửa và truyền mã đơn đó
            FormSuaDonDatPhong frm = new FormSuaDonDatPhong(ma);

            // Nếu người dùng bấm “Lưu” và form trả về OK → cập nhật lại dữ liệu
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataDonDatPhong(); // Hàm reload lại lưới
            }
        }

        private void dgvDonDatPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDatPhong = dgvDonDatPhong.Rows[e.RowIndex].Cells["MaDatPhong"].Value.ToString();
                FormSuaDonDatPhong formSua = new FormSuaDonDatPhong(maDatPhong);
                formSua.ShowDialog();

                // Sau khi đóng form -> reload lại danh sách
                LoadDataDonDatPhong();
            }
        }


        private void sửaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDonDatPhong.SelectedRows.Count > 0)
            {
                string maDatPhong = dgvDonDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value.ToString();
                FormSuaDonDatPhong formSua = new FormSuaDonDatPhong(maDatPhong);
                formSua.ShowDialog();
                LoadDataDonDatPhong();
            }
        }

        private void hủyĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDonDatPhong.SelectedRows.Count > 0)
            {
                string maDatPhong = dgvDonDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn hủy đơn đặt {maDatPhong} không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM DonDatPhongHocNhom WHERE MaDatPhong=@ma";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", maDatPhong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Đã hủy đơn đặt phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataDonDatPhong();
                }
            }
        }

        #endregion



        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
