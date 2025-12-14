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
    public partial class FormSuaDonDatPhong : Form
    {
        string connectionString = @"Data Source=project_final.db;Version=3;";
        string maDatPhong;
        int soGioCu; // số giờ cũ

        public FormSuaDonDatPhong()
        {
            InitializeComponent();
        }
        public FormSuaDonDatPhong(string ma)
        {
            InitializeComponent();
            maDatPhong = ma;
        }

        private void FormSuaDonDatPhong_Load(object sender, EventArgs e)
        {
            // Chặn sửa
            txtMaDatPhong.ReadOnly = true;
            txtMaTheThuVien.ReadOnly = true;
            txtTienCoc.ReadOnly = true;
            txtTienCoc.ReadOnly = true;

            //Load dữ liệu
            LoadComboBoxGio();
            LoadComboBoxPhong();
            LoadComboBoxMucDich();
            LoadThongTinDon();
        }

        private void LoadComboBoxGio()
        {
            string[] gioBD = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            string[] gioKT = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            cbbGioBatDau.Items.AddRange(gioBD);
            cbbGioKetThuc.Items.AddRange(gioKT);
        }
        private void LoadComboBoxPhong()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT MaPhong FROM Phong", conn);
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) cbbMaPhong.Items.Add(r["MaPhong"].ToString());
            }
        }

        private void LoadComboBoxMucDich()
        {
            cbbMucDich.Items.AddRange(new string[] { "Thảo luận nhóm", "Thuyết trình nhóm", "Khác" });
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGhiChu.Text))
                cbbMucDich.SelectedItem = "Khác";
        }

        private void LoadThongTinDon()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM DonDatPhongHocNhom WHERE MaDatPhong=@ma", conn);
                cmd.Parameters.AddWithValue("@ma", maDatPhong);

                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        // Mã, thẻ, phòng
                        txtMaDatPhong.Text = r["MaDatPhong"].ToString();
                        txtMaTheThuVien.Text = r["MaSoThe"].ToString();   // đổi MaTheThuVien -> MaSoThe
                        cbbMaPhong.Text = r["MaPhong"].ToString();

                        // Ngày đặt
                        if (DateTime.TryParse(r["NgayDat"].ToString(), out DateTime ngay))
                            dtpNgayDat.Value = ngay;

                        // ================= GIỜ BẮT ĐẦU / KẾT THÚC =================
                        string gioBDStr = r["GioBatDau"]?.ToString() ?? "";
                        string gioKTStr = r["GioKetThuc"]?.ToString() ?? "";

                        // Nếu có kèm ngày: "2025-01-01 09:00:00" -> lấy phần sau cùng
                        if (gioBDStr.Contains(" ")) gioBDStr = gioBDStr.Split(' ').Last();
                        if (gioKTStr.Contains(" ")) gioKTStr = gioKTStr.Split(' ').Last();

                        // Cắt bớt giây: "09:00:00" -> "09:00"
                        if (gioBDStr.Length >= 5) gioBDStr = gioBDStr.Substring(0, 5);
                        if (gioKTStr.Length >= 5) gioKTStr = gioKTStr.Substring(0, 5);

                        // Nếu chưa có trong Items thì thêm vào
                        if (!cbbGioBatDau.Items.Contains(gioBDStr))
                            cbbGioBatDau.Items.Add(gioBDStr);
                        if (!cbbGioKetThuc.Items.Contains(gioKTStr))
                            cbbGioKetThuc.Items.Add(gioKTStr);

                        // Chọn giờ
                        cbbGioBatDau.SelectedItem = gioBDStr;
                        cbbGioKetThuc.SelectedItem = gioKTStr;

                        // Tính số giờ cũ
                        if (TimeSpan.TryParse(gioBDStr, out TimeSpan bd) &&
                            TimeSpan.TryParse(gioKTStr, out TimeSpan kt))
                            soGioCu = (int)(kt - bd).TotalHours;
                        else
                            soGioCu = 0;

                        // Mục đích
                        cbbMucDich.Text = r["MucDich"]?.ToString();

                        // Ghi chú
                        txtGhiChu.Text = r["GhiChu"] == DBNull.Value ? "" : r["GhiChu"].ToString();

                        // Tiền cọc
                        txtTienCoc.Text = r["TienCoc"].ToString();

                        // Nếu có ghi chú → tự động set mục đích = "Khác"
                        if (!string.IsNullOrWhiteSpace(txtGhiChu.Text))
                            cbbMucDich.Text = "Khác";
                    }
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // BẮT BUỘC phải chọn giờ
                if (string.IsNullOrWhiteSpace(cbbGioBatDau.Text) ||
                    string.IsNullOrWhiteSpace(cbbGioKetThuc.Text))
                {
                    MessageBox.Show("Vui lòng chọn giờ bắt đầu và giờ kết thúc!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse giờ an toàn
                if (!TimeSpan.TryParse(cbbGioBatDau.Text, out TimeSpan gioBD) ||
                    !TimeSpan.TryParse(cbbGioKetThuc.Text, out TimeSpan gioKT))
                {
                    MessageBox.Show("Giờ bắt đầu / kết thúc không hợp lệ!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate ngày (theo logic hiện tại của bạn)
                if (dtpNgayDat.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("Ngày đặt không được lớn hơn ngày hiện tại!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính số giờ mới
                double soGioMoi = (gioKT - gioBD).TotalHours;

                // Giờ phải trước 17:00
                if (gioBD.Hours > 17 || gioKT.Hours > 17)
                {
                    MessageBox.Show("Giờ đặt phải trước 17:00!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (soGioMoi <= 0)
                {
                    MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Không quá 4 tiếng
                if (soGioMoi > 4)
                {
                    MessageBox.Show("Không được đặt quá 4 tiếng!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check trùng lịch
                if (KiemTraTrungLich(cbbMaPhong.Text,
                                     dtpNgayDat.Value.ToString("yyyy-MM-dd"),
                                     gioBD, gioKT))
                {
                    MessageBox.Show("Khung giờ này đã có người đặt!");
                    return;
                }

                // Lưu DB
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE DonDatPhongHocNhom 
                             SET MaPhong=@phong, NgayDat=@ngay, 
                                 GioBatDau=@bd, GioKetThuc=@kt, 
                                 MucDich=@muc, GhiChu=@ghichu, 
                                 SoThanhVienThamGia=@SoThanhVienThamGia
                             WHERE MaDatPhong=@ma";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phong", cbbMaPhong.Text);
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayDat.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@bd", cbbGioBatDau.Text);
                        cmd.Parameters.AddWithValue("@kt", cbbGioKetThuc.Text);
                        cmd.Parameters.AddWithValue("@muc", cbbMucDich.Text);
                        cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                        cmd.Parameters.AddWithValue("@ma", txtMaDatPhong.Text);
                        cmd.Parameters.AddWithValue("@SoThanhVienThamGia", nudSoLuong.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }




        private bool KiemTraTrungLich(string maPhong, string ngayDat, TimeSpan gioBD, TimeSpan gioKT)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM DonDatPhongHocNhom
                                 WHERE MaPhong=@phong AND NgayDat=@ngay 
                                 AND MaDatPhong<>@ma
                                 AND (
                                     (GioBatDau < @kt AND GioKetThuc > @bd)
                                 )";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@phong", maPhong);
                cmd.Parameters.AddWithValue("@ngay", ngayDat);
                cmd.Parameters.AddWithValue("@bd", gioBD.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@kt", gioKT.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@ma", maDatPhong);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
