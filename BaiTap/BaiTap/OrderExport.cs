using BaiTap.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class OrderExport : Form
    {
        SqlConnection con = new SqlConnection(ConfigData.ConnectString);
        public Dictionary<string, string> PayMentType = new Dictionary<string, string>();
        
        private int OrderExportId = 0;
        public OrderExport()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
      
        private void Phong_Load(object sender, EventArgs e)
        {
            //LoadFormcustom();
            //LoadDataCombobox();
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
        //public void LoadDataCombobox()
        //{
        //    string query = "select MaNV, Name from Staff";
        //    con.Open();
        //    SqlCommand da = new SqlCommand(query, con);
        //    DataTable dt = new DataTable();
           
        //    SqlDataReader myReader = da.ExecuteReader();
        //    dt.Load(myReader);
                      
        //    cmbNhanVien.DisplayMember = "Name";
        //    cmbNhanVien.ValueMember = "MaNV";
        //    cmbNhanVien.DataSource = dt;
        //    con.Close();
        //}
        public void LoadFormcustom()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }            
            SqlDataAdapter sda = new SqlDataAdapter("SELECT " +
               "OE.[Id] as Id, " +
               "OE.[CreateDate], " +              
               "OE.[name] AS OrderName ," +
               "OE.[UserName] AS UserName, " +
               "OE.[Address] AS Address, " +
               "OE.[Phone] AS Phone, " +
               "[Total] ," +
               "[TypePaymet] ," +
               "[Status], " +
               "[StatusPayment], " +
               "AC.[name] AS [Name]," +
               "AC.[username] AS [usernameCustomer] " +
               "FROM Orders OE " +
               "left join Accounts AC on OE.UserName = AC.username", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvPhieuXuat.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvPhieuXuat.Rows.Add();
                dgvPhieuXuat.Rows[n].Cells[0].Value = dr["Id"].ToString();
                dgvPhieuXuat.Rows[n].Cells[1].Value = dr["OrderName"].ToString();
                if (dr["UserName"] != null)
                {
                    string userName = Convert.ToString(dr["UserName"]);
                    if (!string.IsNullOrEmpty(userName))
                    {
                        var acount = GetAcountByUserName(userName);
                        if (acount != null && !string.IsNullOrEmpty(acount.Name) && !string.IsNullOrEmpty(acount.UserName))
                        {
                            dgvPhieuXuat.Rows[n].Cells[2].Value = acount.UserName;
                            dgvPhieuXuat.Rows[n].Cells[3].Value = acount.Name;
                        }
                    }
                }
                dgvPhieuXuat.Rows[n].Cells[3].Value = dr["UserName"].ToString();
                dgvPhieuXuat.Rows[n].Cells[4].Value = dr["Phone"].ToString();
                dgvPhieuXuat.Rows[n].Cells[5].Value = dr["Address"].ToString();
                dgvPhieuXuat.Rows[n].Cells[6].Value = dr["Total"].ToString();
                dgvPhieuXuat.Rows[n].Cells[7].Value = Convert.ToDateTime(dr["CreateDate"]).ToString("dd/MM/yyyy");
                //string statusstr = "";
                if (dr["TypePaymet"] != null && !string.IsNullOrEmpty(Convert.ToString(dr["TypePaymet"])))
                {
                    var payment = new Payment();
                    string typePaymet = Convert.ToString(dr["TypePaymet"]);

                    var  typePaymetStr = payment.GetPaymentByName(typePaymet);
                    dgvPhieuXuat.Rows[n].Cells[8].Value = typePaymetStr.Text;
                }
                dgvPhieuXuat.Rows[n].Cells[9].Value = dr["StatusPayment"].ToString();
                if (dr["Status"] != null && !string.IsNullOrEmpty(Convert.ToString(dr["Status"])))
                {
                    var statusOrderExport = new StatusOrderExport();
                    var statusServer = Convert.ToInt32(dr["Status"]);

                    var typePaymetStr = StatusOrderExport.GetOrderByName(statusServer);
                    dgvPhieuXuat.Rows[n].Cells[10].Value = typePaymetStr.Text;
                }
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        
        public OrderExportModel GetValue()
        {
            var model = new OrderExportModel();            
            model.Code = txsMaPhieu.Text;
            //model.UserName = cmbNhanVien.SelectedValue.ToString();
            model.UserName = txtTenDaiLy.Text;
            //model.AgentName = txtTenDaiLy.Text;
            model.Phone = txtPhone.Text;
            model.Address = txtAddress.Text;           
            model.TypePayment = cmbPuongThucThanhToan.SelectedValue.ToString();
            model.StatusTypePayment = cmbTinhTrangThanhToan.SelectedItem.ToString();
            model.Status = Convert.ToInt32(cmbTinhTrang.SelectedValue.ToString());
            model.CreatedDate = datetimpiceNgayTao.Value;
            //model.ExportDate = datetimpiceNgayXuat.Value;
            model.Total = (!string.IsNullOrEmpty(txtTongSanPham.Text) ? Convert.ToInt32(txtTongSanPham.Text):0);
            return model;
        }
        public void SetValue(OrderExportModel model)
        {
            txsMaPhieu.Text = model.Code;
           // cmbNhanVien.SelectedValue = model.UserName;
            txtTenDaiLy.Text = model.UserName;
            txtPhone.Text = model.Phone;
            txtAddress.Text = model.Address;
            cmbPuongThucThanhToan.SelectedItem = model.TypePayment;
            cmbTinhTrang.SelectedItem = model.Status;
        }
        public void SetValueNull()
        {
            txsMaPhieu.ReadOnly = false;
            txsMaPhieu.Text = "";
            txtTenDaiLy.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cmbPuongThucThanhToan.SelectedItem = "";
            cmbTinhTrang.SelectedItem = "";
            txtTongSanPham.Text = "";
            cmbTinhTrangThanhToan.Items.Clear();            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var model = GetValue();

                if (ExistMaKH(model.Code))
                {
                    MessageBox.Show("Mã phiếu " + model.Code + " đã tồn tại vui lòng nhập mã khác");
                }
                else
                {
                    //var acounts = GetAcountByUserName(model.UserName);
                    //if (acounts != null && !string.IsNullOrEmpty(acounts.UserName) && !string.IsNullOrEmpty(acounts.Name))
                    //{
                    //    model.UserName = acounts.UserName;
                    //}
                    if (model.CreatedDate.HasValue && model.CreatedDate.Value != null)
                    {
                        string dateStr = ConvertDateTime(model.CreatedDate.Value.ToString().Split(' ')[0]).Replace('/', '-');
                        model.CreatedDateStr = dateStr;
                        model.CreatedDate = DateTime.Parse(dateStr);
                    }
                    var qry = "Insert into Orders(Name," +
                        "UserName, " +
                        "CreateDate, " +
                        "Status," +
                        "Address, " +
                        "Phone, " +
                        "Total, " +
                        "TypePaymet, " +
                        //"ExportDate, " +
                        "StatusPayment) " +
                        "values('" + model.Code + "'," +
                        "N'" + model.UserName + "'," +
                        "'" + model.CreatedDateStr + "','" +
                        "" + model.Status + "'," +
                        "N'" + model.Address + "'," +
                        "'" + model.Phone + "'," +
                        "" + model.Total + "," +
                        "N'" + model.TypePayment + "'," +
                        //"'" + model.ExportDate + "'," +
                        "N'" + model.StatusTypePayment + "')";
                        
                    SqlCommand sc = new SqlCommand(qry, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Thêm mới " + model.Code + " thành công.");
                        LoadFormcustom();
                        SetValueNull();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới " + model.Code + " không thành công.");
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
                query = "select * from OrderExport where Code = @maP";
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
        public Accounts GetAcountByUserName(string userName)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "";
            if (!string.IsNullOrEmpty(userName))
            {
                query = "select * from Accounts where username = @maP";
            }
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.SelectCommand.Parameters.AddWithValue("@maP", userName);

            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                var acount = new Accounts();
                foreach (DataRow dr in data.Rows)
                {
                    acount.UserName = Convert.ToString(dr["username"]);
                    acount.Name = dr["name"].ToString();                   
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return acount;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return null;
        }





        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                var model = GetValue();
                if (model.CreatedDate.HasValue && model.CreatedDate.Value != null)
                {
                    string dateStr = ConvertDateTime(model.CreatedDate.Value.ToString().Split(' ')[0]).Replace('/', '-');
                    model.CreatedDateStr= dateStr;
                    model.CreatedDate = DateTime.Parse(dateStr);
                }
                String qry = "Update Orders set " +
                    "Name =N'" + model.Code + "'," +
                    "Username =N'" + model.UserName + "'," +
                    "Phone ='" +model.Phone+"', " +
                    "Address =N'"+model.Address+"', " +
                    "Total ="+model.Total+", " +
                    "TypePaymet =N'" + model.TypePayment+"', " +
                    "StatusPayment =N'" + model.StatusTypePayment + "', " +
                    "Status =" + model.Status+", " +
                    "CreateDate ='" + model.CreatedDateStr + "'" +
                    //"ExportDate ='" + model.ExportDate + "' " +
                    " Where ID=" + OrderExportId + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Cập nhật thành công " + model.Code + " thành công.");
                    LoadFormcustom();
                    SetValueNull();
                }
                else
                {
                    MessageBox.Show("Cập nhật " + model.Code + " không thành công.");
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                OrderExportId = 0;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is  " + exp.ToString());
                OrderExportId = 0;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn mã  "+ txsMaPhieu.Text.ToString() + " xóa?","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                string map = txsMaPhieu.Text.ToString();
                string qry = "delete from Orders where ID=" + OrderExportId;
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
                OrderExportId = 0;
                con.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            OrderExportId = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát khỏi", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public  string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[2], elements[1], elements[0]);
            return dt;
        }
        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txsMaPhieu.ReadOnly = true;
            foreach (DataGridViewCell cell in dgvPhieuXuat.SelectedCells)
            {
                //cell.RowIndex
               
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdId"].Value != null)
                {
                    string id = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdId"].Value.ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        OrderExportId = Convert.ToInt32(id);
                    }
                }

                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdMaPhieu"].Value != null)
                {
                    txsMaPhieu.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdMaPhieu"].Value.ToString();
                }
                //if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdUserName"].Value != null)
                //{
                //    cmbNhanVien.SelectedValue = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdUserName"].Value.ToString();
                //}               
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTenDaiLy"].Value != null)
                {
                    txtTenDaiLy.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTenDaiLy"].Value.ToString();
                }
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPhone"].Value != null)
                {
                    txtPhone.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPhone"].Value.ToString();
                }
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdDiaChi"].Value != null)
                {
                    txtAddress.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdDiaChi"].Value.ToString();                   
                }
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTongSanPham"].Value != null)
                {
                    txtTongSanPham.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTongSanPham"].Value.ToString();
                }
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdNgayTao"].Value != null)
                {
                    datetimpiceNgayTao.Value = Convert.ToDateTime(ConvertDateTime(dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdNgayTao"].Value.ToString()));
                }
                //if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdNgayXuat"].Value != null)
                //{
                //    datetimpiceNgayXuat.Value = Convert.ToDateTime(ConvertDateTime(dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdNgayXuat"].Value.ToString()));
                //}
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPhuongThucThanhToan"].Value != null)
                {
                    string phuongthucthanhtoanstr = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPhuongThucThanhToan"].Value.ToString();
                    var payment = new Payment();
                    var paymentOrder = payment.GetPaymentByName(phuongthucthanhtoanstr);

                    cmbPuongThucThanhToan.SelectedValue = paymentOrder.Name;
                }

                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPaymentStatus"].Value != null)
                {
                    cmbTinhTrangThanhToan.SelectedItem = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdPaymentStatus"].Value.ToString();
                }
                if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTinhTrang"].Value != null)
                {
                    string statusStr = dgvPhieuXuat.Rows[cell.RowIndex].Cells["tdTinhTrang"].Value.ToString();                    
                    var statusOrderExport = StatusOrderExport.GetOrderByName(-1,statusStr);
                    cmbTinhTrang.SelectedValue = statusOrderExport.Name;
                }
            }
        }
        public void LoadComboxPayMentType()
        {        
            cmbPuongThucThanhToan.DisplayMember = "Text";
            cmbPuongThucThanhToan.ValueMember = "Name";
            cmbPuongThucThanhToan.DataSource = Payment.Payments;
        }
        public void LoadComboxStatus()
        {
            cmbTinhTrang.DisplayMember = "Text";
            cmbTinhTrang.ValueMember = "Name";
            cmbTinhTrang.DataSource = StatusOrderExport.OrderStatus;
        }

        private void OrderExport_Load(object sender, EventArgs e)
        {
            LoadComboxPayMentType();
            LoadComboxStatus();
            LoadFormcustom();
           // LoadDataCombobox();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SetValueNull();
        }

        //private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txsMaPhieu.ReadOnly = true;
        //    foreach (DataGridViewCell cell in dgvPhieuXuat.SelectedCells)
        //    {
        //        //cell.RowIndex

        //        if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["CodeOrder"].Value != null)
        //        {
        //            txsMaPhieu.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["CodeOrder"].Value.ToString();
        //        }
        //        if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["MaNV"].Value != null)
        //        {
        //            cmbNhanVien.SelectedValue = dgvPhieuXuat.Rows[cell.RowIndex].Cells["MaNV"].Value.ToString();                   
        //        }
        //        if (dgvPhieuXuat.Rows[cell.RowIndex].Cells["Total"].Value != null)
        //        {
        //            txtTongSanPham.Text = dgvPhieuXuat.Rows[cell.RowIndex].Cells["Total"].Value.ToString();
        //        }
        //        cmbNhanVien.Show();
        //    }
        //}
    }
}
