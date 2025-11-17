using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace WinFormsfinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(btnSach, 0, btnSach.Height);
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnPhong, 0, btnPhong.Height);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNguoiDoc_Click(object sender, EventArgs e)
        {

        }


    }
}
