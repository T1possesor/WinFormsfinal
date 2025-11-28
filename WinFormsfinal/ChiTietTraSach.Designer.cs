namespace WinFormsfinal
{
    partial class ChiTietTraSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbPhuongThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            lblTongPhatLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTongTienPhat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            lblMaPhieu = new Label();
            MaCT = new DataGridViewTextBoxColumn();
            MaSach = new DataGridViewTextBoxColumn();
            TenSach = new DataGridViewTextBoxColumn();
            GiaBia = new DataGridViewTextBoxColumn();
            NgayMuon = new DataGridViewTextBoxColumn();
            NgayTraDuKien = new DataGridViewTextBoxColumn();
            NgayTraThucTe = new DataGridViewTextBoxColumn();
            TienPhat = new DataGridViewTextBoxColumn();
            Hu = new DataGridViewCheckBoxColumn();
            Mat = new DataGridViewCheckBoxColumn();
            TinhTrang = new DataGridViewTextBoxColumn();
            PhatTre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Navy;
            guna2HtmlLabel1.Location = new Point(282, 12);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(273, 52);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Chi tiết trả sách";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.TopCenter;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(194, 224, 244);
            dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvChiTiet.ColumnHeadersHeight = 32;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { MaCT, MaSach, TenSach, GiaBia, NgayMuon, NgayTraDuKien, NgayTraThucTe, TienPhat, Hu, Mat, TinhTrang, PhatTre });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(214, 234, 247);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(119, 186, 231);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            dgvChiTiet.GridColor = Color.FromArgb(187, 220, 242);
            dgvChiTiet.Location = new Point(37, 92);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.Size = new Size(797, 268);
            dgvChiTiet.TabIndex = 1;
            dgvChiTiet.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(194, 224, 244);
            dgvChiTiet.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvChiTiet.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvChiTiet.ThemeStyle.BackColor = Color.White;
            dgvChiTiet.ThemeStyle.GridColor = Color.FromArgb(187, 220, 242);
            dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChiTiet.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvChiTiet.ThemeStyle.HeaderStyle.Height = 32;
            dgvChiTiet.ThemeStyle.ReadOnly = false;
            dgvChiTiet.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(214, 234, 247);
            dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvChiTiet.ThemeStyle.RowsStyle.Height = 25;
            dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(119, 186, 231);
            dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dgvChiTiet.CellValueChanged += dgvChiTiet_CellValueChanged;
            dgvChiTiet.CurrentCellDirtyStateChanged += dgvChiTiet_CurrentCellDirtyStateChanged;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(37, 390);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(212, 27);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Phương thức thanh toán:";
            // 
            // cbPhuongThuc
            // 
            cbPhuongThuc.BackColor = Color.Transparent;
            cbPhuongThuc.CustomizableEdges = customizableEdges1;
            cbPhuongThuc.DrawMode = DrawMode.OwnerDrawFixed;
            cbPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPhuongThuc.FocusedColor = Color.FromArgb(94, 148, 255);
            cbPhuongThuc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbPhuongThuc.Font = new Font("Segoe UI", 10F);
            cbPhuongThuc.ForeColor = Color.FromArgb(68, 88, 112);
            cbPhuongThuc.ItemHeight = 30;
            cbPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "None" });
            cbPhuongThuc.Location = new Point(255, 390);
            cbPhuongThuc.Name = "cbPhuongThuc";
            cbPhuongThuc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbPhuongThuc.Size = new Size(140, 36);
            cbPhuongThuc.TabIndex = 3;
            cbPhuongThuc.SelectedIndexChanged += cbPhuongThuc_SelectedIndexChanged;
            // 
            // lblTongPhatLabel
            // 
            lblTongPhatLabel.BackColor = Color.Transparent;
            lblTongPhatLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongPhatLabel.Location = new Point(37, 435);
            lblTongPhatLabel.Name = "lblTongPhatLabel";
            lblTongPhatLabel.Size = new Size(130, 27);
            lblTongPhatLabel.TabIndex = 4;
            lblTongPhatLabel.Text = "Tổng tiền phạt:";
            // 
            // lblTongTienPhat
            // 
            lblTongTienPhat.BackColor = Color.Transparent;
            lblTongTienPhat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTienPhat.Location = new Point(282, 444);
            lblTongTienPhat.Name = "lblTongTienPhat";
            lblTongTienPhat.Size = new Size(24, 27);
            lblTongTienPhat.TabIndex = 5;
            lblTongTienPhat.Text = "0đ";
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Transparent;
            btnXacNhan.BorderRadius = 5;
            btnXacNhan.CustomizableEdges = customizableEdges3;
            btnXacNhan.DisabledState.BorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXacNhan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXacNhan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXacNhan.FillColor = Color.SteelBlue;
            btnXacNhan.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(600, 512);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnXacNhan.Size = new Size(125, 37);
            btnXacNhan.TabIndex = 6;
            btnXacNhan.Text = "Xác nhận trả";
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Transparent;
            btnHuy.BorderRadius = 5;
            btnHuy.CustomizableEdges = customizableEdges5;
            btnHuy.DisabledState.BorderColor = Color.DarkGray;
            btnHuy.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHuy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHuy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHuy.FillColor = Color.LightGray;
            btnHuy.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.Black;
            btnHuy.Location = new Point(747, 512);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnHuy.Size = new Size(125, 37);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "Huỷ";
            btnHuy.Click += btnHuy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 64);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 8;
            label1.Text = "Mã phiếu:";
            // 
            // lblMaPhieu
            // 
            lblMaPhieu.AutoSize = true;
            lblMaPhieu.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaPhieu.Location = new Point(129, 64);
            lblMaPhieu.Name = "lblMaPhieu";
            lblMaPhieu.Size = new Size(93, 25);
            lblMaPhieu.TabIndex = 9;
            lblMaPhieu.Text = "Mã phiếu";
            // 
            // MaCT
            // 
            MaCT.DataPropertyName = "MaCT";
            MaCT.HeaderText = "MaCT";
            MaCT.Name = "MaCT";
            // 
            // MaSach
            // 
            MaSach.DataPropertyName = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.Name = "MaSach";
            // 
            // TenSach
            // 
            TenSach.DataPropertyName = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.Name = "TenSach";
            // 
            // GiaBia
            // 
            GiaBia.DataPropertyName = "GiaBia";
            GiaBia.HeaderText = "Giá Bìa";
            GiaBia.Name = "GiaBia";
            // 
            // NgayMuon
            // 
            NgayMuon.DataPropertyName = "NgayMuon";
            NgayMuon.HeaderText = "Ngày mượn";
            NgayMuon.Name = "NgayMuon";
            // 
            // NgayTraDuKien
            // 
            NgayTraDuKien.DataPropertyName = "NgayTraDuKien";
            NgayTraDuKien.HeaderText = "Ngày trả dự kiến";
            NgayTraDuKien.Name = "NgayTraDuKien";
            // 
            // NgayTraThucTe
            // 
            NgayTraThucTe.DataPropertyName = "NgayTraThucTe";
            NgayTraThucTe.HeaderText = "Ngày trả thực tế";
            NgayTraThucTe.Name = "NgayTraThucTe";
            // 
            // TienPhat
            // 
            TienPhat.DataPropertyName = "TienPhat";
            TienPhat.HeaderText = "Tiền Phạt";
            TienPhat.Name = "TienPhat";
            // 
            // Hu
            // 
            Hu.HeaderText = "Hư";
            Hu.Name = "Hu";
            Hu.Resizable = DataGridViewTriState.True;
            // 
            // Mat
            // 
            Mat.HeaderText = "Mất";
            Mat.Name = "Mat";
            Mat.Resizable = DataGridViewTriState.True;
            // 
            // TinhTrang
            // 
            TinhTrang.DataPropertyName = "TinhTrang";
            TinhTrang.HeaderText = "Tình Trạng";
            TinhTrang.Name = "TinhTrang";
            // 
            // PhatTre
            // 
            PhatTre.HeaderText = "Phạt trễ";
            PhatTre.Name = "PhatTre";
            PhatTre.Visible = false;
            // 
            // ChiTietTraSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(884, 561);
            Controls.Add(lblMaPhieu);
            Controls.Add(label1);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(lblTongTienPhat);
            Controls.Add(lblTongPhatLabel);
            Controls.Add(cbPhuongThuc);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(dgvChiTiet);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChiTietTraSach";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChiTietTraSach";
            Load += ChiTietTraSach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbPhuongThuc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongPhatLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTienPhat;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Label label1;
        private Label lblMaPhieu;
        private DataGridViewTextBoxColumn MaCT;
        private DataGridViewTextBoxColumn MaSach;
        private DataGridViewTextBoxColumn TenSach;
        private DataGridViewTextBoxColumn GiaBia;
        private DataGridViewTextBoxColumn NgayMuon;
        private DataGridViewTextBoxColumn NgayTraDuKien;
        private DataGridViewTextBoxColumn NgayTraThucTe;
        private DataGridViewTextBoxColumn TienPhat;
        private DataGridViewCheckBoxColumn Hu;
        private DataGridViewCheckBoxColumn Mat;
        private DataGridViewTextBoxColumn TinhTrang;
        private DataGridViewTextBoxColumn PhatTre;
    }
}