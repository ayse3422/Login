using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models.Entity;


namespace Login.Controllers
{
    
    public class KayitController : Controller
    {
        TeknikKartDbEntities db = new TeknikKartDbEntities();
        // GET: Kayit
        [HttpGet]
        public ActionResult Index()
                    {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Kullanici tbl)
        {
            db.Tbl_Kullanici.Add(tbl);
            db.SaveChanges();
            return View();
        }
    }
}