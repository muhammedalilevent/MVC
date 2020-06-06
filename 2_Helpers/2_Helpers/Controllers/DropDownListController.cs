using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class DropDownListController : Controller
    {
        // GET: DropDownList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DropDownList(Sehirler item)
        {
            List<Sehirler> sehirler = new List<Sehirler>()
            {
                new Sehirler { ID = 1, SehirAdi = "İstanbul" },
                new Sehirler { ID = 2, SehirAdi = "Ankara" },
                new Sehirler { ID = 3, SehirAdi = "İzmir" },
                new Sehirler { ID = 4, SehirAdi = "EskiŞehir" }
            };
            SelectList list = new SelectList(sehirler.ToList(), "ID", "SehirAdi");
            ViewBag.Sehirler = list;
            return View();
        }

        public ActionResult DropDownListFor()
        {
            List<Sehirler> sehirler = new List<Sehirler>()
            {
                new Sehirler { ID = 1, SehirAdi = "İstanbul" },
                new Sehirler { ID = 2, SehirAdi = "Ankara" },
                new Sehirler { ID = 3, SehirAdi = "Malatya" },
                new Sehirler { ID = 4, SehirAdi = "EskiŞehir" }
            };

            Personel p = new Personel();
            p.Id = 1;
            p.Ad = "Bilal";
            p.SoyAd = "YILMAZ";
            p.Departman = "YAZILIM";
            p.DogumTarihi = new DateTime(1982, 12, 05);
            p.Cinsiyet = true;
            p.SehirID = 3;

            SelectList list = new SelectList(sehirler.ToList(), "ID", "SehirAdi",3);
            ViewBag.Sehirler = list;

            return View(p);
        }
    }
}