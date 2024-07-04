using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        public ActionResult SanPhamm(string search = "", string SortColumn = "MaSP", string IconClass = "fa-sort-asc", int page = 1)
        {
            List<SanPham> sp = db.SanPhams.Where(row => row.TenSP.Contains(search)).ToList();

            //
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "MaSP")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MaSP).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MaSP).ToList();
                }
            }
            else if (SortColumn == "TenSP")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.TenSP).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.TenSP).ToList();
                }
            }
            else if (SortColumn == "GiaBan")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.GiaBan).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.GiaBan).ToList();
                }
            }
            else if (SortColumn == "MauSac")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MauSac).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MauSac).ToList();
                }
            }
            else
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MaBrand).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MaBrand).ToList();
                }
            }

            //
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(sp);

        }
        public ActionResult TaoSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var lastProduct = db.SanPhams.OrderByDescending(p => p.MaSP).FirstOrDefault();
                int newMaSP = (lastProduct != null) ? lastProduct.MaSP + 1 : 1;
                sp.MaSP = newMaSP;

                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("SanPhamm", "Products");
            }
            return View(sp);
        }

        public ActionResult SuaSanPham(int id = 0)
        {
            SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Attach(sp);
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SanPhamm", "Products");
            }
            return View(sp);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SanPham sp = db.SanPhams.Single(row => row.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult XoaSanPham(int id)
        {
            SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XoaSanPhamConfirm(int id)
        {
            SanPham sp = db.SanPhams.Single(d => d.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("SanPhamm", "Products");
        }
        public ActionResult Search(string txt)
        {
            var listSP = db.SanPhams.Where(s => s.TenSP.Contains(txt)).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.TB = "This products not found!";
            }
            return View(listSP);
        }
    }
}