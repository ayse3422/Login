using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Login.Models.Entity;

namespace Login.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TeknikKartDbEntities db = new TeknikKartDbEntities();
        //GET: Login
        public ActionResult Index()
        {
            return View(); 

        }
       
        [HttpPost]
        public ActionResult Index(Tbl_Kullanici tbl)
        {
            var user = db.Tbl_Kullanici.FirstOrDefault(x => x.Email == tbl.Email && x.KullaniciSifre == tbl.KullaniciSifre);
            if(user != null)
            {
                Session.Add("Id", user.KullaniciId);
                Session.Add("adi", user.KullaniciAd);
                Session.Add("soyad", user.KullaniciSoyad);
                FormsAuthentication.SetAuthCookie(tbl.Email, false);
                return RedirectToAction("Index", "Anasayfa");

            }
            else
            {
                ViewBag.Mesaj = "Geçersiz email ya da şifre";
                return View();
            }
            
        }
    }
}