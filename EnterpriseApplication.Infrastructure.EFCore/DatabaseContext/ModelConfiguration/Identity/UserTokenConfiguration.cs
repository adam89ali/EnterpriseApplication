﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.EFCore.DatabaseContext.ModelConfiguration.Identity
{
    class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            builder.ToTable("UserToken", "Identity");
            builder.Property(b => b.UserId)
                .HasColumnName("User_ID_FK");
            builder.Property(b => b.Name)
                .HasMaxLength(200);
            
        }
    }
}
