using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Ürüns
{
    public class ÜrünViewModel
    {
        public Guid Id { get; set; }
        public string? Baslik { get; set; }

        public string? Aciklama { get; set; }

        public string? UrunTuru { get; set; }

        public double? Fiyat { get; set; }

        public double? Kdv { get; set; }

        public string? Icerik { get; set; }
        public bool Etkin { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public string Olusturan { get; set; }
        public bool SilinmisMi { get; set; }


        public AppUser User { get; set; }

        public SatisBirimiViewModel SatisBirimi { get; set; }


    }
}
