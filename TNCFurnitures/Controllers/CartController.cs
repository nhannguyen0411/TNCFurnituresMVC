using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

namespace TNCFurnitures.Controllers
{
    public class CartController : Controller
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        // GET: Cart
        public List<Cart> GetTheCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        public ActionResult AddToCart(int iMaNT, string strURL)
        {
            List<Cart> lstCart = GetTheCart();
            Cart sp = lstCart.Find(n => n.iMaNT == iMaNT);
            if (sp == null)
            {
                sp = new Cart(iMaNT);
                lstCart.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.iSoLuong++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                iTongSoLuong = lstCart.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }

        private double TongTien()
        {
            double iTongtien = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                iTongtien = lstCart.Sum(n => n.dThanhTien);
            }
            return iTongtien;
        }

        public ActionResult Cart()
        {
            List<Cart> lstCart = GetTheCart();
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstCart);
        }

        public ActionResult CartPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        public ActionResult DeleteTheCart(int iMaSP)
        {
            List<Cart> lstCart = GetTheCart();
            Cart sp = lstCart.SingleOrDefault(n => n.iMaNT == iMaSP);
            if (sp != null)
            {
                lstCart.RemoveAll(n => n.iMaNT == iMaSP);
                return RedirectToAction("Cart");
            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult UpdateTheCart(int iMaSP, FormCollection f)
        {
            List<Cart> lstCart = GetTheCart();
            Cart sp = lstCart.SingleOrDefault(n => n.iMaNT == iMaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Cart");
        }

        public ActionResult RemoveAll()
        {
            List<Cart> lstCart = GetTheCart();
            lstCart.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}