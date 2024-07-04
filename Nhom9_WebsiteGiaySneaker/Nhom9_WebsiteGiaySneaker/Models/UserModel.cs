using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom9_WebsiteGiaySneaker.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mã khách hàng. *")]
        public int MaKH { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên khách hàng. *")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh. *")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giới tính. *")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại. *")]
        public string DienThoai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản. *")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu. *")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email. *")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ. *")]
        public string DiaChi { get; set; }

    }
}