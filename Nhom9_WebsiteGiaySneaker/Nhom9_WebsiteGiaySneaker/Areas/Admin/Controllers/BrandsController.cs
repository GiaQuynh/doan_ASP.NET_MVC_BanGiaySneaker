using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        //
        // GET: /Brand/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        public ActionResult Brandd()
        {
            var listB = db.Brands.ToList();
            return View(listB);
        }
        public ActionResult BrandPartial()
        {
            var listB = db.Brands.ToList();
            return View(listB);
        }
        public ActionResult TaoBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoBrand(Brand b)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(b);
                db.SaveChanges();
                return RedirectToAction("Brand");
            }
            return View(b);
        }
        public ActionResult SuaBrand(int id = 0)
        {
            Brand b = db.Brands.Single(d => d.MaBrand == id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost]
        public ActionResult SuaBrand(Brand b)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Attach(b);
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Brand", "Brand");
            }
            return View(b);
        }
        public ActionResult ChiTietBrand(int id)
        {
            Brand b = db.Brands.Single(row => row.MaBrand == id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        public ActionResult XoaBrand(int id)
        {
            Brand sp = db.Brands.Single(d => d.MaBrand == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost, ActionName("XoaBrand")]
        public ActionResult XoaBrandConfirm(int id)
        {
            Brand sp = db.Brands.Single(d => d.MaBrand == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Brand");
        }
    }
}