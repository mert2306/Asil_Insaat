using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class Teklif : VeriTabani
    {
        public Teklif() { }

        public Teklif(string aciklama, DateTime teklifTarih, DateTime sonTarih, double fiyat, Guid urunId, Guid musteriId, Guid userId)
        {
            Aciklama = aciklama;
            TeklifTarih = teklifTarih;
            SonTarih = sonTarih;
            Fiyat = fiyat;
            ÜrünId = urunId;
            MüsteriId = musteriId;
            UserId = userId;
        }

        public string Aciklama { get; set; }
       
        public double? Fiyat { get; set; }
        public Guid ÜrünId { get; set; }
        public Guid MüsteriId { get; set; }
        public Guid UserId { get; set; }
        public Müsteri Müsteri { get; set; }

        public Ürün Ürün { get; set; }

        public AppUser User { get; set; }


        public DateTime? TeklifTarih { get; set; } = DateTime.Now.Date;
        public DateTime? SonTarih { get; set; }



    }
}

