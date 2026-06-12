namespace CSharp_68PM2_TranDinhKhanhDuy_0005668
{
    partial class UC_QLLH
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtGhiChu = new TextBox();
            label4 = new Label();
            txtTenLop = new TextBox();
            label3 = new Label();
            txtMaLop = new TextBox();
            label2 = new Label();
            txtMaID = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXemDSSV = new Button();
            labelTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvLopHoc = new DataGridView();
            colMaID = new DataGridViewTextBoxColumn();
            colMaLop = new DataGridViewTextBoxColumn();
            colTenLop = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();
            btnFirst = new Button();
            btnPrev = new Button();
            lblPhanTrang = new Label();
            btnNext = new Button();
            btnLast = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.BackColor = SystemColors.InactiveBorder;
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTenLop);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMaLop);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaID);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 479);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp học";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 9F);
            txtGhiChu.Location = new Point(16, 280);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(280, 27);
            txtGhiChu.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(16, 255);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 6;
            label4.Text = "Ghi chú:";
            // 
            // txtTenLop
            // 
            txtTenLop.Font = new Font("Segoe UI", 9F);
            txtTenLop.Location = new Point(16, 205);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(280, 27);
            txtTenLop.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(16, 180);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 4;
            label3.Text = "Tên lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Font = new Font("Segoe UI", 9F);
            txtMaLop.Location = new Point(16, 130);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(280, 27);
            txtMaLop.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(16, 105);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã lớp:";
            // 
            // txtMaID
            // 
            txtMaID.Font = new Font("Segoe UI", 9F);
            txtMaID.Location = new Point(16, 55);
            txtMaID.Name = "txtMaID";
            txtMaID.Size = new Size(280, 27);
            txtMaID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(16, 30);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã ID:";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(16, 509);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 45);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSua.BackColor = Color.FromArgb(46, 204, 113);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(186, 509);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 45);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(16, 569);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 45);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(186, 569);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 45);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXemDSSV
            // 
            btnXemDSSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXemDSSV.BackColor = Color.FromArgb(41, 128, 185);
            btnXemDSSV.FlatStyle = FlatStyle.Flat;
            btnXemDSSV.ForeColor = Color.White;
            btnXemDSSV.Location = new Point(16, 629);
            btnXemDSSV.Name = "btnXemDSSV";
            btnXemDSSV.Size = new Size(320, 45);
            btnXemDSSV.TabIndex = 5;
            btnXemDSSV.Text = "Xem danh sách sinh viên";
            btnXemDSSV.UseVisualStyleBackColor = false;
            // 
            // labelTimKiem
            // 
            labelTimKiem.AutoSize = true;
            labelTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTimKiem.Location = new Point(360, 25);
            labelTimKiem.Name = "labelTimKiem";
            labelTimKiem.Size = new Size(265, 20);
            labelTimKiem.TabIndex = 6;
            labelTimKiem.Text = "Tìm kiếm (Mã ID / Mã lớp / Tên lớp):";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(360, 55);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(250, 27);
            txtTimKiem.TabIndex = 7;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(52, 73, 94);
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(620, 50);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(100, 35);
            btnTim.TabIndex = 8;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLopHoc.BackgroundColor = Color.White;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Columns.AddRange(new DataGridViewColumn[] { colMaID, colMaLop, colTenLop, colGhiChu });
            dgvLopHoc.Location = new Point(360, 100);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.RowHeadersWidth = 51;
            dgvLopHoc.Size = new Size(932, 529);
            dgvLopHoc.TabIndex = 9;
            dgvLopHoc.CellContentClick += dgvLopHoc_CellContentClick;
            // 
            // colMaID
            // 
            colMaID.HeaderText = "Mã ID";
            colMaID.MinimumWidth = 6;
            colMaID.Name = "colMaID";
            colMaID.Width = 125;
            // 
            // colMaLop
            // 
            colMaLop.HeaderText = "Mã lớp";
            colMaLop.MinimumWidth = 6;
            colMaLop.Name = "colMaLop";
            colMaLop.Width = 125;
            // 
            // colTenLop
            // 
            colTenLop.HeaderText = "Tên lớp";
            colTenLop.MinimumWidth = 6;
            colTenLop.Name = "colTenLop";
            colTenLop.Width = 200;
            // 
            // colGhiChu
            // 
            colGhiChu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.MinimumWidth = 6;
            colGhiChu.Name = "colGhiChu";
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Bottom;
            btnFirst.Location = new Point(501, 644);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(50, 30);
            btnFirst.TabIndex = 10;
            btnFirst.Text = "<<";
            btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Bottom;
            btnPrev.Location = new Point(561, 644);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(50, 30);
            btnPrev.TabIndex = 11;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPhanTrang
            // 
            lblPhanTrang.Anchor = AnchorStyles.Bottom;
            lblPhanTrang.AutoSize = true;
            lblPhanTrang.Location = new Point(741, 649);
            lblPhanTrang.Name = "lblPhanTrang";
            lblPhanTrang.Size = new Size(146, 20);
            lblPhanTrang.TabIndex = 12;
            lblPhanTrang.Text = "Trang 1/1 | 2 bản ghi";
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom;
            btnNext.Location = new Point(1031, 644);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(50, 30);
            btnNext.TabIndex = 13;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Bottom;
            btnLast.Location = new Point(1091, 644);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(50, 30);
            btnLast.TabIndex = 14;
            btnLast.Text = ">>";
            btnLast.UseVisualStyleBackColor = true;
            // 
            // UC_QLLH
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(lblPhanTrang);
            Controls.Add(btnPrev);
            Controls.Add(btnFirst);
            Controls.Add(dgvLopHoc);
            Controls.Add(btnTim);
            Controls.Add(txtTimKiem);
            Controls.Add(labelTimKiem);
            Controls.Add(btnXemDSSV);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Name = "UC_QLLH";
            Size = new Size(1312, 699);
            Load += UC_QLLH_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemDSSV;
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPhanTrang;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
    }
}