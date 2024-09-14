using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Galeris
{
    public class GaleriEklemeViewModel
    {
        public string? Baslik { get; set; }
        public string? Icerik { get; set; }
        public string? fileType { get; set; }

        public IFormFile Galeri { get; set; }
    }
}
