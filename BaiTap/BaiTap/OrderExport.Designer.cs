
namespace BaiTap
{
    partial class OrderExport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.namephuongthucthanhtoan = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDaiLy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txsMaPhieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuXuat = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTinhTrangThanhToan = new System.Windows.Forms.ComboBox();
            this.datetimpiceNgayTao = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTongSanPham = new System.Windows.Forms.TextBox();
            this.tdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTenDaiLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTongSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdPhuongThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.datetimpiceNgayTao);
            this.groupBox1.Controls.Add(this.txtTongSanPham);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTinhTrangThanhToan);
            this.groupBox1.Controls.Add(this.cmbPuongThucThanhToan);
            this.groupBox1.Controls.Add(this.cmbTinhTrang);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.namephuongthucthanhtoan);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTenDaiLy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txsMaPhieu);
            this.groupBox1.Location = new System.Drawing.Point(131, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu xuất";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbPuongThucThanhToan
            // 
            this.cmbPuongThucThanhToan.FormattingEnabled = true;
            this.cmbPuongThucThanhToan.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cmbPuongThucThanhToan.Location = new System.Drawing.Point(646, 30);
            this.cmbPuongThucThanhToan.Name = "cmbPuongThucThanhToan";
            this.cmbPuongThucThanhToan.Size = new System.Drawing.Size(143, 21);
            this.cmbPuongThucThanhToan.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(560, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Tình Trạng";
            // 
            // cmbTinhTrang
            // 
            this.cmbTinhTrang.FormattingEnabled = true;
            this.cmbTinhTrang.Items.AddRange(new object[] {
            "Đang tạo",
            "Đang vẩn chuyển",
            "Thành công",
            "Trả lại",
            "Hủy đơn hàng"});
            this.cmbTinhTrang.Location = new System.Drawing.Point(646, 97);
            this.cmbTinhTrang.Name = "cmbTinhTrang";
            this.cmbTinhTrang.Size = new System.Drawing.Size(143, 21);
            this.cmbTinhTrang.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ngày tạo";
            // 
            // namephuongthucthanhtoan
            // 
            this.namephuongthucthanhtoan.AutoSize = true;
            this.namephuongthucthanhtoan.Location = new System.Drawing.Point(494, 35);
            this.namephuongthucthanhtoan.Name = "namephuongthucthanhtoan";
            this.namephuongthucthanhtoan.Size = new System.Drawing.Size(134, 13);
            this.namephuongthucthanhtoan.TabIndex = 27;
            this.namephuongthucthanhtoan.Text = "Phương Thức Thanh Toán";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Địa Chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(337, 100);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(118, 20);
            this.txtAddress.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Số Điện Thoại";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(106, 98);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(117, 20);
            this.txtPhone.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên khách";
            // 
            // txtTenDaiLy
            // 
            this.txtTenDaiLy.Location = new System.Drawing.Point(107, 64);
            this.txtTenDaiLy.Name = "txtTenDaiLy";
            this.txtTenDaiLy.Size = new System.Drawing.Size(117, 20);
            this.txtTenDaiLy.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên phiếu";
            // 
            // txsMaPhieu
            // 
            this.txsMaPhieu.Location = new System.Drawing.Point(107, 28);
            this.txsMaPhieu.Name = "txsMaPhieu";
            this.txsMaPhieu.Size = new System.Drawing.Size(117, 20);
            this.txsMaPhieu.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tổng sản phẩm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(206, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 57);
            this.panel1.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(403, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 42);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(519, 7);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 42);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(280, 7);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(156, 7);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(38, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Nhập";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPhieuXuat);
            this.groupBox2.Location = new System.Drawing.Point(12, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phiếu xuất";
            // 
            // dgvPhieuXuat
            // 
            this.dgvPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdId,
            this.tdMaPhieu,
            this.tdUserName,
            this.tdTenDaiLy,
            this.tdPhone,
            this.tdDiaChi,
            this.tdTongSanPham,
            this.tdNgayTao,
            this.tdPhuongThucThanhToan,
            this.tdPaymentStatus,
            this.tdTinhTrang});
            this.dgvPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuXuat.Location = new System.Drawing.Point(3, 16);
            this.dgvPhieuXuat.Name = "dgvPhieuXuat";
            this.dgvPhieuXuat.RowHeadersWidth = 51;
            this.dgvPhieuXuat.Size = new System.Drawing.Size(898, 236);
            this.dgvPhieuXuat.TabIndex = 16;
            this.dgvPhieuXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(441, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Phiếu Xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Tình Trạng Thanh Toán";
            // 
            // cmbTinhTrangThanhToan
            // 
            this.cmbTinhTrangThanhToan.FormattingEnabled = true;
            this.cmbTinhTrangThanhToan.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Kiểm tra thanh toán"});
            this.cmbTinhTrangThanhToan.Location = new System.Drawing.Point(646, 63);
            this.cmbTinhTrangThanhToan.Name = "cmbTinhTrangThanhToan";
            this.cmbTinhTrangThanhToan.Size = new System.Drawing.Size(143, 21);
            this.cmbTinhTrangThanhToan.TabIndex = 30;
            // 
            // datetimpiceNgayTao
            // 
            this.datetimpiceNgayTao.CustomFormat = "dd/MM/yyyy";
            this.datetimpiceNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimpiceNgayTao.Location = new System.Drawing.Point(337, 28);
            this.datetimpiceNgayTao.Margin = new System.Windows.Forms.Padding(2);
            this.datetimpiceNgayTao.Name = "datetimpiceNgayTao";
            this.datetimpiceNgayTao.Size = new System.Drawing.Size(118, 20);
            this.datetimpiceNgayTao.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tổng sản phẩm";
            // 
            // txtTongSanPham
            // 
            this.txtTongSanPham.Location = new System.Drawing.Point(338, 67);
            this.txtTongSanPham.Name = "txtTongSanPham";
            this.txtTongSanPham.Size = new System.Drawing.Size(117, 20);
            this.txtTongSanPham.TabIndex = 24;
            // 
            // tdId
            // 
            this.tdId.HeaderText = "Id";
            this.tdId.MinimumWidth = 6;
            this.tdId.Name = "tdId";
            this.tdId.Width = 40;
            // 
            // tdMaPhieu
            // 
            this.tdMaPhieu.HeaderText = "Tên phiếu";
            this.tdMaPhieu.MinimumWidth = 6;
            this.tdMaPhieu.Name = "tdMaPhieu";
            this.tdMaPhieu.Width = 120;
            // 
            // tdUserName
            // 
            this.tdUserName.HeaderText = "User Name";
            this.tdUserName.MinimumWidth = 6;
            this.tdUserName.Name = "tdUserName";
            this.tdUserName.Width = 90;
            // 
            // tdTenDaiLy
            // 
            this.tdTenDaiLy.HeaderText = "Tên khách";
            this.tdTenDaiLy.MinimumWidth = 6;
            this.tdTenDaiLy.Name = "tdTenDaiLy";
            this.tdTenDaiLy.Width = 125;
            // 
            // tdPhone
            // 
            this.tdPhone.HeaderText = "Số Điện Thoại";
            this.tdPhone.MinimumWidth = 6;
            this.tdPhone.Name = "tdPhone";
            // 
            // tdDiaChi
            // 
            this.tdDiaChi.HeaderText = "Địa Chỉ";
            this.tdDiaChi.MinimumWidth = 6;
            this.tdDiaChi.Name = "tdDiaChi";
            this.tdDiaChi.Width = 125;
            // 
            // tdTongSanPham
            // 
            this.tdTongSanPham.HeaderText = "Tổng sản phẩm";
            this.tdTongSanPham.Name = "tdTongSanPham";
            this.tdTongSanPham.Width = 80;
            // 
            // tdNgayTao
            // 
            this.tdNgayTao.HeaderText = "Ngày Tạo";
            this.tdNgayTao.Name = "tdNgayTao";
            // 
            // tdPhuongThucThanhToan
            // 
            this.tdPhuongThucThanhToan.HeaderText = "Phương Thức Thanh Toán";
            this.tdPhuongThucThanhToan.MinimumWidth = 6;
            this.tdPhuongThucThanhToan.Name = "tdPhuongThucThanhToan";
            // 
            // tdPaymentStatus
            // 
            this.tdPaymentStatus.HeaderText = "Tình trạng thanh toán";
            this.tdPaymentStatus.Name = "tdPaymentStatus";
            // 
            // tdTinhTrang
            // 
            this.tdTinhTrang.HeaderText = "Tình Trạng";
            this.tdTinhTrang.MinimumWidth = 6;
            this.tdTinhTrang.Name = "tdTinhTrang";
            // 
            // OrderExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 667);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "OrderExport";
            this.Text = "Phiếu nhập";
            this.Load += new System.EventHandler(this.OrderExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txsMaPhieu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTinhTrang;
        private System.Windows.Forms.Label namephuongthucthanhtoan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDaiLy;
        private System.Windows.Forms.ComboBox cmbPuongThucThanhToan;
        private System.Windows.Forms.DataGridView dgvPhieuXuat;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdMaNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTinhTrangThanhToan;
        private System.Windows.Forms.DateTimePicker datetimpiceNgayTao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTongSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdMaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTenDaiLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTongSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdPhuongThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTinhTrang;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Sem;
    }
}