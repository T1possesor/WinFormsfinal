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

namespace QLNhapSach_new
{
    public partial class FormThemMoiSach : Form
    {    //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        public FormThemMoiSach()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Khởi động kết nối
            conn = new SQLiteConnection(strConnectionString);
            //Mở kết nối
            conn.Open();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn = null;
        }
        //Hàm lấy mã sách ở dòng cuối cùng trong bảng sách
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
        // Hàm để thực hiện sinh ra mã sách dựa trên dòng cuối cùng của mã sách
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
        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            bool value = true;
            // Gọi hàm sinh mã sách và gán giá trị mã vàoTextBox mã sách
            string MaSach = SinhMaSach();
            // Kiểm tra các trường trước khi lưu vào CSDL
            // Báo lỗi yêu cầu không để trống tên sách
            if (string.IsNullOrEmpty(txtbTenSach.Text))
            {
                erorTenSach.SetError(txtbTenSach, "Không để trống tên sách");
                value = false;
            }
            // Báo lỗi yêu cầu không để trống tên tác giả
            if (string.IsNullOrEmpty(txtbTacGia.Text))
            {
                erorTacGia.SetError(txtbTacGia, "Vui lòng nhập tên tác giả");
                value = false;
            }
            // Báo lỗi yêu cầu không để trống thể loại
            if (string.IsNullOrEmpty(txtbTheLoai.Text))
            {
                erorTheLoai.SetError(txtbTheLoai, "Vui lòng nhập thể loại");
                value = false;
            }
            // Báo lỗi yêu cầu không để trống nhà xuất bản
            if (string.IsNullOrEmpty(txtbNXB.Text))
            {
                erorNXB.SetError(txtbNXB, "Vui lòng nhập nhà xuất bản");
                value = false;
            }
            // Báo lỗi yêu cầu không để trống năm xuất bản
            if (string.IsNullOrEmpty(txtbNamXB.Text))
            {
                erorNamXB.SetError(txtbNamXB, "Vui lòng nhập năm xuất bản");
                value = false;
            }
            // Báo lỗi yêu cầu không để trống giá bìa
            if (string.IsNullOrEmpty(txtbGiaBia.Text))
            {
                erorGiaBia.SetError(txtbGiaBia, "Vui lòng nhập giá bìa");
                value = false;
            }
            // Nếu có bất kỳ một lỗi nào thì trở lại và không thực hiện lưu
            if (!value) { return; }
            // Thực hiện lưu vào cơ sở dữ liệu
            try
            {
                string sql = @"
                INSERT INTO Sach (
                    MaSach, TenSach, TacGia, NhaXuatBan, NamXuatBan,
                    GiaBia, TheLoai
                    )
                VALUES (
                    @MaSach, @TenSach, @TacGia, @NhaXuatBan, @NamXuatBan,
                    @GiaBia, @TheLoai
                     );
                     ";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd.Parameters.AddWithValue("@TenSach", txtbTenSach.Text);
                    cmd.Parameters.AddWithValue("@TacGia", txtbTacGia.Text);
                    cmd.Parameters.AddWithValue("@NhaXuatBan", txtbNXB.Text);
                    cmd.Parameters.AddWithValue("@NamXuatBan", Int64.Parse(txtbNamXB.Text));
                    cmd.Parameters.AddWithValue("@GiaBia", Double.Parse(txtbGiaBia.Text));
                    cmd.Parameters.AddWithValue("@TheLoai", txtbTheLoai.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sách: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtbGiaBia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số, phím control (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbNamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số, phím control (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
