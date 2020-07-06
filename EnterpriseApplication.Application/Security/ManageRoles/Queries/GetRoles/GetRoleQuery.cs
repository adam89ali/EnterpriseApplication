using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageRoles.Queries.GetRoles
{
    public class GetRoleQuery : IRequest<Response<IList<RoleDto>>>
    {
        public Guid roleId { get; set; }
        public string role { get; set; }
    }
}
