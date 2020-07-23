using EnterpriseApplication.Application.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Common
{
    public interface IIdentityDatabaseContext
    {
        DbSet<ApplicationUser> Users { get; set; }

        DbSet<ApplicationRole> Roles { get; set; }

        DbSet<IdentityUserRole<Guid>> UserRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
