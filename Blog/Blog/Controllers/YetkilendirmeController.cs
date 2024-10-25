using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Blog.Controllers
{
    public class YetkilendirmeController : Controller
    {
        // GET: Admin
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var kullanicilar = adm.GetList();
            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin t)
        {
            adm.TAdd(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            Admin admin = adm.GetByID(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(Admin p)
        {
            adm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}