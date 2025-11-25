namespace QuanLyThuVien_PhanHeDocGia
{
    partial class FormQuanLyDocGia
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.labelTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelCongCu = new Guna.UI2.WinForms.Guna2Panel();
            this.buttonXoa = new Guna.UI2.WinForms.Guna2Button();
            this.buttonSua = new Guna.UI2.WinForms.Guna2Button();
            this.buttonThem = new Guna.UI2.WinForms.Guna2Button();
            this.comboBoxTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.textBoxTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.gridViewDocGia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuDocGia = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader.SuspendLayout();
            this.panelCongCu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocGia)).BeginInit();
            this.contextMenuDocGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.FillColor = System.Drawing.Color.White;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(5);
            this.panelHeader.Size = new System.Drawing.Size(1864, 77);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTieuDe
            // 
            this.labelTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.labelTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTieuDe.ForeColor = System.Drawing.Color.Black;
            this.labelTieuDe.Location = new System.Drawing.Point(5, 5);
            this.labelTieuDe.Name = "labelTieuDe";
            this.labelTieuDe.Size = new System.Drawing.Size(1854, 61);
            this.labelTieuDe.TabIndex = 0;
            this.labelTieuDe.Text = "QUẢN LÝ ĐỘC GIẢ";
            this.labelTieuDe.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.labelTieuDe.Click += new System.EventHandler(this.labelTieuDe_Click);
            // 
            // panelCongCu
            // 
            this.panelCongCu.Controls.Add(this.buttonXoa);
            this.panelCongCu.Controls.Add(this.buttonSua);
            this.panelCongCu.Controls.Add(this.buttonThem);
            this.panelCongCu.Controls.Add(this.comboBoxTrangThai);
            this.panelCongCu.Controls.Add(this.textBoxTimKiem);
            this.panelCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCongCu.Location = new System.Drawing.Point(0, 77);
            this.panelCongCu.Name = "panelCongCu";
            this.panelCongCu.Size = new System.Drawing.Size(1864, 241);
            this.panelCongCu.TabIndex = 1;
            // 
            // buttonXoa
            // 
            this.buttonXoa.BorderRadius = 10;
            this.buttonXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonXoa.FillColor = System.Drawing.Color.Maroon;
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.ForeColor = System.Drawing.Color.White;
            this.buttonXoa.Location = new System.Drawing.Point(708, 135);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(250, 71);
            this.buttonXoa.TabIndex = 4;
            this.buttonXoa.Text = "Xóa";
            // 
            // buttonSua
            // 
            this.buttonSua.BorderRadius = 10;
            this.buttonSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSua.ForeColor = System.Drawing.Color.White;
            this.buttonSua.Location = new System.Drawing.Point(355, 135);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(250, 71);
            this.buttonSua.TabIndex = 3;
            this.buttonSua.Text = "Sửa đã chọn";
            // 
            // buttonThem
            // 
            this.buttonThem.BorderRadius = 10;
            this.buttonThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonThem.FillColor = System.Drawing.Color.Green;
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.ForeColor = System.Drawing.Color.White;
            this.buttonThem.Location = new System.Drawing.Point(29, 135);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(250, 71);
            this.buttonThem.TabIndex = 2;
            this.buttonThem.Text = "Thêm độc giả";
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxTrangThai.BorderRadius = 10;
            this.comboBoxTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxTrangThai.ItemHeight = 30;
            this.comboBoxTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Hoạt động",
            "Bị khóa"});
            this.comboBoxTrangThai.Location = new System.Drawing.Point(482, 55);
            this.comboBoxTrangThai.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(202, 36);
            this.comboBoxTrangThai.TabIndex = 1;
            this.comboBoxTrangThai.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrangThai_SelectedIndexChanged);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.BorderRadius = 10;
            this.textBoxTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTimKiem.DefaultText = "";
            this.textBoxTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTimKiem.IconLeft = global::QuanLyThuVien_PhanHeDocGia.Properties.Resources.images__2_;
            this.textBoxTimKiem.Location = new System.Drawing.Point(29, 34);
            this.textBoxTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.PlaceholderText = "Tìm theo Tên, Mã thẻ, SĐT...";
            this.textBoxTimKiem.SelectedText = "";
            this.textBoxTimKiem.Size = new System.Drawing.Size(408, 77);
            this.textBoxTimKiem.TabIndex = 0;
            // 
            // gridViewDocGia
            // 
            this.gridViewDocGia.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(229)))), ((int)(((byte)(251)))));
            this.gridViewDocGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewDocGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridViewDocGia.ColumnHeadersHeight = 4;
            this.gridViewDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridViewDocGia.ContextMenuStrip = this.contextMenuDocGia;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(197)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewDocGia.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridViewDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewDocGia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.gridViewDocGia.Location = new System.Drawing.Point(0, 318);
            this.gridViewDocGia.MultiSelect = false;
            this.gridViewDocGia.Name = "gridViewDocGia";
            this.gridViewDocGia.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewDocGia.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridViewDocGia.RowHeadersVisible = false;
            this.gridViewDocGia.RowHeadersWidth = 82;
            this.gridViewDocGia.RowTemplate.Height = 33;
            this.gridViewDocGia.Size = new System.Drawing.Size(1864, 691);
            this.gridViewDocGia.TabIndex = 2;
            this.gridViewDocGia.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightBlue;
            this.gridViewDocGia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(229)))), ((int)(((byte)(251)))));
            this.gridViewDocGia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridViewDocGia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridViewDocGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridViewDocGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridViewDocGia.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridViewDocGia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.gridViewDocGia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.gridViewDocGia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridViewDocGia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewDocGia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridViewDocGia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridViewDocGia.ThemeStyle.HeaderStyle.Height = 4;
            this.gridViewDocGia.ThemeStyle.ReadOnly = true;
            this.gridViewDocGia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.gridViewDocGia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridViewDocGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewDocGia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gridViewDocGia.ThemeStyle.RowsStyle.Height = 33;
            this.gridViewDocGia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(197)))), ((int)(((byte)(247)))));
            this.gridViewDocGia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // contextMenuDocGia
            // 
            this.contextMenuDocGia.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuDocGia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSua,
            this.menuItemXoa});
            this.contextMenuDocGia.Name = "contextMenuDocGia";
            this.contextMenuDocGia.Size = new System.Drawing.Size(129, 80);
            // 
            // menuItemSua
            // 
            this.menuItemSua.Name = "menuItemSua";
            this.menuItemSua.Size = new System.Drawing.Size(128, 38);
            this.menuItemSua.Text = "Sửa";
            // 
            // menuItemXoa
            // 
            this.menuItemXoa.Name = "menuItemXoa";
            this.menuItemXoa.Size = new System.Drawing.Size(128, 38);
            this.menuItemXoa.Text = "Xóa";
            // 
            // FormQuanLyDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1864, 1009);
            this.Controls.Add(this.gridViewDocGia);
            this.Controls.Add(this.panelCongCu);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormQuanLyDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Thư viện - Quản lý Độc giả";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCongCu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocGia)).EndInit();
            this.contextMenuDocGia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelTieuDe;
        private Guna.UI2.WinForms.Guna2Panel panelCongCu;
        private Guna.UI2.WinForms.Guna2TextBox textBoxTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTrangThai;
        private Guna.UI2.WinForms.Guna2Button buttonXoa;
        private Guna.UI2.WinForms.Guna2Button buttonSua;
        private Guna.UI2.WinForms.Guna2Button buttonThem;
        private Guna.UI2.WinForms.Guna2DataGridView gridViewDocGia;
        private System.Windows.Forms.ContextMenuStrip contextMenuDocGia;
        private System.Windows.Forms.ToolStripMenuItem menuItemSua;
        private System.Windows.Forms.ToolStripMenuItem menuItemXoa;
    }
}

