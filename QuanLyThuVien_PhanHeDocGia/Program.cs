using System;
using System.Windows.Forms;
using SQLitePCL; 

namespace QuanLyThuVien_PhanHeDocGia
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            Application.Run(new FormQuanLyDocGia());
        }
    }
}
