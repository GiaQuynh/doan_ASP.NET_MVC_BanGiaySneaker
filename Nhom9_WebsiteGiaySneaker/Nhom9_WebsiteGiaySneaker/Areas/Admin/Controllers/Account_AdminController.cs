using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class Account_AdminController : Controller
    {
        //
        // GET: /Admin/Account_Admin/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /Products/
        public ActionResult NhanVien(string search = "", string SortColumn = "MaKH", string IconClass = "fa-sort-asc", int page = 1)
        {
            List<NhanVien> sp = db.NhanViens.Where(row => row.HoTenNV.Contains(search)).ToList();

            //
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "MaNV")
            {
                if (IconClass == "fa-sort-asc")
                {
                    sp = sp.OrderBy(row => row.MaNV).ToList();
                }
                else
                {
                    sp = sp.OrderByDescending(row => row.MaNV).ToList();
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
        public ActionResult TaoNhanVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoNhanVien(NhanVien sp)
        {
            if (ModelState.IsValid)
            {
                var lastProduct = db.NhanViens.OrderByDescending(p => p.MaNV).FirstOrDefault();
                int newMaSP = (lastProduct != null) ? lastProduct.MaNV + 1 : 1;
                sp.MaNV = newMaSP;

                db.NhanViens.Add(sp);
                db.SaveChanges();
                return RedirectToAction("NhanVien", "Account_Admin");
            }
            return View(sp);
        }

        public ActionResult SuaNhanVien(int id = 0)
        {
            NhanVien sp = db.NhanViens.Single(d => d.MaNV == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaNhanVien(NhanVien sp)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Attach(sp);
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NhanVien", "Account_Admin");
            }
            return View(sp);
        }
        public ActionResult ChiTietNhanVien(int id)
        {
            NhanVien sp = db.NhanViens.Single(row => row.MaNV == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult XoaNhanVien(int id)
        {
            NhanVien sp = db.NhanViens.Single(d => d.MaNV == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost, ActionName("XoaNhanVien")]
        public ActionResult XoaNhanVienConfirm(int id)
        {
            NhanVien sp = db.NhanViens.Single(d => d.MaNV == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("NhanVien", "Account_Admin");
        }
        public ActionResult SearchNhanVien(string txt)
        {
            var listSP = db.NhanViens.Where(s => s.HoTenNV.Contains(txt)).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.TB = "This prpducts not found!";
            }
            return View(listSP);
        }
        
        
        public ActionResult ProfileNV(int id)
        {
            var user = db.NhanViens.Single(u => u.MaNV == id);

            return View(user);
        }
        public ActionResult EditProfile(int id)
        {
            var user = db.NhanViens.Single(u => u.MaNV == id);

            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(NhanVien kh)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Attach(kh);
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfileNV", "Account_Admin");
            }
            return View(kh);
        }

        [HttpPost]
        public ActionResult LoginAD(DangNhap dn)
        {
            var khachhang = db.KhachHangs.FirstOrDefault(u => u.TaiKhoan == dn.TaiKhoan && u.MatKhau == dn.MatKhau);
            var admin = db.NhanViens.FirstOrDefault(a => a.TaiKhoanNV == dn.TaiKhoan && a.MatKhauNV == dn.MatKhau);
            // Kiểm tra thông tin đăng nhập
            if (khachhang != null)
            {
                Session["user"] = khachhang;
                // Đăng nhập thành công, chuyển hướng đến trang "Index"
                return RedirectToAction("Index", "Home");
            }
            else if (admin != null)
            {
                Session["user"] = admin;
                // Đăng nhập thành công, chuyển hướng đến trang "Index"
                return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
            }
            else
            {
                // Sai thông tin đăng nhập, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("LoginAD");
            }
        }

        public ActionResult LogoutAD()
        {
            // Xóa session hoặc đặt giá trị session thành null để đăng xuất người dùng
            Session["user"] = null;

            // Chuyển hướng người dùng đến trang đăng nhập
            return RedirectToAction("LoginAD", "Account_Admin");
        }
    }
}