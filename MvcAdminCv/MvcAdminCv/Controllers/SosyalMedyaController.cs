using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;
using MvcAdminCv.Repostories;

namespace MvcAdminCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        GenericRepository<Tbl_SosyalMedya> repo = new GenericRepository<Tbl_SosyalMedya>();

        CvSiteEntities1 db = new CvSiteEntities1();
        public ActionResult Index()
        {
            var veriler = repo.List();

            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(Tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.AD = p.AD;
            hesap.Durum = true;
            hesap.Link = p.Link;
            hesap.İkon = p.İkon;
            repo.Tupdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.Tupdate(hesap);
            return RedirectToAction("Index");
        }
    }
}