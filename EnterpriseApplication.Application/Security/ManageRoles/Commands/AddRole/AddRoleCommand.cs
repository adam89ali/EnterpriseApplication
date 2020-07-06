using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageRoles.Commands.AddRole
{
    public class AddRoleCommand : IRequest<Response<Guid>>
    {
        public string role { get; set; }
    }

}
