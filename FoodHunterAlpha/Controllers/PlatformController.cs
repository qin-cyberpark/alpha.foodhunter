using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHunterAlpha.Controllers
{
    public class PlatformController : Controller
    {
        // GET: Platform
        public ActionResult Home()
        {
            ViewBag.PageName = "PlatformHome";
            return View();
        }

        public ActionResult Map()
        {
            ViewBag.PageName = "PlatformHome";
            return View();
        }

        public ActionResult Brands()
        {
            ViewBag.PageName = "PlatformHome";
            return View();
        }

        public ActionResult Nearby()
        {
            ViewBag.PageName = "Nearby";
            return View();
        }
    }
}