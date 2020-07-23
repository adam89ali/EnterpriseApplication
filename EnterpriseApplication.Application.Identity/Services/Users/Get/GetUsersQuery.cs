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

namespace EnterpriseApplication.Application.Identity.Services.Users.Get
{
    public class GetUsersQuery : IRequest<Response<IList<UserDto>>>
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Response<IList<UserDto>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetUsersQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public Task<Response<IList<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _userManager.Users.AsNoTracking()
                             .Where(x => (request.userId == Guid.Empty || x.Id == request.userId) &&
                             (String.IsNullOrEmpty(request.userName) || x.UserName == request.userName) &&
                             String.IsNullOrEmpty(request.email) || x.Email == request.email)
                             .Select(p => new UserDto { userId = p.Id, userName = p.UserName, email = p.Email })
                             .ToList(); 
            return Task.FromResult(Response.Ok<IList<UserDto>>("", false, result));
        }
    }

}
