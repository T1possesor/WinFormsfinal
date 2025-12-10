using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhapSach_new
{
    public partial class FormSuaPN : Form
    { //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;
        //Tạo DataTable dùng cho DataGridView thông tin chi tiết phiếu nhập
        DataTable dataTable = new DataTable();
        // Danh sách sách để hiển thị popup 
        DataTable dtSach = new DataTable();

        private string _maPhieuNhap = "";
        public FormSuaPN(string maPN)
        {
            InitializeComponent();
            _maPhieuNhap = maPN;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gán mã phiếu nhập vào textbox
            txtbMaPhieuNhap.Text = _maPhieuNhap;
            txtbMaPhieuNhap.Enabled = false;

            LoadTTPhieuNhap();
            LoadTTCTPhieuNhap();

            // Lấy danh sách sách từ DB để hiện popup
            dtSach = GetDanhSachSach();
            dgvList.DataSource = dtSach;

            // Tải danh sách người lập đã có trong CDSL
            LoadNguoiLapToCombo();
            // Tải danh sách nhà cung cấp đã có trong CSDL
            LoadNCCToCombo();


        }
        // HÀM TẢI LÊN THÔNG TIN PHIẾU NHẬP
        private void LoadTTPhieuNhap()
        {
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string sql = @"SELECT NhaCungCap,NguoiLap,NgayNhap
                           FROM PhieuNhap 
                           WHERE MaPhieuNhap=@mapn";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mapn", _maPhieuNhap);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cboNCC.Text = reader["NhaCungCap"].ToString();
                            cboNguoiLap.Text = reader["NguoiLap"].ToString();
                            DateTime.TryParseExact(reader["NgayNhap"].ToString(), "dd-MM-yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay);
                            dtpNgayNhap.Value = ngay;
                        }
                    }
                }
            }
        }
        // HÀM TẢI LÊN THÔNG TIN CHI TIẾT PHIẾU NHẬP
        private void LoadTTCTPhieuNhap()
        {
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string sql = @" SELECT 
                                ctpn.MaSach,s.TenSach,ctpn.SoLuong,ctpn.DonGia
                                FROM ChiTietPhieuNhap ctpn
                                JOIN Sach s ON ctpn.MaSach = s.MaSach
                                WHERE ctpn.MaPhieuNhap = @mapn";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mapn", _maPhieuNhap);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }
                    dgCTPhieuNhap.DataSource = dataTable;
                    dgCTPhieuNhap.Columns["MaSach"].HeaderText = "Mã sách";
                    dgCTPhieuNhap.Columns["TenSach"].HeaderText = "Tên sách";
                    dgCTPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgCTPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                }
            }
        }
        // LẤY DANH SÁCH TỪ SQLITE ĐỂ POPUP LIST SỬ DỤNG  
        private DataTable GetDanhSachSach()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new SQLiteConnection(strConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaSach,TenSach, TacGia, NhaXuatBan, NamXuatBan  FROM Sach";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("File SQLite đang dùng:\n" + strConnectionString);
            }
            return dt;
        }
        // TẢI DANH SÁCH NGƯỜI LẬP TỒN TẠI TRONG CSDL
        private void LoadNguoiLapToCombo()
        {
            cboNguoiLap.Items.Clear();
            var conTemp = new SQLiteConnection(strConnectionString);
            conTemp.Open();
            string sql = "SELECT DISTINCT NguoiLap FROM PhieuNhap";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conTemp))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        cboNguoiLap.Items.Add(reader.GetString(0));
                    }
                }
            }
            conTemp.Close();

        }
        // TẢI DANH SÁCH NHÀ CUNG CẤP TỒN TẠI TRONG CSDL
        private void LoadNCCToCombo()
        {
            cboNCC.Items.Clear();
            var conTemp = new SQLiteConnection(strConnectionString);
            conTemp.Open();
            string sql = "SELECT DISTINCT NhaCungCap FROM PhieuNhap";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conTemp))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        cboNCC.Items.Add(reader.GetString(0));
                    }
                }
            }
            conTemp.Close();

        }
        // Lưu vị trí ô đang chọn để gán sách vào ô khi nhấn đúp chuột vào một sách popup danh sách sách
        private int _targetRow = -1;
        private int _targetCol = -1;

        // Hiển thị popup danh sách sách ngay dưới ô được nhấp chuột
        private void ShowPopupBelowCell(int row, int col)
        {    // Lấy vị trí hiển thị của cell trên Form
            Rectangle rect = dgCTPhieuNhap.GetCellDisplayRectangle(col, row, true);
            // Đặt vị trí popup ngay bên dưới cell
            PanelPopup.Left = dgCTPhieuNhap.Left + rect.Left;
            PanelPopup.Top = dgCTPhieuNhap.Top + rect.Bottom;
            PanelPopup.Width = rect.Width + 500;
            PanelPopup.Visible = true;

            // Reset ô tìm kiếm
            txtSearch.Text = "";
            txtSearch.Focus();
            // Reset danh sách trong popup
            dgvList.DataSource = dtSach;
        }

        private void dgCTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Lưu vị trí cell để biết cần gán sách vào dòng nào
            _targetRow = e.RowIndex;
            _targetCol = e.ColumnIndex;
            var row = dgCTPhieuNhap.Rows[e.RowIndex];
            // Nếu click vào cột TenSach sẽ hiển popup chọn sách
            if (row.IsNewRow && e.ColumnIndex == dgCTPhieuNhap.Columns["TenSach"].Index)
            {
                ShowPopupBelowCell(e.RowIndex, e.ColumnIndex);
            }
            // Nếu click không phải vào cột TenSach thì ẩn popup
            if (e.ColumnIndex != dgCTPhieuNhap.Columns["TenSach"].Index)
            {
                PanelPopup.Visible = false;
                return;
            }
        }
        // Biến tạm lưu giá trị cũ của dòng đang edit
        int oldSoLuong = 0;
        double oldDonGia = 0;
        // CHẶN NGƯỜI DÙNG GÕ VÀO CỘT TÊN SÁCH VÀ MÃ SÁCH
        private void dgCTPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int colMaSach = dgCTPhieuNhap.Columns["MaSach"].Index;
            int colTenSach = dgCTPhieuNhap.Columns["TenSach"].Index;
            // Nếu user cố ý gõ vào 2 cột này → chặn
            if (e.ColumnIndex == colMaSach || e.ColumnIndex == colTenSach)
            {
                e.Cancel = true;
            }
            // Chỉ lưu khi bắt đầu edit cột SoLuong hoặc DonGia
            var row = dgCTPhieuNhap.Rows[e.RowIndex];
            if (e.ColumnIndex == dgCTPhieuNhap.Columns["SoLuong"].Index)
                oldSoLuong = int.Parse(row.Cells["SoLuong"].Value?.ToString());

            if (e.ColumnIndex == dgCTPhieuNhap.Columns["DonGia"].Index)
                oldDonGia = double.Parse(row.Cells["DonGia"].Value?.ToString());

        }
        // KIỂM TRA HỢP LỆ SỐ LƯỢNG, ĐƠN GIÁ CHO TỪNG DÒNG TRONG GRID
        private void dgCTPhieuNhap_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow currentRow = dgCTPhieuNhap.Rows[e.RowIndex];

            // Bỏ qua dòng mới chưa nhập dữ liệu
            if (currentRow.IsNewRow) return;

            string maSach = currentRow.Cells["MaSach"].Value?.ToString();

            // Lấy giá trị
            int soLuong = 0;
            int.TryParse(currentRow.Cells["SoLuong"].Value?.ToString(), out soLuong);

            double donGia = 0;
            double.TryParse(currentRow.Cells["DonGia"].Value?.ToString(), out donGia);

            // Biến gom lỗi
            string loi = "";

            // Kiểm tra số lượng
            if (soLuong <= 0)
                loi += " Số lượng phải lớn hơn 0\n";

            // Kiểm tra đơn giá
            if (donGia <= 0)
                loi += " Đơn giá phải lớn hơn 0\n";

            // Nếu có lỗi thì báo
            if (!string.IsNullOrEmpty(loi))
            {
                MessageBox.Show($"Dữ liệu sách {maSach} có lỗi:\n{loi}",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // ngăn rời dòng
                // Khôi phục giá trị cũ
                if (e.ColumnIndex == dgCTPhieuNhap.Columns["SoLuong"].Index)
                    currentRow.Cells["SoLuong"].Value = oldSoLuong;
                if (e.ColumnIndex == dgCTPhieuNhap.Columns["DonGia"].Index)
                    currentRow.Cells["DonGia"].Value = oldDonGia;
            }
        }
        // Lọc sách theo tên khi nhập tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtSach == null) return;

            DataView dv = new DataView(dtSach);
            dv.RowFilter = $"TenSach LIKE '%{txtSearch.Text.Replace("'", "''")}%'";

            dgvList.DataSource = dv;
        }
        // MỞ FORM CHO NGƯỜI DÙNG THÊM SÁCH NẾU SÁCH NHẬP CHƯA TỒN TẠI TRONG CSDL
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            // Mở form thêm sách mới 
            using (var f = new FormThemMoiSach())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    //  Sau khi thêm xong, load lại danh sách sách từ DB
                    dtSach = GetDanhSachSach();  // Load lại danh sách sách
                    dgvList.DataSource = dtSach; // Cập nhật popup danh sách sách
                }
            }
        }
        // NÚT ĐÓNG FORM SỬA PHIẾU NHẬP
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        // KIỂM TRA SỐ LƯỢNG KHI ĐƯỢC SỬA MỚI
        private void dgCTPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCTPhieuNhap.Columns[e.ColumnIndex].Name != "SoLuong")
                return;

            DataGridViewRow row = dgCTPhieuNhap.Rows[e.RowIndex];
            string maSach = row.Cells["MaSach"].Value.ToString();
            int soLuongMoi = Convert.ToInt32(row.Cells["SoLuong"].Value);       // số lượng mới
            int soLuongCu = Convert.ToInt32(oldSoLuong);                           // số lượng cũ (trước khi sửa)

            int soLuongConLai = 0;

            // Lấy số lượng còn lại trong kho từ bảng Sach
            string sql = "SELECT SoLuongConLai FROM Sach WHERE MaSach = @MaSach";
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            soLuongConLai = Convert.ToInt32(r["SoLuongConLai"]);
                        }
                    }
                }
            }
            // Công thức kiểm tra
            if (soLuongConLai - (soLuongCu - soLuongMoi) < 0)
            {
                // Không hợp lệ → hoàn tác
                MessageBox.Show($"Không thể sửa mã sách{maSach}. Giá trị đã được hoàn tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                row.Cells["SoLuong"].Value = oldSoLuong;

            }
        }
        HashSet<int> changedRows = new HashSet<int>();
        HashSet<int> newRows = new HashSet<int>();
        // GHI NHẬN DÒNG ĐÃ SỬA VÀ CẬP NHẬT TỔNG THÀNH TIỀN VÀ TỔNG SỐ LƯỢNG
        private void dgCTPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                changedRows.Add(e.RowIndex);

                // Nếu có >1 dòng thay đổi, bật nút Lưu
                btnLuuPN.Enabled = changedRows.Count > 0;
            }
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                CapNhatTongThanhTien();
                CapNhatTongSoLuong();
            }
        }
        // NÚT LƯU LẠI PHIẾU NHẬP SAU KHI SỬA
        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {   // Cập nhật thông tin chung Phiếu nhập
                        string sqlUpdatePhieuNhap = @"
                    UPDATE PhieuNhap
                    SET NgayNhap = @NgayNhap,
                        NhaCungCap = @NhaCungCap,
                        NguoiLap = @NguoiLap
                    WHERE MaPhieuNhap = @MaPN";

                        using (var cmd = new SQLiteCommand(sqlUpdatePhieuNhap, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value.Date.ToString("dd-MM-yyyy"));
                            cmd.Parameters.AddWithValue("@NhaCungCap", cboNCC.Text);
                            cmd.Parameters.AddWithValue("@NguoiLap", cboNguoiLap.Text);
                            cmd.Parameters.AddWithValue("@MaPN", txtbMaPhieuNhap.Text);
                            cmd.ExecuteNonQuery();
                        }
                           // Cập nhật thông tin chi tiết nhập
                        foreach (int rowIndex in changedRows)
                        {
                            var row = dgCTPhieuNhap.Rows[rowIndex];
                            string maSach = row.Cells["MaSach"].Value?.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                            string sql;
                            // Kiểm tra dòng mới hay cũ
                            bool isNew = newRows.Contains(rowIndex);
                            if (isNew)
                            {
                                // INSERT cho dòng mới
                                sql = @"
                            INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSach, SoLuong, DonGia)
                            VALUES (@MaPN, @MaSach, @SoLuong, @DonGia)";
                            }
                            else
                            {    // UPDATE cho dòng cũ
                                sql = @"
                    UPDATE ChiTietPhieuNhap
                    SET SoLuong = @SoLuong,
                        DonGia = @DonGia
                    WHERE MaPhieuNhap = @MaPN AND MaSach = @MaSach";
                            }
                            using (var cmd = new SQLiteCommand(sql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@DonGia", donGia);
                                cmd.Parameters.AddWithValue("@MaPN", txtbMaPhieuNhap.Text);
                                cmd.Parameters.AddWithValue("@MaSach", maSach);
                                cmd.ExecuteNonQuery();
                            }
                            // Nếu là dòng mới -> xóa khỏi newRows để lần sửa sau update bình thường
                            if (isNew)
                                newRows.Remove(rowIndex);
                        }

                        tran.Commit();
                        MessageBox.Show("Lưu phiếu nhập thành công!");
                        changedRows.Clear();
                        btnLuuPN.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lưu phiếu nhập thất bại: " + ex.Message);
                    }
                }
            }
        }
        private DataTable dtCTPhieuNhap = new DataTable();
        // KHI DOUBLE CLICK SẼ CHỌN SÁCH TRONG POPUP
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_targetRow < 0 || _targetCol < 0) return;
            string maSach = dgvList.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
            string tenSach = dgvList.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();

            // --- Kiểm tra trùng trước khi thêm ---
            foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["MaSach"].Value?.ToString() == maSach)
                {
                    MessageBox.Show("Mã sách này đã tồn tại trong phiếu nhập!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // dừng, không thêm
                }

            }
            // --- Thêm dòng mới trực tiếp ---                    
            DataRow newRow = dataTable.NewRow();
            newRow["MaSach"] = maSach;
            newRow["TenSach"] = tenSach;
            newRow["SoLuong"] = 1; // mặc định
            newRow["DonGia"] = 0; // mặc định

            dataTable.Rows.Add(newRow);
            // DataGridView tự chọn dòng vừa thêm, focus ô SoLuong ngay
            dgCTPhieuNhap.CurrentCell = dgCTPhieuNhap.Rows[dgCTPhieuNhap.Rows.Count - 2].Cells["DonGia"];
            dgCTPhieuNhap.BeginEdit(true);
            // Đánh dấu dòng mới
            changedRows.Add(dgCTPhieuNhap.CurrentRow.Index);
            newRows.Add(dgCTPhieuNhap.CurrentRow.Index);
            btnLuuPN.Enabled = true;
            PanelPopup.Visible = false;

        }
        // ---------------------------
        //  TÍNH TỔNG ĐẦU SÁCH
        // ---------------------------
        private int TinhTongDauSach()
        {
            int soDauSach = 0;

            foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
            {
                if (!row.IsNewRow)   // bỏ dòng trống để thêm dữ liệu
                    soDauSach++;
            }

            return soDauSach;
        }
        private void CapNhatTongDauSach()
        {
            lblTongDauSach.Text = "Tổng đầu sách: " + TinhTongDauSach();
        }
        // ---------------------------
        //  TÍNH TỔNG SỐ LƯỢNG
        // ---------------------------
        private int TinhTongSoLuong()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
            {
                if (!row.IsNewRow) // bỏ dòng để thêm mới
                {
                    int sl = 0;
                    int.TryParse(row.Cells[2].Value?.ToString(), out sl);
                    tong += sl;
                }
            }

            return tong;
        }
        private void CapNhatTongSoLuong()
        {
            lblSoLuong.Text = "Số lượng: " + TinhTongSoLuong();
        }
        // ---------------------------
        //  TÍNH TỔNG THÀNH TIỀN
        // ---------------------------
        private int TinhTongThanhTien()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
            {
                if (row.IsNewRow) continue;   // bỏ dòng trống cuối

                int soLuong = 0;
                int donGia = 0;

                int.TryParse(row.Cells[2].Value?.ToString(), out soLuong);
                int.TryParse(row.Cells[3].Value?.ToString(), out donGia);

                // Thành tiền = SL * Đơn giá
                tong += soLuong * donGia;
            }

            return tong;
        }
        private void CapNhatTongThanhTien()
        {
            lblThanhTien.Text =
                "Tổng tiền: " + TinhTongThanhTien().ToString("#,##0");
        }
        // CẬP NHẬT TỔNG SỐ LƯỢNG VÀ TỔNG ĐẦU SÁCH KHI THÊM DÒNG
        private void dgCTPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
       
            CapNhatTongDauSach();
            CapNhatTongSoLuong();
        }

        

    }
}
