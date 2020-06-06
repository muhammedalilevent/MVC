using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _7_Route
{
    public class RouteConfig
    {
        /*
          1) {controller}/{action}/{id} => /Urunler/Detay/1
          2) {table}/Detay              => /Urunler/Detay
          3) Employee/{action}/{entry}  => /Urunler/Detay/1
          4) {reportType}/{year}/{month}/{day}   => /Sales/2018/6/24
          5) {locale}/{controller}/{action}/{id} => /tr/Urunler/Detay/1
          6) {language}-{country}/{controller}/{action}/{id} =>/tr-TR/Urunler/Detay/1
         */

        /*
         https://www.hepsiburada.com/samsung-galaxy-tab-3-lite-t113-8gb-7-beyaz-tablet-p-BD601324
         */
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Product",
                url: "{CategoryName}-{CategoryId}/{ProductName}-{ProductId}",
                defaults: new
                {
                    controller = "Product",
                    action = "Details",
                    CategoryName = UrlParameter.Optional,
                    CategoryId = UrlParameter.Optional,
                    ProductName = UrlParameter.Optional,
                    ProductId = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            

        }
    }
}
