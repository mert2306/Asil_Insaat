using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IMüsteriService
    {

         Task<Müsteri> MüsteriGetirByGuid(Guid id);

        Task MüsteriOlusturAsync(MüsteriEklemeViewModel müsteriEklemeViewModel);

        Task<List<MüsteriViewModel>> SilinmemisTümMüsterilerileriGetir();

        Task<List<MüsteriViewModel>> SilinmemisTümMüsterileriGetirSıralı();

        Task<string> MüsteriGüncelleAsync(MüsteriGuncellemeViewModel müsteriGuncellemeViewModel);
        Task<string> MüsterisGüvenliSilAsync(Guid müsteriId);


    }
}
