using EnterpriseApplication.Application.Security.Interface;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Infrastructure.Security.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public bool Login(string userName, string password,bool rememberMe)
        {
            var result = _signInManager.PasswordSignInAsync(userName, password, rememberMe, false)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            return result.Succeeded;
        }
        public void LogOut()
        {
            _signInManager.SignOutAsync().ConfigureAwait(false);
        }
    }
}
