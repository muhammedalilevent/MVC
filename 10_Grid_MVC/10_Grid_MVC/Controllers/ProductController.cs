using _10_Grid_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _10_Grid_MVC.Controllers
{
    public class ProductController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            string filter = Request.QueryString["grid-filter"];
            string sort = Request.QueryString["grid-column"];
            string sortdir = Request.QueryString["grid-dir"];
            int page = Convert.ToInt32(Request.QueryString["grid-page"]);
            int pageSize = Convert.ToInt32(Request.QueryString["grid-pageSize"]);

            if (page == 0)
                page = 1;
            if (pageSize == 0)
                pageSize = 10;


            PagedList<Product> records = new PagedList<Product>();
            ViewBag.filter = filter;
            records.Content = db.Products
                .Where(x => filter == null ||
                (x.ProductName.Contains(filter)) ||
                (x.Category.CategoryName.Contains(filter)))
                //.OrderBy(x => GetPropertyValue(x,sort))
                //.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Count

            records.TotalRecords = db.Products
                 .Where(x => filter == null ||
                 (x.ProductName.Contains(filter)) ||
                 (x.Category.CategoryName.Contains(filter))).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            //List<Product> list = new List<Product>();
            //list = db.Products.ToList();

            return View(records);
        }
    }
}