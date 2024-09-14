using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.SatisBirimi
{
    public class SatisBirimiViewModel
    {
        public Guid Id { get; set; }
        public string Aciklama { get; set; }
        public string Olusturan { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;


        public bool SilinmisMi { get; set; }
    }
}
