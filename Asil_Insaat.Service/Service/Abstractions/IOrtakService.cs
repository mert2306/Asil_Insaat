using Asil_Insaat.Entity.ViewModels.Ortaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IOrtakService
    {
        Task<List<OrtakViewModel>> SilinmemisOrtaklariGetirAsync();
        Task OrtakOlusturAsync(OrtakEklemeViewModel ortakEklemeViewModel);
        Task<string> OrtakGüncelleAsync(OrtakGuncellemeViewModel ortakGuncellemeViewModel);
        Task<OrtakViewModel> SilinmemisOrtaklariGetirIdGöreAsync(Guid ortakId);
        Task<string> OrtakGüvenliSilmeAsync(Guid ortakId);
        Task<List<OrtakViewModel>> SilimisTümOrtakGetirAsync();
        Task<string> OrtakGüvenliGeriGetirAsync(Guid ortakId);
    }
}
