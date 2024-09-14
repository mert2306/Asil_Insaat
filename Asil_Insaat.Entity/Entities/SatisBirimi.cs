using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class SatisBirimi : VeriTabani
    {
        public SatisBirimi() 
        { 

        }


        public SatisBirimi (string aciklama)
        {
            Aciklama = aciklama;
        }

        public string? Aciklama { get; set; }
        public ICollection<Ürün> Ürüns { get; set; }

    }
}
