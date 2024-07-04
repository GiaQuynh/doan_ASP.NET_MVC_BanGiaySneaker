using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Controllers
{
    public class GioHangController : Controller
    {
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //
        // GET: /GioHang/
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult AddGioHang(int ms, string URL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(sp => sp.iMaSP == ms);
            if (sanpham == null)
            {
                sanpham = new GioHang(ms);
                lstGioHang.Add(sanpham);
                Session["SLS"] = Sum();
                return Redirect(URL);
            }
            else
            {
                sanpham.iSoLuong++;
                Session["SLS"] = Sum();
                return Redirect(URL);
            }
        }

        private int Sum()
        {
            int s = 0;
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if (lstgiohang != null)
            {
                s = lstgiohang.Sum(sp => sp.iSoLuong);
            }
            return s;
        }
        private double ThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if (lstgiohang != null)
            {
                ttt += lstgiohang.Sum(sp => sp.iThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index1", "Home");
            }
            List<GioHang> lstgiohang = LayGioHang();


            Session["SLS"] = Sum();
            Session["TT"] = ThanhTien();

            ViewBag.TongSoLuong = Sum();
            ViewBag.TongThanhTien = ThanhTien();

            return View(lstgiohang);
        }
        public ActionResult GioHangPartial()
        {
            var list = this.Session["GioHang"];
            if (list == null)
            {
                return RedirectToAction("Index1", "Home");
            }

            Session["SLS"] = Sum();
            Session["TT"] = ThanhTien();

            ViewBag.TongSoLuong = Sum();
            ViewBag.TongThanhTien = ThanhTien();

            return View(list);
        }
        public ActionResult ProductRemove(int maSP)
        {
            var ListSP = LayGioHang();
            GioHang sp = ListSP.Single(s => s.iMaSP == maSP);
            ListSP.RemoveAll(s => s.iMaSP == maSP);
            Session["SLS"] = Sum();
            if (ListSP.Count == 0)
            {
                return RedirectToAction("Index1", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult ProductRemoveAll()
        {
            var listGioHang = LayGioHang();
            listGioHang.Clear();
            Session["SLS"] = 0;
            return RedirectToAction("Index1", "Home");
        }
        public ActionResult ProductUpdate(int MASP, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSP == MASP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtsoluong"].ToString());
                Session["SLS"] = 0;
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        //
        //public ActionResult Partial_Item_ThanhToan()
        //{
        //    GioHang cart = (GioHang)Session["Cart"];
        //    if (cart != null)
        //    {
        //        return PartialView(cart.iMaSP);

        //    }
        //    return PartialView();
        //}
        public ActionResult Checkout()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (Session["user"] == null)
            {
                // Chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Login_Register");
            }

            List<GioHang> lstgiohang = LayGioHang();
            ViewBag.TongSoLuong = Sum();
            ViewBag.TongThanhTien = ThanhTien();

            return View(lstgiohang);
        }
        public ActionResult ThanhToanThanhCong()
        {
            Session["SLS"] = null;
            Session["TT"] = null;
            return View();
        }

    }
}