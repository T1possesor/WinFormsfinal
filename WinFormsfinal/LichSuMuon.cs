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
using System.Globalization;

namespace WinFormsfinal
{
    public partial class LichSuMuon : Form
    {
        string connectionString = "Data Source=project_final.db;Version=3;";
        private readonly string _maNguoiDung;

        public LichSuMuon(string maNguoiDung)
        {
            InitializeComponent();
            dgvLichSu.ColumnHeadersHeight = 40;
            _maNguoiDung = maNguoiDung;


        }

        private void LoadLichSu(string maNguoiDung)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT
                MaSach,
                TenSach,
                SoLuong,
                NgayMuon,
                NgayDuKien,
                TrangThai,
                TienPhat
            FROM LichSuMuon
            WHERE MaNguoiDung = @ma
            ORDER BY NgayMuon DESC
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maNguoiDung);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // cột tiền phạt tạm tính
                        if (!dt.Columns.Contains("TienPhatTamTinh"))
                            dt.Columns.Add("TienPhatTamTinh", typeof(double));

                        // các định dạng ngày có thể có trong DB
                        string[] dateFormats = { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };

                        foreach (DataRow row in dt.Rows)
                        {
                            // ---- parse NgayMuon nếu cần hiển thị đúng ----
                            if (DateTime.TryParseExact(
                                    row["NgayMuon"]?.ToString(),
                                    dateFormats,
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime ngayMuon))
                            {
                                // lưu lại đúng kiểu DateTime
                                row["NgayMuon"] = ngayMuon;
                            }

                            // ---- parse NgayDuKien để tính phạt ----
                            if (!DateTime.TryParseExact(
                                    row["NgayDuKien"]?.ToString(),
                                    dateFormats,
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime ngayDuKien))
                            {
                                // nếu không đọc được ngày -> bỏ qua dòng này
                                continue;
                            }

                            string trangThai = row["TrangThai"]?.ToString() ?? "";
                            double phat = 0;

                            if (trangThai == "Chưa trả")
                            {
                                int daysLate = (DateTime.Today - ngayDuKien).Days;
                                if (daysLate > 0)
                                    phat = daysLate * 10000;
                            }
                            else
                            {
                                double.TryParse(row["TienPhat"]?.ToString(), out phat);
                            }

                            row["TienPhatTamTinh"] = phat;
                        }

                        dgvLichSu.DataSource = dt;

                        // Ẩn cột tiền phạt gốc
                        if (dgvLichSu.Columns.Contains("TienPhat"))
                            dgvLichSu.Columns["TienPhat"].Visible = false;

                        dgvLichSu.Columns["TienPhatTamTinh"].HeaderText = "Tiền phạt";

                        // Format hiển thị ngày trên lưới (đã là DateTime)
                        if (dgvLichSu.Columns.Contains("NgayMuon"))
                            dgvLichSu.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        if (dgvLichSu.Columns.Contains("NgayDuKien"))
                            dgvLichSu.Columns["NgayDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }

            // Tính tổng phạt chưa trả
            double tong = 0;
            foreach (DataGridViewRow row in dgvLichSu.Rows)
            {
                if (row.Cells["TrangThai"].Value?.ToString() == "Chưa trả")
                {
                    double phat = 0;
                    double.TryParse(row.Cells["TienPhatTamTinh"].Value?.ToString(), out phat);
                    tong += phat;
                }
            }

            lblTongTienPhat.Text = tong.ToString("N0") + " đ";
        }


        private void LichSuMuon_Load(object sender, EventArgs e)
        {
            LoadLichSu(_maNguoiDung);
        }
    }
}
