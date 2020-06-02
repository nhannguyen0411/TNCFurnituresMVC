using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

namespace TNCFurnitures.Controllers
{
    public class HomeController : Controller
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        public ActionResult Index()
        {
            var chude = from cd in db.LOAINOITHATs select cd;
            return View(chude);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}