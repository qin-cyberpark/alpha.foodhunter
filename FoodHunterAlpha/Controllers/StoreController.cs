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
    public class StoreController : Controller
    {
        #region map / home / menu
        public ActionResult Home(string nameId)
        {
            ViewBag.PageName = "StoreHome";
            ViewBag.Store = Store.Get(nameId);
            if (ViewBag.Store == null)
            {
                return Redirect("/");
            }
            var lastStore = new HttpCookie("LastVisitedStoreNameId", nameId);
            lastStore.Expires = DateTime.Today.AddDays(14);
            Response.Cookies.Set(lastStore);
            return View();
        }

        public ActionResult Menu(string nameId, string id)
        {
            ViewBag.PageName = "Menu";
            var store = Store.Get(nameId);
            if (store == null)
            {
                return Redirect("/");
            }
            ViewBag.Store = store;
            ViewBag.CategoryId = store.GetCategoryId(id);
            return View();
        }
        #endregion
    }
}