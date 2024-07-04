using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nhom9_WebsiteGiaySneaker.Models;

namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class BrandsAPIController : ApiController
    {
        [HttpGet]
        public List<BrandMD> GetBrandList()
        {
            QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
            var listBrand = from brand in db.Brands
                            select new BrandMD()
                            {
                                MaBrand = brand.MaBrand,
                                TenBrand = brand.TenBrand
                            };
            return listBrand.ToList();
        }

        [HttpGet]
        public BrandMD GetBrand(int id)
        {
            QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
            var Brand = from brand in db.Brands
                        select new BrandMD()
                        {
                            MaBrand = brand.MaBrand,
                            TenBrand = brand.TenBrand
                        };
            return Brand.FirstOrDefault(e => e.MaBrand == id);
        }

        [HttpPost]
        public int InsertNewBrand(string TenBrand)
        {
            try
            {
                QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
                Brand s = new Brand();

                bool kt = db.Brands.Any(song => song.TenBrand.Equals(TenBrand));
                if (kt == true)
                {
                    return 0;
                }

                int maxMaBrand = db.Brands.Max(b => b.MaBrand); // Tìm MaBrand lớn nhất
                s.MaBrand = maxMaBrand + 1; // Tăng thêm 1 đơn vị
                s.TenBrand = TenBrand;
                db.Brands.Add(s);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [HttpPut]
        public bool UpdateNewBrand(int MaBrand, string TenBrand)
        {
            try
            {
                QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
                Brand s = db.Brands.FirstOrDefault(song => song.MaBrand == MaBrand);
                if (s == null) return false;
                s.TenBrand = TenBrand;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteBrand(int MaBrand)
        {
            QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
            Brand s = db.Brands.FirstOrDefault(song => song.MaBrand == MaBrand);
            if (s == null) return false;
            db.Brands.Remove(s);
            db.SaveChanges();
            return true;
        }
    }
}
