using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Interface
{
    public interface IApplicationUserService
    {
        public bool Login(string userName, string password,bool rememberMe);
        public bool LogOut();
    }
}
