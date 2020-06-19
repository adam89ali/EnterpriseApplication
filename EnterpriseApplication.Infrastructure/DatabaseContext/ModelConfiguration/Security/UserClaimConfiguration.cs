using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Security
{
    class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            builder.ToTable("UserClaim", "Security");
            builder.Property(b => b.Id)
               .HasColumnName("UserClaim_ID_PK");
            builder.Property(b => b.UserId)
                .HasColumnName("User_ID_FK");
            builder.Property(b => b.ClaimType).HasMaxLength(50);
            builder.Property(b => b.ClaimValue).HasMaxLength(50);
        }
    }
}
