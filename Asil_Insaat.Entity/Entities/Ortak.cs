using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class Ortak : VeriTabani
    {
        public Ortak()
        {

        }


        public Ortak(string baslik, string baglanti, Guid userId, string olusturan, string fileType, Guid resimId)
        {
            Baslik = baslik;
            Baglanti = baglanti;
            UserId = userId;
            Olusturan = olusturan;
            Oluşturan = olusturan;
            FileType = fileType;
            ResimId = resimId;
        }


        public string Baslik { get; set; }
        public string Baglanti { get; set; }
        public Guid UserId { get; set; }
        public string Olusturan { get; }
        public AppUser User { get; set; }

        public Resim Resim { get; set; }

        public string? FileType { get; set; }
        public Guid ResimId { get; set; }
    }
}
