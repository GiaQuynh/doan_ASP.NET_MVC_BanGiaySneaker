using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nhom9_WebsiteGiaySneaker.Models;
namespace Nhom9_WebsiteGiaySneaker.Areas.Admin.Controllers
{
    public class ProductsAPIController : ApiController
    {
        public List<ProductBrandMix> GetListProductBrand()
        {
            QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
            var listProductsMix = from product in db.SanPhams
                                  join brand in db.Brands
                                  on product.MaBrand equals brand.MaBrand
                                  select new ProductBrandMix()
                                  {
                                      MaSP = product.MaSP,
                                      TenSP = product.TenSP,
                                      AnhSP = product.AnhSP,
                                      GiaBan = product.GiaBan ?? 0,
                                      MauSac = product.MauSac,
                                      MoTa = product.MoTa,
                                      TenBrand = brand.TenBrand
                                  };
            return listProductsMix.ToList();
        }
        public ProductBrandMix GetProductBrand(int id)
        {
            QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
            var ProductsMix = from product in db.SanPhams
                              join brand in db.Brands
                              on product.MaBrand equals brand.MaBrand
                              select new ProductBrandMix()
                              {
                                  MaSP = product.MaSP,
                                  TenSP = product.TenSP,
                                  AnhSP = product.AnhSP,
                                  GiaBan = product.GiaBan ?? 0,
                                  MauSac = product.MauSac,
                                  MoTa = product.MoTa,
                                  TenBrand = brand.TenBrand
                              };
            return ProductsMix.FirstOrDefault(e => e.MaSP == id);
        }
        //[HttpPost]
        //public bool InsertNewProduct(ProductBrandMix productBrandMix)
        //{
        //    try
        //    {
        //        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //        SanPham s = new SanPham();
                
        //        int maxMaSP = db.SanPhams.Max(b => b.MaSP); // Find the maximum MaBrand
        //        s.MaSP = maxMaSP + 1; // Increment by 1
        //        s.TenSP = productBrandMix.TenSP;
        //        s.AnhSP = productBrandMix.AnhSP;
        //        s.GiaBan = productBrandMix.GiaBan;
        //        s.MauSac = productBrandMix.MauSac;
        //        s.MoTa = productBrandMix.MoTa;
        //        s.MaBrand = db.Brands.FirstOrDefault(b => b.TenBrand == productBrandMix.TenBrand).MaBrand;

        //        db.SanPhams.Add(s);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //[HttpPut]
        //public bool UpdateProduct(int id, ProductBrandMix productBrandMix)
        //{
        //    try
        //    {
        //        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //        SanPham s = db.SanPhams.FirstOrDefault(p => p.MaSP == id);

        //        if (s == null) return false;

        //        s.TenSP = productBrandMix.TenSP;
        //        s.AnhSP = productBrandMix.AnhSP;
        //        s.GiaBan = productBrandMix.GiaBan;
        //        s.MauSac = productBrandMix.MauSac;
        //        s.MoTa = productBrandMix.MoTa;
        //        s.MaBrand = db.Brands.FirstOrDefault(b => b.TenBrand == productBrandMix.TenBrand).MaBrand;

        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //[HttpDelete]
        //public bool DeleteProduct(int id)
        //{
        //    try
        //    {
        //        QL_GIAY_LTWEntities db = new QL_GIAY_LTWEntities();
        //        SanPham s = db.SanPhams.FirstOrDefault(p => p.MaSP == id);

        //        if (s == null) return false;

        //        db.SanPhams.Remove(s);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}
