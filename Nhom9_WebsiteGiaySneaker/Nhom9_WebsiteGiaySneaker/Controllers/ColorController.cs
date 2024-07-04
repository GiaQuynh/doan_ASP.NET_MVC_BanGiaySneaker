using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Controllers
{
    public class ColorController : Controller
    {
        //
        // GET: /Brand/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        public ActionResult ColorPartial()
        {
            var listB = db.SanPhams.ToList();
            return View(listB);
        }
	}
}