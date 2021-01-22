using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class EntityTabloData
    {
        public int KartId { get; set; }
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }
        public string Aciklama { get; set; }
        public string İs { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
    }
}