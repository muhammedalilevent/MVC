using _15_MVC_Cookie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _15_MVC_Cookie.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Cookies["login"] != null)
            {
                HttpCookie user = Request.Cookies["login"];
                UserVM vm = new UserVM();
                vm.UserName = user["UserName"];
                vm.Password = user["Password"];
                return View(vm);
            }
            else
            {
                UserVM vm = new UserVM();
                vm.UserName = "";
                vm.Password = "";
                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult Login(UserVM vm)
        {
            if (vm.Remember)
            {
                HttpCookie cerez = new HttpCookie("login");
                cerez.Values.Add("UserName", vm.UserName);
                cerez.Values.Add("Password", vm.Password);
                // Expires : Cookie istemci bilgisayar üzerinde ne kadar süre tutulacağını belirtir. Genellikle DateTime nesnesinin Add metotları kullanılır.
                cerez.Expires = DateTime.Now.AddDays(15);

                //Domain verimesi durumunda oluşturulan cookie sadece bu domain altında çalışacaktır.
                //cerez.Domain = "kurumsal.bilgeadam.com";

                //Path oluşturulması durumunda, oluşturulan cookie bu klasör içerisinde yer alacaktır
                //cerez.Path = "/Student";

                Response.Cookies.Add(cerez);
                return RedirectToAction("Index");

            }
            else
            {
                //Giriş Kontrolü yap
               return RedirectToAction("Index");
            }
        }

        public ActionResult ClearCookie()
        {
            if (Request.Cookies.AllKeys.Contains("login"))
            {
                HttpCookie cookie = Request.Cookies["login"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index");
        }

        public ActionResult LoginJQuery()
        {
            return View();
        }
    }
}