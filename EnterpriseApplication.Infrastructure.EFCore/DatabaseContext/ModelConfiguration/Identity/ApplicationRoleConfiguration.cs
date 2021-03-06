﻿using EnterpriseApplication.Application.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.EFCore.DatabaseContext.ModelConfiguration.Identity
{
    class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles", "Identity")
                .Property(b => b.Id)
                .HasColumnName("Role_ID_PK");
        }

    }
}
