using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageRoles.Commands.EditRole
{
    public class EditRoleCommand : IRequest<Response<bool>>
    {
        public Guid roleId { get; set; }
        public string role { get; set; }
    }
}
