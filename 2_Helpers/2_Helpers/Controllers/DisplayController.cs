using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class DisplayController : Controller
    {
        Entities db = new Entities();
        // GET: Display
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            Category cat = db.Categories.Find(1);
            return View(cat);
        }
    }
}