using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class Müsteri : VeriTabani
    {
        public Müsteri() { }

        public Müsteri(string isim, string email,  string telefon, string adres, string sehir, string postaKodu, string odemeSarti, /*bool etkin,*/ string olusturan)
        {
            Isim = isim;
            Email = email;
            Telefon = telefon;
            Adres = adres;
            Sehir = sehir;
            PostaKodu = postaKodu;
            OdemeSarti = odemeSarti;
            //Etkin = etkin;
            Olusturan = olusturan;
        }
        
        public string? Isim { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
        public string? Sehir { get; set; }
        public string? PostaKodu { get; set; }
        public string? OdemeSarti { get; set; }
        //public bool Etkin { get; set; }
        public string? Olusturan { get; set; }

        public ICollection<Teklif> Teklifs { get; set; }
    }
}
