using BaiTap.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Phong : Form
    {
        SqlConnection con = new SqlConnection("Data Source=G07VNXDFVLTTI15;Initial Catalog=MyPham;Integrated Security=True");
        public Phong()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
        private void Phong_Load(object sender, EventArgs e)
        {
            LoadFormcustom();
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;

            var _cmbTinhTrang = new List<CmbTinhTrang>() {
                new CmbTinhTrang(){Name="Da cho thue",Text="Có khách"},
                new CmbTinhTrang(){Name="Chua cho thue",Text="Trống"},
            };
            cmbTinhTrang.DataSource = _cmbTinhTrang;
            cmbTinhTrang.DisplayMember = "Text";
            cmbTinhTrang.ValueMember = "Name";
        }
        public void LoadFormcustom()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from OrderImport", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvPhong.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                int n = dgvPhong.Rows.Add();
                dgvPhong.Rows[n].Cells[0].Value = dr[0].ToString();
                dgvPhong.Rows[n].Cells[1].Value = dr[1].ToString();
                dgvPhong.Rows[n].Cells[2].Value = dr[2].ToString();
                dgvPhong.Rows[n].Cells[3].Value = dr[3].ToString();

            }
        }

        public PhongModel GetValue()
        {
            var model = new PhongModel();
            model.MaPhong = txtPhong.Text;
            model.SoGiuong = Convert.ToInt32(txtGiuong.Text);
            model.DonGia = Convert.ToDecimal(txtDonGia.Text);
            model.TinhTrang = cmbTinhTrang.SelectedValue.ToString();           
            return model;
        }
        public void SetValue(PhongModel model)
        {
            txtPhong.Text = model.MaPhong;
            txtGiuong.Text = Convert.ToString(model.SoGiuong);
            txtDonGia.Text = Convert.ToString(model.DonGia);
            //cmbTinhTrang.SelectedValue = model.TinhTrang;
        }
        public void SetValueNull()
        {
            txtPhong.Text = "";
            txtGiuong.Text = "";
            txtDonGia.Text = "";
            cmbTinhTrang.SelectedItem = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                var model = GetValue();

                if (ExistMaKH(model.MaPhong))
                {
                    MessageBox.Show("Mã phòng " + model.MaPhong + " đã tồn tại vui lòng nhập mã khác");
                }
                else
                {
                    var qry = "insert into Phong values('" + model.MaPhong + "','" + model.SoGiuong + "'," + model.DonGia + ",'" + model.TinhTrang + "')";
                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Thêm mới " + model.MaPhong + " thành công.");
                        LoadFormcustom();
                        SetValueNull();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới " + model.MaPhong + " không thành công.");
                    }
                }

                          
                con.Close();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is  " + exp.ToString());

            }
        }

        private void dgvPhong_MouseClick(object sender, MouseEventArgs e)
        {

            //txtPhong.Text = dgvPhong.SelectedRows[0].Cells[0].Value.ToString();
            //txtGiuong.Text = dgvPhong.SelectedRows[0].Cells[1].Value.ToString();
            //txtDonGia.Text = dgvPhong.SelectedRows[0].Cells[2].Value.ToString();
            //var tinhtrang = dgvPhong.SelectedRows[0].Cells[3].Value.ToString();
            //if (tinhtrang == "chua cho thue")
            //{
            //cmbTinhTrang.SelectedItem = "Trống";
            //}
            //else
            //{
            //cmbTinhTrang.SelectedItem = "Đã có khách";
            //}
        }
        public bool ExistMaKH(string maP)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = ""; //"select * from Employee where maPhong = @maPhong";
            if (!string.IsNullOrEmpty(maP))
            {
                query = "select * from Phong where MaP = @maP";
            }
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.SelectCommand.Parameters.AddWithValue("@maP", maP);

            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            return false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var model = GetValue();
                String qry = "update Phong set MaP='" + model.MaPhong + "', SoGiuong=" + model.SoGiuong + ", DonGia=" + model.DonGia + ", TinhTrang='" + model.TinhTrang + "' where MaP='" + model.MaPhong + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Cập nhật thành công " + model.MaPhong + " thành công.");
                    LoadFormcustom();
                    SetValueNull();
                }
                else
                {
                    MessageBox.Show("Cập nhật " + model.MaPhong + " không thành công.");
                }                                                  
                con.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is  " + exp.ToString());

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn mã phòng "+ txtPhong.Text.ToString() + " xóa?","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                string map = txtPhong.Text.ToString();
                string qry = "delete from Phong where Map='" + map + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Xóa thành công " + map + " thành công.");
                    LoadFormcustom();
                    SetValueNull();
                }
                else
                {
                    MessageBox.Show("Xóa " + map + " không thành công.");
                }

                con.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát khỏi", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPhong.ReadOnly = true;
            foreach (DataGridViewCell cell in dgvPhong.SelectedCells)
            {
                //cell.RowIndex

                if (dgvPhong.Rows[cell.RowIndex].Cells[0].Value != null)
                {
                    txtPhong.Text = dgvPhong.Rows[cell.RowIndex].Cells[0].Value.ToString();
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells[1].Value != null)
                {
                    txtGiuong.Text = dgvPhong.Rows[cell.RowIndex].Cells[1].Value.ToString();
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells[2].Value != null)
                {
                    txtDonGia.Text = dgvPhong.Rows[cell.RowIndex].Cells[2].Value.ToString();
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells[3].Value != null)
                {
                    cmbTinhTrang.SelectedValue = dgvPhong.Rows[cell.RowIndex].Cells[3].Value.ToString();
                }
                
               
              
                //if (textCmb == "Chua cho thue")
                //{
                //    cmbTinhTrang.SelectedValue = 
                //}
                cmbTinhTrang.Show();

                //cmbMaPhong.SelectedValue = dgvPhong.Rows[cell.RowIndex].Cells[4].Value.ToString();
                //cmbMaPhong.Show();
            }
        }
    }
}
