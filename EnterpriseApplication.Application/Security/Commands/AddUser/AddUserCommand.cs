using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
