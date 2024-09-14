using Asil_Insaat.Entity.ViewModels.Kategoris;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Yazis
{
    public class YaziEklemeViewModel
    {
        public string? Baslik { get; set; }
        public string? Icerik { get; set; }

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

        public string? Dosya {  get; set; }
        public Guid KategoriId { get; set; }

        public IFormFile Fotograf { get; set; }

        public IList<KategoriViewModel> Kategoris { get; set; }
    }
}
