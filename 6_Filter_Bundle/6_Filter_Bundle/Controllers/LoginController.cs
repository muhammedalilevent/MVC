using _6_Filter_Bundle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_Filter_Bundle.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            if (user.UserName != null && user.Password != null)
            {
                HttpContext.Session.Add("login", user);
                return RedirectToAction("About", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}