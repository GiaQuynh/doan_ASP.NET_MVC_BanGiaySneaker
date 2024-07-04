using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom9_WebsiteGiaySneaker.Models
{
    public class GioHang
    {
        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        public int iMaSP { get; set; }
        public string iTenSP { get; set; }
        public string iAnhSP { get; set; }
        public double iGiaBan { get; set; }
        public int iSoLuong { get; set; }
        public double iThanhTien
        {
            get { return iSoLuong * iGiaBan; }
        }

        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            SanPham sp = db.SanPhams.Single(s => s.MaSP == iMaSP);
            iTenSP = sp.TenSP;
            iAnhSP = sp.AnhSP;
            iGiaBan = double.Parse(sp.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}