using _6_Filter_Bundle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_Filter_Bundle.ActionFilters
{
    public class CheckUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            TCKimlikSorgula.KPSPublicSoapClient service = new TCKimlikSorgula.KPSPublicSoapClient();

            User user = filterContext.ActionParameters["user"] as User;
            bool result = false;
            try
            {
                result = service.TCKimlikNoDogrula(
                    long.Parse(user.TCKN), 
                    user.FirstName.ToUpper(), 
                    user.LastName.ToUpper(), 
                    int.Parse(user.BirthYear));
            }
            catch
            {
                result = false;
            }
            filterContext.Result = new RedirectResult("/User/Create?result=" + result);
        }
    }
}