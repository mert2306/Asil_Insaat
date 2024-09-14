using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Teklifs
{
    public class TeklifViewModel
    {
        public Guid Id { get; set; }

        public string? Aciklama { get; set; }
        public DateTime TeklifTarih { get; set; } = DateTime.Now;
        public DateTime SonTarih { get; set; }
        public double? Fiyat { get; set; }

        public ÜrünViewModel ÜrünView {  get; set; }

        public MüsteriViewModel MüsteriView { get; set; }

        public AppUser User { get; set; }

        public Müsteri Müsteri { get; set; }

        public Ürün Ürün { get; set; }

        public string Olusturan { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public bool SilinmisMi { get; set; }

    }
}
