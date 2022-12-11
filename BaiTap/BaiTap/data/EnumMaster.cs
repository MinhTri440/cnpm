using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaiTap.data
{
    public class EnumMaster
    {
        
    }
    public  class Payment
    {
        public string Name { get; set; }
        public string Text { get; set; }
        List<Payment> payment;
        public static List<Payment> Payments = new List<Payment>()
        {
            new Payment
            {
                Name = "tructiep",
                Text = "Trực tiếp"
            },
            new Payment
            {
                Name = "the",
                Text = "Pay by card"
            },
            new Payment
            {
                Name = "momo",
                Text = "Pay by momo"
            }
        }; 
        public Payment GetPaymentByName(string name)
        {
            var payment = Payments.FirstOrDefault(p => p.Name == name || p.Text == name);
            return payment;
        }

    }
    public class StatusOrderExport
    {
        public int Name { get; set; }
        public string Text { get; set; }
        List<StatusOrderExport> payment;
        public static List<StatusOrderExport> OrderStatus = new List<StatusOrderExport>()
        {
            new StatusOrderExport
            {
                Name = 0,
                Text = "Chờ xử lí"
            },
            new StatusOrderExport
            {
                Name = 1,
                Text = "Đã được vận chuyển"
            },
            new StatusOrderExport
            {
                Name = 2,
                Text = "Đã bị hủy"
            }
        };
        public static StatusOrderExport GetOrderByName(int name,string text ="")
        {
            var status = new StatusOrderExport();
            if (name >= 0)
            {
                status = OrderStatus.FirstOrDefault(p => p.Name == name);
            }
            if (!string.IsNullOrEmpty(text))
            {
                status = OrderStatus.FirstOrDefault(p => p.Text == text);
            }
            
            return status;
        }

    }

}
