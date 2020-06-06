using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class RawController : Controller
    {
        // GET: Raw
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Raw()
        {
            Tasarim tasarim = new Tasarim();
            tasarim.Sayfa = "<div style='background-color:red;width:100px;height:100px'></div>";
            return View(tasarim);
        }
    }
}