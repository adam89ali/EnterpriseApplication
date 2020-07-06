using EnterpriseApplication.Application.Security.Authentication.Repositories;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Infrastructure.Security.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public bool Login(string userName, string password,bool rememberMe)
        {
            var result = _signInManager.PasswordSignInAsync(userName, password, rememberMe, false)
                .GetAwaiter().GetResult();
            return result.Succeeded;
        }
        public  bool LogOut()
        {
           _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return true;
        }
    }
}
