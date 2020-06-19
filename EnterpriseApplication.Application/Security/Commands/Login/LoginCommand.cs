using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.Login
{
    public class LoginCommand : IRequest<bool>
    {
        public string userName { get; set; }

        public string password { get; set; }

        public bool rememberMe { get; set; }
    }
}
