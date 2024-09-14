using Asil_Insaat.Service.FluentValidations;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace Asil_Insaat.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IYaziService, YaziService>();
            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResimHelper, ResimHelper>();
            services.AddScoped<IFotografService, FotografService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IGaleriService, GaleriService>();
            services.AddScoped<IOrtakService, OrtakService>();
            services.AddScoped<ISatisBirimiService, SatisBirimiService>();
            services.AddScoped<IMüsteriService, MüsteriService>();
            services.AddScoped<IUrunService, UrunService>();
            services.AddScoped<ITeklifService, TeklifService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<YaziValidator>();
                    opt.DisableDataAnnotationsValidation = true;
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });
            return services;
        }
    }
}
