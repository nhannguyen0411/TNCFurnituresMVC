using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

namespace TNCFurnitures.Controllers
{
    public class FurnitureStoreController : Controller
    {
        dbQLFurnituresDataContext db = new dbQLFurnituresDataContext();
        // GET: FurnitureStore
        private List<NOITHAT> LayNoiThat(int count)
        {
            return db.NOITHATs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }



        public ActionResult Index()
        {
            var chude = from cd in db.LOAINOITHATs select cd;
            return View(chude);
        }

        public ActionResult Desk(int id)
        {
            var desk = from d in db.NOITHATs where d.MaLoaiNT == id select d;
            return View(desk);
        }
    }
}