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

        public ActionResult Logout()
        {
            Session["NguoiDung"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Profile(int id)
        {
            NGUOIDUNG nd = db.NGUOIDUNGs.SingleOrDefault(n => n.MaND == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nd);
        }

        [HttpPost]
        public ActionResult Profile(NGUOIDUNG nd)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var editUser = db.NGUOIDUNGs.SingleOrDefault(u => u.MaND == nd.MaND);
                    editUser.TenND = nd.TenND;
                    //editUser.Email = editUser.Email;
                    editUser.MatKhau = nd.MatKhau;
                    editUser.DiaChi = nd.DiaChi;
                    editUser.DienThoai = nd.DienThoai;
                    editUser.NgaySinh = nd.NgaySinh;
                    UpdateModel(editUser);
                    db.SubmitChanges();
                    ViewBag.Thongbao = "Update successfully";
                    return View();
                }
                catch(Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ViewBag.Thongbao = "Error";
                return View();
            }
        }
    }
}