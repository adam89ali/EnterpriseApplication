using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Interface
{
    public interface IApplicationUserService
    {
        public bool Login(string userName, string password,bool rememberMe);
        public void LogOut();
    }
}
