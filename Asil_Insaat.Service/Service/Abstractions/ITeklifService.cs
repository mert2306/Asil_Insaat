using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using Asil_Insaat.Entity.ViewModels.Teklifs;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface ITeklifService
    {
        Task<List<TeklifViewModel>> SilinmemisTümTeklifMüsteriVeUrunleriGetirAsync();
        Task<Teklif> TeklifleriGetirByGuid(Guid id);
        Task TeklifOlusturAsync(TeklifEklemeViewModel teklifEklemeViewModel);
        Task<TeklifViewModel> SilinmemisTeklifUrunVeMüsterileriGetirAsync(Guid teklifId);
        Task<string> TeklifGuncelleAsync(TeklifGuncellemeViewModel teklifGuncellemeViewModel);


    }
}
