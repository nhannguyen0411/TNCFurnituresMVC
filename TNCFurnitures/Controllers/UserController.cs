using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

namespace TNCFurnitures.Controllers
{
    public class UserController : Controller
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection, NGUOIDUNG nd)
        {
            var email = collection["email"];
            var name = collection["name"];
            var phone = collection["phone"];
            var address = collection["address"];
            var password = collection["pass"];
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Error"] = "Email is required!";
            }
            else if (String.IsNullOrEmpty(name))
            {
                ViewData["Error"] = "Name is required!";
            }
            else if (String.IsNullOrEmpty(phone))
            {
                ViewData["Error"] = "Phone is required!";
            }
            else if (String.IsNullOrEmpty(address))
            {
                ViewData["Error"] = "Address is required!";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["Error"] = "Password is required!";
            }
            else
            {
                nd.TenND = name;
                nd.MatKhau = password;
                nd.DiaChi = address;
                nd.Email = email;
                nd.DienThoai = phone;
                db.NGUOIDUNGs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Register();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var email = collection["email"];
            var password = collection["pass"];
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Error"] = "Email is required!";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["Error"] = "Password is required!";
            }
            else
            {
                NGUOIDUNG nd = db.NGUOIDUNGs.SingleOrDefault(n => n.Email == email && n.MatKhau == password);
                if (nd != null)
                {
                    ViewBag.Thongbao = "Login successful!";
                    Session["NguoiDung"] = nd;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Thongbao = "Wrong email or password!";
                }
            }
            return View();
        }
    }
}