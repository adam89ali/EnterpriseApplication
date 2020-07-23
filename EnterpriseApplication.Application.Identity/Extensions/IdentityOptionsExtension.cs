using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Identity.Extensions
{
    public static class IdentityOptionsExtension
    {
        public static void ConfigurePassword(this IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        }
    }
}
