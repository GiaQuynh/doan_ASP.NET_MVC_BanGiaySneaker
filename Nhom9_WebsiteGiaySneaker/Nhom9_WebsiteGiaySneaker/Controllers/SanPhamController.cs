using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Controllers
{
    public class SanPhamController : Controller
    {
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        //public ActionResult SanPham(string search = "")
        //{
        //    List<SanPham> sp = db.SanPhams.Where(row => row.TenSP.Contains(search)).ToList();
        //    return View(sp);
        //}
        //public ActionResult TaoSanPham()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult TaoSanPham(SanPham sp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SanPhams.Add(sp);
        //        db.SaveChanges();
        //        return RedirectToAction("SanPham", "SanPham");
        //    }
        //    return View(sp);
        //}
        //public ActionResult SuaSanPham(int id = 0)
        //{
        //    SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
        //    if (sp == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sp);
        //}
        //[HttpPost]
        //public ActionResult SuaSanPham(SanPham sp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SanPhams.Attach(sp);
        //        db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("SanPham", "SanPham");
        //    }
        //    return View(sp);
        //}
        //public ActionResult ChiTietSanPham(int id)
        //{
        //    SanPham sp = db.SanPhams.Single(row => row.MaSP == id);
        //    if (sp == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sp);
        //}
        //public ActionResult XoaSanPham(int id)
        //{
        //    SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
        //    if (sp == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sp);
        //}
        //[HttpPost, ActionName("XoaSanPham")]
        //public ActionResult XoaSanPhamConfirm(int id)
        //{
        //    SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
        //    if (sp == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("SanPham");
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SanPhamView(int page = 1, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = db.SanPhams.AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan <= maxPrice.Value);
            }

            var listSP = query.ToList();
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(listSP.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            listSP = listSP.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(listSP);
        }
        public ActionResult SanPhamPartial()
        {
            var listSP = db.SanPhams.Take(8).ToList();
            return View(listSP);
        }
        public ActionResult ChiTietSanPhamView(int id)
        {
            SanPham sp = db.SanPhams.Single(masp => masp.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult SanPhamTheoBrand(int maB, int page = 1, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = db.SanPhams.Where(s => s.MaBrand == maB);

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan <= maxPrice.Value);
            }

            var sp = query.ToList();

            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(sp);
        }
        public ActionResult SanPhamTheoMau(string mau, int page = 1, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = db.SanPhams.Where(s => s.MauSac == mau);

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan <= maxPrice.Value);
            }

            var sp = query.ToList();
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sp);
        }
        public ActionResult Search(string txt_sach)
        {
            var listSach = db.SanPhams.Where(s => s.TenSP.Contains(txt_sach)).ToList();
            if (listSach.Count == 0)
            {
                ViewBag.TB = "This products not found!";
            }
            return View(listSach);
        }
        public ActionResult FilterByPrice(int page = 1, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = db.SanPhams.AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.GiaBan <= maxPrice.Value);
            }

            var listSP = query.ToList();

            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(listSP.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            listSP = listSP.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(listSP);
        }
    }
}