using MyPhamWeb.Context;
using MyPhamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MyPhamWeb.Context;
using MyPhamWeb.Models;
using System.Web.Razor.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace MyPhamWeb.Controllers
{
    public class CartController : Controller
    {
        MyPhamEntities myPhamEntities = new MyPhamEntities();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }

            else
            {
                var cart = Session[CartSession];
                var list = new List<CartModel>();
                ViewBag.Cart = Total();
                if (cart != null)
                {
                    list = (List<CartModel>)cart;
                }
                return View(list);
            }


        }

        public ActionResult AddItem(int productID, int quantity)
        {
            if (Session["UserName"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }

            var product = myPhamEntities.Products.FirstOrDefault(s => s.id == productID);

            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(x => x.Product.id == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.id == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // create new object
                    var item = new CartModel();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

                Session[CartSession] = list;

            }
            else
            {
                // create new object
                var item = new CartModel();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartModel>();
                list.Add(item);

                // assign to session
                Session[CartSession] = list;
            }


            return RedirectToAction("Index");



        }
        public ActionResult UpdateCart(FormCollection form)
        {
            var cart = Session[CartSession];
            var list = (List<CartModel>)cart;

            int id = int.Parse(form["id"]);
            int quan = int.Parse(form["quantity"]);
            foreach (var item in list)
            {
                if (item.Product.id == id)
                {
                    item.Quantity = quan;
                }
            }
            Session[CartSession] = list;
            return RedirectToAction("Index");

        }
        public ActionResult DeleteCart(int ProductID)
        {
            var cart = Session[CartSession];
            var list = (List<CartModel>)cart;
            foreach (var item in list)
            {
                if (item.Product.id == ProductID)
                {
                    list.Remove(item);
                    break;
                }
            }
            Session[CartSession] = list;
            return RedirectToAction("Index");

        }
        public double Total()
        {
            var cart = Session[CartSession];
            var list = (List<CartModel>)cart;
            double total = 0;
            if (Session["role"] != null && Session["Username"] != null)
            {
                if (Session["role"].ToString().Equals("1"))
                {
                    if (list == null)
                    {
                        total = 0;
                        return total;

                    }

                    foreach (var item in list)
                    {
                        double quan = item.Quantity;
                        var price = item.Product.pricefordistributors.GetValueOrDefault();
                        total = total + quan * price;

                    }
                }
                else
                {
                    if (list == null)
                    {
                        total = 0;
                        return total;

                    }

                    foreach (var item in list)
                    {
                        double quan = item.Quantity;
                        var price = item.Product.price.GetValueOrDefault();
                        total = total + quan * price;

                    }
                }
            }

            return total;
        }

        public ActionResult AddOrderToDatabase()
        {
            if (Session["UserName"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            string pay = TempData["mydata"] as string;

            var cart = Session[CartSession];
            var list = new List<CartModel>();

            var listAccount = myPhamEntities.Accounts.ToList();

            list = (List<CartModel>)cart;
            Order objOrder = new Order();
            objOrder.Name = "Order-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            objOrder.CreateDate = DateTime.Now;
            objOrder.Status = 0;
            objOrder.Username = Session["UserName"].ToString();
            objOrder.StatusPayment = "Kiểm tra thanh toán";
            objOrder.TypePaymet = pay;

            foreach (var item in listAccount)
            {
                if (item.username.Equals(objOrder.Username))
                {
                    objOrder.Address = item.address2.ToString();
                    objOrder.Phone = item.phone2.ToString();
                    break;
                }
            }

            myPhamEntities.Orders.Add(objOrder);
            myPhamEntities.SaveChanges();



            int orderID = objOrder.ID;
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();

            // calculate total order
            float totalOrder = 0.0f;

            foreach (var item in list)
            {
                OrderDetail orDetail = new OrderDetail();
                orDetail.Quantity = item.Quantity;
                orDetail.OrderID = orderID;
                orDetail.ProductID = item.Product.id;
                if (Session["role"] != null && Session["Username"] != null)
                {
                    if (Session["role"].ToString().Equals("1"))
                    {
                        orDetail.Price = (decimal?)item.Product.pricefordistributors * item.Quantity;
                        totalOrder += (float)orDetail.Price;
                    }
                    else
                    {
                        orDetail.Price = (decimal?)item.Product.price * item.Quantity;
                        totalOrder += (float)orDetail.Price;
                    }

                    listOrderDetail.Add(orDetail);
                }
            }
           

            myPhamEntities.OrderDetails.AddRange(listOrderDetail);

            var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID == orderID);
            setTotalOrder.Total = totalOrder;   // update total price of order in database 
            // save data in order and detail order of database

            myPhamEntities.SaveChanges();
            int sum = (int)totalOrder * 25000 * 100;
            TempData["total"] = sum.ToString();
            TempData["orderID"] = orderID.ToString();
            if (setTotalOrder.TypePaymet.Equals("tructiep"))
            {
                Session[CartSession] = null;
                return RedirectToAction("Index", "Payment");
            }

            else if (setTotalOrder.TypePaymet.Equals("the"))
            {
                return RedirectToAction("Payment");
            }

            else
            {
                return RedirectToAction("PaymentMoMo");
            }
        }


        public ActionResult clearCart()
        {
            Session[CartSession] = null;
            return RedirectToAction("Index", "Payment");
        }
        public ActionResult Check()
        {
            var list = myPhamEntities.Accounts.ToList();
            string a = Session["UserName"].ToString();
            foreach (var item in list)
            {
                if (item.username.Equals(a))
                {
                    ViewBag.check = item.phone.ToString();
                    ViewBag.check2 = item.address.ToString();
                    break;
                }
            }
            return View();
        }
        public ActionResult ConfirmCheck(FormCollection form)
        {
            string phone = form["inputphone"];
            string address = form["inputadd"];
            string payment = form["payment"];
            string name = Session["UserName"].ToString();
            var list = myPhamEntities.Accounts.ToList();
            foreach (var item in list)
            {
                if (item.username.Equals(name))
                {

                    item.phone2 = phone;
                    item.address2 = address;

                    break;
                }
            }
           myPhamEntities.SaveChanges();
            TempData["mydata"] = payment;

            return RedirectToAction("AddOrderToDatabase");
        }
        public ActionResult Payment()
        {
            string total = TempData["total"] as string;
            string url = ConfigurationManager.AppSettings["Url"];
            string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

            PayLib pay = new PayLib();

            pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
            pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
            pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
            pay.AddRequestData("vnp_Amount", total); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
            pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
            pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
            pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
            pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            return Redirect(paymentUrl);
        }
        public ActionResult PaymentConfirm()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"]; //Chuỗi bí mật
                var vnpayData = Request.QueryString;
                PayLib pay = new PayLib();

                //lấy toàn bộ dữ liệu được trả về
                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }

                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                TempData["orderIDnew"]=orderId.ToString();
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; //hash của dữ liệu trả về
                TempData["statusThanhtoan"] = vnp_ResponseCode;
                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?
                TempData["chuki"] = checkSignature.ToString();
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {


                        //Thanh toán thành công
                        ViewBag.Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;
                        
                    }
                    else
                    {
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                    }
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View();
        }
        public ActionResult SavePaymentVnpay()
        {
            string statusThanhToan = TempData["statusThanhtoan"] as string;
            string chuki = TempData["chuki"] as string;
            if (chuki.Equals("true"))
            {
                if (statusThanhToan.Equals("00"))
                {
                    string orderID = TempData["orderID"] as string;
                    string TenHoaDon = TempData["orderIDnew"] as string;
                    var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                    setTotalOrder.Name = TenHoaDon;
                    myPhamEntities.SaveChanges();
                }
                else
                {
                    string orderID = TempData["orderID"] as string;
                    var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                    myPhamEntities.Orders.Remove(setTotalOrder);
                    myPhamEntities.SaveChanges();
                    //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode

                }
            }
            else
            {
                string orderID = TempData["orderID"] as string;
                var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                myPhamEntities.Orders.Remove(setTotalOrder);
                myPhamEntities.SaveChanges();
            }

            //cập nhật dữ liệu vào db

            return RedirectToAction("clearCart");

        }

        public ActionResult PaymentMoMo()
        {
            string total = TempData["total"] as string;
            int temp = Int32.Parse(total) / 100;
            string finaltotal=temp.ToString();   
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "test MOMO";
            string returnUrl = "https://localhost:44386/Cart/ConfirmPaymentClient";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = finaltotal;
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient(Result result)
        {
            //lấy kết quả Momo trả về và hiển thị thông báo cho người dùng (có thể lấy dữ liệu ở đây cập nhật xuống db)
            string rMessage = result.message;
            string rOrderId = result.orderId;
            string rErrorCode = result.errorCode; // = 0: thanh toán thành công
            TempData["statusThanhtoanMoMo"] = rErrorCode;
            TempData["rOrderId"] = rOrderId;
            if (rErrorCode.Equals("0"))
                {
                ViewBag.MessageMoMo = "Thanh toán thành công hóa đơn. | Mã giao dịch: " + rOrderId;


            }
            else
            {
                ViewBag.MessageMoMo = "Thanh toán không thành công hóa đơn.";
            }
            return View();
        }
        public ActionResult SavePaymentMoMo()
        {
            string statusThanhToan = TempData["statusThanhtoanMoMo"] as string;
            string chuki = TempData["rOrderId"] as string;
            if (chuki.Equals("true"))
            {
                if (statusThanhToan.Equals("00"))
                {
                    string orderID = TempData["orderID"] as string;
                    string rOrderID = TempData["rOrderID"] as string;
                    var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                    setTotalOrder.Name = orderID;
                    myPhamEntities.SaveChanges();
                }
                else
                {
                    string orderID = TempData["orderID"] as string;
                    var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                    myPhamEntities.Orders.Remove(setTotalOrder);
                    myPhamEntities.SaveChanges();
                    //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode

                }
            }
            else
            {
                string orderID = TempData["orderID"] as string;
                var setTotalOrder = myPhamEntities.Orders.FirstOrDefault(s => s.ID.ToString().Equals(orderID));
                myPhamEntities.Orders.Remove(setTotalOrder);
                myPhamEntities.SaveChanges();
            }

            //cập nhật dữ liệu vào db

            return RedirectToAction("clearCart");

        }






    }

}