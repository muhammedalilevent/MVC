using _7_Route.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7_Route.Controllers
{
    public class ProductController : Controller
    {
        Entities db = new Entities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        
        public ActionResult Details(string CategoryName,int CategoryId, string ProductName, int ProductId)
        {
            Product pro = db.Products.Where(p => p.ProductID == ProductId).FirstOrDefault();
            return View(pro);
        }

        [Route("UrunDetay-{id}")]
        public ActionResult Detay(int id)
        {
            Product pro = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(pro);
        }

        [Route("{ProductName}-{id}")]
        public ActionResult SonDetay(int id)
        {
            Product pro = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(pro);
        }
    }
}