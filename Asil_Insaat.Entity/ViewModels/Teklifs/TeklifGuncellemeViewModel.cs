using Asil_Insaat.Entity.ViewModels.Müsteris;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Teklifs
{
    public class TeklifGuncellemeViewModel
    {
        public Guid Id { get; set; }

        public string? Aciklama { get; set; }
        public DateTime TeklifTarih { get; set; }
        public DateTime? SonTarih { get; set; }
        public double? Fiyat { get; set; }

        public Guid ÜrünId { get; set; }

        public Guid MüsteriId { get; set; }

        public IList<ÜrünViewModel> Ürüns { get; set; }

        public IList<MüsteriViewModel> Müsteris { get; set; }
    }
}
