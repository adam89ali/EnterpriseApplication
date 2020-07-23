using EnterpriseApplication.Application.Identity.Common;
using EnterpriseApplication.Application.Identity.Entities;
using EnterpriseApplication.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseApplication.Application.Identity.Extensions;

namespace EnterpriseApplication.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDatabaseContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
            // identity configuration
            services.AddScoped<IIdentityDatabaseContext>(provider => provider.GetService<ApplicationDatabaseContext>());
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
                options.ConfigurePassword();
            })
            .AddEntityFrameworkStores<ApplicationDatabaseContext>();

           

            return services;
        }

    }
}
