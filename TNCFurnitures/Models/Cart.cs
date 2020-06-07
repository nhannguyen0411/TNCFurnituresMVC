using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNCFurnitures.Models
{
    public class Cart
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        public int iMaNT { get; set; }
        public string sTenNT { get; set; }
        public string sAnhBia { get; set; }
        public Double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public Double dThanhTien 
        {
            get { 
                return iSoLuong * dDonGia; 
            }
        }
        public Cart(int MaNT) 
        {
            iMaNT = MaNT;
            NOITHAT noithat = db.NOITHATs.Single(n => n.MaNT == iMaNT);
            sTenNT = noithat.TenNT;
            sAnhBia = noithat.AnhBia;
            dDonGia = double.Parse(noithat.GiaBan.ToString());
            iSoLuong = 1;
        }

    }
}