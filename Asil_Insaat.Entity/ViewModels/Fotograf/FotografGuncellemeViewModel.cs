using Asil_Insaat.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Fotograf
{
    public class FotografGuncellemeViewModel
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public Resim Resim { get; set; }

        public IFormFile? Fotograf { get; set; }
    }
}
