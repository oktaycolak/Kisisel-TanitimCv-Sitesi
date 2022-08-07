using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminCv.Models.Entity;
using MvcAdminCv.Repostories;

namespace MvcAdminCv.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim

        GenericRepository<Tbl_İletisim> repo = new GenericRepository<Tbl_İletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}