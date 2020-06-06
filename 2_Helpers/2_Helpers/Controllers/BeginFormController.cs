using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class BeginFormController : Controller
    {
        // GET: BeginForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BeginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BeginForm(int id)
        {
            return View();
        }

        public ActionResult PostAction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostAction(int userid,string userName)
        {
            return View();
        }

        public ActionResult Rapor(int UserId, string UserName)
        {
            RaporVM r = new RaporVM();
            r.UserId = UserId;
            r.UserName = UserName; 
            return View(r);
        }
    }
}