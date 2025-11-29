using System;
using System.Data;                                    // <-- cần cho DataTable / DataAdapter
using System.Windows.Forms;
using System.Data.SQLite;                             // dùng System.Data.SQLite
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsfinal
{
    public partial class ThongKeControl : UserControl
    {
        // KẾT NỐI DB – giống kiểu fLogin / fRegister
        private const string ConnectionString = @"Data Source=project_final.db;Version=3;";

        public ThongKeControl()
        {
            InitializeComponent();

            // Đổi tiêu đề khu vực biểu đồ 3 cho đúng nội dung mới (nếu bạn chưa sửa ở Designer)
            if (lblThanhToanTitle != null)
                lblThanhToanTitle.Text = "THỐNG KÊ LƯỢT MƯỢN THEO THỂ LOẠI";

            LoadStatisticsFromDatabase();
        }

        /// <summary>
        /// Đọc dữ liệu từ database và đổ lên các card + biểu đồ
        /// </summary>
        private void LoadStatisticsFromDatabase()
        {
            try
            {
                // 1) Tổng số đầu sách (trong các phiếu mượn)
                int tongDauSach = GetTotalTitles();
                lblTongSachValue.Text = tongDauSach.ToString("N0");

                // 2) Tổng lượt mượn trong tháng hiện tại
                int luotMuonThang = GetBorrowCountThisMonth();
                lblLuotMuonValue.Text = luotMuonThang.ToString("N0") + " lượt";

                // 3) Số độc giả đang hoạt động
                int docGiaHoatDong = GetActiveReaders();
                lblDocGiaValue.Text = docGiaHoatDong.ToString("N0");

                // 4) Số phòng đã từng được đặt
                int soPhongDaDat = GetBookedRooms();
                lblPhongValue.Text = $"{soPhongDaDat} phòng";

                // ====== BIỂU ĐỒ ======
                LoadChartMucDichDatPhong();     // Column
                LoadChartTrangThaiTheDocGia();  // Pie
                LoadChartHinhThucThanhToan();   // Column theo thể loại
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

        #region CARD NUMBERS

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
        //  BIỂU ĐỒ 1 – COLUMN: Đơn đặt phòng theo mục đích (nhỏ/lớn)
        // =====================================================================
        #region Chart 1: Mục đích đặt phòng

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

                        int soPhongNho = reader.IsDBNull(reader.GetOrdinal("PhongNho"))
                                         ? 0 : Convert.ToInt32(reader["PhongNho"]);
                        int soPhongLon = reader.IsDBNull(reader.GetOrdinal("PhongLon"))
                                         ? 0 : Convert.ToInt32(reader["PhongLon"]);

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
        //  BIỂU ĐỒ 2 – PIE: Trạng thái thẻ độc giả
        // =====================================================================
        #region Chart 2: Trạng thái thẻ độc giả

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
        //  BIỂU ĐỒ 3 – COLUMN: Lượt mượn theo THỂ LOẠI
        //  -> Mỗi thể loại = 1 cột
        // =====================================================================
        #region Chart 3: Lượt mượn theo thể loại

        private void LoadChartHinhThucThanhToan()
        {
            chartThanhToan.Series.Clear();
            chartThanhToan.DataSource = null;

            var area = chartThanhToan.ChartAreas[0];
            // 1) Đừng để auto-fit cắt chữ
            area.AxisX.IsLabelAutoFit = false;                 // tắt auto-fit
            area.AxisX.LabelStyle.TruncatedLabels = false;     // KHÔNG cắt ngắn nhãn
            area.AxisX.Interval = 1;                           // hiện mọi nhãn
            area.AxisX.LabelStyle.Angle = -30;                 // xoay nhẹ cho đỡ chồng (tùy bạn)
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);

            // 2) Dành thêm khoảng trống dưới để nhãn không chạm mép control
            area.Position.Auto = false;
            area.Position = new ElementPosition(3f, 8f, 96f, 88f);     // kéo ChartArea lên một chút

            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition = new ElementPosition(10f, -3f, 86f, 78f); // plot nằm cao hơn, chừa đáy cho nhãn


            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisX.Interval = 1;
            area.AxisX.IsMarginVisible = true;
            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.LabelStyle.Angle = -20;
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisX.Title = "Thể loại";
            area.AxisY.Title = "Số lượt mượn";

            // 1 series cột
            var series = new Series("Lượt mượn")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 1,
                IsValueShownAsLabel = true,
                XValueType = ChartValueType.String,   // QUAN TRỌNG: trục X là chuỗi
                IsXValueIndexed = true,               // phân bổ đều theo danh mục
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            // Lấy TẤT CẢ thể loại trong Sách và đếm lượt mượn (kể cả = 0)
            const string sql = @"
        WITH TheLoaiBase AS (
            SELECT DISTINCT COALESCE(NULLIF(TRIM(TheLoai), ''), 'Khác') AS TheLoaiNorm
            FROM Sach
        )
        SELECT b.TheLoaiNorm AS TheLoai,
               COUNT(ct.MaSach) AS LuotMuon
        FROM TheLoaiBase b
        LEFT JOIN Sach s
               ON COALESCE(NULLIF(TRIM(s.TheLoai), ''), 'Khác') = b.TheLoaiNorm
        LEFT JOIN ChiTietPhieuMuon ct
               ON ct.MaSach = s.MaSach
        GROUP BY b.TheLoaiNorm
        ORDER BY LuotMuon DESC, TheLoai;
    ";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string theLoai = reader["TheLoai"]?.ToString() ?? "Khác";
                        int luotMuon = reader.IsDBNull(reader.GetOrdinal("LuotMuon"))
                                         ? 0 : Convert.ToInt32(reader["LuotMuon"]);

                        // QUAN TRỌNG: đặt AxisLabel để trục X hiểu là chuỗi riêng
                        var p = new DataPoint
                        {
                            AxisLabel = theLoai
                        };
                        p.YValues = new[] { (double)luotMuon };
                        series.Points.Add(p);
                    }
                }
            }

            // 1 series thì tắt legend cho gọn
            if (chartThanhToan.Legends.Count > 0)
                chartThanhToan.Legends[0].Enabled = false;

            // Độ rộng cột dễ nhìn (tuỳ)
            series["PixelPointWidth"] = "40";

            chartThanhToan.Series.Add(series);
        }


        #endregion

        // =====================================================================
        //  BIỂU ĐỒ 4 – BUBBLE: Tình trạng sách khi mượn/trả
        // =====================================================================
        #region Chart 4: Tình trạng sách

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

                        double soLuong = reader.IsDBNull(reader.GetOrdinal("SoLuong"))
                                         ? 0 : Convert.ToDouble(reader["SoLuong"]);

                        double tongPhat = reader.IsDBNull(reader.GetOrdinal("TongPhat"))
                                         ? 0 : Convert.ToDouble(reader["TongPhat"]);

                        int pointIndex = series.Points.AddXY(xIndex, tongPhat);
                        var point = series.Points[pointIndex];

                        // Y[0] = tổng phạt, Y[1] = kích thước bubble
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

        #region Helper: ExecuteScalarInt

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
