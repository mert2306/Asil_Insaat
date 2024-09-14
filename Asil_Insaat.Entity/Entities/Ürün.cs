using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class Ürün : VeriTabani
    {

        public Ürün()
        {
            
        }

        public Ürün(string baslik, string urunTuru, string aciklama, double fiyat, double kdv, /*bool etkin*/ Guid satisBirimiId, string icerik, Guid userId)
        {
            Baslik = baslik;
            UrunTuru = urunTuru;
            Aciklama = aciklama;
            Fiyat = fiyat;
            Kdv = kdv;
            //Etkin = etkin;
            SatisBirimiId = satisBirimiId;
            Icerik = icerik;
            UserId = userId;
        }

        public string? Baslik { get; set; }
        public  string? UrunTuru { get; set; }
        public string? Aciklama { get; set; }
        public string? Icerik { get; set; }
        public double? Fiyat { get; set;  }
        public double? Kdv { get; set; }
        //public bool Etkin { get; set; }
        public Guid SatisBirimiId { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        

        public SatisBirimi SatisBirimi { get; set; }

        public ICollection<Teklif> Teklifs { get; set; }
    }
}
