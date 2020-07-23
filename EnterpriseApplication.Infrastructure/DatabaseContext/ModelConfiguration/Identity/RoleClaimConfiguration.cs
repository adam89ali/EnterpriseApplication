using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Identity
{
    class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
        {
            builder.ToTable("RoleClaim", "Security");
            builder.Property(b => b.Id)
               .HasColumnName("RoleClaim_ID_PK");
            builder.Property(b => b.RoleId)
                .HasColumnName("Role_ID_FK");
            builder.Property(b => b.ClaimType).HasMaxLength(50);
            builder.Property(b => b.ClaimValue).HasMaxLength(50);

        }
    }
}
