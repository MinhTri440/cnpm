
namespace BaiTap
{
    partial class ThongKe
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
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.datetimpickeNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimpiceNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvThongTinThongKe = new System.Windows.Forms.DataGridView();
            this.tdSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTongSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdSoLuongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.datetimpickeNgayKetThuc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datetimpiceNgayBatDau);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(137, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thống kê";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(550, 18);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(94, 42);
            this.btnTimKiem.TabIndex = 36;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // datetimpickeNgayKetThuc
            // 
            this.datetimpickeNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.datetimpickeNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimpickeNgayKetThuc.Location = new System.Drawing.Point(359, 32);
            this.datetimpickeNgayKetThuc.Margin = new System.Windows.Forms.Padding(2);
            this.datetimpickeNgayKetThuc.Name = "datetimpickeNgayKetThuc";
            this.datetimpickeNgayKetThuc.Size = new System.Drawing.Size(118, 20);
            this.datetimpickeNgayKetThuc.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Ngày kết thúc";
            // 
            // datetimpiceNgayBatDau
            // 
            this.datetimpiceNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.datetimpiceNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimpiceNgayBatDau.Location = new System.Drawing.Point(105, 32);
            this.datetimpiceNgayBatDau.Margin = new System.Windows.Forms.Padding(2);
            this.datetimpiceNgayBatDau.Name = "datetimpiceNgayBatDau";
            this.datetimpiceNgayBatDau.Size = new System.Drawing.Size(118, 20);
            this.datetimpiceNgayBatDau.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Ngày bắt đầu";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Trống",
            "Có Khách"});
            this.comboBox1.Location = new System.Drawing.Point(423, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 21);
            this.comboBox1.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvThongTinThongKe);
            this.groupBox2.Location = new System.Drawing.Point(46, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 375);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvThongTinThongKe
            // 
            this.dgvThongTinThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTinThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdSTT,
            this.tdTenSanPham,
            this.tdDonGia,
            this.tdTongSanPham,
            this.tdSoLuongBan,
            this.tdThanhTien,
            this.tdNgayNhap,
            this.tdDiaChi});
            this.dgvThongTinThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongTinThongKe.Location = new System.Drawing.Point(3, 16);
            this.dgvThongTinThongKe.Name = "dgvThongTinThongKe";
            this.dgvThongTinThongKe.RowHeadersWidth = 51;
            this.dgvThongTinThongKe.Size = new System.Drawing.Size(872, 356);
            this.dgvThongTinThongKe.TabIndex = 16;
            // 
            // tdSTT
            // 
            this.tdSTT.HeaderText = "STT";
            this.tdSTT.MinimumWidth = 6;
            this.tdSTT.Name = "tdSTT";
            this.tdSTT.Width = 38;
            // 
            // tdTenSanPham
            // 
            this.tdTenSanPham.HeaderText = "Tên sản phẩm";
            this.tdTenSanPham.MinimumWidth = 6;
            this.tdTenSanPham.Name = "tdTenSanPham";
            this.tdTenSanPham.Width = 125;
            // 
            // tdDonGia
            // 
            this.tdDonGia.HeaderText = "Đơn giá";
            this.tdDonGia.MinimumWidth = 6;
            this.tdDonGia.Name = "tdDonGia";
            // 
            // tdTongSanPham
            // 
            this.tdTongSanPham.HeaderText = "Tổng sản phẩm";
            this.tdTongSanPham.MinimumWidth = 6;
            this.tdTongSanPham.Name = "tdTongSanPham";
            this.tdTongSanPham.Width = 130;
            // 
            // tdSoLuongBan
            // 
            this.tdSoLuongBan.HeaderText = "Số lượng bán";
            this.tdSoLuongBan.MinimumWidth = 6;
            this.tdSoLuongBan.Name = "tdSoLuongBan";
            // 
            // tdThanhTien
            // 
            this.tdThanhTien.HeaderText = "Thành tiền";
            this.tdThanhTien.MinimumWidth = 6;
            this.tdThanhTien.Name = "tdThanhTien";
            this.tdThanhTien.Width = 125;
            // 
            // tdNgayNhap
            // 
            this.tdNgayNhap.HeaderText = "Ngày nhập";
            this.tdNgayNhap.MinimumWidth = 6;
            this.tdNgayNhap.Name = "tdNgayNhap";
            // 
            // tdDiaChi
            // 
            this.tdDiaChi.HeaderText = "Ngày xuất";
            this.tdDiaChi.MinimumWidth = 6;
            this.tdDiaChi.Name = "tdDiaChi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(396, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Thống kê";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 667);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThongKe";
            this.Text = "Phiếu nhập";
            this.Load += new System.EventHandler(this.OrderExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvThongTinThongKe;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker datetimpiceNgayBatDau;
        private System.Windows.Forms.DateTimePicker datetimpickeNgayKetThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTongSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdSoLuongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdNgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDiaChi;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Sem;
    }
}