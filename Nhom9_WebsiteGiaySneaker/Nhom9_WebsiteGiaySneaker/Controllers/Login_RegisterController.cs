using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Controllers
{
    public class Login_RegisterController : Controller
    {
        //
        // GET: /Login_Register/
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        // GET: Login_Register
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // Lấy mã khách hàng mới từ cơ sở dữ liệu (tự động tăng)
                var newMaKH = db.KhachHangs.Max(kh => kh.MaKH) + 1;

                // Tạo một đối tượng User từ UserModel
                var newUser = new KhachHang
                {
                    MaKH = newMaKH,
                    HoTen = user.HoTen,
                    NgaySinh = user.NgaySinh,
                    GioiTinh = user.GioiTinh,
                    DienThoai = user.DienThoai,
                    TaiKhoan = user.TaiKhoan,
                    MatKhau = user.MatKhau,
                    Email = user.Email,
                    DiaChi = user.DiaChi
                };

                // Lưu đối tượng User vào cơ sở dữ liệu
                db.KhachHangs.Add(newUser);
                db.SaveChanges();

                ViewBag.NameUser = user.HoTen; // Set the username in ViewBag

                return RedirectToAction("Login");
            }

            return View(user);
        }
        [HttpPost]
        public ActionResult Login(DangNhap dn)
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
                return View("Login");
            }
        }

        //private bool IsValidLogin(DangNhap dn)
        //{
        //    // Kiểm tra thông tin đăng nhập trong cơ sở dữ liệu
        //    var user = db.KhachHangs.FirstOrDefault(u => u.TaiKhoan == dn.TaiKhoan && u.MatKhau == dn.MatKhau);
        //    return (user != null);
        //}

        public ActionResult Profile(int id)
        {
            var user = db.KhachHangs.Single(u => u.MaKH == id);

            return View(user);
        }
        public ActionResult EditProfile(int id)
        {
            var user = db.KhachHangs.Single(u => u.MaKH == id);

            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Attach(kh);
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Checkout", "GioHang");
            }
            return View(kh);
        }
        public ActionResult Logout()
        {
            // Xóa session hoặc đặt giá trị session thành null để đăng xuất người dùng
            Session["user"] = null;

            // Chuyển hướng người dùng đến trang đăng nhập
            return RedirectToAction("Login");
        }
    }
}