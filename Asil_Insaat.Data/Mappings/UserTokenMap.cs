using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Data.Mappings
{
    public class UserTokenMap : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            builder.Property(t => t.LoginProvider).HasMaxLength(100);
            builder.Property(t => t.Name).HasMaxLength(100);


            builder.ToTable("UserTokens");
        }
    }
}
