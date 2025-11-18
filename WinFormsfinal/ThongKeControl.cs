using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class ThongKeControl : UserControl
    {
        // ĐƯỜNG DẪN DB – chỉnh đúng như của bạn
        private const string ConnectionString =
            @"Data Source=D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\project_final.db";

        public ThongKeControl()
        {
            InitializeComponent();
            LoadStatisticsFromDatabase();
        }

        /// <summary>
        /// Đọc dữ liệu từ database và đổ lên các label + biểu đồ
        /// </summary>
        private void LoadStatisticsFromDatabase()
        {
            try
            {
                // 1. Tổng số đầu sách (trong các phiếu mượn)
                int tongDauSach = GetTotalTitles();
                lblTongSachValue.Text = tongDauSach.ToString("N0");

                // 2. Tổng lượt mượn trong tháng hiện tại
                int luotMuonThang = GetBorrowCountThisMonth();
                lblLuotMuonValue.Text = luotMuonThang.ToString("N0") + " lượt";

                // 3. Số độc giả đang hoạt động
                int docGiaHoatDong = GetActiveReaders();
                lblDocGiaValue.Text = docGiaHoatDong.ToString("N0");

                // 4. Số phòng đã từng được đặt
                int soPhongDaDat = GetBookedRooms();
                lblPhongValue.Text = $"{soPhongDaDat} phòng";

                // 5. Biểu đồ: số đơn đặt phòng theo Mục đích
                LoadUsageChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải thống kê từ cơ sở dữ liệu:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Các hàm lấy số liệu

        // Đếm số mã sách khác nhau trong chi tiết phiếu mượn
        private int GetTotalTitles()
        {
            const string sql = "SELECT COUNT(DISTINCT MaSach) FROM ChiTietPhieuMuon;";
            return ExecuteScalarInt(sql);
        }

        // Lượt mượn trong tháng hiện tại (dựa vào NgayMuon)
        private int GetBorrowCountThisMonth()
        {
            string currentMonth = DateTime.Now.ToString("yyyy-MM");

            const string sql = @"
                SELECT COUNT(*) 
                FROM ChiTietPhieuMuon
                WHERE strftime('%Y-%m', NgayMuon) = @month;
            ";

            return ExecuteScalarInt(sql, ("@month", currentMonth));
        }

        // Số độc giả đang hoạt động
        private int GetActiveReaders()
        {
            const string sql = "SELECT COUNT(*) FROM NguoiDung WHERE TrangThai = 'HoatDong';";
            return ExecuteScalarInt(sql);
        }

        // Số phòng đã từng được đặt
        private int GetBookedRooms()
        {
            const string sql = "SELECT COUNT(DISTINCT MaPhong) FROM DonDatPhongHocNhom;";
            return ExecuteScalarInt(sql);
        }

        #endregion

        #region Biểu đồ số đơn đặt phòng theo Mục đích

        private void LoadUsageChart()
        {
            // Đổi label cho đúng ý nghĩa
            lblCN.Text   = "Thảo luận";
            lblKT.Text   = "Thuyết trình";
            lblNN.Text   = "Khác";
            lblKH.Text   = string.Empty;
            lblKhac.Text = string.Empty;

            int thaoLuan = 0;
            int thuyetTrinh = 0;
            int khac = 0;

            const string sql = @"
                SELECT MucDich, COUNT(*) AS SoLuong
                FROM DonDatPhongHocNhom
                GROUP BY MucDich;
            ";

            using (var conn = new SqliteConnection(ConnectionString))
            using (var cmd = new SqliteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mucDich = reader["MucDich"]?.ToString() ?? string.Empty;
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);

                        if (mucDich.Equals("Thảo luận nhóm", StringComparison.OrdinalIgnoreCase))
                        {
                            thaoLuan = soLuong;
                        }
                        else if (mucDich.Equals("Thuyết trình nhóm", StringComparison.OrdinalIgnoreCase))
                        {
                            thuyetTrinh = soLuong;
                        }
                        else
                        {
                            // Còn lại gom chung vào "Khác"
                            khac += soLuong;
                        }
                    }
                }
            }

            // Tính chiều cao cột tương đối
            int max = Math.Max(thaoLuan, Math.Max(thuyetTrinh, khac));
            if (max <= 0) max = 1; // tránh chia 0

            int maxHeight = 160; // chiều cao tối đa 1 cột
            int hThaoLuan = (int)(maxHeight * thaoLuan / (double)max);
            int hThuyetTrinh = (int)(maxHeight * thuyetTrinh / (double)max);
            int hKhac = (int)(maxHeight * khac / (double)max);

            panelBarCN.Height = hThaoLuan;
            panelBarKT.Height = hThuyetTrinh;
            panelBarNN.Height = hKhac;
            panelBarKH.Height = 0;
            panelBarKhac.Height = 0;

            // Căn cột từ dưới lên
            int baseLine = panelBarContainer.Height - 35;

            panelBarCN.Top   = baseLine - panelBarCN.Height;
            panelBarKT.Top   = baseLine - panelBarKT.Height;
            panelBarNN.Top   = baseLine - panelBarNN.Height;
            panelBarKH.Top   = baseLine - panelBarKH.Height;
            panelBarKhac.Top = baseLine - panelBarKhac.Height;
        }

        #endregion

        #region Helper: chạy scalar int

        private int ExecuteScalarInt(string sql, params (string name, object value)[] parameters)
        {
            using (var conn = new SqliteConnection(ConnectionString))
            using (var cmd = new SqliteCommand(sql, conn))
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                }

                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToInt32(result);
            }
        }

        #endregion
    }
}
