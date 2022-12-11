using MyPhamWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamWeb.Context;


namespace MyPhamWeb.Models
{
    public class OrderView
    {
        public Order Order { get; set; }

        public Product Product { get; set; }
        public OrderDetail orderDetail { get; set; }


    }
}