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
    public partial class FormInPN : Form
    {   //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        public FormInPN()
        {
            InitializeComponent();
        }
        // LOAD DANH SÁCH MÃ PHIẾU NHẬP VÀO COMBOBOX
        private void LoadMaPNToCombo()
        {
            using (var con = new SQLiteConnection(strConnectionString))
            {
                con.Open();
                string sql = "SELECT DISTINCT MaPhieuNhap FROM PhieuNhap";

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMaPN.DataSource = dt;
                    cboMaPN.DisplayMember = "MaPhieuNhap";
                    cboMaPN.ValueMember = "MaPhieuNhap";
                    cboMaPN.SelectedIndex = -1;
                }
            }
        }

        private void FormInPN_Load(object sender, EventArgs e)
        {
            LoadMaPNToCombo();
        }
       // LẤY THÔNG TIN CHI TIẾT PHIẾU NHẬP
        private DataTable GetCTPhieuNhap(string maPN)
        {
            ct = new DataTable();

            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string sql = @" SELECT 
                        ctpn.MaSach, s.TenSach, ctpn.SoLuong, ctpn.DonGia
                        FROM ChiTietPhieuNhap ctpn
                        JOIN Sach s ON ctpn.MaSach = s.MaSach
                        WHERE ctpn.MaPhieuNhap = @mapn";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mapn", maPN);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(ct);
                    }
                }
            }

            return ct;
        }
        // SỰ KIỆN IN
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Font
            Font title = new Font("Arial", 18, FontStyle.Bold);
            Font header = new Font("Arial", 12, FontStyle.Bold);
            Font normal = new Font("Arial", 12);

            int left = 60;
            int y = 60;

            // ===== TIÊU ĐỀ =====
            e.Graphics.DrawString($"Phiếu nhập sách {maPN}", title, Brushes.Black, left, y);
            y += 40;

            // ===== THÔNG TIN CHUNG =====
            e.Graphics.DrawString($"Ngày lập: {NgayNhap}", normal, Brushes.Black, left, y); y += 25;
            e.Graphics.DrawString($"Nhà cung cấp: {NhaCungCap}", normal, Brushes.Black, left, y);
            e.Graphics.DrawString($"Người lập: {NguoiLap}", normal, Brushes.Black, left + 350, y);
            y += 35;

            // ===== HEADER BẢNG =====
            e.Graphics.DrawString("Mã sách", header, Brushes.Black, left, y);
            e.Graphics.DrawString("Tên sách", header, Brushes.Black, left + 120, y);
            e.Graphics.DrawString("SL", header, Brushes.Black, left + 420, y);
            e.Graphics.DrawString("Đơn giá", header, Brushes.Black, left + 480, y);
            y += 30;

            // ===== VÒNG LẶP HIỂN THỊ CHI TIẾT =====
            int soDauSach = 0;
            int tongSL = 0;
            double tongTien = 0;

            foreach (DataRow row in ct.Rows)
            {
                e.Graphics.DrawString(row["MaSach"].ToString(), normal, Brushes.Black, left, y);
                e.Graphics.DrawString(row["TenSach"].ToString(), normal, Brushes.Black, left + 120, y);
                e.Graphics.DrawString(row["SoLuong"].ToString(), normal, Brushes.Black, left + 420, y);
                e.Graphics.DrawString(row["DonGia"].ToString(), normal, Brushes.Black, left + 480, y);

                soDauSach++;
                tongSL += Convert.ToInt32(row["SoLuong"]);
                tongTien += Convert.ToInt32(row["SoLuong"]) * Convert.ToDouble(row["DonGia"]);

                y += 25;
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Black, left, y, left + 700, y);
            y += 15;

            // ===== FOOTER =====
            e.Graphics.DrawString($"Số đầu sách: {soDauSach}", header, Brushes.Black, left, y);
            e.Graphics.DrawString($"Số lượng: {tongSL}", header, Brushes.Black, left + 200, y);
            e.Graphics.DrawString($"Tổng tiền: {tongTien:N0}", header, Brushes.Black, left + 400, y);
        }
        private string maPN;
        private string NhaCungCap;
        private string NgayNhap;
        private string NguoiLap;
        private DataTable ct;
        // XỬ LÝ NÚT IN
        private void btnIn_Click(object sender, EventArgs e)
        {   //  Kiểm tra đã chọn mã phiếu chưa 
            if (cboMaPN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập muốn in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            maPN = cboMaPN.SelectedValue.ToString();
            // Lấy thông tin phiếu nhập từ CSDL
            using (var conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string sql = @"SELECT NhaCungCap,NguoiLap,NgayNhap
                           FROM PhieuNhap 
                           WHERE MaPhieuNhap=@mapn";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mapn", maPN);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NhaCungCap = reader["NhaCungCap"].ToString();
                            NguoiLap = reader["NguoiLap"].ToString();
                            NgayNhap = reader["NgayNhap"].ToString();

                        }
                    }
                }
            }
            // Lấy chi tiết phiếu nhập 
            ct = GetCTPhieuNhap(maPN);
                // Nếu không có dòng nào thì thông báo
            if (ct.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập này không có chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hiển thị Preview & In 
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
        // NÚT ĐÓNG FORM
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
