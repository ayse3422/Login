using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models;
using Login.Models.Entity;

namespace Login.Controllers
{
    public class TabloController : Controller
    {

        TeknikKartDbEntities db = new TeknikKartDbEntities();
        // GET: Tablo
        public ActionResult Index()
        {
            string kullaniciId = Session["Id"].ToString();
            var x = db.Tbl_Kart.ToList();
            var y = db.Tbl_Kullanici.ToList();
            var data = (from t in db.Tbl_Kart
                        where t.KullaniciId.ToString() == kullaniciId
                        select new
                        {
                            t.KartId,
                            t.Aciklama,
                            t.Tarih,
                            t.Durum,
                            t.İs

                        }).ToList();
           
            
            List<EntityTabloData> list = new List<EntityTabloData>();
            foreach (var kart in data)
            {
                EntityTabloData a = new EntityTabloData();
                a.Aciklama = kart.Aciklama;
                a.Tarih = Convert.ToDateTime(kart.Tarih);
                a.İs = kart.İs;
                a.Durum = kart.Durum;
                a.KartId = kart.KartId;
                list.Add(a);
            }

            return View(list);
        }

        [HttpGet]
        public ActionResult TabloEkle()
        {
            var kart = db.Tbl_Kart.ToList();
            string kullaniciId = Session["Id"].ToString();
            int kullaniciIdInt = int.Parse(kullaniciId);
            return View(kart);
        }
        [HttpPost]
        public ActionResult TabloEkle(Tbl_Kart tbl)
        {
            string kullaniciId = Session["Id"].ToString();
            tbl.KullaniciId = int.Parse(kullaniciId);
            db.Tbl_Kart.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Index", "Tablo");
        }
        public ActionResult TabloSilme(int Id)
        {
            var del = db.Tbl_Kart.Find(Id);
            db.Tbl_Kart.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index","Tablo");
        }

        [HttpGet]
        public ActionResult TabloEdit2()
        {

            return Redirect("TabloGuncelle");
        }
        public ActionResult TabloGuncelle(int id)
        {
            
            return View("TabloGuncelle");
        }

        [HttpPost]
        public ActionResult TabloEdit(Tbl_Kart tbl)
        {
            
            var c = db.Tbl_Kart.Find(tbl.KartId);
            c.Durum = tbl.Durum;
            c.Aciklama = tbl.Aciklama;
            c.Tarih = tbl.Tarih;
            c.İs = tbl.İs;
            
            db.SaveChanges();
            return RedirectToAction("Index", "Tablo");
        }

    }
}