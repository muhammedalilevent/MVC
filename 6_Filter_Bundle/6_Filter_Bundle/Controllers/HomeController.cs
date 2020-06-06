using _6_Filter_Bundle.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_Filter_Bundle.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [LoginFilter]
        public ActionResult About()
        {
            return View();
        }
    }
}