using MvcAdminCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;

namespace MvcAdminCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        //DeneyimRepository repo=new DeneyimRepository();

        GenericRepository<Tbl_Deneyimlerim> repo = new GenericRepository<Tbl_Deneyimlerim>();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }

        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Altbaslik = p.Altbaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.Tupdate(t);
            return RedirectToAction("Index");

        }
    }
}