using _11_MVC_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _11_MVC_AJAX.Controllers
{
    public class ProductController : Controller
    {
        Entities db;
        public ProductController()
        {
            db = new Entities();
        }
        public ActionResult Index()
        {
            return View(db.Products.Take(5).ToList());
        }

        public PartialViewResult ProductDetail(int id)
        {
            Product pro = db.Products.Find(id);
            //Thread.Sleep(5000);
            return PartialView("_ProductDetail", pro);
        }
    }
}