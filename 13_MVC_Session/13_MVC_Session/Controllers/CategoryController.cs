using _13_MVC_Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_MVC_Session.Controllers
{
    public class CategoryController : Controller
    {
        Entities db;
        public CategoryController()
        {
            db = new Entities();
        }

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categoryList = db.Categories.ToList();
            return View(categoryList);
        }
    }
}