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
using System.Threading;

namespace WinFormsfinal
{
    public partial class UserDatPhongHocNhom : Form
    {
        string connectionString = @"Data Source=project_final.db;Version=3;";
        public UserDatPhongHocNhom()
        {
            InitializeComponent();
            this.Resize += Form_Resize;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserDatPhongHocNhom_Load(object sender, EventArgs e)
        {
            // Culture Việt Nam để "Thứ hai", "Tháng 12", v.v.
            var vi = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = vi;
            Thread.CurrentThread.CurrentUICulture = vi;

            // Định dạng hiển thị theo: Thứ …, ngày … tháng … năm …
            dateNgayDat.Format = DateTimePickerFormat.Custom;
            dateNgayDat.CustomFormat = "dd/MM/yyyy";


            LoadDanhSachPhong();
            LoadGioComboBox();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void LoadDanhSachPhong()
        {
            cbbPhong.Items.Clear();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaPhong, TenPhong FROM Phong WHERE TrangThai <> 'Bảo trì'";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cbbPhong.Items.Add(new { MaPhong = reader["MaPhong"].ToString(), TenPhong = reader["TenPhong"].ToString() });
                }
            }
            cbbPhong.DisplayMember = "TenPhong";
        }

        private void LoadGioComboBox()
        {
            string[] gio = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            cbbGioBD.Items.AddRange(gio);
            cbbGioKT.Items.AddRange(gio);
        }

        private void btnTiepTheo_Click(object sender, EventArgs e)
        {
            if (cbbPhong.SelectedItem == null || cbbGioBD.Text == "" || cbbGioKT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayDat = dateNgayDat.Value.Date;
            if ((ngayDat - DateTime.Today).TotalDays > 2)
            {
                MessageBox.Show("Chỉ được đặt trước tối đa 2 ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan bd = TimeSpan.Parse(cbbGioBD.Text);
            TimeSpan kt = TimeSpan.Parse(cbbGioKT.Text);
            if ((kt - bd).TotalHours > 4)
            {
                MessageBox.Show("Không được đặt quá 4 tiếng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // giờ hợp lệ
            if (!TimeSpan.TryParse(cbbGioBD.Text, out TimeSpan gioBD) ||
                !TimeSpan.TryParse(cbbGioKT.Text, out TimeSpan gioKT))
                return;

            if (gioKT <= gioBD)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((gioKT - gioBD).TotalHours > 4)
            {
                MessageBox.Show("Không được đặt quá 4 tiếng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTrungLich(((dynamic)cbbPhong.SelectedItem).MaPhong, ngayDat, bd, kt))
            {
                MessageBox.Show("Phòng này đã được đặt trong khung giờ bạn chọn, vui lòng chọn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form chi tiết
            string maPhong = ((dynamic)cbbPhong.SelectedItem).MaPhong;
            var formChiTiet = new BieuMauDatPhong(maPhong, ngayDat, bd, kt);
            formChiTiet.ShowDialog();
        }

        private bool KiemTraTrungLich(string maPhong, DateTime ngayDat, TimeSpan bd, TimeSpan kt)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM DonDatPhongHocNhom 
                               WHERE MaPhong=@phong AND NgayDat=@ngay 
                               AND ((GioBatDau < @kt AND GioKetThuc > @bd))";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@phong", maPhong);
                    cmd.Parameters.AddWithValue("@ngay", ngayDat.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@bd", bd.ToString(@"hh\:mm"));
                    cmd.Parameters.AddWithValue("@kt", kt.ToString(@"hh\:mm"));
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
