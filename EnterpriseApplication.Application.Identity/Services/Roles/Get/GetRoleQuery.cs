using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Roles.Get
{
    public class GetRoleQuery : IRequest<Response<IList<RoleDto>>>
    {
        public Guid roleId { get; set; }
        public string role { get; set; }
    }

    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Response<IList<RoleDto>>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public GetRoleQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public Task<Response<IList<RoleDto>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var result = _roleManager.Roles.AsNoTracking()
                           .Where(x => (request.roleId == Guid.Empty || x.Id == request.roleId) &&
                             (String.IsNullOrEmpty(request.role) || x.Name == request.role))
                           .Select(p => new RoleDto { roleId = p.Id, role = p.Name })
                           .ToList(); 
            return Task.FromResult(Response.Ok<IList<RoleDto>>("", false, result));
        }
    }
}
