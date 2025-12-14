using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNhapSach_new
{
    public partial class FormThemPN : Form
    {    //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;       
        //Tạo DataTable dùng cho DataGridView phiếu nhập
        DataTable dataTable = new DataTable();
        // Danh sách sách để hiển thị popup 
        DataTable dtSach = new DataTable();

        private string _maPhieuNhap = "";
        private DateTime defaultDate;
        public FormThemPN(string maPN)
        {
            InitializeComponent();
            _maPhieuNhap = maPN;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {   // Gán mã phiếu nhập từ Form gọi vào textbox
            txtbMaPhieuNhap.Text = _maPhieuNhap;
            txtbMaPhieuNhap.Enabled = false;

            // Tạo cấu trúc bảng phiếu nhập
            ThemPN();

            // Lấy danh sách sách từ DB để hiện popup
            dtSach = GetDanhSachSach();
            dgvList.DataSource = dtSach;

            // Tải danh sách người lập đã có trong CDSL
            LoadNguoiLapToCombo();
            // Tải danh sách nhà cung cấp đã có trong CSDL
            LoadNCCToCombo();

            // Ngày nhập mặc định
            dtpNgayNhap.Value = DateTime.Now;
            defaultDate = dtpNgayNhap.Value.Date;           
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
        // TẠO CẤU TRÚC DATATABLE CHO CHI TIẾT PHIẾU NHẬP        
        void ThemPN()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("MaPhieuNhap", typeof(string));
            dataTable.Columns.Add("MaSach", typeof(string));
            dataTable.Columns.Add("TenSach", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("DonGia", typeof(double));
            // Liên kết DataTable với DataGridView
            dgCTPhieuNhap.DataSource = dataTable;
            // Đặt tên hiển thị cột
            dgCTPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu nhập";
            dgCTPhieuNhap.Columns["MaSach"].HeaderText = "Mã sách";
            dgCTPhieuNhap.Columns["TenSach"].HeaderText = "Tên sách";
            dgCTPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
            dgCTPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
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
        private void dgCTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Lưu vị trí cell để biết cần gán sách vào dòng nào
            _targetRow = e.RowIndex;
            _targetCol = e.ColumnIndex;
            // Nếu click vào cột TenSach sẽ hiển popup chọn sách
            if (e.ColumnIndex == dgCTPhieuNhap.Columns["TenSach"].Index)
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
        // HIỂN THỊ POPUP DANH SÁCH SÁCH NGAY DƯỚI Ô ĐƯỢC NHẤP CHUỘT      
        private void ShowPopupBelowCell(int row, int col)
        {
            // Lấy vị trí hiển thị của cell trên Form
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
        // LỌC SÁCH THEO TÊN KHI NHẬP VÀO TÌM KIẾM
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtSach == null) return;

            DataView dv = new DataView(dtSach);
            dv.RowFilter = $"TenSach LIKE '%{txtSearch.Text.Replace("'", "''")}%'";

            dgvList.DataSource = dv;
        }
        // KHI DOUBLE CLICK SẼ CHỌN SÁCH TRONG POPUP
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_targetRow < 0 || _targetCol < 0) return;
            // Kiểm tra phiếu nhập đã tạo chưa
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM PhieuNhap WHERE MaPhieuNhap = @mapn";
                using (SQLiteCommand cmdCheck = new SQLiteCommand(checkSql, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@mapn", txtbMaPhieuNhap.Text);
                    cmdCheck.ExecuteNonQuery();
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count == 0)
                    {
                        MessageBox.Show("Phiếu nhập chưa được tạo. Vui lòng tạo phiếu nhập trước khi thêm chi tiết.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            // Lấy thông tin sách được chọn
            string maSach = dgvList.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
            string tenSach = dgvList.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();

            // Kiểm tra trùng trước mã sách khi thêm
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
            // Nếu đang chọn ở dòng dòng cuối cùng thì tạo dòng mới
            if (_targetRow >= dataTable.Rows.Count)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["MaSach"] = maSach;
                newRow["TenSach"] = tenSach;
                newRow["SoLuong"] = 1;     // Cho giá trị mặc định
                newRow["DonGia"] = 0;      // Cho giá trị mặc định
                dataTable.Rows.Add(newRow);
            }
            else
            {
                // Nếu dòng đã tồn tại, ghi đè lại
                dataTable.Rows[_targetRow]["MaSach"] = maSach;
                dataTable.Rows[_targetRow]["TenSach"] = tenSach;
            }

            dgCTPhieuNhap.Refresh();
            PanelPopup.Visible = false;
            // Bật nút lưu
            btnLuuPN.Enabled = true;         

        }
        // CHẶN NGƯỜI DÙNG GÕ VÀO CỘT MÃ SÁCH, TÊN SÁCH, MÃ PHIẾU NHẬP
        private void dgCTPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int colMaSach = dgCTPhieuNhap.Columns["MaSach"].Index;
            int colTenSach = dgCTPhieuNhap.Columns["TenSach"].Index;
            int colMaPN = dgCTPhieuNhap.Columns["MaPhieuNhap"].Index;
            // Nếu user cố ý gõ vào các cột này thì hủy thao tác
            if (e.ColumnIndex == colMaSach || e.ColumnIndex == colTenSach || e.ColumnIndex == colMaPN)
            {
                e.Cancel = true;
            }
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
                    int.TryParse(row.Cells[3].Value?.ToString(), out sl);
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

                int.TryParse(row.Cells[3].Value?.ToString(), out soLuong);
                int.TryParse(row.Cells[4].Value?.ToString(), out donGia);

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
            if (dgCTPhieuNhap.Rows[e.RowIndex].IsNewRow == false) 
            {
                dgCTPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value = txtbMaPhieuNhap.Text;
            }
            CapNhatTongDauSach();
            CapNhatTongSoLuong();
        }
        // CẬP NHẬT TỔNG SỐ LƯỢNG VÀ TỔNG ĐẦU SÁCH KHI THÊM DÒNG
        private void dgCTPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CapNhatTongDauSach();
            CapNhatTongSoLuong();
        }
        // TÍNH LẠI TỔNG SỐ LƯỢNG VÀ TỔNG THÀNH TIỀN KHI THAY ĐỔI CỘT SỐ LƯỢNG VÀ ĐƠN GIÁ
        private void dgCTPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                CapNhatTongThanhTien();
                CapNhatTongSoLuong();
            }
        }
        // CLICK VÀO MENU XÓA CHI TIẾT PHIẾU NHẬP
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCTPhieuNhap.SelectedRows.Count > 0)
            {
                int index = dgCTPhieuNhap.SelectedRows[0].Index;
                if (dgCTPhieuNhap.Rows[index].IsNewRow)
                {
                    return;
                }
                dgCTPhieuNhap.Rows.RemoveAt(index);
            }
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            bool value = true;
            if (string.IsNullOrEmpty(cboNCC.Text))
            {
                erorNCC.SetError(cboNCC, "Vui lòng điền Nhà cung cấp");
                value = false;
            }
            if (string.IsNullOrEmpty(cboNguoiLap.Text))
            {
                erorNguoiLap.SetError(cboNguoiLap, "Vui lòng điền người lập phiếu");
                value = false;
            }
            if (!value)
            {
                return;
            }
            DateTime ngayChon = dtpNgayNhap.Value.Date;
            if (ngayChon == defaultDate)
            {   // Hiển thị cảnh báo về ngày nhập đang để ở mặc định
                DialogResult rs = MessageBox.Show("Ngày nhập có phải là ngày mặc định là hôm nay?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );
                // Nếu chọn No thì sẽ không thực hiện lưu
                if (rs == DialogResult.No)
                {
                    dtpNgayNhap.Focus();
                    return;
                }
                try
                {
                    string sql = @"
                    INSERT INTO PhieuNhap (MaPhieuNhap,NgayNhap,NhaCungCap,NguoiLap)
                    VALUES (@MaPhieu,@NgayNhap,@NhaCungCap,@NguoiLap);
                    ";
                    using (var conn = new SQLiteConnection(strConnectionString))
                    {
                        conn.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", txtbMaPhieuNhap.Text);
                            cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value.Date.ToString("dd-MM-yyyy"));
                            cmd.Parameters.AddWithValue("@NhaCungCap", cboNCC.Text);
                            cmd.Parameters.AddWithValue("@NguoiLap", cboNguoiLap.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Lưu phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // NÚT LƯU PN SAU KHI THÊM CHI TIẾT THÔNG TIN PHIẾU NHẬP
        private void btnLuuPN_Click(object sender, EventArgs e)
        {   
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                // Kiểm tra dữ liệu trước khi lưu
                foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
                {
                    if (row.IsNewRow) continue;

                    int soLuong = 0;
                    double donGia = 0;
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out soLuong);
                    double.TryParse(row.Cells["DonGia"].Value?.ToString(), out donGia);

                    if (soLuong <= 0 || donGia <= 0)
                    {
                        MessageBox.Show($"Dữ liệu sách {row.Cells["MaSach"].Value} có lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng lưu
                    }
                }
                // Thực hiện lưu vào cơ sở dữ liệu
                using (SQLiteTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
                        {   
                            if (row.IsNewRow) continue;
                            string MaPN = txtbMaPhieuNhap.Text.Trim();
                            string MaSach = row.Cells["MaSach"].Value?.ToString();
                            string SoLuong = row.Cells["SoLuong"].Value?.ToString();
                            string DonGia = row.Cells["DonGia"].Value?.ToString();

                            string sql = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap,MaSach,SoLuong,DonGia) VALUES (@mapn,@masach,@sl,@dg)";

                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@mapn", MaPN);
                                cmd.Parameters.AddWithValue("@masach", MaSach);
                                cmd.Parameters.AddWithValue("@sl", SoLuong);
                                cmd.Parameters.AddWithValue("@dg", DonGia);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
                    }

                }
            }
        }
        // KIỂM TRA HỢP LỆ SỐ LƯỢNG, ĐƠN GIÁ CHO TỪNG DÒNG TRONG GRID
        private void dgCTPhieuNhap_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {   // Nếu đang chuyển focus sang button đóng → bỏ qua validation
            if (ActiveControl == btnDong)
            {
                return;
            }
            DataGridViewRow currentRow = dgCTPhieuNhap.Rows[e.RowIndex];

            // Bỏ qua dòng mới chưa nhập dữ liệu
            if (currentRow.IsNewRow) return;

            string maSach = currentRow.Cells["MaSach"].Value?.ToString();

            // Lấy giá trị số lượng, đơn giá
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

                e.Cancel = true;  // ngăn rời dòng

            }
        }
        // MỞ FORM CHO NGƯỜI DÙNG THÊM SÁCH NẾU SÁCH NHẬP CHƯA TỒN TẠI TRONG CSDL
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            // Mở form thêm sách mới 
            using (var f = new FormThemMoiSach())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi thêm xong, load lại danh sách sách từ DB
                    dtSach = GetDanhSachSach();  // Load lại danh sách sách
                    dgvList.DataSource = dtSach; // Cập nhật lại popup danh sách sách
                }
            }
        }
        private void cboNCC_TextChanged(object sender, EventArgs e)
        {
            erorNCC.Clear();
        }
        private void cboNguoiLap_TextChanged(object sender, EventArgs e)
        {
            erorNguoiLap.Clear();
        }        
        private void btnDong_Click(object sender, EventArgs e)        
        {
          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
