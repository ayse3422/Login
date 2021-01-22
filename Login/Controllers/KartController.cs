using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;
using Login.Models.Entity;

namespace Login.Controllers
{
    public class KartController : Controller
    {
        TeknikKartDbEntities db = new TeknikKartDbEntities();
        // GET: Kart
        public ActionResult Index()
        {
            string kullaniciId = Session["Id"].ToString();
            var x = db.Tbl_Kart.ToList();
            var y = db.Tbl_Kullanici.ToList();
            var data = (from t in db.Tbl_Start
                        where t.KullaniciId.ToString() == kullaniciId
                        select new
                        {
                            t.Aciklama,
                            t.Tarih,
                            t.Baslik,
                            t.Turu
                            

                        }).ToList();


            List<EntityData> list = new List<EntityData>();
            foreach (var kart in data)
            {
                EntityData b = new EntityData();
                b.Aciklama = kart.Aciklama;
                b.Tarih = Convert.ToDateTime(kart.Tarih);
                b.Baslik = kart.Baslik;
                b.Turu = kart.Turu;
                list.Add(b);
            }

            return View(list);
        }
  
    [HttpPost]
        public ActionResult Index(Tbl_Start tbl)
        {
            

            string kullaniciId = Session["Id"].ToString();
            tbl.KullaniciId = int.Parse(kullaniciId);
            return View();
        }

     
    }
}