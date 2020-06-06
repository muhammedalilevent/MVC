using _13_MVC_Session.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_MVC_Session.Controllers
{
    public class ProductController : Controller
    {
        Entities db;
        public ProductController()
        {
            db = new Entities();
        }

        public ActionResult Index(int? id, int page = 1)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            List<Product> productList = db.Products.Where(p => p.CategoryID == id).ToList();
            return View(productList.ToPagedList(page,10));
        }
    }
}