using Guna.UI2.WinForms;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAn_1
{

    public partial class ImportHĐCT : Form
    {
        private string MaPN;
        private byte[] pdfBytes = null;
        PdfiumViewer.PdfViewer pdfiumViewer1;

        //Chuỗi kết nối
        string strConnectionString = string.Format(@"Data Source ={0}\project_final.db;Version=3;", Application.StartupPath);
        // Đối tượng kết nối dữ liệu
        SQLiteConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SQLiteDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;

        public ImportHĐCT(string maPN)
        {
            InitializeComponent();
            MaPN = maPN;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Khởi động kết nối
            conn = new SQLiteConnection(strConnectionString);
            //Mở kết nối
            conn.Open();           
            txtbMaPN.Text = MaPN;
            txtbMaPN.Enabled = false;

            pdfiumViewer1 = new PdfViewer();
            guna2Panel3.Controls.Add(pdfiumViewer1);
            pdfiumViewer1.BringToFront();
            pdfiumViewer1.Dock = DockStyle.Fill;

            LoadHD();

        }
        void LoadHD()
        {
            byte[] fileFromDb = null;
            string sql = "SELECT HoaDonDT FROM PhieuNhap WHERE MaPhieuNhap=@MaPN";
            using (conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPN", txtbMaPN.Text);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["HoaDonDT"] != DBNull.Value)
                            fileFromDb = (byte[])reader["HoaDonDT"];
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            pdfiumViewer1.Document?.Dispose();
            pdfiumViewer1.Document = null;
            if (fileFromDb == null)
            {
                MessageBox.Show("Chưa có PDF trong database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MemoryStream ms = new MemoryStream(fileFromDb);
            var pdfDoc = PdfiumViewer.PdfDocument.Load(ms);
            pdfiumViewer1.Document = pdfDoc;



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KTHDTrongDB(txtbMaPN.Text))
            {
                MessageBox.Show("Phiếu nhập này đã có PDF! Không thể ghi đè.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pdfBytes == null)
            {
                MessageBox.Show("Bạn chưa chọn file PDF nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE PhieuNhap SET HoaDonDT = @file WHERE MaPhieuNhap = @MaPN";
            using (conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", txtbMaPN.Text);
                        cmd.Parameters.Add("@file", System.Data.DbType.Binary).Value = pdfBytes;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Lưu PDF vào database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pdfBytes = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không tải lên CSDL" + ex.Message);
                }
            }


        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.Title = "Mở hóa đơn điện tử";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu file vào mảng byte
                    pdfBytes = File.ReadAllBytes(openFileDialog.FileName);
                    // Load the PDF file using PdfiumViewer
                    var pdfDocument = PdfDocument.Load(openFileDialog.FileName);
                    pdfiumViewer1.Document?.Dispose();
                    pdfiumViewer1.Document = pdfDocument;
                }
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbMaPN.Text))
            {
                MessageBox.Show("Không có mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KTHDTrongDB(txtbMaPN.Text))
            {
                MessageBox.Show("Phiếu nhập này không có file PDF để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn PDF?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;
            using (conn = new SQLiteConnection(strConnectionString))
            {
                conn.Open();
                string sql = "UPDATE PhieuNhap SET HoaDonDT = NULL WHERE MaPhieuNhap=@MaPN";

                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", txtbMaPN.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa hiển thị hiện tại
                    pdfiumViewer1.Document?.Dispose();
                    pdfiumViewer1.Document = null;

                    MessageBox.Show("Đã xóa PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa PDF: " + ex.Message);
                }
            }

        }
        private bool KTHDTrongDB(string maPN)
 {
     string sql = "SELECT HoaDonDT FROM PhieuNhap WHERE MaPhieuNhap=@MaPN";
     using (conn = new SQLiteConnection(strConnectionString))
     {
         conn.Open();
         using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
         {
             cmd.Parameters.AddWithValue("@MaPN", maPN);
             object result = cmd.ExecuteScalar();

             if (result is byte[] data)
             {
                 return data.Length > 0;
             }

             return false; // NULL hoặc không phải byte[]
         }
     }
 }



    }
}
