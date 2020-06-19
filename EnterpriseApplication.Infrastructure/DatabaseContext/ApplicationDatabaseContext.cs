using EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Security;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnterpriseApplication.Infrastructure.DatabaseContext
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplySecurityConfiguration();
        }

    }
}
