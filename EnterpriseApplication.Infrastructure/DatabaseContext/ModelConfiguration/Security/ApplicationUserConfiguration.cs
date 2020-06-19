using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Security
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users","Security")
                .Property(b => b.Id)
                .HasColumnName("User_ID_PK");
        }
    }
}
