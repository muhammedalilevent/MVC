using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YedinciKullanim(int id)
        {
            return View();
        }
        public ActionResult RouteValueDictionary(int? categoryID, int? urunID)
        {
            return View("Index");
        }
    }
}