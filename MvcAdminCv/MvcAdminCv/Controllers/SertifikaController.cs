using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;
using MvcAdminCv.Repostories;


namespace MvcAdminCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepository<Tbl_Sertifikalarım> repo = new GenericRepository<Tbl_Sertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]

        public ActionResult SertifikaGetir(Tbl_Sertifikalarım t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Tarih = t.Tarih;
            y.Aciklama = t.Aciklama;
            repo.Tupdate(y);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifikalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}