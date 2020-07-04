using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Interface
{
    public interface IApplicationUserService
    {
        public Task<bool> Login(string userName, string password,bool rememberMe);
        public Task<bool> LogOut();
    }
}
