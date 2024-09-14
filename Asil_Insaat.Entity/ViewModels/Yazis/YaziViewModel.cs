using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;

namespace Asil_Insaat.Entity.ViewModels.Yazis
{
    public class YaziViewModel
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }

        public string? Fiyat { get; set; }
        public string? Bilgi1 { get; set; }
        public string? Bilgi2 { get; set; }
        public string? Bilgi3 { get; set; }
        public string? Bilgi4 { get; set; }
        public string? Bilgi5 { get; set; }
        public string? Bilgiİcerik1 { get; set; }
        public string? Bilgiİcerik2 { get; set; }
        public string? Bilgiİcerik3 { get; set; }
        public string? Bilgiİcerik4 { get; set; }
        public string? Bilgiİcerik5 { get; set; }
        public string? Dosya { get; set; }
        public KategoriViewModel Kategori { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;


        public Resim Resim { get; set; }

        public AppUser User { get; set; }

        public string Olusturan { get; set; }
        public bool SilinmisMi { get; set; }    


    }
}
