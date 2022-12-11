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
    public partial class OrderImport : Form
    {
        SqlConnection con = new SqlConnection(ConfigData.ConnectString);
        public OrderImport()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
      
        private void Phong_Load(object sender, EventArgs e)
        {
            LoadFormcustom();
            LoadDataCombobox();
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;

            //var _cmbTinhTrang = new List<CmbTinhTrang>() {
            //    new CmbTinhTrang(){Name="Da cho thue",Text="Có khách"},
            //    new CmbTinhTrang(){Name="Chua cho thue",Text="Trống"},
            //};
            //cmbNhanVien.DataSource = _cmbTinhTrang;
            //cmbNhanVien.DisplayMember = "Text";
            //cmbNhanVien.ValueMember = "Name";
        }
        public void LoadDataCombobox()
        {
            string query = "select MaNV, Name from Staff";
            con.Open();
            SqlCommand da = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            SqlDataReader myReader = da.ExecuteReader();
            dt.Load(myReader);

            cmbNhanVien.DisplayMember = "Name";
            cmbNhanVien.ValueMember = "MaNV";
            cmbNhanVien.DataSource = dt;
            con.Close();
        }
        public void LoadFormcustom()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select od.Id as Id, CodeOrder,od.MaNV as MaNV,CreateDated,Total,Note,Name,ImportLocation from OrderImport od left join Staff st on od.MaNV = st.MaNV", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvPhong.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvPhong.Rows.Add();
                dgvPhong.Rows[n].Cells[0].Value = dr["Id"].ToString();
                dgvPhong.Rows[n].Cells[1].Value = dr["CodeOrder"].ToString();
                dgvPhong.Rows[n].Cells[2].Value = dr["MaNV"].ToString();
                dgvPhong.Rows[n].Cells[3].Value = dr["Name"].ToString();
                dgvPhong.Rows[n].Cells[4].Value = dr["CreateDated"].ToString();
                dgvPhong.Rows[n].Cells[5].Value = dr["ImportLocation"].ToString();
                dgvPhong.Rows[n].Cells[6].Value = dr["Note"].ToString();
            }
        }
        
        public PhieuModel GetValue()
        {
            var model = new PhieuModel();
            model.MaPhieu = txsMaPhieu.Text;
            model.ImportLocation = txtDiaDiemKho.Text;
            model.UserName = cmbNhanVien.SelectedValue.ToString();
            model.NgayNhap = datetimpiceNgayNhapKho.Value;
            model.Note = txtNote.Text;
            return model;
        }
        public void SetValue(PhieuModel model)
        {
            txsMaPhieu.Text = model.MaPhieu;
            txtDiaDiemKho.Text = model.ImportLocation;
            cmbNhanVien.SelectedValue = model.UserName;
        }
        public void SetValueNull()
        {
            txsMaPhieu.Text = "";
            txtNote.Text = "";
            cmbNhanVien.SelectedItem = "";
            txtDiaDiemKho.Text = "";
        }
        public string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[2], elements[1], elements[0]);
            return dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {                
                var model = GetValue();               
                if (ExistMaKH(model.MaPhieu))
                {
                    MessageBox.Show("Mã phiếu " + model.MaPhieu + " đã tồn tại vui lòng nhập mã khác");
                }
                else
                {
                    if (model.NgayNhap.HasValue && model.NgayNhap.Value != null)
                    {
                        string dateStr = ConvertDateTime(model.NgayNhap.Value.ToString().Split(' ')[0]).Replace('/', '-');
                        model.NgayNhapStr = dateStr;                       
                    }

                    var qry = "insert into OrderImport(CodeOrder,MaNV,CreateDated,Total,Note,ImportLocation) values('" + model.MaPhieu + "','" + model.UserName + "','" + model.NgayNhapStr + "'," + model.Total + ",N'" + model.Note + "',N'" + model.ImportLocation + "')";
                    SqlCommand sc = new SqlCommand(qry, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Thêm mới " + model.MaPhieu + " thành công.");
                        LoadFormcustom();
                        SetValueNull();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới " + model.MaPhieu + " không thành công.");
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
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
            string query = "";
            if (!string.IsNullOrEmpty(maP))
            {
                query = "select * from OrderImport where CodeOrder = @maP";
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
                if (model.NgayNhap.HasValue && model.NgayNhap.Value != null)
                {
                    string dateStr = ConvertDateTime(model.NgayNhap.Value.ToString().Split(' ')[0]).Replace('/', '-');
                    model.NgayNhapStr = dateStr;
                }
                String qry = "update OrderImport set Total=" + model.Total + ",Note=N'"+model.Note+ "', ImportLocation=N'" + model.ImportLocation+ "', CreateDated='" + model.NgayNhapStr + "'  where CodeOrder='" + model.MaPhieu + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Cập nhật thành công " + model.MaPhieu + " thành công.");
                    LoadFormcustom();
                    SetValueNull();
                }
                else
                {
                    MessageBox.Show("Cập nhật " + model.MaPhieu + " không thành công.");
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
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn mã phòng "+ txsMaPhieu.Text.ToString() + " xóa?","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                string map = txsMaPhieu.Text.ToString();
                string qry = "delete from OrderImport where CodeOrder='" + map + "'";
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
            txsMaPhieu.ReadOnly = true;
            foreach (DataGridViewCell cell in dgvPhong.SelectedCells)
            {
                //cell.RowIndex

                if (dgvPhong.Rows[cell.RowIndex].Cells["CodeOrder"].Value != null)
                {
                    txsMaPhieu.Text = dgvPhong.Rows[cell.RowIndex].Cells["CodeOrder"].Value.ToString();
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells["MaNV"].Value != null)
                {
                    cmbNhanVien.SelectedValue = dgvPhong.Rows[cell.RowIndex].Cells["MaNV"].Value.ToString();                   
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells["tdDiaDiemNhapKho"].Value != null)
                {
                    txtDiaDiemKho.Text = dgvPhong.Rows[cell.RowIndex].Cells["tdDiaDiemNhapKho"].Value.ToString();
                }
                if (dgvPhong.Rows[cell.RowIndex].Cells["Note"].Value != null)
                {
                    txtNote.Text = dgvPhong.Rows[cell.RowIndex].Cells["Note"].Value.ToString();
                }
                cmbNhanVien.Show();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txsMaPhieu.ReadOnly = false;
            SetValueNull();
        }
    }
}
