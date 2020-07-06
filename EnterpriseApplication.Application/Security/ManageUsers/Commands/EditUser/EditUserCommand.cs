using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageUsers.Commands.EditUser
{
    public class EditUserCommand : IRequest<Response<bool>>
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
