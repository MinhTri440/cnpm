using BaiTap.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap.data
{
    public class OrderExportDetailModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string AgentName { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int OrderExportId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
  
}

public class OrderExportDetailPDFModel
{
    // hóa đơn xuất
    public string STT { get; set; }
    public string CodeOrder { get; set; }
    public string StatusPayment { get; set; }
    

    // nhân viên
    public string MaNV { get; set; }
    public string Name { get; set; }
    // thông tin đại lý
    public string AgentName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public decimal Total { get; set; }
    public string TypePayment { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string CreatedDateStr { get; set; }
    public string Note { get; set; }
    // thông tin sản phẩm
    public List<ProductModel> Products { get; set; }
}