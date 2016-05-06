using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunterAlpha.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Home(string nameId)
        {
            if ("columbus".Equals(nameId.ToLower()))
            {
                ViewBag.BrandNameId = "columbus";
            }
            else
            {
                return Redirect("/brands");
            }
            ViewBag.PageName = "BrandHome";
            return View();
        }

        public ActionResult Map(string nameId)
        {
            if (!"columbus".Equals(nameId.ToLower()))
            {
                return Redirect("/map");
            }
            ViewBag.BrandNameId = "columbus";
            ViewBag.PageName = "Map";
            return View();
        }
    }
}