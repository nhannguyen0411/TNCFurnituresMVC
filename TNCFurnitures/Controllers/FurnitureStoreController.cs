using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNCFurnitures.Models;

using PagedList;
using PagedList.Mvc;

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

        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);

            var ntmoi = LayNoiThat(20);
            return View(ntmoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Products(int ? page, int id, bool isRoom)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            if (isRoom)
            {
                var room = from r in db.NOITHATs where r.MaLoaiPhong == id select r;
                ViewBag.Thongbao = "Desk";
                return View(room.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var funi = from d in db.NOITHATs where d.MaLoaiNT == id select d;
                return View(funi.ToPagedList(pageNum, pageSize));
            }
        }

        public ActionResult Details(int id)
        {
            var product = from p in db.NOITHATs where p.MaNT == id select p;
            return View(product.Single());
        }
    }
}