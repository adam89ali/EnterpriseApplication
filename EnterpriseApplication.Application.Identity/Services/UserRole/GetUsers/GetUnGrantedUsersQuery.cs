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

namespace EnterpriseApplication.Application.Identity.Services.UserRole.GetUsers
{
    public class GetUnGrantedUsersQuery : IRequest<Response<IList<UserDto>>>
    {
        public Guid roleId { get; set; }
        public string userName { get; set; }
    }

    public class GetUnGrantedUsersQueryHandler : IRequestHandler<GetUnGrantedUsersQuery, Response<IList<UserDto>>>
    {
        private readonly IIdentityDatabaseContext _dbContext;
        public GetUnGrantedUsersQueryHandler(IIdentityDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Response<IList<UserDto>>> Handle(GetUnGrantedUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _dbContext.Users.AsNoTracking()
               .Where(x => !_dbContext.UserRoles.Any(y => y.UserId == x.Id && y.RoleId == request.roleId) &&
               (string.IsNullOrEmpty(request.userName) || x.UserName.Contains(request.userName)))
               .Select(p => new UserDto { userId = p.Id, userName = p.UserName })
               .ToList();
            var unGrantedUsers = (IList<UserDto>)result;
            return Task.FromResult(Response.Ok("", false, unGrantedUsers));
        }
    }
}
