using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action(int id)
        {
            Category c = db.Categories.Find(id);
            return View(c);
        }
        Entities db = new Entities();
        public PartialViewResult _PartilAction(int id)
        {
            List<Product> list = db.Products.Where(x => x.CategoryID == id).ToList();
            return PartialView(list);
        }
    }
}