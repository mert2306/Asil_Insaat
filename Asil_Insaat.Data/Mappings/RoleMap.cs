using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asil_Insaat.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            builder.ToTable("Roles");

            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);


            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id = Guid.Parse("BB50035E-53DF-4510-84A0-1B52A5695DF5"),
                Name = "Superadmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            },
            new AppRole
            {
                Id = Guid.Parse("258CA24D-5F16-44A0-AFCC-8DEA4D026528"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

        }
    }
}
