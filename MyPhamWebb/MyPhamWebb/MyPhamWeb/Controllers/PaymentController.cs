using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyPhamWeb.Context;
using MyPhamWeb.Models;

namespace MyPhamWeb.Controllers
{
    public class PaymentController : Controller
    {
        MyPhamEntities objWebMobileEntities = new MyPhamEntities();
        // GET: Payment
        public ActionResult Index()
        {
            var listOr = objWebMobileEntities.Orders.ToList();

            var model = from a in objWebMobileEntities.Orders
                        join c in objWebMobileEntities.OrderDetails on a.ID equals c.OrderID
                        join b in objWebMobileEntities.Products on c.ProductID equals b.id
                        select new OrderView
                        {
                            Order = a,
                            orderDetail = c,
                            Product = b,
                        };
            ViewBag.Orderview = model.ToList();

            return View(listOr);
        }
    }
}