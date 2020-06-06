using _8_MVC_Login.Models.Data.Context;
using _8_MVC_Login.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _8_MVC_Login.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                using (ProjectContext context = new ProjectContext())
                {
                    var user = context.User.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

                    if (user != null)
                    {
                        //cookie oluşturma işlemi webconfig'de 2880 saniyelik oturum olarak ayarlandı.
                        //false ise sessionda oluşturur.Browser kapanınca silinir.
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}