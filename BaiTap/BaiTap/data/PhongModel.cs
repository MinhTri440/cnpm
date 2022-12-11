using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap.data
{    
    public class PhieuModel
    {
        public int Id { get; set; }
        public string MaPhieu { get; set; }
        public string UserName { get; set; }
        public int Total { get; set; }
        public string Note { get; set; }
        public string NgayNhapStr { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string ImportLocation { get; set; }
    }   
}
