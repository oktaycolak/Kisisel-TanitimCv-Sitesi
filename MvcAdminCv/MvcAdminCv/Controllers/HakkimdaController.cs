using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;
using MvcAdminCv.Repostories;

namespace MvcAdminCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda


        GenericRepository<Tbl_Hakkimda> repo = new GenericRepository<Tbl_Hakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda p)
        {
            //if (Request.Files.Count > 0)

            //{

            //    System.IO.File.Delete(Server.MapPath("~/image/resim.jpg"));

            //    string yol = "~/image/resim.jpg"  /*"resim.jpg"*/;

            //    Request.Files[0].SaveAs(Server.MapPath(yol));

            //    p.Resim = "/image/" + "resim.jpg";

            //}


            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.Tupdate(t);
            return RedirectToAction("Index");
        }

    }
}