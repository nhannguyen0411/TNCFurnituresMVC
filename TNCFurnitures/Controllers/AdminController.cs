using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

namespace TNCFurnitures.Controllers
{
    public class AdminController : Controller
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
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
                NGUOIQUANTRI nqt = db.NGUOIQUANTRIs.SingleOrDefault(n => n.TaiKhoanNQT == email && n.MatKhauNQT == password);
                if (nqt != null)
                {
                    ViewBag.Thongbao = "Login successful!";
                    Session["NguoiQuanTri"] = nqt;
                    return RedirectToAction("Index", "Admin");
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