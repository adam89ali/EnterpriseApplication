using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Response<bool>>
    {
        public Guid roleId { get; set; }
    }
}
