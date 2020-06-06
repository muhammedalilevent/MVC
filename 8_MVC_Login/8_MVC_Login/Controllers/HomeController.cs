using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8_MVC_Login.Controllers
{
    //otomatik olarak kullnıcının login olduğunu kontrol eder.
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Kullanıcının bilgisini oku
            ViewBag.CurrentUser = User.Identity.Name;
            return View();
        }
    }
}