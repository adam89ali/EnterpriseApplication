using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.UserRole.GetRoles
{
    public class GetRolesQuery : IRequest<Response<IList<RoleDto>>> { }

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, Response<IList<RoleDto>>>
    {
        private readonly IIdentityDatabaseContext _dbContext;
        public GetRolesQueryHandler(IIdentityDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Response<IList<RoleDto>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var result = _dbContext.Roles.AsNoTracking()
              .Select(p => new RoleDto { roleId = p.Id, role = p.Name })
              .ToList();
            var roles = (IList<RoleDto>) result;
            return Task.FromResult(Response.Ok("", false, roles));
        }
    }

}
