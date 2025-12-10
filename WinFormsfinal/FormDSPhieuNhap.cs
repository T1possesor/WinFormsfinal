using DoAn_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhapSach_new
{
    public partial class FormDSPhieuNhap : Form
    {   //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        public FormDSPhieuNhap()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Khởi động kết nối
            conn = new SQLiteConnection(strConnectionString);
            //Mở kết nối
            conn.Open();

            LoadPhieuNhap();

            ToolTipDSPN.SetToolTip(btnLamMoi, "Tải lại danh sách phiếu nhập");
            ToolTipDSPN.SetToolTip(btnInPN, "In thông tin phiếu nhập");          
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn = null;
        }
        // HÀM LẤY MÃ PHIẾU NHẬP CUỐI CÙNG TRONG BẢNG PHIẾU NHẬP       
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
        // HÀM TỰ SINH MÃ PHIẾU NHẬP DỰA TRÊN DÒNG CUỐI CÙNG 
        public string SinhMaPN()
        {
            string prefix = "PN";
            int dodaikytuso = 3;

            string MaPNCC = LayMaPN();
            // Nếu chưa có phiếu nhập nào
            if (string.IsNullOrEmpty(MaPNCC))
            {
                return prefix + "001";
            }
            // Lấy phần số phía sau PN
            int number = int.Parse(MaPNCC.Substring(prefix.Length));
            number++;
            // Trả về mã phiếu nhập sinh ra
            return prefix + number.ToString().PadLeft(dodaikytuso, '0');
        }
        // Nút lập phiếu nhập
        private void btnLapPN_Click(object sender, EventArgs e)
        {   // Truyền vào mã phiếu nhập tự sinh ra
            string maPN = SinhMaPN();
            // Mở form thêm phiếu nhập 
            using (FormThemPN fThemPN = new FormThemPN(maPN))
            {
                if (fThemPN.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi nhấn nút đóng ở form Thêm PN, load lại danh sách phiếu nhập
                    LoadPhieuNhap();
                }
            }
        }
        // HÀM TÍNH TỔNG SỐ PHIẾU NHẬP
        void TinhTongPN()
        {
            int soPN = 0;

            foreach (DataGridViewRow row in dgPhieuNhap.Rows)
            {   // bỏ dòng trống không cộng vào tổng số phiếu nhập
                if (!row.IsNewRow)
                    soPN++;
            }
            // hiển thị tổng số phiếu nhập
            toolStripStatusLabelSoPN.Text = "Tổng kết quả: " + soPN;
        }
        // HÀM DANH SÁCH PHIẾU NHẬP KÈM LỌC THEO ĐIỀU KIỆN NGÀY (nếu có)
        void LoadPhieuNhap()
        {
            try
            {
                string sql = "SELECT MaPhieuNhap, NgayNhap, NhaCungCap, NguoiLap FROM PhieuNhap";
                // Kiểm tra xem người dùng có bật lọc theo ngày hay không
                bool isLocTheoNgay = chboxLoc.Checked;
                // Nếu bật lọc thì thêm điều kiện WHERE
                if (isLocTheoNgay)
                {   // SUBSTR cắt chuỗi kiểu dd-MM-yyyy thành yyyymmdd để so sánh ngày
                    sql += " WHERE SUBSTR(NgayNhap,7,4) || SUBSTR(NgayNhap,4,2) || SUBSTR(NgayNhap,1,2) BETWEEN @TuNgay AND @DenNgay";
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (isLocTheoNgay)
                    {
                        // Lấy 2 ngày từ DateTimePicker
                        DateTime tuNgay = dtpTuNgay.Value.Date;
                        DateTime denNgay = dtpDenNgay.Value.Date;

                        if (tuNgay > denNgay)
                        {
                            MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        // Truyền tham số dạng yyyymmdd để SQLite so sánh
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.ToString("yyyyMMdd"));
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay.ToString("yyyyMMdd"));
                    }
                    da = new SQLiteDataAdapter(cmd);
                    ds = new DataSet();
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
            // Sau khi load, thực hiện tính tổng số phiếu nhập
            TinhTongPN();

        }
        //Mỗi khi thay đổi trạng thái lọc sẽ thực hiện load lại phiếu nhập
        private void chboxLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhieuNhap();
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
        // HIỂN THỊ PANEL THÔNG TIN CHI TIẾT PHIẾU NHẬP KHI NHẤN VÀO Ô MÃ PHIẾU NHẬP
        private void dgPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {   // Nếu là dòng mới thì return
            if (dgPhieuNhap.Rows[e.RowIndex].IsNewRow)
                return;
            if (e.RowIndex >= 0 && e.ColumnIndex == dgPhieuNhap.Columns["MaPhieuNhap"].Index)
            {  // Lấy mã phiếu nhập từ dòng đang được chọn
                string maPN = dgPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value.ToString();
                // Tạo UC
                UserControlCTPN uc;
                try
                {     // Xóa usercontrol cũ để không bị chồng
                    PanelTTPN_ND.Controls.Clear();
                    // Truyền vào mã phiếu để load dữ liệu
                    uc = new UserControlCTPN(maPN);
                    MessageBox.Show("Ô đang được click");
                    // Hiển thị panel và thêm User Control
                    PanelTTPN.Visible = true;
                    PanelTTPN_ND.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;

                    dgPhieuNhap.SendToBack();
                    PanelTTPN.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }


            }
        }
        // THIẾT LẬP KÍCH THƯỚC PANEL CHỨA USERCONTROLTTPN KHI RESIZE
        private void dgPhieuNhap_Resize(object sender, EventArgs e)
        {
            PanelTTPN.Height = dgPhieuNhap.Height - statusStrip1.Height;
            int colWidth = 150;
            PanelTTPN.Width = this.Width - dgPhieuNhap.Left - colWidth;
            PanelTTPN.Left = this.ClientSize.Width - PanelTTPN.Width;
        }
        // NÚT ĐÓNG PANEL TTPN (HIỂN THỊ USERCONTROL TTPN)
        private void btnDongTTPN_Click(object sender, EventArgs e)
        {
            PanelTTPN.Visible = false;
            PanelTTPN_ND.Controls.Clear();
        }
        // KIỂM TRA CÓ THỂ XÓA PHIẾU NHẬP KHÔNG
        bool KiemTraSachKhachDung(string maPN, out string loi)
        {
            loi = "";
            string sqlChiTiet = "SELECT MaSach, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPN";
            using (SQLiteCommand cmd = new SQLiteCommand(sqlChiTiet, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maSach = reader["MaSach"].ToString();
                        int soLuongPN = Convert.ToInt32(reader["SoLuong"]);

                        string sqlSoLuong = "SELECT SoLuongConLai, SoLuongMat FROM Sach WHERE MaSach = @MaSach";
                        using (SQLiteCommand cmd2 = new SQLiteCommand(sqlSoLuong, conn))
                        {
                            cmd2.Parameters.AddWithValue("@MaSach", maSach);
                            using (SQLiteDataReader r = cmd2.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    int soLuongConLai = Convert.ToInt32(r["SoLuongConLai"]);
                                    int soLuongMat = Convert.ToInt32(r["SoLuongMat"]);

                                    if (soLuongConLai + soLuongMat < soLuongPN)
                                    {
                                        loi += "/" + maSach + "/";
                                    }
                                }
                            }
                        }
                    }
                    if (loi != "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // CẬP NHẬT LẠI KHO KHI XÓA PHIẾU NHẬP
        void CapNhatKhoKhiXoa(string maPN)
        {
            string sqlChiTiet = "SELECT MaSach, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPN";
            using (SQLiteCommand cmd = new SQLiteCommand(sqlChiTiet, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maSach = reader["MaSach"].ToString();
                        int soLuongPN = Convert.ToInt32(reader["SoLuong"]);

                        string sqlGet = "SELECT SoLuongConLai, SoLuongTong FROM Sach WHERE MaSach=@MaSach";
                        using (SQLiteCommand cmd2 = new SQLiteCommand(sqlGet, conn))
                        {
                            cmd2.Parameters.AddWithValue("@MaSach", maSach);
                            using (SQLiteDataReader r = cmd2.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    int soLuongConLai = Convert.ToInt32(r["SoLuongConLai"]);
                                    int soLuongTong = Convert.ToInt32(r["SoLuongTong"]);

                                    int soLuongConLaiMoi = Math.Max(0, soLuongConLai - soLuongPN);
                                    int soLuongTongMoi = soLuongTong - soLuongPN;

                                    string sqlUpdate = @"UPDATE Sach 
                                          SET SoLuongConLai=@SoLuongConLaiMoi, SoLuongTong=@SoLuongTongMoi 
                                          WHERE MaSach=@MaSach";
                                    using (SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate, conn))
                                    {
                                        cmdUpdate.Parameters.AddWithValue("@SoLuongConLaiMoi", soLuongConLaiMoi);
                                        cmdUpdate.Parameters.AddWithValue("@SoLuongTongMoi", soLuongTongMoi);
                                        cmdUpdate.Parameters.AddWithValue("@MaSach", maSach);
                                        cmdUpdate.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        // XÓA PHIẾU NHẬP
        void XoaPN()
        {
            int index = dgPhieuNhap.CurrentRow.Index;
            if (dgPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Lấy dòng được chọn
            DataGridViewRow row = dgPhieuNhap.SelectedRows[0];
            string maPN = row.Cells["MaPhieuNhap"].Value.ToString();

            if (!KiemTraSachKhachDung(maPN, out string maSachLoi))
            {
                MessageBox.Show($"Không thể xóa phiếu nhập vì sách {maSachLoi} đã được mượn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CapNhatKhoKhiXoa(maPN);
            string sql = @"DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPN;
                   DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPN;

        ";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // CLICK MENU "XÓA PHIẾU NHẬP"
        private void ToolStripMenuItemXoaPN_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgPhieuNhap.SelectedRows[0];
            string maPN = row.Cells["MaPhieuNhap"].Value.ToString();
            DialogResult dg = MessageBox.Show($"Bạn có chắc muốn xóa phiếu nhập {maPN}?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                XoaPN();
            }

        }
        // CLICK MENU "SỬA PHIẾU NHẬP"
        private void ToolStripMenuItemSuaPN_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgPhieuNhap.SelectedRows[0];
            string maPN = row.Cells["MaPhieuNhap"].Value.ToString();
            // 1. Mở form sửa phiếu nhập
            using (FormSuaPN fSuaPN = new FormSuaPN(maPN))
            {
                if (fSuaPN.ShowDialog() == DialogResult.OK)
                {
                    // 2. Sau khi thêm xong, load lại danh sách Phiếu nhập từ DB
                    LoadPhieuNhap();
                }
            }
        }
        // NÚT "HÓA ĐƠN" ĐỂ HIỂN THỊ BIÊN BẢN NHẬN SÁCH
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
        // NÚT IN PHIẾU NHẬP
        private void btnInPN_Click(object sender, EventArgs e)
        {   // Mở form in phiếu nhập để điển tham số và thực hiện in
            FormInPN formInPN = new FormInPN();
            formInPN.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }
    }
}
