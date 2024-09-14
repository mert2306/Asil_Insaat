using Asil_Insaat.Data.Context;
using Asil_Insaat.Data.Repostories.Abstractions;
using Asil_Insaat.Data.Repostories.Concretes;
using Asil_Insaat.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asil_Insaat.Data.Uzantilar
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnetion")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
