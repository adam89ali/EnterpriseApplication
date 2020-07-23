using EnterpriseApplication.Application.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.DatabaseContext.ModelConfiguration.Identity
{
    public static class IdentityConfiguration
    {
        public static void ApplyIdentityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.SeedData();
            
        }
        private static void SeedData(this ModelBuilder modelBuilder)
        {
            Guid ADMIN_ID = Guid.NewGuid();
            Guid ROLE_ID = Guid.NewGuid();


            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = ROLE_ID,
                Name = "SuperAdmin",
                NormalizedName = "superadmin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Adam",
                NormalizedUserName = "superadmin".ToUpper(),
                Email = "alisuriya89@gmail.com",
                NormalizedEmail = "alisuriya89@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            }
            );
        }
    }
}
