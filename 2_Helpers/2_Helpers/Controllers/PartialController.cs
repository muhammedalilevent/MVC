using _2_Helpers.Models;
using _2_Helpers.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial()
        {
            Category cat = new Category()
            {
                CategoryID = 1,
                CategoryName = "Beverages",
                Description = "",
                Picture = null
            };
            //List<MenuVM> menuList = new List<MenuVM>()
            //{
            //    new MenuVM {ID = 1 , MenuAdi = "AnaSayfa", MenuLink = "/Anasayfa" },
            //    new MenuVM {ID = 2 , MenuAdi = "Hakkımızda", MenuLink = "/hakkimizda"  },
            //    new MenuVM {ID = 3 , MenuAdi = "İletişim", MenuLink = "/iletisim"  },
            //    new MenuVM {ID = 4 , MenuAdi = "Hizmetler", MenuLink = "/hizmetler"  },
            //};
            //ViewBag.Menu = menuList;
            return View(cat);
        }

        public PartialViewResult _Partial()
        {
            return PartialView();
        }

        public ActionResult Menu()
        {
            List<MenuVM> menuList = new List<MenuVM>()
            {
                new MenuVM {ID = 1 , MenuAdi = "AnaSayfa", MenuLink = "/Anasayfa" },
                new MenuVM {ID = 2 , MenuAdi = "Hakkımızda", MenuLink = "/hakkimizda"  },
                new MenuVM {ID = 3 , MenuAdi = "İletişim", MenuLink = "/iletisim"  },
                new MenuVM {ID = 4 , MenuAdi = "Hizmetler", MenuLink = "/hizmetler"  },
            };
            return View("~/Views/Deneme/_Menu.cshtml", menuList.ToList());
        }
    }
}