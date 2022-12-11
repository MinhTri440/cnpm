using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class ChuongTrinhQuanLy : Form
    {
        public ChuongTrinhQuanLy()
        {
            InitializeComponent();
            LoadIndexForm();
            //Application.Run(new Phong1());
        }

        private void tabQuanLiPhong_Click(object sender, EventArgs e)
        {
            Application.Run(new OrderExport());
        }
        public void LoadIndexForm()
        {
            Form frm = new Form();


            if (tabChuongTrinh.SelectedTab == tabChuongTrinh.TabPages["tabQuanLiPhieuNhap"])
            {
                frm = new OrderImport();
                FormatForm(frm);
                tabChuongTrinh.TabPages["tabQuanLiPhieuNhap"].Controls.Add(frm);
            }

            if (tabChuongTrinh.SelectedTab == tabChuongTrinh.TabPages["tabQuanLiChiTietPhieuNhap"])
            {
                frm = new OrderImportDetail();
                FormatForm(frm);
                tabChuongTrinh.TabPages["tabQuanLiChiTietPhieuNhap"].Controls.Add(frm);
            }
            if (tabChuongTrinh.SelectedTab == tabChuongTrinh.TabPages["tabPhieuXuat"])
            {
                frm = new OrderExport();
                FormatForm(frm);
                tabChuongTrinh.TabPages["tabPhieuXuat"].Controls.Add(frm);
            }
            if (tabChuongTrinh.SelectedTab == tabChuongTrinh.TabPages["tabChiTietPhieuXuat"])
            {
                frm = new OrderExportDetail();
                FormatForm(frm);
                tabChuongTrinh.TabPages["tabChiTietPhieuXuat"].Controls.Add(frm);
            }

            if (tabChuongTrinh.SelectedTab == tabChuongTrinh.TabPages["tabThongke"])
            {
                frm = new ThongKe();
                FormatForm(frm);
                tabChuongTrinh.TabPages["tabThongke"].Controls.Add(frm);
            }


        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIndexForm();


        }
        public void FormatForm(Form frm)
        {
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
        }
        private void OpenChildForm(Form childForm)
        {

        }
    }
}
