using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormChiTietDocGia : Form
    {
        private string connectionString;
        private string maNguoiDungHienTai = null;

        public FormChiTietDocGia(string maNguoiDung = null) 
        {
            InitializeComponent();
            string dbPath = Path.Combine(Application.StartupPath, "project_final.db");
            connectionString = $"Data Source={dbPath};";
            this.maNguoiDungHienTai = maNguoiDung; 
            CaiDatSuKien();
        }
       

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void FormChiTietDocGia_Load(object sender, EventArgs e)
        {
            // Load combobox trạng thái
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Bị khóa");
            cmbTrangThai.SelectedIndex = 0;

            if (maNguoiDungHienTai != null)
            {
                TaiThongTinNguoiDung(maNguoiDungHienTai);
                this.Text = "Sửa thông tin độc giả";
                txtMaThe.Enabled = false; // Không cho sửa mã thẻ khi edit (nghiệp vụ)
            }
            else
            {
                this.Text = "Thêm độc giả mới";
                // Tự động sinh Mã người dùng (NDxxx) nếu cần, hoặc để user nhập
            }
        }

        private void CaiDatSuKien()
        {
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => this.Close();
            this.Load += FormChiTietDocGia_Load; // Thêm sự kiện Load để khởi tạo combobox
        }

        private void TaiThongTinNguoiDung(string id)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand("SELECT * FROM NguoiDung WHERE MaNguoiDung = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["HoTen"].ToString();
                        txtMaThe.Text = reader["MaSoThe"].ToString();
                        txtSDT.Text = reader["SoDienThoai"].ToString();
                        txtEmail.Text = reader["Email"].ToString();

                        // Xử lý ngày tháng (lưu dưới dạng chuỗi trong SQLite)
                        if (DateTime.TryParse(reader["NgaySinh"].ToString(), out DateTime ns)) dtpNgaySinh.Value = ns;
                        if (DateTime.TryParse(reader["NgayTaoThe"].ToString(), out DateTime nc)) dtpNgayCap.Value = nc;
                        if (DateTime.TryParse(reader["NgayHetHanThe"].ToString(), out DateTime nhh)) dtpNgayHetHan.Value = nhh;

                        // Đảm bảo item tồn tại trước khi gán
                        string trangThaiDB = reader["TrangThai"].ToString();
                        if (cmbTrangThai.Items.Contains(trangThaiDB))
                        {
                            cmbTrangThai.SelectedItem = trangThaiDB;
                        }
                    }
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // 1. Validate dữ liệu (Cơ bản)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtMaThe.Text))
            {
                MessageBox.Show("Họ tên và Mã thẻ không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();
                    SqliteCommand cmd;

                    string ngaySinh = dtpNgaySinh.Value.ToString("dd-MM-yyyy");
                    string ngayCap = dtpNgayCap.Value.ToString("dd-MM-yyyy");
                    string ngayHetHan = dtpNgayHetHan.Value.ToString("dd-MM-yyyy");

                    if (maNguoiDungHienTai == null) // THÊM MỚI
                    {
                        // Tạo mã ND tự động đơn giản (thực tế nên làm tốt hơn)
                        string newID = "ND" + DateTime.Now.Ticks.ToString().Substring(10);

                        string sql = @"INSERT INTO NguoiDung (MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, Email, NgayTaoThe, NgayHetHanThe, TrangThai)
                                       VALUES (@id, @ten, @mathe, @ns, @sdt, @email, @nc, @nhh, @tt)";
                        cmd = new SqliteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", newID);
                    }
                    else // CẬP NHẬT
                    {
                        string sql = @"UPDATE NguoiDung 
                                       SET HoTen=@ten, NgaySinh=@ns, SoDienThoai=@sdt, Email=@email, 
                                           NgayTaoThe=@nc, NgayHetHanThe=@nhh, TrangThai=@tt
                                       WHERE MaNguoiDung=@id";
                        cmd = new SqliteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", maNguoiDungHienTai);
                    }

                    // Các tham số chung
                    cmd.Parameters.AddWithValue("@ten", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@mathe", txtMaThe.Text); // Lưu ý: Insert dùng, Update thì ko ảnh hưởng nếu query ko set
                    cmd.Parameters.AddWithValue("@ns", ngaySinh);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@nc", ngayCap);
                    cmd.Parameters.AddWithValue("@nhh", ngayHetHan);
                    cmd.Parameters.AddWithValue("@tt", cmbTrangThai.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Báo cho Form cha biết là đã xong
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
