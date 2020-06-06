using _6_Filter_Bundle.ActionFilters;
using _6_Filter_Bundle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_Filter_Bundle.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(bool? result)
        {
            if (result.HasValue)
            {
                if (result.Value == true)
                {
                    ViewBag.Result = new string[] { "TCNO Doğrulanmıştır", "alert alert-success" };
                }
                else
                {
                    ViewBag.Result = new string[] { "TCNO Doğrulanmamıştır", "alert alert-danger" };
                }
            }
            return View();
        }

        [HttpPost,CheckUser]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            return View();
        }
    }
}