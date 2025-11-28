namespace WinFormsfinal
{
    partial class LichSuMuon
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
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvLichSu = new Guna.UI2.WinForms.Guna2DataGridView();
            MaSach = new DataGridViewTextBoxColumn();
            TenSach = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            NgayMuon = new DataGridViewTextBoxColumn();
            NgayTraDuKien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            TienPhatTamTinh = new DataGridViewTextBoxColumn();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTongTienPhat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Navy;
            guna2HtmlLabel1.Location = new Point(17, 20);
            guna2HtmlLabel1.Margin = new Padding(4, 5, 4, 5);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(339, 73);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Lịch sử mượn";
            // 
            // dgvLichSu
            // 
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvLichSu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLichSu.ColumnHeadersHeight = 17;
            dgvLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLichSu.Columns.AddRange(new DataGridViewColumn[] { MaSach, TenSach, SoLuong, NgayMuon, NgayTraDuKien, TrangThai, TienPhatTamTinh });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLichSu.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLichSu.GridColor = Color.FromArgb(231, 229, 255);
            dgvLichSu.Location = new Point(17, 112);
            dgvLichSu.Margin = new Padding(4, 5, 4, 5);
            dgvLichSu.Name = "dgvLichSu";
            dgvLichSu.ReadOnly = true;
            dgvLichSu.RowHeadersVisible = false;
            dgvLichSu.RowHeadersWidth = 62;
            dgvLichSu.RowTemplate.Height = 25;
            dgvLichSu.Size = new Size(1903, 578);
            dgvLichSu.TabIndex = 1;
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvLichSu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvLichSu.ThemeStyle.BackColor = Color.White;
            dgvLichSu.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvLichSu.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvLichSu.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLichSu.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvLichSu.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvLichSu.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLichSu.ThemeStyle.HeaderStyle.Height = 17;
            dgvLichSu.ThemeStyle.ReadOnly = true;
            dgvLichSu.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvLichSu.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLichSu.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLichSu.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvLichSu.ThemeStyle.RowsStyle.Height = 25;
            dgvLichSu.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvLichSu.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // MaSach
            // 
            MaSach.DataPropertyName = "MaSach";
            MaSach.HeaderText = "Mã Sách";
            MaSach.MinimumWidth = 8;
            MaSach.Name = "MaSach";
            MaSach.ReadOnly = true;
            // 
            // TenSach
            // 
            TenSach.DataPropertyName = "TenSach";
            TenSach.HeaderText = "Tên Sách";
            TenSach.MinimumWidth = 8;
            TenSach.Name = "TenSach";
            TenSach.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 8;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // NgayMuon
            // 
            NgayMuon.DataPropertyName = "NgayMuon";
            NgayMuon.HeaderText = "Ngày Mượn";
            NgayMuon.MinimumWidth = 8;
            NgayMuon.Name = "NgayMuon";
            NgayMuon.ReadOnly = true;
            // 
            // NgayTraDuKien
            // 
            NgayTraDuKien.DataPropertyName = "NgayDuKien";
            NgayTraDuKien.HeaderText = "Ngày Trả Dự Kiến";
            NgayTraDuKien.MinimumWidth = 8;
            NgayTraDuKien.Name = "NgayTraDuKien";
            NgayTraDuKien.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 8;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // TienPhatTamTinh
            // 
            TienPhatTamTinh.DataPropertyName = "TienPhatTamTinh";
            TienPhatTamTinh.HeaderText = "Tiền Phạt";
            TienPhatTamTinh.MinimumWidth = 8;
            TienPhatTamTinh.Name = "TienPhatTamTinh";
            TienPhatTamTinh.ReadOnly = true;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(1040, 700);
            guna2HtmlLabel2.Margin = new Padding(4, 5, 4, 5);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(374, 50);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Tổng tiền phạt phải trả:";
            // 
            // lblTongTienPhat
            // 
            lblTongTienPhat.BackColor = Color.Transparent;
            lblTongTienPhat.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTienPhat.Location = new Point(1451, 700);
            lblTongTienPhat.Margin = new Padding(4, 5, 4, 5);
            lblTongTienPhat.Name = "lblTongTienPhat";
            lblTongTienPhat.Size = new Size(43, 50);
            lblTongTienPhat.TabIndex = 3;
            lblTongTienPhat.Text = "0đ";
            // 
            // LichSuMuon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1924, 1050);
            Controls.Add(lblTongTienPhat);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(dgvLichSu);
            Controls.Add(guna2HtmlLabel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LichSuMuon";
            Text = "LichSuMuon";
            Load += LichSuMuon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLichSu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTienPhat;
        private DataGridViewTextBoxColumn MaSach;
        private DataGridViewTextBoxColumn TenSach;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn NgayMuon;
        private DataGridViewTextBoxColumn NgayTraDuKien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn TienPhatTamTinh;
    }
}