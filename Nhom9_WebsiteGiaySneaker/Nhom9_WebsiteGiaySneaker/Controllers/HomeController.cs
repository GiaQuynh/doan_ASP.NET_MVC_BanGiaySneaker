using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Controllers
{
    public class HomeController : Controller
    {
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Home/
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
    }
}
