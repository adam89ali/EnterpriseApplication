using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.UserRole.Revoke
{
    public class RevokeRoleFromUsersCommand : IRequest<Response<bool>>
    {
        public Guid roleId { get; set; }
        public IList<Guid> users { get; set; }
    }

    public class RevokeRoleFromUsersCommandHandler : IRequestHandler<RevokeRoleFromUsersCommand, Response<bool>>
    {
        private readonly IIdentityDatabaseContext _dbContext;
        public RevokeRoleFromUsersCommandHandler(IIdentityDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response<bool>> Handle(RevokeRoleFromUsersCommand request, CancellationToken cancellationToken)
        {
            var entities = request.users.Select(p => new IdentityUserRole<Guid> { RoleId = request.roleId, UserId = p }).ToArray();
            _dbContext.UserRoles.RemoveRange(entities);
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            return Response.Ok<bool>("Role has been revoked from users", false, true);
        }
    }
}
