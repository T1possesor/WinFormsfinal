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

namespace DoAn_1
{
    public partial class QLSach : Form
    {
        //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        //Đối tượng tự động cập nhật dữ liệu
        SQLiteCommandBuilder cmd = null;
        public QLSach()
        {
            InitializeComponent();
            txtbMaSach.Enabled = false;
           
        }        
        private void Form2_Load_1(object sender, EventArgs e)
        {            
            //Khởi động kết nối
            conn = new SQLiteConnection(strConnectionString);
            //Mở kết nối
            conn.Open();
            LoadSach();          
        }
        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null;
            conn.Close();
            conn = null;
        }
        void LoadSach()
        {
            try
            {
                // Vận chuyển dữ liệu
                da = new SQLiteDataAdapter("SELECT MaSach, TenSach, TacGia, NhaXuatBan, NamXuatBan, GiaBia,TheLoai, SoLuongTong, SoLuongConLai, SoLuongMat, SoLuongHuHong, TrangThaiMuon, ViTriKeSach,MoTa FROM Sach", conn);
                //Khởi tạo đối tượng chứa dữ liệu
                ds = new DataSet();

                //Đổ dữ liệu vào DataSet
                da.Fill(ds, "Sach");

                // Đưa dữ liệu lên DataGridView
                dgSach.DataSource = ds.Tables["Sach"];

                dgSach.Columns[0].HeaderText = "Mã sách";
                dgSach.Columns[1].HeaderText = "Tên sách";
                dgSach.Columns[2].HeaderText = "Tác giả";
                dgSach.Columns[3].HeaderText = "Nhà xuất bản";
                dgSach.Columns[4].HeaderText = "Năm xuất bản";
                dgSach.Columns[5].HeaderText = "Giá bìa";
                dgSach.Columns[6].HeaderText = "Thể loại";
                dgSach.Columns[7].HeaderText = "Số lượng tổng";
                dgSach.Columns[8].HeaderText = "Số lượng còn lại";
                dgSach.Columns[9].HeaderText = " Số lượng mất";
                dgSach.Columns[10].HeaderText = " Số lượng hư hỏng";
                dgSach.Columns[11].HeaderText = "Trạng thái mượn";
                dgSach.Columns[12].HeaderText = "Vị trí kệ sách";
                dgSach.Columns[13].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!"+ ex.Message);
                MessageBox.Show("File SQLite đang dùng:\n" + strConnectionString);
            }
            foreach (DataGridViewRow row in dgSach.Rows)
            {
                row.ReadOnly = true;
            }
        }
        //kiểm tra sách đã tồn tại thông qua tên sách, tác giả và năm xuất bản
        //(TH sách có 2 phiên bản thì cần thêm điểm phân biệt ví dụ thể hiện trong tên sách/ năm xuất bản/tác giả)
        private bool SachDaTonTai(string ten, string tacgia, int nam)
        {
            ten = ten.Trim();
            tacgia = tacgia.Trim();

            foreach (DataGridViewRow row in dgSach.Rows)
            {
                if (row.IsNewRow) continue;

                var tenRow = row.Cells["TenSach"].Value?.ToString().Trim();
                var tacGiaRow = row.Cells["TacGia"].Value?.ToString().Trim();
                var namRow = row.Cells["NamXuatBan"].Value;

                if (tenRow == null || tacGiaRow == null || namRow == null)
                    continue;

                int namDB = Convert.ToInt32(namRow);

                // So sánh không phân biệt hoa/thường
                if (string.Equals(ten, tenRow, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(tacgia, tacGiaRow, StringComparison.OrdinalIgnoreCase) &&
                    nam == namDB)
                {
                    return true; 
                }
            }
            return false;
        }
        //hàm lấy mã sách ở dòng cuối cùng trong bảng sách
        public string LayMaSach()
        {
            string MaSach = null;
            string sql = "SELECT MaSach FROM Sach ORDER BY MaSach DESC LIMIT 1";
            var connTemp = new SQLiteConnection(strConnectionString);
            connTemp.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(sql, connTemp))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MaSach = result.ToString();
                }

            }
            return MaSach;
            connTemp.Close();
        }
        // hàm để thực hiện sinh ra mã sách dựa trên dòng cuối cùng của mã sách
        public string SinhMaSach()
        {
            string prefix = "S";
            int dodaikytuso = 3;

            string MaSachCC = LayMaSach();

            if (string.IsNullOrEmpty(MaSachCC))
            {
                return prefix + "001";
            }
            int number = int.Parse(MaSachCC.Substring(prefix.Length));
            number++;
            return prefix + number.ToString().PadLeft(dodaikytuso, '0');
        }
        private void btnLuu_Click(object sender, EventArgs e)
        { bool value = true;
            txtbMaSach.Text = SinhMaSach();
            if (string.IsNullOrEmpty(txtbTenSach.Text) )
                {
                erorTenSach.SetError(txtbTenSach, "Không để trống tên sách");
                value = false;
                }
            if (string.IsNullOrEmpty(txtbTacGia.Text))
            {
                erorTacGia.SetError(txtbTacGia, "Vui lòng nhập tên tác giả");
                value = false;
            }
            if(string.IsNullOrEmpty(txtbTheLoai.Text) )
            {
                erorTheLoai.SetError(txtbTheLoai, "Vui lòng nhập thể loại");
                value = false;
            }  
            if (string.IsNullOrEmpty(txtbNXB.Text))
            {
                erorNXB.SetError(txtbNXB, "Vui lòng nhập nhà xuất bản");
                value = false;
            } 
            if (string.IsNullOrEmpty(txtbNamXB.Text))
            {
                erorNamXB.SetError(txtbNamXB, "Vui lòng nhập năm xuất bản");
                value = false;
            } 
            if(string.IsNullOrEmpty (txtbGiaBia.Text))
            {
                erorGiaBia.SetError(txtbGiaBia, "Vui lòng nhập giá bìa");
                value = false;
            }
            if (!value) { return; }
            string ten = txtbTenSach.Text;
            string tacgia = txtbTacGia.Text;
            int nam = int.Parse(txtbNamXB.Text);

            if (SachDaTonTai(ten, tacgia, nam))
            {
                MessageBox.Show(
                    "Cuốn sách này đã tồn tại (trùng tên, tác giả và năm xuất bản). Hãy thêm điểm phân biệt",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            try
            {
                string sql = @"
                INSERT INTO Sach (
                    MaSach, TenSach, TacGia, NhaXuatBan, NamXuatBan,
                    GiaBia, TheLoai, ViTriKeSach, MoTa
                    )
                VALUES (
                    @MaSach, @TenSach, @TacGia, @NhaXuatBan, @NamXuatBan,
                    @GiaBia, @TheLoai, @ViTriKeSach, @MoTa
                     );
                     ";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", txtbMaSach.Text);
                    cmd.Parameters.AddWithValue("@TenSach", txtbTenSach.Text);
                    cmd.Parameters.AddWithValue("@TacGia", txtbTacGia.Text);
                    cmd.Parameters.AddWithValue("@NhaXuatBan", txtbNXB.Text);
                    cmd.Parameters.AddWithValue("@NamXuatBan", Int64.Parse(txtbNamXB.Text));
                    cmd.Parameters.AddWithValue("@GiaBia", Double.Parse(txtbGiaBia.Text));
                    cmd.Parameters.AddWithValue("@TheLoai", txtbTheLoai.Text);
                    cmd.Parameters.AddWithValue("@ViTriKeSach", txtbViTriKe.Text);
                    cmd.Parameters.AddWithValue("@MoTa",txtbMoTa.Text);  
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm sách thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sách: " + ex.Message);
            }
        }             

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
                UPDATE Sach
                SET 
                    TenSach = @TenSach,
                    TacGia = @TacGia,
                    NhaXuatBan = @NhaXuatBan,
                    NamXuatBan = @NamXuatBan,
                    GiaBia = @GiaBia,
                    TheLoai = @TheLoai,
                    ViTriKeSach = @ViTriKeSach,
                    MoTa = @MoTa
                WHERE MaSach = @MaSach;
                    ";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", txtbMaSach.Text);
                    cmd.Parameters.AddWithValue("@TenSach", txtbTenSach.Text);
                    cmd.Parameters.AddWithValue("@TacGia", txtbTacGia.Text);
                    cmd.Parameters.AddWithValue("@NhaXuatBan", txtbNXB.Text);
                    cmd.Parameters.AddWithValue("@NamXuatBan", Int64.Parse(txtbNamXB.Text));
                    cmd.Parameters.AddWithValue("@GiaBia", Double.Parse(txtbGiaBia.Text));
                    cmd.Parameters.AddWithValue("@TheLoai", txtbTheLoai.Text);
                    cmd.Parameters.AddWithValue("@ViTriKeSach", txtbViTriKe.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txtbMoTa.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sửa thông tin sách thành công!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            try
            {
                string sql = @"
                DELETE FROM Sach Where MaSach=@MaSach;
                ";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", txtbMaSach.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Xóa sách thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadSach();
            }
            catch (SQLiteException ex)
            {
               MessageBox.Show(ex.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);          
                
            }           
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }

        }
        // hàm loại bỏ dấu
        public static string BoKyTuDau(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return new string(
                text.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray()
            );
        }
        void TimKiem(string keyword)
        {
            keyword = BoKyTuDau(keyword).Replace(" ", "").ToLower();
            try
            {
                //Khai báo câu truy vấn
                string sql = "SELECT * FROM Sach";          

                da = new SQLiteDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "Sach");
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dgSach.DataSource = ds.Tables["Sach"];
                    return;
                }

                // Lọc dữ liệu trong C# (bỏ dấu + bỏ khoảng trắng + hạ chữ thường)
                var filtered = ds.Tables["Sach"].AsEnumerable()
                    .Where(row => BoKyTuDau(row.Field<string>("TenSach"))
                                  .Replace(" ", "")
                                  .ToLower()
                                  .Contains(keyword));

                // Hiển thị lên DataGridView
                if (filtered.Any())
                    dgSach.DataSource = filtered.CopyToDataTable();
                else
                    MessageBox.Show("Sách không tồn tại","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);                   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
             TimKiem(txtbKeyWord.Text);
          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtbMaSach.Text= "";
            txtbTenSach.ResetText();
            txtbTacGia.ResetText();
            txtbNXB.ResetText();
            txtbNamXB.ResetText();
            txtbTheLoai.ResetText();
            txtbGiaBia.ResetText();
            txtbViTriKe.ResetText();
            txtbMoTa.ResetText();
        }
       
        private void dgSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgSach.Rows[e.RowIndex];
                txtbMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtbTenSach.Text = row.Cells["TenSach"].Value.ToString();
                txtbTacGia.Text = row.Cells["TacGia"].Value.ToString();
                txtbNXB.Text = row.Cells["NhaXuatBan"].Value.ToString();
                txtbNamXB.Text = row.Cells["NamXuatBan"].Value.ToString();
                txtbGiaBia.Text = row.Cells["GiaBia"].Value.ToString();
                txtbTheLoai.Text = row.Cells["TheLoai"].Value.ToString();
                txtbViTriKe.Text = row.Cells["ViTriKeSach"].Value.ToString();
                txtbMoTa.Text = row.Cells["MoTa"].Value.ToString();
            }
        }    

        private void txtbTenSach_TextChanged(object sender, EventArgs e)
        {
            erorTenSach.Clear();
        }

        private void txtbTacGia_TextChanged(object sender, EventArgs e)
        {
            erorTacGia.Clear();
        }

        private void txtbTheLoai_TextChanged(object sender, EventArgs e)
        {
            erorTheLoai.Clear();
        }

        private void txtbNXB_TextChanged(object sender, EventArgs e)
        {
            erorNXB.Clear();
        }

        private void txtbNamXB_TextChanged(object sender, EventArgs e)
        {
            erorNamXB.Clear();
        }

        private void txtbGiaBia_TextChanged(object sender, EventArgs e)
        {
            erorGiaBia.Clear();
        }
        // hiển thị cảnh báo tên sách bị trùng cho người dùng
        private void txtbTenSach_Leave(object sender, EventArgs e)
        {
            string TenSach = txtbTenSach.Text.Trim();
            if (TenSach == "") return;

            foreach (DataGridViewRow row in dgSach.Rows)
            {
                
                if (row.IsNewRow) continue;
                var value = row.Cells["TenSach"].Value;        
                if (string.Equals(TenSach, value.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tên sách đã tồn tại. Hãy kiểm tra tác giả hoặc phiên bản trước khi thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                  
                    return;
                }
            }

        }     
        //khi keyword trả về giá trị null sẽ load lại toàn bộ danh sách
        private void txtbKeyWord_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtbKeyWord.Text))
            {
                LoadSach();
            }    
        }
        // Chỉ cho pho phép nhập số đối với năm xuất bản
        private void txtbNamXB_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        // Chỉ cho phép nhập số đối với giá bìa
        private void txtbGiaBia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; 
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

