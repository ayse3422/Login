using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class EntityData
    {
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string Turu { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
    }
}