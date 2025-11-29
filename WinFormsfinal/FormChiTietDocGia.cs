using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormChiTietDocGia : Form
    {
        // ====== KẾT NỐI DATABASE ======
        private static readonly string DbPath = Path.Combine(Application.StartupPath, "project_final.db");
        private static readonly string ConnectionString =
            new SqliteConnectionStringBuilder
            {
                DataSource = DbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true,
                Cache = SqliteCacheMode.Shared
            }.ToString();

        // null => thêm mới; khác null => sửa theo mã người dùng
        private readonly string? _maNguoiDungHienTai;

        // Lưu mã mới được sinh (khi thêm)
        private string? _newId;

        public FormChiTietDocGia(string? maNguoiDung = null)
        {
            InitializeComponent();
            _maNguoiDungHienTai = maNguoiDung;
            CaiDatSuKien();
        }

        // ====== GÁN SỰ KIỆN ======
        private void CaiDatSuKien()
        {
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => Close();     // Hủy: đóng ngay, không kiểm tra gì
            Load += FormChiTietDocGia_Load;

            // Ràng buộc nhập số cho SĐT (realtime) — KHÔNG popup validate khi rời ô
            txtSDT.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
        }

        // ====== HÀM HỖ TRỢ KIỂM TRA (chỉ dùng khi bấm Lưu) ======
        private static bool IsValidPhone(string s) => Regex.IsMatch(s ?? "", @"^\d{10}$");
        private static bool IsValidEmail(string s) => Regex.IsMatch(s ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        // ====== HÀM SINH MÃ TĂNG DẦN DẠNG ND001, ND002,... ======
        private string GenerateNextId()
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT IFNULL(MAX(CAST(SUBSTR(MaNguoiDung, 3) AS INTEGER)), 0)
                  FROM NguoiDung
                  WHERE MaNguoiDung LIKE 'ND%';";
            var maxNum = Convert.ToInt32(cmd.ExecuteScalar());
            var next = maxNum + 1;
            return "ND" + next.ToString("D3"); // ND001, ND010, ND123 ...
        }

        // ====== LOAD FORM ======
        private void FormChiTietDocGia_Load(object? sender, EventArgs e)
        {
            // Combobox trạng thái
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Bị khóa");
            cmbTrangThai.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(_maNguoiDungHienTai))
            {
                // ---- SỬA ----
                TaiThongTinNguoiDung(_maNguoiDungHienTai);
                Text = "Sửa thông tin độc giả";
                txtMaThe.ReadOnly = true;
                txtMaThe.FillColor = Color.Gainsboro;
            }
            else
            {
                // ---- THÊM MỚI ----
                Text = "Thêm độc giả mới";

                _newId = GenerateNextId();  // NDxxx tiếp theo
                // Hiển thị vào ô "Mã thẻ" và khóa lại (không phải nhập)
                txtMaThe.Text = _newId;
                txtMaThe.ReadOnly = true;
                txtMaThe.FillColor = Color.Gainsboro;

                dtpNgayCap.Value = DateTime.Today;
                dtpNgayHetHan.Value = DateTime.Today;
            }
        }

        // ====== TẢI THÔNG TIN KHI SỬA ======
        private void TaiThongTinNguoiDung(string id)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM NguoiDung WHERE MaNguoiDung = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return;

            txtHoTen.Text = reader["HoTen"]?.ToString();
            txtMaThe.Text = reader["MaSoThe"]?.ToString();
            txtSDT.Text = reader["SoDienThoai"]?.ToString();
            txtEmail.Text = reader["Email"]?.ToString();

            if (DateTime.TryParse(reader["NgaySinh"]?.ToString(), out var ns)) dtpNgaySinh.Value = ns;
            if (DateTime.TryParse(reader["NgayTaoThe"]?.ToString(), out var nc)) dtpNgayCap.Value = nc;
            if (DateTime.TryParse(reader["NgayHetHanThe"]?.ToString(), out var nhh)) dtpNgayHetHan.Value = nhh;

            string dbTrangThai = (reader["TrangThai"]?.ToString() ?? "HoatDong").Trim();
            cmbTrangThai.SelectedItem = string.Equals(dbTrangThai, "BiKhoa", StringComparison.OrdinalIgnoreCase)
                ? "Bị khóa"
                : "Hoạt động";
        }

        // ====== LƯU (CHỈ TẠI ĐÂY MỚI KIỂM TRA BẮT BUỘC) ======
        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            // Bắt buộc: Họ tên, SĐT, Email (chỉ check ở đây)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var sdt = txtSDT.Text?.Trim() ?? "";
            if (!IsValidPhone(sdt))
            {
                MessageBox.Show("Số điện thoại bắt buộc và phải gồm đúng 10 chữ số.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            var mail = txtEmail.Text?.Trim() ?? "";
            if (!IsValidEmail(mail))
            {
                MessageBox.Show("Email bắt buộc và phải hợp lệ (có '@' và dấu '.' sau '@').", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();

                string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                string ngayCap = dtpNgayCap.Value.ToString("yyyy-MM-dd");
                string ngayHet = dtpNgayHetHan.Value.ToString("yyyy-MM-dd");

                string uiTrangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Hoạt động";
                string dbTrangThai = uiTrangThai == "Hoạt động" ? "HoatDong" : "BiKhoa";

                using var tr = conn.BeginTransaction();
                using var cmd = conn.CreateCommand();
                cmd.Transaction = tr;

                if (string.IsNullOrEmpty(_maNguoiDungHienTai))
                {
                    // ===== THÊM MỚI =====
                    _newId ??= GenerateNextId();

                    if (string.IsNullOrWhiteSpace(txtMaThe.Text))
                        txtMaThe.Text = _newId;

                    cmd.CommandText = @"
                        INSERT INTO NguoiDung
                        (MaNguoiDung, HoTen, MaSoThe, NgaySinh, SoDienThoai, Email, NgayTaoThe, NgayHetHanThe, TrangThai)
                        VALUES (@id, @ten, @mathe, @ns, @sdt, @mail, @nc, @nhh, @tt);";

                    cmd.Parameters.AddWithValue("@id", _newId);
                    cmd.Parameters.AddWithValue("@ten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@mathe", _newId);   // Mã thẻ = NDxxx
                    cmd.Parameters.AddWithValue("@ns", ngaySinh);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@nc", ngayCap);
                    cmd.Parameters.AddWithValue("@nhh", ngayHet);
                    cmd.Parameters.AddWithValue("@tt", dbTrangThai);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // ===== CẬP NHẬT =====
                    cmd.CommandText = @"
                        UPDATE NguoiDung
                        SET HoTen=@ten,
                            NgaySinh=@ns,
                            SoDienThoai=@sdt,
                            Email=@mail,
                            NgayTaoThe=@nc,
                            NgayHetHanThe=@nhh,
                            TrangThai=@tt
                        WHERE MaNguoiDung=@id;";

                    cmd.Parameters.AddWithValue("@ten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@ns", ngaySinh);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@nc", ngayCap);
                    cmd.Parameters.AddWithValue("@nhh", ngayHet);
                    cmd.Parameters.AddWithValue("@tt", dbTrangThai);
                    cmd.Parameters.AddWithValue("@id", _maNguoiDungHienTai);

                    cmd.ExecuteNonQuery();
                }

                tr.Commit();

                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Handler rỗng do Designer trỏ vào ======
        private void guna2TextBox1_TextChanged(object? sender, EventArgs e) { /* no-op */ }
    }
}
