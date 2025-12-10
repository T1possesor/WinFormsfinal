using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhapSach_new
{
    public partial class UserControlCTPN : UserControl
    {
        private string _maPhieuNhap;
        private string strConnectionString =
       $@"Data Source={Application.StartupPath}\project_final.db;Version=3;";

        public UserControlCTPN(string maPhieuNhap)
        {
            InitializeComponent();
            _maPhieuNhap = maPhieuNhap;
            lblCTPhieuNhap.Text = "Phiếu nhập sách " + _maPhieuNhap;
            LoadTTPhieuNhap();
            LoadTTCTPhieuNhap();            
        }
        // TẢI THÔNG TIN PHIẾU NHẬP TỪ CƠ SỞ DỮ LIỆU
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
                            lblNCC.Text = "Nhà cung cấp: " + reader["NhaCungCap"].ToString();
                            lblNguoiLap.Text = "Người lập: " + reader["NguoiLap"].ToString();                                                 
                            lblNgayNhap.Text = "Ngày lập: " + reader["NgayNhap"].ToString();
                        }
                    }
                }
            }
        }
        // TẢI THÔNG TIN CHI TIẾT PHIẾU NHẬP TỪ CƠ SỞ DỮ LIỆU
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
                    DataTable dt = new DataTable();
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    dgTTPhieuNhap.DataSource = dt;
                    dgTTPhieuNhap.Columns["MaSach"].HeaderText = "Mã sách";
                    dgTTPhieuNhap.Columns["TenSach"].HeaderText = "Tên sách";
                    dgTTPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgTTPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                }
            }
            TinhTongDauSach();
            TinhTongSoLuong();
            TinhTongThanhTien();
        }
        // ---------------------------
        //  TÍNH TỔNG ĐẦU SÁCH
        // ---------------------------
        private void TinhTongDauSach()
        {
            int soDauSach = 0;

            foreach (DataGridViewRow row in dgTTPhieuNhap.Rows)
            {
                if (!row.IsNewRow)   // bỏ dòng trống để thêm dữ liệu
                    soDauSach++;
            }

            lblTongDauSach.Text = "Tổng đầu sách: " + soDauSach;
        }       
        // ---------------------------
        //  TÍNH TỔNG SỐ LƯỢNG
        // ---------------------------
        private void TinhTongSoLuong()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgTTPhieuNhap.Rows)
            {
                if (!row.IsNewRow) // bỏ dòng để thêm mới
                {
                    int sl = 0;
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out sl);
                    tong += sl;
                }
            }
            lblSoLuong.Text = "Số lượng: " + tong;

        }       
        // ---------------------------
        //  TÍNH TỔNG THÀNH TIỀN
        // ---------------------------
        private void TinhTongThanhTien()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgTTPhieuNhap.Rows)
            {
                if (row.IsNewRow) continue;   // bỏ dòng trống cuối

                int soLuong = 0;
                int donGia = 0;

                int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out soLuong);
                int.TryParse(row.Cells["DonGia"].Value?.ToString(), out donGia);

                // Thành tiền = SL * Đơn giá
                tong += soLuong * donGia;
            }
            lblThanhTien.Text =
               "Tổng tiền: " + tong.ToString("#,##0");

        }
       

    }
}
