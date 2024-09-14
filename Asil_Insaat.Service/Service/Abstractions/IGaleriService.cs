using Asil_Insaat.Entity.ViewModels.Galeris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IGaleriService
    {
        Task<List<GaleriViewModel>> SilinmemisGaleriGetirAsync();
        Task GaleriOlusturAsync(GaleriEklemeViewModel galeriEklemeViewModel);
        Task<string> GaleriGüncelleAsync(GaleriGuncellemeViewModel galeriGuncellemeViewModel);
        Task<GaleriViewModel> SilinmemisGaleriGetirIdGöreAsync(Guid galeriId);
        Task<string> GaleriGüvenliSilmeAsync(Guid galeriId);
        Task<List<GaleriViewModel>> SilimisTümGaleriGetirAsync();
        Task<string> GaleriGüvenliGeriGetirAsync(Guid galeriId);


    }
}
