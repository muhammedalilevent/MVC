using _14_MVC_Cache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace _14_MVC_Cache.Controllers
{
    public class CacheController : Controller
    {
        Entities db;
        public CacheController()
        {
            db = new Entities();
        }

        public ActionResult Index()
        {
            List<Category> categories;
            if (HttpContext.Cache["kategori"] == null)
            {
                categories = db.Categories.ToList();
                //HttpContext.Cache.Insert("kategori", categories);

                // Sliding Expiration => Onbellege atilan nesnenin otelemeli olarak yasamasini istiyorsaniz bu bitis tipini secebilirsiniz. TimeSpan tipinde sizden oteleme miktarini isteyecektir. Asagidaki ornekte ise, cache'in yasam suresi icerisinde bir istek gelmesi durumunda nesnenin omrunun 2 dakika daha uzatilmasi istenmistir!
                //HttpContext.Cache.Insert("kategori", categories, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(120));

                // Absolute Expiration => Kesin zamanli olarak bir Cache'in onbellekte ne zaman bozulacagini belirtirsiniz. Genellikle new DateTime() diyip yeni bir tarih uretmektense, o anki tarihe ekleme yapan DateTime'in Add metotlarini kullanabilirsiniz. Asagidaki ornekte bu tip kullanilmakla beraber, ne olursa olsun ilgili cache'in 2 dakika yasayacagi belirtilmistir...
                HttpContext.Cache.Insert("kategori", categories, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);

            }
            else
            {
                categories = HttpContext.Cache["kategori"] as List<Category>;
            }
            return View(categories);
        }
    }
}