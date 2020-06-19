using EnterpriseApplication.Infrastructure.DatabaseContext;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EnterpriseApplication.Application.Security.Interface;
using EnterpriseApplication.Infrastructure.Security.Services;

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

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDatabaseContext>();

            services.AddScoped<IApplicationUserService,ApplicationUserService>();
            return services;
        }

    }
}
