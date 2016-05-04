using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using FoodHunterAlpha.Models;
using FoodHunterAlpha.Printer;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FoodHunterAlpha.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.PageName = "Home";
            return View();
        }

        #region map / home / menu
        public ActionResult StoreHome(string name)
        {
            ViewBag.PageName = "Home";
            ViewBag.Store = Store.Get(name);
            var lastStore = new HttpCookie("LastVisitedStoreNameId", name);
            lastStore.Expires = DateTime.Today.AddDays(14);
            Response.Cookies.Set(lastStore);
            return View();
        }

        public ActionResult Map()
        {
            ViewBag.PageName = "Map";
            return View();
        }

        public ActionResult Menu(string name, string id)
        {
            ViewBag.PageName = "Menu";
            var store = Store.Get(name);
            ViewBag.Store = store;
            ViewBag.CategoryId = store.GetCategoryId(id);
            return View();
        }
        #endregion
        #region cart / checkout / pay
        // GET: Cart
        public ActionResult Cart()
        {
            ViewBag.PageName = "Cart";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.PageName = "Cart";
            return View();
        }

        [HttpPost]
        public ActionResult Pay()
        {
            //
            Order.OrderType ordType = "pick-up".Equals(Request["option_type"]) ? Order.OrderType.Pickup : Order.OrderType.DineIn;
            var tblNoOrMins = int.Parse(Request["option_value"]);
            var storeId = int.Parse(Request["store_id"]);
            var orderRawData = HttpUtility.UrlDecode(Request.Cookies["cart"].Value);

            //create order
            var order = new Order();
            order.SerialNo = Order.GetNextOrderSerialNo(storeId);
            order.Id = string.Format("{0:0000}{1:yyyyMMdd}{2:0000}", storeId, DateTime.Today, order.SerialNo);

            order.Type = ordType;
            if (order.Type == Order.OrderType.Pickup)
            {
                order.PickupTime = order.OrderTime.AddMinutes(tblNoOrMins);
            }
            else if (order.Type == Order.OrderType.DineIn)
            {
                order.TableNumber = tblNoOrMins;
            }
            order.CustomerId = Store.DefaultCustomerId;
            var store = Store.Get(storeId);
            order.Store = store;

            //item
            var cart = JsonConvert.DeserializeObject<ViewModels.CartVM>(orderRawData);
            foreach (var itm in cart.Items)
            {
                var nwItm = Store.GetItem(itm.Id);
                order.Items.Add(new OrderItem()
                {
                    Item = nwItm,
                    Quantity = itm.Quantity
                });
            }

            Order.Add(order);

            if (Request.Cookies["cart"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cart");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            if (bool.Parse(ConfigurationManager.AppSettings["PrintOrder"]))
            {
                Task.Run(() => { store.PrintOrder(order); });
            }

            //push order
            MessageCenter.LoadOrderQueue();


            return RedirectToAction("YourOrders");
        }
        #endregion

        #region account
        public ActionResult YourOrders()
        {
            ViewBag.PageName = "Account";
            ViewBag.Orders = FoodHunterAlpha.Models.Order.GetOrder();
            return View();
        }
        #endregion
    }
}