using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface ISatisBirimiService
    {
        Task<SatisBirimi> SatisBirimiGetirByGuid(Guid id);

        Task SatisBirimiOlusturAsync(SatisBirimiEklemeViewModel SatisBirimiEklemeViewModel);

        Task<List<SatisBirimiViewModel>> SilinmemisTümSatisBirimleriniGetir();

        Task<List<SatisBirimiViewModel>> SilinmemisTümSatisBirimleriniGetirSıralı();

        Task<string> SatisBirimiGüncelleAsync(SatisBirimiGuncellemeViewModel satisBirimiGuncellemeViewModel);

        Task<List<SatisBirimiViewModel>> TümSilinmisSatisBirimleriniGetir();

        Task<string> SatisBirimleriniGüvenliSilAsync(Guid satisBirimiId);

        Task<string> SilinenSatisBirimleriniGeriGetirAsync(Guid satisBirimiId);

    }
}
