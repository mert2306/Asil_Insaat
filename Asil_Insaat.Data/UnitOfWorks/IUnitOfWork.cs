using Asil_Insaat.Core.Veris;
using Asil_Insaat.Data.Repostories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IVeriTabani, new();
        Task<int> SaveAsync();
        int Save();
    }
}
