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

namespace WinFormsfinal
{
    public partial class LichSuMuon : Form
    {
        string connectionString = "Data Source=project_final.db;Version=3;";

        public LichSuMuon()
        {
            InitializeComponent();

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
                        // Chuyển đổi 2 cột ngày sang DateTime
                        foreach (DataRow row in dt.Rows)
                        {
                            // Ngày mượn
                            if (DateTime.TryParse(row["NgayMuon"]?.ToString(), out DateTime nm))
                                row["NgayMuon"] = nm.ToString("dd/MM/yyyy");

                            // Ngày trả dự kiến
                            if (DateTime.TryParse(row["NgayDuKien"]?.ToString(), out DateTime ndk))
                                row["NgayDuKien"] = ndk.ToString("dd/MM/yyyy");
                        }

                        if (!dt.Columns.Contains("TienPhatTamTinh"))
                            dt.Columns.Add("TienPhatTamTinh", typeof(double));

                        foreach (DataRow row in dt.Rows)
                        {
                            string trangThai = row["TrangThai"].ToString();
                            DateTime ngayDuKien = DateTime.Parse(row["NgayDuKien"].ToString());

                            double phat = 0;

                            if (trangThai == "Chưa trả")
                            {
                                int daysLate = (DateTime.Today - ngayDuKien).Days;
                                if (daysLate > 0)
                                    phat = daysLate * 10000;
                            }
                            else
                            {
                                phat = Convert.ToDouble(row["TienPhat"]);
                            }

                            row["TienPhatTamTinh"] = phat;
                        }

                        dgvLichSu.DataSource = dt;

                        // Ẩn cột tiền phạt gốc
                        if (dgvLichSu.Columns.Contains("TienPhat"))
                            dgvLichSu.Columns["TienPhat"].Visible = false;

                        dgvLichSu.Columns["TienPhatTamTinh"].HeaderText = "Tiền phạt";

                        // Format ngày
                        if (dgvLichSu.Columns.Contains("NgayMuon"))
                            dgvLichSu.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        if (dgvLichSu.Columns.Contains("NgayTraDuKien"))
                            dgvLichSu.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }

            // Tính tổng phạt chưa trả
            double tong = 0;
            foreach (DataGridViewRow row in dgvLichSu.Rows)
            {
                if (row.Cells["TrangThai"].Value.ToString() == "Chưa trả")
                    tong += Convert.ToDouble(row.Cells["TienPhatTamTinh"].Value);
            }

            lblTongTienPhat.Text = tong.ToString("N0") + " đ";
        }

        private void LichSuMuon_Load(object sender, EventArgs e)
        {
            string maNguoiDung = "ND001";
            LoadLichSu(maNguoiDung);
        }
    }
}
