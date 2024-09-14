using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Ürüns
{
    public class ÜrünEklemeViewModel
    {

        public string? Baslik { get; set; }

        public string? Aciklama { get; set; }
        public string? Icerik { get; set; }


        public string? UrunTuru { get; set; }

        public double? Fiyat { get; set; }

        public double?   Kdv { get; set; }

        public Guid UserId { get; set; }

        //public bool Etkin { get; set; }


        public Guid SatisBirimiId { get; set; }

        public IList<SatisBirimiViewModel> SatisBirimis { get; set; }

    }
}
