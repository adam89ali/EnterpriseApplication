using EnterpriseApplication.Application.Identity.Common;
using EnterpriseApplication.Application.Identity.Entities;
using EnterpriseApplication.Infrastructure.EFCore.DatabaseContext.ModelConfiguration.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnterpriseApplication.Infrastructure.EFCore.DatabaseContext
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>,IIdentityDatabaseContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyIdentityConfiguration();
        }

    }
}
