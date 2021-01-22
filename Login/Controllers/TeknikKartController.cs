using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models.Entity;



namespace Login.Controllers
{
    [AllowAnonymous]
    public class TeknikKartController : Controller
    {
        TeknikKartDbEntities db = new TeknikKartDbEntities();
        // GET: TeknikKart
        [HttpGet]
        public ActionResult Index()
        {
            string kullaniciId = Session["Id"].ToString();
            int kullaniciIdInt = int.Parse(kullaniciId);
            var user = db.Tbl_Kullanici.FirstOrDefault(c => c.KullaniciId == kullaniciIdInt);
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Teknik tbl)
        {
            string kullaniciId = Session["Id"].ToString();
            tbl.KullaniciId = int.Parse(kullaniciId);
            db.Tbl_Teknik.Add(tbl);
            db.SaveChanges();
            return View();
        }
    }
}