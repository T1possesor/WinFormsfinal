using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WinFormsfinal
{
    public partial class MuonSach : Form
    {
        string connectionString = "Data Source=project_final.db;Version=3;";

        public MuonSach()
        {
            InitializeComponent();

            panelUserInfo.Visible = false;
            dgvChiTietPhieu.Visible = false;
            panelFind.Visible = false;
            lblSachChuaTra.Visible = false;
            dgvSachChuaTra.Visible = false;

        }

        // ============================
        // TÌM KIẾM NGƯỜI DÙNG
        // ============================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maThe = txtSearchMaThe.Text.Trim();

            if (maThe == "")
            {
                MessageBox.Show("Vui lòng nhập mã thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM NguoiDung WHERE MaSoThe = @maThe";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maThe", maThe);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTen.Text = reader["HoTen"].ToString();
                            lblMaThe.Text = reader["MaSoThe"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblSDT.Text = reader["SoDienThoai"].ToString();
                            lblMaNguoiDung.Text = reader["MaNguoiDung"].ToString();
                            lblTenDocGia.Text = reader["HoTen"].ToString();
                            lbTrangThaiThe.Text = reader["TrangThai"].ToString();
                            // Format ngày tạo thẻ
                            if (DateTime.TryParse(reader["NgayTaoThe"]?.ToString(), out DateTime ngayTao))
                                lblNgayTao.Text = ngayTao.ToString("dd/MM/yyyy");
                            else
                                lblNgayTao.Text = "";

                            // Format ngày hết hạn thẻ
                            if (DateTime.TryParse(reader["NgayHetHanThe"]?.ToString(), out DateTime ngayHet))
                                lblNgayHet.Text = ngayHet.ToString("dd/MM/yyyy");
                            else
                                lblNgayHet.Text = "";

                            panelUserInfo.Visible = true;
                            dgvChiTietPhieu.Visible = true;
                            panelFind.Visible = true;
                            lblSachChuaTra.Visible = true;
                            dgvSachChuaTra.Visible = true;
                            LoadSachChuaTra(lblMaNguoiDung.Text);
                            dgvChiTietPhieu.Rows.Clear();
                            txtMaSachMulti.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearLabels();
                        }
                    }
                }
            }
        }

        private void ClearLabels()
        {
            lblTen.Text = "";
            lblMaThe.Text = "";
            lblEmail.Text = "";
            lblSDT.Text = "";
            lblNgayTao.Text = "";
            lblNgayHet.Text = "";
            panelUserInfo.Visible = false;
        }

        private void txtSearchMaThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem.PerformClick();
        }

        // ============================
        // TÁCH MÃ SÁCH
        // ============================
        private List<string> TachMaSach(string input)
        {
            return input
                .Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => x != "")
                .ToList();
        }

        // ============================
        // LẤY SÁCH THEO MÃ
        // ============================
        private Sach GetSachByMa(string maSach)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT MaSach, TenSach, GiaBia FROM Sach WHERE MaSach = @maSach";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maSach", maSach);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Sach
                            {
                                MaSach = reader["MaSach"].ToString(),
                                TenSach = reader["TenSach"].ToString(),
                                GiaBia = Convert.ToDouble(reader["GiaBia"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ============================
        // PHIẾU MƯỢN
        // ============================
        private string TaoMaPhieuMoi()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT MaPhieu FROM PhieuMuon ORDER BY MaPhieu DESC LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result.ToString() == "")
                        return "PM001";

                    string lastMa = result.ToString();
                    int number = int.Parse(lastMa.Substring(2));
                    number++;

                    return "PM" + number.ToString("000");
                }
            }
        }

        private void InsertPhieuMuon(string maPhieu, string maNguoiDung, DateTime ngayMuon, DateTime ngayTra, string ghiChu = "")
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                INSERT INTO PhieuMuon (MaPhieu, MaNguoiDung, NgayMuon, NgayTraDuKien, GhiChu)
                VALUES (@MaPhieu, @MaNguoiDung, @NgayMuon, @NgayTraDuKien, @GhiChu)
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@NgayTraDuKien", ngayTra.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ============================
        // INSERT CHI TIẾT (CÓ SỐ LƯỢNG)
        // ============================
        private void InsertChiTietPhieuMuon(string maPhieu, Sach sach, DateTime ngayMuon, DateTime ngayTraDK)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            INSERT INTO ChiTietPhieuMuon
            (MaPhieu, MaSach, TenSach, GiaBia, NgayMuon, NgayTraDuKien, NgayTraThucTe, TinhTrang, TienPhat, PhuongThucTra)
            VALUES
            (@MaPhieu, @MaSach, @TenSach, @GiaBia, @NgayMuon, @NgayTraDuKien, NULL, 'Bình thường', 0, 'None')
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
                    cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@GiaBia", sach.GiaBia);
                    cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@NgayTraDuKien", ngayTraDK.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ============================
        // LỊCH SỬ MƯỢN
        // ============================
        private void InsertLichSuMuon(string maNguoiDung, Sach sach, DateTime ngayMuon, DateTime ngayDuKien)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            INSERT INTO LichSuMuon
            (MaNguoiDung, MaSach, TenSach, SoLuong, NgayMuon, NgayDuKien, TrangThai, TienPhat)
            VALUES
            (@MaNguoiDung, @MaSach, @TenSach, 1, @NgayMuon, @NgayDuKien, 'Chưa trả', 0)
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
                    cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@NgayDuKien", ngayDuKien.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ============================
        // KIỂM TRA ĐANG MƯỢN
        // ============================
        private int SoSachDangMuon(string maNguoiDung)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
            SELECT COUNT(*)
            FROM ChiTietPhieuMuon c
            JOIN PhieuMuon p ON c.MaPhieu = p.MaPhieu
            WHERE p.MaNguoiDung = @MaNguoiDung
            AND c.NgayTraThucTe IS NULL
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }



        private int SoSachQuaHan(string maNguoiDung)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

               string sql = @"
    SELECT COUNT(*)
    FROM ChiTietPhieuMuon c
    JOIN PhieuMuon p ON c.MaPhieu = p.MaPhieu
    WHERE p.MaNguoiDung = @MaNguoiDung
    AND c.NgayTraThucTe IS NULL
    AND date(c.NgayTraDuKien) < date('now')
";


                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // ============================
        // NÚT MƯỢN SÁCH
        // ============================
        private void btnMuon_Click(object sender, EventArgs e)
        {
            string rawInput = txtMaSachMulti.Text;
            string maNguoiDung = lblMaNguoiDung.Text.Trim();
            dgvChiTietPhieu.Rows.Clear();
            txtMaSachMulti.Text = "";

            if (maNguoiDung == "")
            {
                MessageBox.Show("Chưa có thông tin người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int dangMuon = SoSachDangMuon(maNguoiDung);
            if (dangMuon >= 3)
            {
                MessageBox.Show("Người dùng đã mượn tối đa 3 cuốn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int quaHan = SoSachQuaHan(maNguoiDung);
            if (quaHan > 0)
            {
                MessageBox.Show("Người dùng có sách quá hạn chưa trả!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            List<string> listMaSach = TachMaSach(rawInput);
            if (listMaSach.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- GOM NHÓM THEO SỐ LƯỢNG ---
            var groupedList = listMaSach
                .GroupBy(x => x)
                .Select(g => new { MaSach = g.Key, SoLuongMuon = g.Count() })
                .ToList();

            int muonLanNay = groupedList.Sum(x => x.SoLuongMuon);
            if (muonLanNay + dangMuon   > 3)
            {
                MessageBox.Show("Tổng số sách mượn vượt quá 3 cuốn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA TỒN TẠI
            foreach (var item in groupedList)
            {
                if (GetSachByMa(item.MaSach) == null)
                {
                    MessageBox.Show($"Mã sách '{item.MaSach}' không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // --- TIẾN HÀNH MƯỢN ---
            DateTime ngayMuon = DateTime.Now;
            DateTime ngayTraDK = ngayMuon.AddDays(14);
            string maPhieu = TaoMaPhieuMoi();

            InsertPhieuMuon(maPhieu, maNguoiDung, ngayMuon, ngayTraDK);

            dgvChiTietPhieu.Rows.Clear();

            foreach (var item in groupedList)
            {
                var sach = GetSachByMa(item.MaSach);

                // INSERT từng cuốn vào DB
                for (int i = 0; i < item.SoLuongMuon; i++)
                {
                    InsertChiTietPhieuMuon(maPhieu, sach, ngayMuon, ngayTraDK);
                    InsertLichSuMuon(maNguoiDung, sach, ngayMuon, ngayTraDK);
                }

                // UI vẫn nhóm theo số lượng
                dgvChiTietPhieu.Rows.Add(
                    sach.MaSach,
                    sach.TenSach,
                    sach.GiaBia,
                    item.SoLuongMuon,
                    ngayMuon.ToString("dd/MM/yyyy"),
                    ngayTraDK.ToString("dd/MM/yyyy")
                );
                // Format ngày (chỉ khi cột đã tồn tại)
                if (dgvChiTietPhieu.Columns.Contains("NgayMuon"))
                    dgvChiTietPhieu.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvChiTietPhieu.Columns.Contains("NgayTraDuKien"))
                    dgvChiTietPhieu.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSachChuaTra(maNguoiDung);
        }

        private void LoadSachChuaTra(string maNguoiDung)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT MaSach, TenSach, COUNT(*) AS SoLuong
FROM ChiTietPhieuMuon c
JOIN PhieuMuon p ON c.MaPhieu = p.MaPhieu
WHERE p.MaNguoiDung = @MaNguoiDung
AND c.NgayTraThucTe IS NULL
GROUP BY MaSach;
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);

                    using (var reader = cmd.ExecuteReader())
                    {
                        dgvSachChuaTra.Rows.Clear();  // Xóa dữ liệu cũ

                        while (reader.Read())
                        {
                            string tenSach = reader["TenSach"].ToString();
                            int soLuong = Convert.ToInt32(reader["SoLuong"]);

                            dgvSachChuaTra.Rows.Add(tenSach, soLuong);
                        }
                    }
                }
            }

            dgvSachChuaTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSachChuaTra.AllowUserToAddRows = false;
            dgvSachChuaTra.ReadOnly = true;
        }



    }
}
