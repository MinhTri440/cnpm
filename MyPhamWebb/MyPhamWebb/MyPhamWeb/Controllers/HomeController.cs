using MyPhamWeb.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyPhamWeb.Context;

namespace MyPhamWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        MyPhamEntities myphamEntities = new MyPhamEntities();
        public ActionResult Index()
        {

            var listProduct = myphamEntities.Products.ToList();
            return View(listProduct);
        }


        public ActionResult SearchProduct(string searchString)
        {
            string searchStringnew = searchString.ToLower();

            var listProduct = myphamEntities.Products.ToList();

            List<Product> list = new List<Product>();
            foreach (var item in listProduct)
            {
                if (item.name.ToLower().Contains(searchString))
                {
                    list.Add(item);
                }
            }

            ViewBag.Drum = null;
            if (list.Count == 0)
            {
                ViewBag.Drum = "Không tìm thấy sản phẩm";
            }
            return View(list);
        }




        public ActionResult Detail(int productID)
        {
            var product = myphamEntities.Products.FirstOrDefault(s => s.id == productID);
            return View(product);
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}