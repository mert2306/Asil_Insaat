using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Asil_Insaat.Entity.Entities;
using System.Reflection;

namespace Asil_Insaat.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Yazi> Yazis { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Resim> Resims { get; set; }
        public DbSet<Fotograf> Fotografs { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Galeri> Galeris { get; set; }

        public DbSet<Ortak> Ortaks { get; set; }

        public DbSet<Teklif> Teklifs { get; set; }

        public DbSet<Müsteri> Müsteris { get; set; }

        public DbSet<Ürün> Ürüns { get; set; }

        public DbSet<SatisBirimi> SatisBirimis { get; set; }



        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
