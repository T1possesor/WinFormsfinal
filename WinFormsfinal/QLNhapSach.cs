using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn_1
{
    public partial class QLNhapSach : Form
    {
        //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;

        //Tạo DataTable
        DataTable dataTable = new DataTable();

        int index;
        private DateTime defaultDate;
        public QLNhapSach()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Khởi động kết nối
            conn = new SQLiteConnection(strConnectionString);
            //Mở kết nối
            conn.Open();
            LoadPhieuNhap();
            LoadNguoiLapToCombo();
            LoadCTPhieuNhap();
            dtpNgayNhap.Value = DateTime.Now;
            defaultDate = dtpNgayNhap.Value.Date;


            // Tăng chiều cao hàng tiêu đề
            dgPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgPhieuNhap.ColumnHeadersHeight = 40;

            dgCTPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgCTPhieuNhap.ColumnHeadersHeight = 40;


        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ds.Dispose();
            // ds = null;
            conn.Close();
            conn = null;

        }
        void LoadPhieuNhap()
        {
            try
            {
                string sql = "SELECT MaPhieuNhap, NgayNhap, NhaCungCap, NguoiLap FROM PhieuNhap";

                bool isLocTheoNgay = chboxLoc.Checked;
                if (isLocTheoNgay)
                {
                    sql += " WHERE SUBSTR(NgayNhap,7,4) || SUBSTR(NgayNhap,4,2) || SUBSTR(NgayNhap,1,2) BETWEEN @TuNgay AND @DenNgay";
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (isLocTheoNgay)
                    {

                        DateTime tuNgay = dtpTuNgay.Value.Date;
                        DateTime denNgay = dtpDenNgay.Value.Date;

                        if (tuNgay > denNgay)
                        {
                            MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyyMMdd"));
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyyMMdd"));
                    }
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "PhieuNhap");

                    dgPhieuNhap.DataSource = ds.Tables["PhieuNhap"];

                    dgPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu nhập";
                    dgPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                    dgPhieuNhap.Columns["NhaCungCap"].HeaderText = "Nhà cung cấp";
                    dgPhieuNhap.Columns["NguoiLap"].HeaderText = "Người lập";

                    // Thêm cột nút "Hóa đơn" nếu chưa tồn tại
                    if (dgPhieuNhap.Columns["btnHoaDon"] == null)
                    {
                        DataGridViewButtonColumn btnHoaDon = new DataGridViewButtonColumn
                        {
                            HeaderText = "Hóa đơn",
                            Name = "btnHoaDon",
                            Text = "Xem / Import",
                            UseColumnTextForButtonValue = true
                        };
                        dgPhieuNhap.Columns.Add(btnHoaDon);
                    }
                }
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
                MessageBox.Show("File SQLite đang dùng:\n" + strConnectionString);
            }
        }
        //Mỗi khi thay đổi trạng thái lọc sẽ thực hiện load lại phiếu nhập
        private void chboxLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }
        // Thực hiện load người lập đã tồn tại trong db vào combobox
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
        void LoadCTPhieuNhap()
        {
            string sqlCheck = "SELECT COUNT(*) FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@MaPN";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sqlCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPN", txtbMaPhieu_1.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        // Trường hợp: Nếu có dữ liệu trong DB  thì tải lên DataGridView
                        string sqlLoad = "SELECT MaPhieuNhap,MaSach,SoLuong,DonGia FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@MaPN";
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(sqlLoad, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@MaPN", txtbMaPhieu_1.Text);
                            dataTable = new DataTable();
                            da.Fill(dataTable);
                            dgCTPhieuNhap.DataSource = dataTable;
                        }
                    }
                    // Trường hợp chưa có thì thực hiện thêm header vào datagridview
                    else
                    {
                        dataTable = new DataTable();
                        // dataTable.Columns.Add("Mã phiếu nhập", typeof(string));
                        dataTable.Columns.Add("MaPhieuNhap", typeof(string));
                        dataTable.Columns.Add("MaSach", typeof(string));
                        dataTable.Columns.Add("SoLuong", typeof(int));
                        dataTable.Columns.Add("DonGia", typeof(double));
                        // Liên kết DataTable với DataGridView
                        dgCTPhieuNhap.DataSource = dataTable;
                    }
                    dgCTPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu nhập";
                    dgCTPhieuNhap.Columns["MaSach"].HeaderText = "Mã sách";
                    dgCTPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgCTPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // hàm lấy mã phiếu nhập ở dòng cuối cùng trong bảng phiếu nhập
        public string LayMaPN()
        {
            string MaPN = null;
            string sql = "SELECT MaPhieuNhap FROM PhieuNhap ORDER BY MaPhieuNhap DESC LIMIT 1";
            var connTemp = new SQLiteConnection(strConnectionString);
            connTemp.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql, connTemp))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MaPN = result.ToString();
                }

            }
            return MaPN;
            connTemp.Close();
        }
        // hàm để thực hiện sinh ra mã phiếu nhập dựa trên dòng cuối cùng của mã phiếu nhập
        public string SinhMaPN()
        {
            string prefix = "PN";
            int dodaikytuso = 3;

            string MaPNCC = LayMaPN();

            if (string.IsNullOrEmpty(MaPNCC))
            {
                return prefix + "001";
            }
            int number = int.Parse(MaPNCC.Substring(prefix.Length));
            number++;
            return prefix + number.ToString().PadLeft(dodaikytuso, '0');
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            bool value = true;
            string maPN = SinhMaPN();
            txtbMaPhieu.Text = maPN;
            if (string.IsNullOrEmpty(txtbNCC.Text))
            {
                erorNCC.SetError(txtbNCC, "Vui lòng điền Nhà cung cấp");
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
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", maPN);
                        cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value.Date.ToString("dd-MM-yyyy"));
                        cmd.Parameters.AddWithValue("@NhaCungCap", txtbNCC.Text);
                        cmd.Parameters.AddWithValue("@NguoiLap", cboNguoiLap.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Lưu phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuNhap();
                    LoadNguoiLapToCombo();
                    ResetTTPN();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void txtbNCC_TextChanged(object sender, EventArgs e)
        {
            erorNCC.Clear();
        }
        private void cboNguoiLap_TextChanged_1(object sender, EventArgs e)
        {
            erorNguoiLap.Clear();
        }
        void ResetTTPN()
        {
            dtpNgayNhap.Value = defaultDate;
            txtbMaPhieu.Text = "";
            txtbNCC.ResetText();
            cboNguoiLap.Text = "";
        }
        void XoaPN()
        {
            if (dgPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Lấy dòng được chọn
            DataGridViewRow row = dgPhieuNhap.SelectedRows[0];
            string maPN = row.Cells["MaPhieuNhap"].Value.ToString();
            string sql = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPN";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
                    cmd.ExecuteNonQuery();
                }
                dgPhieuNhap.Rows.RemoveAt(index);
                LoadPhieuNhap();
                MessageBox.Show("Đã xóa thành công" + maPN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetTTPN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaPN();
        }
        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            XoaPN();
            ResetTextBox();
        }
        void SuaPN()
        {
            string maPN = txtbMaPhieu.Text;

            if (string.IsNullOrEmpty(txtbNCC.Text))
            {
                erorNCC.SetError(txtbNCC, "Vui lòng điền Nhà cung cấp");
                return;
            }

            try
            {
                string sql = @"
                UPDATE PhieuNhap
                SET NgayNhap = @NgayNhap,
                    NhaCungCap = @NhaCungCap,
                    NguoiLap = @NguoiLap
                WHERE MaPhieuNhap = @MaPN";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
                    cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value.Date.ToString("dd-MM-yyyy"));
                    cmd.Parameters.AddWithValue("@NhaCungCap", txtbNCC.Text);
                    cmd.Parameters.AddWithValue("@NguoiLap", cboNguoiLap.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhieuNhap();
                ResetTTPN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu nhập: " + ex.Message);
            }
        }
        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            SuaPN();
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaPN();
        }
        private void dgPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgPhieuNhap.Columns[e.ColumnIndex].Name == "btnHoaDon")
            {
                // Lấy mã phiếu nhập dòng hiện tại
                string maPN = dgPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value.ToString();

                // Mở FormHoaDon và truyền mã phiếu nhập
                ImportHĐCT fHoaDon = new ImportHĐCT(maPN);
                fHoaDon.Show();
            }
        }
        private void toolStripLamMoi_Click(object sender, EventArgs e)
        {
            ResetTTPN();
            erorNCC.Clear();
            erorNguoiLap.Clear();
        }
        private void dgPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgPhieuNhap.Rows[e.RowIndex];
                // Lấy dữ liệu hiện tại từ dòng
                txtbMaPhieu.Text = row.Cells["MaPhieuNhap"].Value.ToString();
                txtbNCC.Text = row.Cells["NhaCungCap"].Value.ToString();
                cboNguoiLap.Text = row.Cells["NguoiLap"].Value.ToString();

                // Nếu có cột ngày nhập            

                if (DateTime.TryParseExact(row.Cells["NgayNhap"].Value.ToString(), "dd-MM-yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime ngay))
                {
                    dtpNgayNhap.Value = ngay;
                }
            }
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            erorSoLuong.Clear();
        }
        // Chỉ cho phép nhập số đối với đơn giá
        private void txtbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // bỏ ký tự không hợp lệ
            }
        }
        // Khi chọn ngày bắt đầu lọc thì thực hiện lọc nếu checkbox lọc được checked
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (chboxLoc.Checked)
                LoadPhieuNhap();
        }
        // Khi chọn ngày kết thúc lọc thì thực hiện lọc nếu checkbox lọc được checked
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (chboxLoc.Checked)
                LoadPhieuNhap();
        }
        private string MaPhieuNhapChon;
        // khi chọn vào chi tiết phiếu nhập sẽ hiển thị chi tiết từng sách trong phiếu nhập
        private void chiTiếtNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            txtbTongCong.ResetText();
            if (dgPhieuNhap.CurrentRow == null) return;

            // Lấy dữ liệu dòng được chọn
            DataGridViewRow row = dgPhieuNhap.CurrentRow;

            MaPhieuNhapChon = row.Cells["MaPhieuNhap"].Value.ToString();
            // Gán vào các TextBox trên tab chi tiết
            txtbMaPhieu_1.Text = MaPhieuNhapChon;
            txtbMaPhieu_1.Enabled = false;

            // Chuyển tab sang tab Chi tiết
            tabControl1.SelectedTab = tabPage2;
            LoadCTPhieuNhap();
        }
        void TinhTong()
        {
            double tongcong = 0;
            foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                tongcong += ((Int32.Parse(row.Cells["SoLuong"].Value.ToString())) * (Double.Parse(row.Cells["DonGia"].Value.ToString())));
            }
            txtbTongCong.Text = tongcong.ToString();
        }
        private void btnTinhTong_Click_1(object sender, EventArgs e)
        {
            TinhTong();
        }
        // dựa trên tên sách nhập để lấy mã sách lưu trong data grid view
        public string LayMaSachTheoTen(string TenSach)
        {
            string MaSach = null;
            string sql = @"SELECT MaSach From Sach WHERE TenSach=@TenSach;";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenSach", TenSach);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    MaSach = result.ToString();
            }
            return MaSach;
        }
        // khi nhập mã phiếu trong chi tiết nhập sẽ kiểm tra xem có trong db thì mới thêm vào data grid view
        private bool KiemTraPhieuNhapDaTonTai(string maPN)
        {
            string sql = "SELECT COUNT(*) FROM PhieuNhap WHERE MaPhieuNhap = @ma";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", maPN);

                long count = (long)cmd.ExecuteScalar();

                return count > 0;
            }

        }
        //lấy danh sách tên sách dựa trên text người dùng nhập trên txtbTenSach
        private List<string> TimSachTheoKeyword(string keyword)
        {
            List<string> list = new List<string>();

            string sql = @"SELECT TenSach FROM Sach WHERE TenSach LIKE '%" + keyword + "%'";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(rd.GetString(0));
                    }
                }
            }
            return list;
        }
        //sự kiện textchange gọi hàm TimSachTheoKeyWord, sau đó đưa danh sách vào listbox
        private void txtbTenSach_TextChanged(object sender, EventArgs e)
        {
            erorTenSach.Clear();
            string keyword = txtbTenSach.Text.Trim();

            // Nếu trống thì không gợi ý
            if (keyword == "")
                return;

            // Lấy dữ liệu gợi ý
            var suggestions = TimSachTheoKeyword(keyword);
            if (suggestions.Count == 0)
            {
                return;
            }
            // Gán dữ liệu vào ListBox
            listBox1.DataSource = suggestions;
            listBox1.Visible = true;
            listBox1.Top = txtbTenSach.Bottom + 2;
            listBox1.Height = 80;

        }
        // sự kiện click 2 lần vào trong item sẽ gán vào txtbTenSach
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Gán giá trị ListBox vào TextBox
                txtbTenSach.Text = listBox1.SelectedItem.ToString();
            }
        }
        void ResetTextBox()
        {
            txtbMaPhieu_1.Enabled = false;
            txtbTenSach.ResetText();
            txtbDonGia.ResetText();
            numSoLuong.Value = 0;
            listBox1.Visible = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool value = true;
            string MaPhieu = txtbMaPhieu_1.Text;
            if (!KiemTraPhieuNhapDaTonTai(MaPhieu))
            {
                MessageBox.Show("Mã phiếu nhập chưa tồn tại, vui lòng tạo phiếu nhập!");
                return;
            }
            string TenSach = txtbTenSach.Text.Trim();
            string MaSach = LayMaSachTheoTen(TenSach);
            if (string.IsNullOrEmpty(txtbTenSach.Text))
            {
                erorTenSach.SetError(txtbTenSach, "Vui lòng điền tên sách");
                value = false;
            }
            else
            {
                if (MaSach == null)
                {
                    MessageBox.Show("Không tìm thấy sách trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (numSoLuong.Value <= 0)
            {
                erorSoLuong.SetError(numSoLuong, "Số lượng phải lớn hơn 0");
                value = false;
            }
            if (string.IsNullOrEmpty(txtbDonGia.Text) || !string.IsNullOrEmpty(txtbDonGia.Text) && double.Parse(txtbDonGia.Text) <= 0)
            {
                erorDonGia.SetError(txtbDonGia, "Kiểm tra lại đơn giá không bỏ trống và phải lớn hơn 0");
                value = false;
            }
            if (!value) { return; }
            foreach (DataRow row in dataTable.Rows)
            {
                string existingMaSach = row["MaSach"].ToString();
                if (existingMaSach.Equals(MaSach))
                {
                    MessageBox.Show("Sách này đã tồn tại trong phiếu. Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            double DonGia;
            if (!double.TryParse(txtbDonGia.Text, out DonGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            dataTable.Rows.Add(MaPhieu, MaSach, numSoLuong.Value, DonGia);
            ResetTextBox();
            TinhTong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool value = true;
            DataGridViewRow row = dgCTPhieuNhap.Rows[index];
            string TenSach = txtbTenSach.Text.Trim();
            string MaSach = LayMaSachTheoTen(TenSach);
            if (MaSach == null)
            {
                MessageBox.Show("Không tìm thấy sách trong cơ sở dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtbTenSach.Text))
            {
                erorTenSach.SetError(txtbTenSach, "Vui lòng điền tên sách");
                value = false;
            }
            if (numSoLuong.Value <= 0)
            {
                erorSoLuong.SetError(numSoLuong, "Số lượng phải lớn hơn 0");
                value = false;
            }
            if (!value) { return; }
            row.Cells["MaSach"].Value = MaSach;
            row.Cells["SoLuong"].Value = numSoLuong.Value;
            row.Cells["DonGia"].Value = txtbDonGia.Text;
            ResetTextBox();
            TinhTong();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgCTPhieuNhap.CurrentRow;
            if (row == null || row.IsNewRow)
            {
                return;
            }
            dgCTPhieuNhap.Rows.Remove(row);
            ResetTextBox();
            TinhTong();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            for (int i = dgCTPhieuNhap.Rows.Count - 1; i >= 0; i--)
            {
                if (!dgCTPhieuNhap.Rows[i].IsNewRow)
                {
                    dgCTPhieuNhap.Rows.RemoveAt(i);
                }
                txtbMaPhieu_1.Enabled = true;
                txtbMaPhieu_1.ResetText();
                txtbTenSach.ResetText();
                txtbDonGia.ResetText();
                numSoLuong.Value = 0;
                listBox1.Visible = false;

            }

        }
        private void dgCTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                DataGridViewRow row = dgCTPhieuNhap.Rows[e.RowIndex];
                // Từ mã sách để ra tên sách
                string sql = @"SELECT TenSach FROM Sach WHERE MaSach=@MaSach;";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", row.Cells["MaSach"].Value?.ToString());
                    object res = cmd.ExecuteScalar();
                    if (res != null)
                    {
                        txtbTenSach.Text = res.ToString();
                    }

                }
                numSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtbDonGia.Text = row.Cells["DonGia"].Value?.ToString();
                //txtbMaPhieu_1.Text = row.Cells["Mã phiếu nhập"].Value?.ToString();
                txtbMaPhieu_1.Enabled = false;
            }
        }


        private void btnLuuDL_Click_1(object sender, EventArgs e)
        {
            using (SQLiteTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    foreach (DataGridViewRow row in dgCTPhieuNhap.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // string MaPN = row.Cells["Mã Phiếu Nhập"].Value?.ToString();
                        string MaPN = txtbMaPhieu_1.Text.Trim();
                        string MaSach = row.Cells["MaSach"].Value?.ToString();
                        string SoLuong = row.Cells["SoLuong"].Value?.ToString();
                        string DonGia = row.Cells["DonGia"].Value?.ToString();
                        // Kiểm tra xem dòng đã tồn tại chưa
                        string sqlCheck = @"
                        SELECT COUNT(*) 
                        FROM ChiTietPhieuNhap 
                        WHERE MaPhieuNhap=@mapn AND MaSach=@masach";

                        int countExist = 0;
                        using (SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@mapn", MaPN);
                            cmdCheck.Parameters.AddWithValue("@masach", MaSach);
                            countExist = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        }

                        if (countExist > 0)
                        {
                            // Nếu đã tồn tại thì thực hiện câu lệch update
                            string sqlUpdate = @"
                        UPDATE ChiTietPhieuNhap 
                        SET SoLuong=@sl, DonGia=@dg
                        WHERE MaPhieuNhap=@mapn AND MaSach=@masach";

                            using (SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate, conn, trans))
                            {
                                cmdUpdate.Parameters.AddWithValue("@sl", SoLuong);
                                cmdUpdate.Parameters.AddWithValue("@dg", DonGia);
                                cmdUpdate.Parameters.AddWithValue("@mapn", MaPN);
                                cmdUpdate.Parameters.AddWithValue("@masach", MaSach);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Nếu chưa tồn tại thì thực hiện insert
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
                    }
                    trans.Commit();
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTaiLen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbMaPhieu_1.Text))
            {
                MessageBox.Show("Bạn chưa điền mã phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraPhieuNhapDaTonTai(txtbMaPhieu_1.Text))
            {
                MessageBox.Show("Mã phiếu nhập chưa tồn tại, vui lòng tạo phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadCTPhieuNhap();
            txtbMaPhieu_1.Enabled = false;
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            for (int i = dgCTPhieuNhap.Rows.Count - 1; i >= 0; i--)
            {
                if (!dgCTPhieuNhap.Rows[i].IsNewRow)
                {
                    dgCTPhieuNhap.Rows.RemoveAt(i);
                }
                txtbMaPhieu_1.Enabled = true;
                txtbMaPhieu_1.ResetText();
                txtbTenSach.ResetText();
                txtbDonGia.ResetText();
                numSoLuong.Value = 0;
                listBox1.Visible = false;

            }
            txtbTongCong.ResetText();
            erorTenSach.Clear();
            erorSoLuong.Clear();
            erorDonGia.Clear();
        }

        private void txtbDonGia_TextChanged(object sender, EventArgs e)
        {
            erorDonGia.Clear();
        }
    }
}
