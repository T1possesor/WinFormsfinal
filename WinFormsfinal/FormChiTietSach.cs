using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyThuVien_PhanHeDocGia
{
    public partial class FormChiTietSach : Form
    {
        // ====== DB ======
        private static readonly string DbFilePath =
            Path.Combine(Application.StartupPath, "project_final.db");

        // C# 7.3: dùng chuỗi thường, tránh nameof(...)
        private static readonly string ConnectionString =
            "Data Source=" + @"project_final.db";

        private readonly string _maSach; // Mã sách cần xem

        public FormChiTietSach(string maSach)
        {
            InitializeComponent();
            _maSach = maSach ?? string.Empty;

            Load += FormChiTietSach_Load;
            btnDong.Click += (s, e) => Close();

            if (pbAnhBia != null)
            {
                pbAnhBia.SizeMode = PictureBoxSizeMode.Zoom;
                pbAnhBia.BackColor = Color.White;
            }
        }

        private void FormChiTietSach_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_maSach))
                TaiThongTinChiTiet(_maSach);
        }

        private void TaiThongTinChiTiet(string maSach)
        {
            try
            {
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();

                    const string sql = "SELECT * FROM Sach WHERE MaSach = @id";
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", maSach);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Không tìm thấy sách.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            lblTenSach.Text = Convert.ToString(reader["TenSach"]);
                            lblMaSach.Text = "<b>Mã sách:</b> " + Convert.ToString(reader["MaSach"]);
                            lblTacGia.Text = "<b>Tác giả:</b> " + Convert.ToString(reader["TacGia"]);
                            lblNhaXuatBan.Text = "<b>Nhà xuất bản:</b> " + Convert.ToString(reader["NhaXuatBan"])
                                                 + " (" + Convert.ToString(reader["NamXuatBan"]) + ")";
                            lblTheLoai.Text = "<b>Thể loại:</b> " + Convert.ToString(reader["TheLoai"]);
                            lblViTri.Text = "<b>Vị trí kệ:</b> " + Convert.ToString(reader["ViTriKeSach"]);
                            lblSoLuong.Text = "<b>Số lượng còn lại:</b> " + Convert.ToString(reader["SoLuongConLai"]);

                            var trangThai = Convert.ToString(reader["TrangThaiMuon"]) ?? "";
                            lblTrangThai.Text = "<b>Trạng thái:</b> " + trangThai;
                            lblTrangThai.ForeColor =
                                string.Equals(trangThai, "Sẵn có", StringComparison.OrdinalIgnoreCase)
                                ? Color.Green : Color.Red;

                            var moTa = Convert.ToString(reader["MoTa"]) ?? "";
                            lblMoTaChiTiet.Text = moTa.Replace("\r\n", "\n").Replace("\n", "<br/>");
                            lblMoTaChiTiet.MaximumSize = new Size(420, 0);

                            var relPath = Convert.ToString(reader["AnhBiaURL"]);
                            HienThiAnhBia(relPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải chi tiết sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiAnhBia(string relativePath)
        {
            pbAnhBia.SizeMode = PictureBoxSizeMode.Zoom;

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                pbAnhBia.Image = null;
                return;
            }

            try
            {
                // Ghép với thư mục chạy (bin\Debug...\)
                string fullPath = Path.Combine(Application.StartupPath, relativePath);

                if (File.Exists(fullPath))
                {
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        pbAnhBia.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    // Debug nhanh: xem đường dẫn đang tìm
                    // MessageBox.Show(fullPath);
                    pbAnhBia.Image = null;
                }
            }
            catch
            {
                pbAnhBia.Image = null;
            }
        }


    }
}
