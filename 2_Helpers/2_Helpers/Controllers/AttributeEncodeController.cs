using _2_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helpers.Controllers
{
    public class AttributeEncodeController : Controller
    {
        // GET: AttributeEncode
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AttributeEncode()
        {
            Personel p = new Personel();
            p.Ad = "Şerif Çarık Öğretmen Evi";
            return View(p);
        }

    }
}