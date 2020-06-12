using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;
namespace MvcBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        // GET: BookStore

        private List<SACH> Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var sachmoi = Laysachmoi(5);

            return View(sachmoi);
        }
        public ActionResult Nhaxuatban()
        {
            var nxb = from cd in data.NHAXUATBANs select cd;
            return PartialView(nxb);
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from cd in data.SACHes where cd.MaCD == id select cd;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from cd in data.SACHes where cd.MaNXB == id select cd;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }
    }
}