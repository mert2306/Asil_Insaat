using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Resims;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Helpers.Resims
{
    public interface IResimHelper
    {
        Task<ResimYüklemeViewModel> Upload(string name, IFormFile imageFile, ResimType resimType, string? folderName = null);
        void Delete(string resimIsim);
    }
}
