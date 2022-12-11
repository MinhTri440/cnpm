using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap.data
{
    public class KhachHangModel
    {
        public string MaKh { get; set; }
        public string HoTen { get; set; }
        public string SoCMND { get; set; }
        public string MaPhong { get; set; }
        public int SoNgayO { get; set; }
        public decimal ThanhTien { get; set; }
    }
    public class Accounts
    {
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
