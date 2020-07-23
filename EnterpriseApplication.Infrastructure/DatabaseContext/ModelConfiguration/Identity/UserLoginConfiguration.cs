using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Identity
{
    class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            builder.ToTable("UserLogin", "Security");
            builder.Property(b => b.UserId)
                .HasColumnName("User_ID_FK");
            builder.Property(b => b.ProviderDisplayName)
               .HasMaxLength(200);
        }
    }
}
