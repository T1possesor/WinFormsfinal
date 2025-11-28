using System;
using System.Windows.Forms;
using System.Data.SQLite;                           // ĐỔI: dùng System.Data.SQLite
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsfinal
{
    public partial class ThongKeControl : UserControl
    {
        // KẾT NỐI DB – giống kiểu fLogin / fRegister
        private const string ConnectionString =
            @"Data Source=project_final.db;Version=3;";

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

                // ================== CÁC BIỂU ĐỒ ==================
                LoadChartMucDichDatPhong();     // Column
                LoadChartTrangThaiTheDocGia();  // Pie
                LoadChartHinhThucThanhToan();   // Line
                LoadChartTinhTrangSach();       // Bubble
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

        #region Các hàm lấy số liệu cho card

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

        // =====================================================================
        //  HÌNH 1 – COLUMN CHART
        //  ĐƠN ĐẶT PHÒNG THEO KHUNG GIỜ
        //  -> 2 cột: Buổi sáng / Buổi chiều
        // =====================================================================
        #region Biểu đồ 1 – Column: Đơn đặt phòng theo khung giờ

        private void LoadChartMucDichDatPhong()
        {
            chartMucDich.Series.Clear();

            var area = chartMucDich.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisX.Title = "Mục đích";
            area.AxisY.Title = "Số đơn đặt";

            // ------- 2 series (2 cột) ----------
            var seriesPhongNho = new Series("Phòng ≤ 5 chỗ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = false,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            var seriesPhongLon = new Series("Phòng > 5 chỗ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = false,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            const string sql = @"
        SELECT 
            CASE 
                WHEN d.MucDich = 'Thảo luận nhóm'    THEN 'Thảo luận'
                WHEN d.MucDich = 'Thuyết trình nhóm' THEN 'Thuyết trình'
                ELSE 'Khác'
            END AS NhomMucDich,
            SUM(CASE WHEN p.SucChua <= 5 THEN 1 ELSE 0 END) AS PhongNho,
            SUM(CASE WHEN p.SucChua  > 5 THEN 1 ELSE 0 END) AS PhongLon
        FROM DonDatPhongHocNhom d
        JOIN Phong p ON d.MaPhong = p.MaPhong
        GROUP BY NhomMucDich
        ORDER BY NhomMucDich;
    ";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string label = reader["NhomMucDich"]?.ToString() ?? "";

                        // xử lý NULL -> 0
                        int soPhongNho = 0;
                        if (!reader.IsDBNull(reader.GetOrdinal("PhongNho")))
                            soPhongNho = Convert.ToInt32(reader["PhongNho"]);

                        int soPhongLon = 0;
                        if (!reader.IsDBNull(reader.GetOrdinal("PhongLon")))
                            soPhongLon = Convert.ToInt32(reader["PhongLon"]);

                        seriesPhongNho.Points.AddXY(label, soPhongNho);
                        seriesPhongLon.Points.AddXY(label, soPhongLon);
                    }
                }
            }

            chartMucDich.Legends[0].Docking = Docking.Right;
            chartMucDich.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9F);

            chartMucDich.Series.Add(seriesPhongNho);
            chartMucDich.Series.Add(seriesPhongLon);
        }


        #endregion

        // =====================================================================
        //  HÌNH 2 – PIE CHART
        //  TRẠNG THÁI THẺ ĐỘC GIẢ
        //  -> Tỉ lệ Hoạt động / Bị khóa
        // =====================================================================
        #region Biểu đồ 2 – Pie: Trạng thái thẻ độc giả

        private void LoadChartTrangThaiTheDocGia()
        {
            chartTrangThaiThe.Series.Clear();

            var area = chartTrangThaiThe.ChartAreas[0];
            area.AxisX.Enabled = AxisEnabled.False;
            area.AxisY.Enabled = AxisEnabled.False;

            chartTrangThaiThe.Legends[0].Docking = Docking.Right;
            chartTrangThaiThe.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9F);

            var series = new Series("Trạng thái thẻ")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#VALX: #PERCENT{P0}",
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            const string sql = @"
                SELECT TrangThai, COUNT(*) AS SoLuong
                FROM NguoiDung
                GROUP BY TrangThai;
            ";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string raw = reader["TrangThai"]?.ToString() ?? "";
                        string label = raw == "HoatDong" ? "Hoạt động" :
                                       raw == "BiKhoa" ? "Bị khóa" :
                                       raw;
                        int value = Convert.ToInt32(reader["SoLuong"]);
                        series.Points.AddXY(label, value);
                    }
                }
            }

            chartTrangThaiThe.Series.Add(series);
        }

        #endregion

        // =====================================================================
        //  HÌNH 3 – LINE CHART
        //  HÌNH THỨC THANH TOÁN TIỀN CỌC
        //  -> Tổng tiền cọc theo NGÀY, tách 2 line Momo / Ngân hàng
        // =====================================================================
        #region Biểu đồ 3 – Line: Hình thức thanh toán tiền cọc

        private void LoadChartHinhThucThanhToan()
        {
            chartThanhToan.Series.Clear();

            var area = chartThanhToan.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisX.Title = "Ngày thanh toán";
            area.AxisY.Title = "Tổng tiền cọc";

            var seriesMomo = new Series("Momo")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                XValueType = ChartValueType.DateTime,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                IsValueShownAsLabel = false
            };

            var seriesNganHang = new Series("Ngân hàng")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                XValueType = ChartValueType.DateTime,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                IsValueShownAsLabel = false
            };

            const string sql = @"
        SELECT date(ThoiGianThanhToan) AS Ngay,
               HinhThucThanhToan,
               SUM(SoTienCoc) AS TongTien
        FROM ThanhToanTienCoc
        GROUP BY Ngay, HinhThucThanhToan
        ORDER BY Ngay;
    ";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ngayStr = reader["Ngay"]?.ToString() ?? "";
                        if (!DateTime.TryParse(ngayStr, out DateTime ngay))
                            continue; // nếu parse không được thì bỏ qua

                        // xử lý NULL → 0
                        double tongTien = 0;
                        if (!reader.IsDBNull(reader.GetOrdinal("TongTien")))
                            tongTien = Convert.ToDouble(reader["TongTien"]);

                        string hinhThuc = reader["HinhThucThanhToan"]?.ToString() ?? "";

                        if (hinhThuc == "Momo")
                        {
                            seriesMomo.Points.AddXY(ngay, tongTien);
                        }
                        else if (hinhThuc == "Ngân hàng")
                        {
                            seriesNganHang.Points.AddXY(ngay, tongTien);
                        }
                    }
                }
            }

            chartThanhToan.Legends[0].Docking = Docking.Right;
            chartThanhToan.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9F);

            chartThanhToan.Series.Add(seriesMomo);
            chartThanhToan.Series.Add(seriesNganHang);
        }

        #endregion

        // =====================================================================
        //  HÌNH 4 – BUBBLE CHART
        //  TÌNH TRẠNG SÁCH KHI MƯỢN/TRẢ
        //  -> Mỗi bubble = 1 tình trạng
        //     X: vị trí (1,2,3), Y: Tổng tiền phạt, Kích thước: Số lượng sách
        // =====================================================================
        #region Biểu đồ 4 – Bubble: Tình trạng sách khi mượn/trả

        private void LoadChartTinhTrangSach()
        {
            chartTinhTrangSach.Series.Clear();

            var area = chartTinhTrangSach.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisX.Title = "Tình trạng";
            area.AxisY.Title = "Tổng tiền phạt";

            var series = new Series("Tình trạng")
            {
                ChartType = SeriesChartType.Bubble,
                IsValueShownAsLabel = true,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            const string sql = @"
        SELECT TinhTrang,
               COUNT(*) AS SoLuong,
               SUM(TienPhat) AS TongPhat
        FROM ChiTietPhieuMuon
        GROUP BY TinhTrang;
    ";

            int xIndex = 1;

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string raw = reader["TinhTrang"]?.ToString() ?? "";
                        string label = raw == "BinhThuong" ? "Bình thường" :
                                       raw == "HuHong" ? "Hư hỏng" :
                                       raw == "Mat" ? "Mất" : raw;

                        // số lượng
                        double soLuong = 0;
                        if (!reader.IsDBNull(reader.GetOrdinal("SoLuong")))
                            soLuong = Convert.ToDouble(reader["SoLuong"]);

                        // tổng phạt có thể NULL → 0
                        double tongPhat = 0;
                        if (!reader.IsDBNull(reader.GetOrdinal("TongPhat")))
                            tongPhat = Convert.ToDouble(reader["TongPhat"]);

                        int pointIndex = series.Points.AddXY(xIndex, tongPhat);
                        var point = series.Points[pointIndex];

                        // Y value 0 = tổng phạt, Y value 1 = kích thước bubble
                        point.YValues = new double[] { tongPhat, soLuong };
                        point.AxisLabel = label;
                        point.Label = $"{label}\nSL:{soLuong}";

                        xIndex++;
                    }
                }
            }

            chartTinhTrangSach.Legends[0].Docking = Docking.Right;
            chartTinhTrangSach.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9F);
            chartTinhTrangSach.Series.Add(series);
        }

        #endregion

        #region Helper: chạy scalar int

        private int ExecuteScalarInt(string sql, params (string name, object value)[] parameters)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                }

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToInt32(result);
            }
        }

        #endregion
    }
}
