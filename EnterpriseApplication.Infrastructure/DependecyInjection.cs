using EnterpriseApplication.Infrastructure.DatabaseContext;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EnterpriseApplication.Infrastructure.Security.Services;
using EnterpriseApplication.Infrastructure.Security.Repositories;
using EnterpriseApplication.Application.Security.ManageUsers.Repositories;
using EnterpriseApplication.Application.Security.ManageRoles.Repositories;
using EnterpriseApplication.Application.Security.Authentication.Repositories;

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

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDatabaseContext>();

            // Security Module Dependency Register
            services.AddTransient<IAuthenticationRepository,AuthenticationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            return services;
        }

    }
}
