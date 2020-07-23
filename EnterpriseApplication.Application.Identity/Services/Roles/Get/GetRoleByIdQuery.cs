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
    public class GetRoleByIdQuery : IRequest<Response<RoleDto>>
    {
        public Guid roleId { get; set; }
    }

    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Response<RoleDto>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public GetRoleByIdQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public Task<Response<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _roleManager.Roles.AsNoTracking()
                            .Where(x => x.Id == request.roleId)
                            .Select(p => new RoleDto { roleId = p.Id, role = p.Name })
                            .FirstOrDefault();
            return Task.FromResult(Response.Ok<RoleDto>("", false, result));
        }
    }

}
