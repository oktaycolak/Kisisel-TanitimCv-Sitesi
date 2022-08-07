using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;
using MvcAdminCv.Repostories;

namespace MvcAdminCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Egitimlerim> repo = new GenericRepository<Tbl_Egitimlerim>();

        
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {

            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]

        public ActionResult EgitimDuzenle(Tbl_Egitimlerim t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Baslik = t.Baslik;
            y.AltBaslik1 = t.AltBaslik1;
            y.AltBaslik2 = t.AltBaslik2;
            y.GNO = t.GNO;
            t.Tarih = t.GNO;
            repo.Tupdate(y);
            return RedirectToAction("Index");
        }
    }
}