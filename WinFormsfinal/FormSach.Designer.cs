namespace QuanLyThuVien_PhanHeDocGia
{
    partial class FormSach
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSach));
            pnHeader = new Guna.UI2.WinForms.Guna2Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnCongCu = new Guna.UI2.WinForms.Guna2Panel();
            cmbTheLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            pnGridContainer = new Guna.UI2.WinForms.Guna2Panel();
            dgvSach = new Guna.UI2.WinForms.Guna2DataGridView();
            pnHeader.SuspendLayout();
            pnCongCu.SuspendLayout();
            pnGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(guna2HtmlLabel1);
            pnHeader.CustomizableEdges = customizableEdges1;
            pnHeader.Dock = DockStyle.Top;
            pnHeader.FillColor = Color.Transparent;
            pnHeader.ForeColor = SystemColors.ActiveCaptionText;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Margin = new Padding(2, 3, 2, 3);
            pnHeader.Name = "pnHeader";
            pnHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnHeader.Size = new Size(1569, 183);
            pnHeader.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Dock = DockStyle.Top;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel1.Location = new Point(0, 0);
            guna2HtmlLabel1.Margin = new Padding(2, 3, 2, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(508, 50);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "THƯ VIỆN SÁCH TRỰC TUYẾN";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.TopCenter;
            // 
            // pnCongCu
            // 
            pnCongCu.BackColor = Color.Transparent;
            pnCongCu.Controls.Add(cmbTheLoai);
            pnCongCu.Controls.Add(txtTimKiem);
            pnCongCu.CustomizableEdges = customizableEdges7;
            pnCongCu.Dock = DockStyle.Top;
            pnCongCu.Location = new Point(0, 183);
            pnCongCu.Margin = new Padding(2, 3, 2, 3);
            pnCongCu.Name = "pnCongCu";
            pnCongCu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnCongCu.Size = new Size(1569, 99);
            pnCongCu.TabIndex = 1;
            pnCongCu.UseTransparentBackground = true;
            // 
            // cmbTheLoai
            // 
            cmbTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cmbTheLoai.BackColor = Color.Transparent;
            cmbTheLoai.CustomizableEdges = customizableEdges3;
            cmbTheLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheLoai.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbTheLoai.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbTheLoai.Font = new Font("Segoe UI", 10F);
            cmbTheLoai.ForeColor = Color.FromArgb(68, 88, 112);
            cmbTheLoai.ItemHeight = 30;
            cmbTheLoai.Location = new Point(462, 24);
            cmbTheLoai.Margin = new Padding(2, 3, 2, 3);
            cmbTheLoai.Name = "cmbTheLoai";
            cmbTheLoai.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbTheLoai.Size = new Size(296, 36);
            cmbTheLoai.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 10;
            txtTimKiem.Cursor = Cursors.IBeam;
            txtTimKiem.CustomizableEdges = customizableEdges5;
            txtTimKiem.DefaultText = "";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.Dock = DockStyle.Left;
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Location = new Point(0, 0);
            txtTimKiem.Margin = new Padding(5, 6, 5, 6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm kiếm theo tên sách, tác giả...";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtTimKiem.Size = new Size(415, 99);
            txtTimKiem.TabIndex = 0;
            // 
            // pnGridContainer
            // 
            pnGridContainer.BackColor = Color.Transparent;
            pnGridContainer.Controls.Add(dgvSach);
            pnGridContainer.CustomizableEdges = customizableEdges9;
            pnGridContainer.Dock = DockStyle.Fill;
            pnGridContainer.Location = new Point(0, 282);
            pnGridContainer.Margin = new Padding(2, 3, 2, 3);
            pnGridContainer.Name = "pnGridContainer";
            pnGridContainer.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnGridContainer.Size = new Size(1569, 768);
            pnGridContainer.TabIndex = 2;
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.AllowUserToResizeColumns = false;
            dgvSach.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSach.ColumnHeadersHeight = 4;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSach.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSach.Dock = DockStyle.Fill;
            dgvSach.GridColor = Color.FromArgb(231, 229, 255);
            dgvSach.Location = new Point(0, 0);
            dgvSach.Margin = new Padding(2, 3, 2, 3);
            dgvSach.MultiSelect = false;
            dgvSach.Name = "dgvSach";
            dgvSach.ReadOnly = true;
            dgvSach.RowHeadersVisible = false;
            dgvSach.RowHeadersWidth = 82;
            dgvSach.Size = new Size(1569, 768);
            dgvSach.TabIndex = 0;
            dgvSach.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvSach.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvSach.ThemeStyle.BackColor = Color.White;
            dgvSach.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvSach.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvSach.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSach.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSach.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvSach.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSach.ThemeStyle.HeaderStyle.Height = 4;
            dgvSach.ThemeStyle.ReadOnly = true;
            dgvSach.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvSach.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSach.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSach.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvSach.ThemeStyle.RowsStyle.Height = 33;
            dgvSach.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvSach.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // FormSach
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1569, 1050);
            Controls.Add(pnGridContainer);
            Controls.Add(pnCongCu);
            Controls.Add(pnHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            Name = "FormSach";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh Sách Sách - Thư Viện";
            WindowState = FormWindowState.Maximized;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnCongCu.ResumeLayout(false);
            pnGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel pnCongCu;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTheLoai;
        private Guna.UI2.WinForms.Guna2Panel pnGridContainer;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSach;
    }
}