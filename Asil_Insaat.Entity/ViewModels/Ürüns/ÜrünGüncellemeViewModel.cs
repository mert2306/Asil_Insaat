using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Ürüns
{
    public class ÜrünGüncellemeViewModel
    {
        public Guid Id { get; set; }
        public string? Baslik { get; set; }
        public string? Icerik { get; set; }
        public string? UrunTuru { get; set; }

        public double? Fiyat { get; set; }

        public double? Kdv { get; set; }

        public bool Etkin { get; set; }

        public Guid SatisBirimiId { get; set; }

        public IList<SatisBirimiViewModel> SatisBirimis { get; set; }

    }
}
