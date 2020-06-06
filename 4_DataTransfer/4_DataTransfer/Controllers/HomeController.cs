using _4_DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        /*  
         VIEWDATA & VIEWBAG

         Küçük boyutlardaki verileri Controller dan view sayfasına taşınmasını sağlar.
         ViewData MVC 2 ile gelen bir özelliktir.
         ViewBag  MVC 3 ile gelen bir özellik ve Runtime sırasında oluşan  dinamik bir yapıdır.
         ViewData nesneside birden fazla farklı nesne ayırmasını ViewDataDictionary sınıfı aracılıyla, “key/value” syntax sayesinde çözüm sağlanmıştır.
         ViewBag kullanıldığı zaman complex li değerler için tip dönüşümüne gerek yoktur.
         ViewData, ViewDataDictionary classın türemiş string bir objedir.

         TEMPDATA

         Basit bir çalışma mantığına sahiptir.
         ViewBag ve ViewData ile aynı işi yapar.
         TempData yı ViewData ve ViewBag’ten ayıran en büyük özellik bir sonraki sayfaya taşınan verilerin daha sonradan tekrardan başka bir sayfa kullanılmak istenilmesi durumunda TempData bu işlemi başarılı bir şekilde gerçekleştirmektedir.
         Bir controllerdan, başka bir Controller’ a veri akışı sağlayabilir.
         TempDataDictionary classından türemiş string ve object olarak kullanılabilen bir yapıdır.
         Genellikle ekranda bir seferlik gösterilmesi sağlanan mesajlarda, hata mesajlarında ve validation(doğrulama) işlemlerinde kullanılabilir.
         */
        public ActionResult Index()
        {
            List<Kategori> Kategoriler = new List<Kategori>
            {
                new Kategori { ID = 1, KategoriAdi =  "Beverages" },
                new Kategori { ID = 2, KategoriAdi =  "Condiments" },
                new Kategori { ID = 3, KategoriAdi =  "Confections" },
                new Kategori { ID = 4, KategoriAdi =  "Dairy Products" },
                new Kategori { ID = 5, KategoriAdi =  "Grains/Cereals" }

            };
            ViewBag.KategoriListesi = Kategoriler;
            ViewData["KategoriListesi"] = Kategoriler;
            TempData["KategoriListesi"] = Kategoriler;
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
    }
}