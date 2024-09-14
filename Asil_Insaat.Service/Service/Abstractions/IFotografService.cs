using Asil_Insaat.Entity.ViewModels.Fotograf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IFotografService
    {
        Task<List<FotografViewModel>> SilinmemisFotograflariiGetirAsync();
        Task FotografOlusturAsync(FotografEklmeViewModel fotografEklmeViewModel);
        Task<string> FotografGüncelleAsync(FotografGuncellemeViewModel fotografGuncellemeViewModel);
        Task<FotografViewModel> SilinmemisFotograflariGetirAsync(Guid fotografId);

        Task<List<FotografViewModel>> SilimisTümFotograflariGetirAsync();
        Task<string> FotografGüvenliSilmeAsync(Guid fotografId);
        Task<string> FotografGüvenliGetirAsync(Guid fotografId);

    }
}
