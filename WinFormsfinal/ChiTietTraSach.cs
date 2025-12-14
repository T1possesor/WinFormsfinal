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
using System.Globalization;
namespace WinFormsfinal
{
    public partial class ChiTietTraSach : Form
    {
        bool _isInternalCheck = false;
        private string maPhieu;
        string connectionString = "Data Source=project_final.db;Version=3;";

        public ChiTietTraSach(string maPhieu)
        {
            InitializeComponent();
            this.maPhieu = maPhieu;
        }

        private void ChiTietTraSach_Load(object sender, EventArgs e)
        {
            lblMaPhieu.Text = maPhieu;
            LoadChiTietSach();

            dgvChiTiet.CurrentCellDirtyStateChanged += dgvChiTiet_CurrentCellDirtyStateChanged;
            dgvChiTiet.CellValueChanged += dgvChiTiet_CellValueChanged;

            bool phieuDaTra = KiemTraPhieuDaTra(maPhieu);
            if (phieuDaTra)
            {
                ChuyenSangCheDoXem();
            }

            TinhPhatTreHanLucLoad();
        }

        // Load các sách trong phiếu
        private void LoadChiTietSach()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT 
                MaCT,
                MaSach,
                TenSach,
                GiaBia,
                NgayMuon,
                NgayTraDuKien,
                NgayTraThucTe,
                TinhTrang,
                TienPhat
            FROM ChiTietPhieuMuon
            WHERE MaPhieu = @MaPhieu
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Format ngày trong bảng
                        foreach (DataRow row in dt.Rows)
                        {
                            if (DateTime.TryParse(row["NgayMuon"]?.ToString(), out DateTime nm))
                                row["NgayMuon"] = nm.ToString("dd/MM/yyyy");

                            if (DateTime.TryParse(row["NgayTraDuKien"]?.ToString(), out DateTime ndk))
                                row["NgayTraDuKien"] = ndk.ToString("dd/MM/yyyy");

                            if (DateTime.TryParse(row["NgayTraThucTe"]?.ToString(), out DateTime ntt))
                                row["NgayTraThucTe"] = ntt.ToString("dd/MM/yyyy");
                        }

                        dgvChiTiet.DataSource = dt;
                    }
                }
            }

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.AllowUserToAddRows = false;
        }


        // Auto tính phạt trễ ngày khi mở form
        private void TinhPhatTreHanLucLoad()
        {
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                var raw = row.Cells["NgayTraDuKien"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(raw))
                    continue;

                var formats = new[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };

                if (!DateTime.TryParseExact(
                        raw,
                        formats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime ngayDK))
                {
                    continue; // không parse được thì bỏ qua
                }

                int daysLate = (DateTime.Today.Date - ngayDK.Date).Days;
                if (daysLate < 0) daysLate = 0;

                double phatTre = daysLate * 10000;

                bool daTra = !string.IsNullOrWhiteSpace(row.Cells["NgayTraThucTe"].Value?.ToString());

                if (!daTra)
                {
                    row.Cells["PhatTre"].Value = phatTre;
                    if (Convert.ToDouble(row.Cells["TienPhat"].Value) == 0)
                        row.Cells["TienPhat"].Value = phatTre;
                }
            }

            TinhTongTienPhat();
        }




        // Tính tổng tiền phạt toàn phiếu
        private void TinhTongTienPhat()
        {
            double tong = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells["TienPhat"].Value != DBNull.Value)
                    tong += Convert.ToDouble(row.Cells["TienPhat"].Value);
            }

            lblTongTienPhat.Text = tong.ToString("N0") + "đ";
        }
        // Xác nhận trả

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbPhuongThuc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận trả sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string phuongThuc = cbPhuongThuc.Text;
            string ngayTraThucTe = DateTime.Today.ToString("yyyy-MM-dd");
            string maNguoiDung = LayMaNguoiDungTheoMaPhieu(maPhieu);

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    int maCT = Convert.ToInt32(row.Cells["MaCT"].Value);
                    string tinhTrang = row.Cells["TinhTrang"].Value.ToString();
                    double tienPhat = Convert.ToDouble(row.Cells["TienPhat"].Value);

                    string sql = @"
                UPDATE ChiTietPhieuMuon
                SET 
                    NgayTraThucTe = @NgayTra,
                    TinhTrang = @TinhTrang,
                    TienPhat = @TienPhat,
                    PhuongThucTra = @PhuongThuc
                WHERE MaCT = @MaCT
            ";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NgayTra", ngayTraThucTe);
                        cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                        cmd.Parameters.AddWithValue("@TienPhat", tienPhat);
                        cmd.Parameters.AddWithValue("@PhuongThuc", phuongThuc);
                        cmd.Parameters.AddWithValue("@MaCT", maCT);

                        cmd.ExecuteNonQuery();
                    }

                    UpdateLichSuMuon(maNguoiDung,
                        row.Cells["MaSach"].Value.ToString(),
                        DateTime.Today,
                        tienPhat);
                }

                // update ngày trả thực tế vào PhieuMuon
                string sqlPM = @"UPDATE PhieuMuon SET NgayTraThucTe = @NgayTra WHERE MaPhieu = @MaPhieu";
                using (var cmd2 = new SQLiteCommand(sqlPM, conn))
                {
                    cmd2.Parameters.AddWithValue("@NgayTra", ngayTraThucTe);
                    cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd2.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đã trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Bắt buộc để checkbox kích hoạt event ngay khi tick
        private void dgvChiTiet_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChiTiet.IsCurrentCellDirty)
                dgvChiTiet.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isInternalCheck) return;
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex != dgvChiTiet.Columns["Hu"].Index &&
                e.ColumnIndex != dgvChiTiet.Columns["Mat"].Index)
                return;

            var row = dgvChiTiet.Rows[e.RowIndex];

            bool isHu = Convert.ToBoolean(row.Cells["Hu"].Value ?? false);
            bool isMat = Convert.ToBoolean(row.Cells["Mat"].Value ?? false);

            double giaBia = Convert.ToDouble(row.Cells["GiaBia"].Value);
            double phatTre = Convert.ToDouble(row.Cells["PhatTre"].Value);

            if (isHu && isMat)
            {
                MessageBox.Show("Không thể chọn cả Hư và Mất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                _isInternalCheck = true;
                row.Cells["Hu"].Value = false;
                row.Cells["Mat"].Value = false;
                row.Cells["TinhTrang"].Value = "Bình thường";
                row.Cells["TienPhat"].Value = phatTre;
                _isInternalCheck = false;
                return;
            }

            double phatHuMat = 0;

            if (isHu)
            {
                row.Cells["TinhTrang"].Value = "Hư hỏng";
                phatHuMat = giaBia * 1.5;
            }
            else if (isMat)
            {
                row.Cells["TinhTrang"].Value = "Mất";
                phatHuMat = giaBia * 1.5;
            }
            else
            {
                row.Cells["TinhTrang"].Value = "Bình thường";
            }

            row.Cells["TienPhat"].Value = phatTre + phatHuMat;

            TinhTongTienPhat();
        }




        // hàm kiểm tra phiếu đã trả chưa
        private bool KiemTraPhieuDaTra(string maPhieu)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT NgayTraThucTe FROM PhieuMuon WHERE MaPhieu = @MaPhieu";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                    var result = cmd.ExecuteScalar();

                    // Nếu null → chưa trả
                    if (result == null || result == DBNull.Value || string.IsNullOrWhiteSpace(result.ToString()))
                        return false;

                    return true; // đã trả
                }
            }
        }

        // hàm CHUYỂN FORM sang chế độ xem
        private void ChuyenSangCheDoXem()
        {
            // 1. Khóa DataGridView hoàn toàn
            dgvChiTiet.ReadOnly = true;

            // 2. Không hiển thị checkbox (không tick được)
            dgvChiTiet.Columns["Hu"].ReadOnly = true;
            dgvChiTiet.Columns["Mat"].ReadOnly = true;

            // 3. Khóa combobox thanh toán
            cbPhuongThuc.Enabled = false;

            // 4. Khóa nút xác nhận
            btnXacNhan.Enabled = false;
            btnXacNhan.BackColor = Color.Gray;

            // 5. Không cho thay đổi bất kỳ ô nào
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 6. Thông báo nhẹ nhàng (optional)
            // MessageBox.Show("Phiếu này đã trả, chỉ được xem thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateLichSuMuon(string maNguoiDung, string maSach, DateTime ngayTra, double tienPhat)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
        UPDATE LichSuMuon
        SET 
            TrangThai = 'Đã trả',
            TienPhat = @TienPhat
        WHERE MaNguoiDung = @MaND
          AND MaSach = @MaSach
          AND TrangThai = 'Chưa trả'
        LIMIT 1;
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaND", maNguoiDung);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                    cmd.Parameters.AddWithValue("@TienPhat", tienPhat);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private string LayMaNguoiDungTheoMaPhieu(string maPhieu)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT MaNguoiDung FROM PhieuMuon WHERE MaPhieu = @mp";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mp", maPhieu);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        private void cbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chọn None → kiểm tra xem có tiền phạt hay không
            if (cbPhuongThuc.SelectedItem != null && cbPhuongThuc.SelectedItem.ToString() == "None")
            {
                double tongTien = 0;

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.Cells["TienPhat"].Value != DBNull.Value &&
                        double.TryParse(row.Cells["TienPhat"].Value.ToString(), out double phat))
                    {
                        tongTien += phat;
                    }
                }

                // Nếu tổng tiền phạt > 0 -> không cho chọn None
                if (tongTien > 0)
                {
                    MessageBox.Show(
                        "Có tiền phạt cần thanh toán. Không thể chọn phương thức 'None'.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Reset lựa chọn
                    cbPhuongThuc.SelectedIndex = -1;
                }
            }
        }
    }
}




