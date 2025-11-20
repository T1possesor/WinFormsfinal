using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsfinal
{
    public partial class fTheThuVien : Form
    {
        private readonly string _username;

        public fTheThuVien(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;

            lblUserCaption.Text = "Tài khoản: " + _username;
            this.Load += fTheThuVien_Load;
        }

        // giống connection string form thông tin cá nhân
        private string GetConnectionString()
        {
            string dbPath = @"D:\btvnptudesktop\Bai_final\test2\WinFormsfinal\Database\project_final.db";
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("KHÔNG tìm thấy file DB tại:\n" + dbPath,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return $"Data Source={dbPath}";
        }

        private void fTheThuVien_Load(object? sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqliteConnection(GetConnectionString()))
                {
                    conn.Open();

                    string sql = @"
                        SELECT tk.TenDangNhap,
                               nd.MaNguoiDung,
                               nd.HoTen,
                               nd.MaSoThe,
                               nd.NgaySinh,
                               nd.SoDienThoai,
                               nd.Email,
                               nd.DiaChi,
                               nd.NgayTaoThe,
                               nd.NgayHetHanThe,
                               nd.TrangThai
                        FROM TaiKhoan tk
                        LEFT JOIN NguoiDung nd ON tk.MaNguoiDung = nd.MaNguoiDung
                        WHERE tk.TenDangNhap = @user
                    ";

                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", _username);

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                // Không có MaNguoiDung => chưa có thẻ
                                if (rd["MaNguoiDung"] == DBNull.Value ||
                                    string.IsNullOrWhiteSpace(rd["MaNguoiDung"].ToString()))
                                {
                                    MessageBox.Show(
                                        "Bạn chưa có thẻ thư viện.\n" +
                                        "Vui lòng vào mục 'Thông tin cá nhân' để cập nhật đầy đủ thông tin, " +
                                        "hệ thống sẽ tạo thẻ cho bạn.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    this.Close();
                                    return;
                                }

                                txtMaSoThe.Text     = rd["MaSoThe"]        as string ?? "";
                                txtHoTen.Text      = rd["HoTen"]          as string ?? "";
                                txtNgaySinh.Text   = rd["NgaySinh"]       as string ?? "";
                                txtSDT.Text        = rd["SoDienThoai"]    as string ?? "";
                                txtEmail.Text      = rd["Email"]          as string ?? "";
                                txtDiaChi.Text     = rd["DiaChi"]         as string ?? "";
                                txtNgayTao.Text    = rd["NgayTaoThe"]     as string ?? "";
                                txtNgayHetHan.Text = rd["NgayHetHanThe"]  as string ?? "";

                                string trangThai = rd["TrangThai"] as string ?? "";
                                txtTrangThai.Text = trangThai;

                                // nếu trạng thái BiKhoa thì hiện nút Thanh toán
                                btnThanhToan.Visible =
                                    string.Equals(trangThai, "BiKhoa", StringComparison.OrdinalIgnoreCase);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thẻ thư viện: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Thẻ thư viện của bạn đang ở trạng thái BI KHÓA.\n\n" +
                "Vui lòng đến thư viện để thanh toán và mở khóa thẻ tại địa chỉ:\n\n" +
                "279 Nguyễn Tri Phương, Phường 5, Quận 10, TP. Hồ Chí Minh.",
                "Hướng dẫn thanh toán",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
