using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login.Models.Entity;

namespace Login.Controllers
{
    public class Tbl_KartController : Controller
    {
        private TeknikKartDbEntities db = new TeknikKartDbEntities();

        // GET: Tbl_Kart
        public ActionResult Index()
        {
            var tbl_Kart = db.Tbl_Kart.Include(t => t.Tbl_Teknik);
            return View(tbl_Kart.ToList());
        }

        // GET: Tbl_Kart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kart tbl_Kart = db.Tbl_Kart.Find(id);
            if (tbl_Kart == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kart);
        }

        // GET: Tbl_Kart/Create
        public ActionResult Create()
        {
            ViewBag.TeknikId = new SelectList(db.Tbl_Teknik, "TeknikId", "ProjeAdi");
            return View();
        }

        // POST: Tbl_Kart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KartId,Tarih,Durum,İs,Aciklama,StatusId,TeknikId,KullaniciId")] Tbl_Kart tbl_Kart)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Kart.Add(tbl_Kart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeknikId = new SelectList(db.Tbl_Teknik, "TeknikId", "ProjeAdi", tbl_Kart.TeknikId);
            return View(tbl_Kart);
        }

        // GET: Tbl_Kart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kart tbl_Kart = db.Tbl_Kart.Find(id);
            if (tbl_Kart == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeknikId = new SelectList(db.Tbl_Teknik, "TeknikId", "ProjeAdi", tbl_Kart.TeknikId);
            return View(tbl_Kart);
        }

        // POST: Tbl_Kart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KartId,Tarih,Durum,İs,Aciklama,StatusId,TeknikId,KullaniciId")] Tbl_Kart tbl_Kart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Kart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeknikId = new SelectList(db.Tbl_Teknik, "TeknikId", "ProjeAdi", tbl_Kart.TeknikId);
            return View(tbl_Kart);
        }

        // GET: Tbl_Kart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kart tbl_Kart = db.Tbl_Kart.Find(id);
            if (tbl_Kart == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kart);
        }

        // POST: Tbl_Kart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Kart tbl_Kart = db.Tbl_Kart.Find(id);
            db.Tbl_Kart.Remove(tbl_Kart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
