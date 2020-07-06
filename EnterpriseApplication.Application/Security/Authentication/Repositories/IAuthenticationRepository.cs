using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        public bool Login(string userName, string password,bool rememberMe);
        public bool LogOut();
    }
}
