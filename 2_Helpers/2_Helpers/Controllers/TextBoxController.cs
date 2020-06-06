using _2_Helpers.Models;
using _2_Helpers.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class TextBoxController : Controller
    {
        public ActionResult TextBox()
        {
            Personel p = new Personel();
            p.Id = 1;
            p.Ad = "Bilal";
            p.SoyAd = "YILMAZ";
            p.Departman = "YAZILIM";
            p.DogumTarihi = new DateTime(1982, 12, 05);
            p.Cinsiyet = true;

            Ogrenci ogr = new Ogrenci();
            ogr.ID = 1;

            Category cat = new Category();
            cat.CategoryID = 1;

            TextBoxVM vm = new TextBoxVM();
            vm.Personel = p;
            vm.Ogrenci = ogr;
            vm.Category = cat;
            return View(vm);
        }

        public ActionResult TextBoxFor()
        {
            Personel p = new Personel();
            p.Id = 1;
            p.Ad = "Bilal";
            p.SoyAd = "YILMAZ";
            p.Departman = "YAZILIM";
            p.DogumTarihi = new DateTime(1982, 12, 05);
            p.Cinsiyet = true;

            Ogrenci ogr = new Ogrenci();
            ogr.ID = 1;

            Category cat = new Category();
            cat.CategoryID = 1;

            TextBoxVM vm = new TextBoxVM();
            vm.Personel = p;
            vm.Ogrenci = ogr;
            vm.Category = cat;
            return View("TextBox_For",vm);
        }
    }
}