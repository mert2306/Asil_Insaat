using Asil_Insaat.Core.Veris;

namespace Asil_Insaat.Entity.Entities
{
    public class Yazi : VeriTabani
    {
        public Yazi()
        {


        }

        public Yazi(string baslik, string icerik, Guid userId, string olusturan, Guid kategoriId, Guid resimId, string fiyat, string bilgi1, string bilgi2, string bilgi3, string bilgi4, string bilgi5, string bilgiicerik1, string bilgiicerik2, string bilgiicerik3, string bilgiicerik4, string bilgiicerik5, string dosya)
        {
            Baslik = baslik;
            Icerik = icerik;
            UserId = userId;
            Oluşturan = olusturan;
            KategoriId = kategoriId;
            ResimId = resimId;
            Fiyat = fiyat;
            Bilgi1 = bilgi1;
            Bilgi2 = bilgi2;
            Bilgi3 = bilgi3;
            Bilgi4 = bilgi4;
            Bilgi5 = bilgi5;
            Bilgiİcerik1 = bilgiicerik1;
            Bilgiİcerik2 = bilgiicerik2;
            Bilgiİcerik3 = bilgiicerik3;
            Bilgiİcerik4 = bilgiicerik4;
            Bilgiİcerik5 = bilgiicerik5;
			Dosya = dosya;
		}

        public string Baslik { get; set; }
        public string Icerik { get; set; }
        
        public Guid KategoriId { get; set; }
        public Guid ResimId { get; set; }
       
        public Resim? Resim { get; set; }
        public Guid UserId { get; set; }
        public Kategori Kategori { get; set; }
        public AppUser User { get; set; }
        public string? Fiyat { get; set; }
        public string? Bilgi1 { get; set; }
        public string? Bilgi2 { get; set; }
        public string? Bilgi3 { get; set;}
        public string? Bilgi4 { get; set; }
        public string? Bilgi5 { get; set; }
        public string? Bilgiİcerik1 { get; set; }
        public string? Bilgiİcerik2 { get; set; }
        public string? Bilgiİcerik3 { get; set; }
        public string? Bilgiİcerik4 { get; set; }
        public string? Bilgiİcerik5 { get; set; }
		public string Dosya { get; set; }
	}
}
