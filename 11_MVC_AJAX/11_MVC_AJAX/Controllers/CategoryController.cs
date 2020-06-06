using _11_MVC_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _11_MVC_AJAX.Controllers
{
    public class CategoryController : Controller
    {
        Entities db;
        public CategoryController()
        {
            db = new Entities();
        }
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Category cat = new Category();
            return View(cat);
        }
        [HttpPost]
        public JsonResult Create(Category category)
        {
            Thread.Sleep(3000);
            JsonResultModel jr = new JsonResultModel();
            if (category.CategoryName == null)
            {
                jr.IsSuccess = false;
                jr.UserMessage = "Kategori Adı Boş Geçilemez";
            }
            else
            {
                try
                {
                    db.Categories.Add(category);
                    db.SaveChanges();

                    jr.IsSuccess = true;
                    jr.UserMessage = "Kategori Başarıyla Eklendi";
                }
                catch (Exception)
                {
                    jr.IsSuccess = false;
                    jr.UserMessage = "Kayıt İşlemi Hatalı";
                }
            }
            return Json(jr,JsonRequestBehavior.AllowGet);
        }
    }
}