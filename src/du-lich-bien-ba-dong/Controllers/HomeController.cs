using du_lich_bien_ba_dong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace du_lich_bien_ba_dong.Controllers
{
    public class HomeController : Controller
    {
        BienBaDongDbContext _db;
        public HomeController()
        {
            _db = new BienBaDongDbContext();
        }
        public ActionResult Index()
        {
            List<TinTuc> t = _db.TinTucs.ToList();
            return View(t);
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