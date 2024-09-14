using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asil_Insaat.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.ToTable("UserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("83314624-C7A0-4468-A6AA-1F2AF06F4660"),
                RoleId = Guid.Parse("BB50035E-53DF-4510-84A0-1B52A5695DF5")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("BEF76420-D441-4820-A5C0-5B39D62A8E0B"),
                RoleId = Guid.Parse("258CA24D-5F16-44A0-AFCC-8DEA4D026528")

            }
            );
        }
    }
}
