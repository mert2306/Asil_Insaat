using Asil_Insaat.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asil_Insaat.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);


            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");


            builder.ToTable("Users");

            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.UserName).HasMaxLength(100);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);


            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();



            var superadmin = new AppUser
            {
                Id = Guid.Parse("83314624-C7A0-4468-A6AA-1F2AF06F4660"),
                UserName = "mertcanasil3@gmail.com",
                NormalizedUserName = "MERTCANASIL3@GMAIL.COM",
                Email = "mertcanasil3@gmail.com",
                NormalizedEmail = "MERTCANASIL3@GMAIL.COM",
                Isim = "Mertcan",
                Soyisim = "Asıl",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ResimId = Guid.Parse("C70801CA-CC45-4079-83C6-B0DA466BBABB")
            };
            superadmin.PasswordHash = CreatPasswordHash(superadmin, "11235813");

            var admin = new AppUser
            {
                Id = Guid.Parse("BEF76420-D441-4820-A5C0-5B39D62A8E0B"),
                UserName = "asilinsaatyapiyalitim@gmail.com",
                NormalizedUserName = "ASILINSAATYAPIYALITIM@GMAIL.COM",
                Email = "asilinsaatyapiyalitim@gmail.com",
                NormalizedEmail = "ASILINSAATYAPIYALITIM@GMAIL.COM",
                Isim = "Vahit",
                Soyisim = "Asil",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ResimId = Guid.Parse("77E2D3F6-B7BF-4549-B7E2-7673D57586D6")
            };
            admin.PasswordHash = CreatPasswordHash(admin, "232323");

            builder.HasData(superadmin, admin);
        }


        private string CreatPasswordHash(AppUser user, string password)
        {

            var passwordHaser = new PasswordHasher<AppUser>();
            return passwordHaser.HashPassword(user, password);
        }
    }
}
