using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageRoles.Queries.GetRoles
{
    public class GetRoleByIdQuery : IRequest<Response<RoleDto>>
    {
        public Guid roleId { get; set; }
    }
}
