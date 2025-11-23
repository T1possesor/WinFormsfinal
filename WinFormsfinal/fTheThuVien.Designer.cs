using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WinFormsfinal
{
    partial class fTheThuVien
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel panelMain;

        private Label lblTitle;
        private Label lblUserCaption;

        private Label lblMaSoThe;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblNgayTao;
        private Label lblNgayHetHan;
        private Label lblTrangThai;

        private Guna2TextBox txtMaSoThe;
        private Guna2TextBox txtHoTen;
        private Guna2TextBox txtNgaySinh;
        private Guna2TextBox txtSDT;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtDiaChi;
        private Guna2TextBox txtNgayTao;
        private Guna2TextBox txtNgayHetHan;
        private Guna2TextBox txtTrangThai;

        private Guna2Button btnThanhToan;
        private Guna2Button btnDong;

        // ===== THÊM: khung ảnh thẻ =====
        private Guna2PictureBox picAvatar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var cePanel = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceMain = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceTxt9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceBtn1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ceBtn2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            guna2BorderlessForm1 = new Guna2BorderlessForm(components);
            panelMain            = new Guna2Panel();

            lblTitle       = new Label();
            lblUserCaption = new Label();

            lblMaSoThe   = new Label();
            lblHoTen     = new Label();
            lblNgaySinh  = new Label();
            lblSDT       = new Label();
            lblEmail     = new Label();
            lblDiaChi    = new Label();
            lblNgayTao   = new Label();
            lblNgayHetHan= new Label();
            lblTrangThai = new Label();

            txtMaSoThe   = new Guna2TextBox();
            txtHoTen     = new Guna2TextBox();
            txtNgaySinh  = new Guna2TextBox();
            txtSDT       = new Guna2TextBox();
            txtEmail     = new Guna2TextBox();
            txtDiaChi    = new Guna2TextBox();
            txtNgayTao   = new Guna2TextBox();
            txtNgayHetHan= new Guna2TextBox();
            txtTrangThai = new Guna2TextBox();

            btnThanhToan = new Guna2Button();
            btnDong      = new Guna2Button();

            // ===== THÊM: avatar =====
            picAvatar = new Guna2PictureBox();

            SuspendLayout();

            // ===== Borderless form =====
            guna2BorderlessForm1.BorderRadius = 14;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;

            // ===== panelMain =====
            panelMain.BorderRadius = 16;
            panelMain.CustomizableEdges = cePanel;
            panelMain.FillColor = Color.White;
            panelMain.ShadowDecoration.BorderRadius = 16;
            panelMain.ShadowDecoration.CustomizableEdges = ceMain;
            panelMain.ShadowDecoration.Enabled = true;
            panelMain.ShadowDecoration.Shadow = new Padding(0, 0, 6, 6);
            panelMain.Size = new Size(700, 500);
            panelMain.Location = new Point(20, 20);

            // ===== Title =====
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(230, 18);
            lblTitle.Text = "Thẻ thư viện của bạn";

            lblUserCaption.AutoSize = true;
            lblUserCaption.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblUserCaption.ForeColor = Color.FromArgb(73, 80, 87);
            lblUserCaption.Location = new Point(30, 55);
            lblUserCaption.Text = "Tài khoản:";

            int leftLabel = 30;
            int leftInput = 170;
            int topFirst = 90;
            int lineHeight = 34;
            int gap = 8;

            // ===== Dòng 1 – Mã số thẻ =====
            lblMaSoThe.AutoSize = true;
            lblMaSoThe.Font = new Font("Segoe UI", 10F);
            lblMaSoThe.Location = new Point(leftLabel, topFirst);
            lblMaSoThe.Text = "Mã số thẻ";

            txtMaSoThe.BorderRadius = 8;
            txtMaSoThe.CustomizableEdges = ceTxt1;
            txtMaSoThe.Location = new Point(leftInput, topFirst - 3);
            txtMaSoThe.Size = new Size(180, 28);
            txtMaSoThe.Font = new Font("Segoe UI", 10F);
            txtMaSoThe.ReadOnly = true;
            txtMaSoThe.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 2 – Họ tên =====
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 1);
            lblHoTen.Text = "Họ tên";

            txtHoTen.BorderRadius = 8;
            txtHoTen.CustomizableEdges = ceTxt2;
            txtHoTen.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 1 - 3);
            txtHoTen.Size = new Size(310, 28);
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.ReadOnly = true;
            txtHoTen.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 3 – Ngày sinh =====
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 2);
            lblNgaySinh.Text = "Ngày sinh";

            txtNgaySinh.BorderRadius = 8;
            txtNgaySinh.CustomizableEdges = ceTxt3;
            txtNgaySinh.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 2 - 3);
            txtNgaySinh.Size = new Size(180, 28);
            txtNgaySinh.Font = new Font("Segoe UI", 10F);
            txtNgaySinh.ReadOnly = true;
            txtNgaySinh.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 4 – SĐT =====
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 10F);
            lblSDT.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 3);
            lblSDT.Text = "Số điện thoại";

            txtSDT.BorderRadius = 8;
            txtSDT.CustomizableEdges = ceTxt4;
            txtSDT.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 3 - 3);
            txtSDT.Size = new Size(180, 28);
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.ReadOnly = true;
            txtSDT.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 5 – Email =====
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 4);
            lblEmail.Text = "Email";

            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = ceTxt5;
            txtEmail.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 4 - 3);
            txtEmail.Size = new Size(310, 28);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ReadOnly = true;
            txtEmail.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 6 – Địa chỉ =====
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 5);
            lblDiaChi.Text = "Địa chỉ";

            txtDiaChi.BorderRadius = 8;
            txtDiaChi.CustomizableEdges = ceTxt6;
            txtDiaChi.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 5 - 3);
            txtDiaChi.Size = new Size(310, 28);
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.ReadOnly = true;
            txtDiaChi.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 7 – Ngày tạo thẻ =====
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new Font("Segoe UI", 10F);
            lblNgayTao.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 6);
            lblNgayTao.Text = "Ngày tạo thẻ";

            txtNgayTao.BorderRadius = 8;
            txtNgayTao.CustomizableEdges = ceTxt7;
            txtNgayTao.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 6 - 3);
            txtNgayTao.Size = new Size(180, 28);
            txtNgayTao.Font = new Font("Segoe UI", 10F);
            txtNgayTao.ReadOnly = true;
            txtNgayTao.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 8 – Ngày hết hạn =====
            lblNgayHetHan.AutoSize = true;
            lblNgayHetHan.Font = new Font("Segoe UI", 10F);
            lblNgayHetHan.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 7);
            lblNgayHetHan.Text = "Ngày hết hạn";

            txtNgayHetHan.BorderRadius = 8;
            txtNgayHetHan.CustomizableEdges = ceTxt8;
            txtNgayHetHan.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 7 - 3);
            txtNgayHetHan.Size = new Size(180, 28);
            txtNgayHetHan.Font = new Font("Segoe UI", 10F);
            txtNgayHetHan.ReadOnly = true;
            txtNgayHetHan.FillColor = Color.FromArgb(245, 245, 245);

            // ===== Dòng 9 – Trạng thái =====
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 10F);
            lblTrangThai.Location = new Point(leftLabel, topFirst + (lineHeight + gap) * 8);
            lblTrangThai.Text = "Trạng thái";

            txtTrangThai.BorderRadius = 8;
            txtTrangThai.CustomizableEdges = ceTxt9;
            txtTrangThai.Location = new Point(leftInput, topFirst + (lineHeight + gap) * 8 - 3);
            txtTrangThai.Size = new Size(180, 28);
            txtTrangThai.Font = new Font("Segoe UI", 10F);
            txtTrangThai.ReadOnly = true;
            txtTrangThai.FillColor = Color.FromArgb(245, 245, 245);

            // ===== ẢNH THẺ (bên phải) =====
            picAvatar.ImageRotate = 0F;
            picAvatar.Size = new Size(120, 120);
            picAvatar.Location = new Point(540, 90);            // cột phải
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;       // ảnh đã crop vuông ⇒ lấp đầy
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.FillColor = Color.FromArgb(245, 245, 245);
            picAvatar.BorderRadius = 8;

            // ===== Button Thanh toán =====
            btnThanhToan.BorderRadius = 10;
            btnThanhToan.CustomizableEdges = ceBtn1;
            btnThanhToan.FillColor = Color.FromArgb(0, 123, 255);
            btnThanhToan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Size = new Size(120, 32);
            btnThanhToan.Location = new Point(400, 445);
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Visible = false;
            btnThanhToan.Click += btnThanhToan_Click;

            // ===== Button Đóng =====
            btnDong.BorderRadius = 10;
            btnDong.CustomizableEdges = ceBtn2;
            btnDong.FillColor = Color.FromArgb(108, 117, 125);
            btnDong.Font = new Font("Segoe UI", 10F);
            btnDong.ForeColor = Color.White;
            btnDong.Size = new Size(100, 32);
            btnDong.Location = new Point(540, 445);
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;

            // ===== Add controls vào panelMain =====
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblUserCaption);

            panelMain.Controls.Add(lblMaSoThe);
            panelMain.Controls.Add(txtMaSoThe);
            panelMain.Controls.Add(lblHoTen);
            panelMain.Controls.Add(txtHoTen);
            panelMain.Controls.Add(lblNgaySinh);
            panelMain.Controls.Add(txtNgaySinh);
            panelMain.Controls.Add(lblSDT);
            panelMain.Controls.Add(txtSDT);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblDiaChi);
            panelMain.Controls.Add(txtDiaChi);
            panelMain.Controls.Add(lblNgayTao);
            panelMain.Controls.Add(txtNgayTao);
            panelMain.Controls.Add(lblNgayHetHan);
            panelMain.Controls.Add(txtNgayHetHan);
            panelMain.Controls.Add(lblTrangThai);
            panelMain.Controls.Add(txtTrangThai);

            panelMain.Controls.Add(picAvatar);      // THÊM

            panelMain.Controls.Add(btnThanhToan);
            panelMain.Controls.Add(btnDong);

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 250);
            ClientSize = new Size(740, 540);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fTheThuVien";
            Text = "Thẻ thư viện";
            StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
        }

        #endregion
    }
}
