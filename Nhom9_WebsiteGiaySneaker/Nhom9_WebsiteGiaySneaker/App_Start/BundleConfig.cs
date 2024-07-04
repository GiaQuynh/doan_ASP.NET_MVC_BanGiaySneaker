using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Nhom9_WebsiteGiaySneaker.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Định nghĩa bundle CSS
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Assets/css/open-iconic-bootstrap.min.css"));

            // Định nghĩa bundle JavaScript
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
        }
    }
}