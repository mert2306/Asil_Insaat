using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IUrunService
    {

        Task<Ürün> UrunleriGetirByGuid(Guid id);
        Task UrunOlusturAsync(ÜrünEklemeViewModel ürünEklemeViewModel);
        Task<List<ÜrünViewModel>> SilinmemisTümUrunVeSatisBirinleriniGetirAsync();
        Task<string> UrunGuncelleAsync(ÜrünGüncellemeViewModel ürünGüncellemeViewModel);
        Task<ÜrünViewModel> SilinmemisUrunVeSatisBirimleriniGetirAsync(Guid urunId);
        Task<string> UrunGüvenliSilmeAsync(Guid urunId);
    }
}
