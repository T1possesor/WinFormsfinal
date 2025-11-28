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
using System.Data.SQLite;

namespace WinFormsfinal
{
    public partial class TraSach : Form
    {

        string connectionString = "Data Source=project_final.db;Version=3;";

        public TraSach()
        {
            InitializeComponent();
            dgvPhieuMuon.Visible = false;
            panelUserInfo.Visible = false;

        }
        //Lấy mã người dùng NDxxxx từ mã thẻ TVxxxx
        private string LayMaNguoiDungTuMaThe(string maThe)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT MaNguoiDung FROM NguoiDung WHERE MaSoThe = @maThe";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maThe", maThe);
                    object result = cmd.ExecuteScalar();

                    return result?.ToString(); // null nếu không có
                }
            }
        }

        private void LoadDanhSachPhieuMuon(string maNguoiDung)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT 
                p.MaPhieu,
                p.NgayMuon,
                p.NgayTraDuKien,
                p.NgayTraThucTe,
                IFNULL(SUM(c.TienPhat), 0) AS TongTienPhat,
                MAX(c.PhuongThucTra) AS PhuongThucTra
            FROM PhieuMuon p
            LEFT JOIN ChiTietPhieuMuon c ON p.MaPhieu = c.MaPhieu
            WHERE p.MaNguoiDung = @MaNguoiDung
            GROUP BY p.MaPhieu;
        ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPhieuMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                        dgvPhieuMuon.ColumnHeadersHeight = 40;
                        foreach (DataRow row in dt.Rows)
                        {
                            // Ngày mượn
                            if (DateTime.TryParse(row["NgayMuon"]?.ToString(), out DateTime nm))
                                row["NgayMuon"] = nm.ToString("dd/MM/yyyy");

                            // Ngày trả dự kiến
                            if (DateTime.TryParse(row["NgayTraDuKien"]?.ToString(), out DateTime ndk))
                                row["NgayTraDuKien"] = ndk.ToString("dd/MM/yyyy");

                            // Ngày trả thực tế (nếu có)
                            if (DateTime.TryParse(row["NgayTraThucTe"]?.ToString(), out DateTime ntt))
                                row["NgayTraThucTe"] = ntt.ToString("dd/MM/yyyy");
                        }

                        dgvPhieuMuon.DataSource = dt;
                    }
                }
            }

            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.AllowUserToAddRows = false;

            // THÊM NÚT XEM CHI TIẾT
            if (!dgvPhieuMuon.Columns.Contains("ChiTiet"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "ChiTiet";
                btn.HeaderText = "";
                btn.Text = "Xem chi tiết";
                btn.UseColumnTextForButtonValue = true;
                dgvPhieuMuon.Columns.Add(btn);
            }
        }
        private void LoadThongTinNguoiDung(string maThe)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM NguoiDung WHERE MaSoThe = @maThe";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maThe", maThe);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTenNguoiDung.Text = reader["HoTen"].ToString();
                            lblMaThe.Text = reader["MaSoThe"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblSDT.Text = reader["SoDienThoai"].ToString();
                            // Format ngày tạo thẻ
                            if (DateTime.TryParse(reader["NgayTaoThe"]?.ToString(), out DateTime ngayTao))
                                lblNgayTaoThe.Text = ngayTao.ToString("dd/MM/yyyy");
                            else
                                lblNgayTaoThe.Text = "";

                            // Format ngày hết hạn thẻ
                            if (DateTime.TryParse(reader["NgayHetHanThe"]?.ToString(), out DateTime ngayHet))
                                lblNgayHetThe.Text = ngayHet.ToString("dd/MM/yyyy");
                            else
                                lblNgayHetThe.Text = "";
                            lblTrangThaiThe.Text = reader["TrangThai"].ToString();
                            lblMaNguoiDung.Text = reader["MaNguoiDung"].ToString();

                            panelUserInfo.Visible = true;
                            dgvPhieuMuon.Visible = true;

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            panelUserInfo.Visible = false;
                        }
                    }
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maThe = txtMaThe.Text.Trim();

            if (string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Vui lòng nhập mã thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHUYỂN TV0001 -> ND001
            string maNguoiDung = LayMaNguoiDungTuMaThe(maThe);

            if (maNguoiDung == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với mã thẻ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //  HIỂN THỊ THÔNG TIN NGƯỜI DÙNG
            LoadThongTinNguoiDung(maThe);
            // Load phiếu mượn theo mã người dùng
            LoadDanhSachPhieuMuon(maNguoiDung);
        }

        private void dgvPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào cột "ChiTiet"
            if (e.ColumnIndex == dgvPhieuMuon.Columns["ChiTiet"].Index && e.RowIndex >= 0)
            {
                string maPhieu = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();

                // Mở FORM 2
                ChiTietTraSach form = new ChiTietTraSach(maPhieu);
                form.ShowDialog();

                // Sau khi đóng form 2 → load lại danh sách
                string maThe = txtMaThe.Text.Trim();
                string maNguoiDung = LayMaNguoiDungTuMaThe(maThe);
                LoadDanhSachPhieuMuon(maNguoiDung);
            }
        }


        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem.PerformClick();
        }
    }
}


