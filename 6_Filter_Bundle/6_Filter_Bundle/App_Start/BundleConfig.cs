using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace _6_Filter_Bundle.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/modernizr-2.6.2.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}