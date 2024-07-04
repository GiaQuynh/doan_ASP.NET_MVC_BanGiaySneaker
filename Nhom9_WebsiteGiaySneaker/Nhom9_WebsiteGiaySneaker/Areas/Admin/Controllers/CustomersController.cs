using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Admin/Customers/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        public ActionResult Customers(string search = "", string SortColumn = "MaKH", string IconClass = "fa-sort-asc", int page = 1)
        {
            List<KhachHang> sp = db.KhachHangs.Where(row => row.HoTen.Contains(search)).ToList();

            //
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "MaKH")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MaKH).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MaKH).ToList();
                }
            }
            //else if (SortColumn == "HoTen")
            //{
            //    if (IconClass == "fa-sort-asc")
            //    {
            //        sp = sp.OrderBy(row => row.HoTen).ToList();
            //    }
            //    else
            //    {
            //        sp = sp.OrderByDescending(row => row.HoTen).ToList();
            //    }
            //}
            //else if (SortColumn == "NgaySinh")
            //{
            //    if (IconClass == "fa-sort-asc")
            //    {
            //        sp = sp.OrderBy(row => row.NgaySinh).ToList();
            //    }
            //    else
            //    {
            //        sp = sp.OrderByDescending(row => row.NgaySinh).ToList();
            //    }
            //}
            //else if (SortColumn == "MauSac")
            //{
            //    if (IconClass == "fa-sort-asc")
            //    {
            //        sp = sp.OrderBy(row => row.MauSac).ToList();
            //    }
            //    else
            //    {
            //        sp = sp.OrderByDescending(row => row.MauSac).ToList();
            //    }
            //}
            //else
            //{
            //    if (IconClass == "fa-sort-asc")
            //    {
            //        sp = sp.OrderBy(row => row.MaBrand).ToList();
            //    }
            //    else
            //    {
            //        sp = sp.OrderByDescending(row => row.MaBrand).ToList();
            //    }
            //}

            //
            int NoOfRecordPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sp = sp.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(sp);

        }
        public ActionResult TaoKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoKhachHang(KhachHang sp)
        {
            if (ModelState.IsValid)
            {
                var lastProduct = db.KhachHangs.OrderByDescending(p => p.MaKH).FirstOrDefault();
                int newMaSP = (lastProduct != null) ? lastProduct.MaKH + 1 : 1;
                sp.MaKH = newMaSP;

                db.KhachHangs.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Customers", "Customers");
            }
            return View(sp);
        }

        public ActionResult SuaKhachHang(int id = 0)
        {
            KhachHang sp = db.KhachHangs.Single(d => d.MaKH == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(KhachHang sp)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Attach(sp);
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customers", "Customers");
            }
            return View(sp);
        }
        public ActionResult ChiTietKhachHang(int id)
        {
            KhachHang sp = db.KhachHangs.Single(row => row.MaKH == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult XoaKhachHang(int id)
        {
            KhachHang sp = db.KhachHangs.Single(d => d.MaKH == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost, ActionName("XoaKhachHang")]
        public ActionResult XoaKhachHangConfirm(int id)
        {
            KhachHang sp = db.KhachHangs.Single(d => d.MaKH == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Customers", "Customers");
        }
        public ActionResult SearchKhachHang(string txt)
        {
            var listSP = db.KhachHangs.Where(s => s.HoTen.Contains(txt)).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.TB = "This prpducts not found!";
            }
            return View(listSP);
        }
    }
}