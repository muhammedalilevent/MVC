using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class ActionLinkController : Controller
    {
        // GET: ActionLink
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActionDeneme(int id)
        {
            return View("Index");
        }

        public ActionResult RouteValueDictionary(int? categoryID , int? urunID)
        {
            return View("Index");
        }
    }
}