using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap.data
{
    public class OrderImportDetailModel
    {
        public int Id { get; set; }
        public string MaPhieu { get; set; }
        public int OrderImportId { get; set; }
        public int ProductId { get; set; }
        public string MaSanPham { get; set; }
        public int Total { get; set; }
        public string Note { get; set; }
        public decimal Price { get; set; }
        public DateTime? NgayNhap { get; set; }
    }
    public class OrderImportDetailExportModel
    {
        public string STT { get; set; }
        public string CodeOrder { get; set; }
        public string MaNV { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreateDatedStr { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
        public List<ProductModel>  Products { get; set; }
    }


}
