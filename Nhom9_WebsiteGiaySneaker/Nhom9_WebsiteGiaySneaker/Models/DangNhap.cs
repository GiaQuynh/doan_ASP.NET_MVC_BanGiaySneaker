using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Nhom9_WebsiteGiaySneaker.Models
{
    public class DangNhap
    {
        [Required(ErrorMessage = "Vui lòng nhập tài khoản. *")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu. *")]
        public string MatKhau { get; set; }
    }
}