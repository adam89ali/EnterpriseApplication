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
    public class GetUserByIdQuery : IRequest<Response<UserDto>>
    {
        public Guid userId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _userManager.Users.AsNoTracking()
                  .Where(x => x.Id == request.userId)
                  .Select(p => new UserDto { userId = p.Id, userName = p.UserName, email = p.Email })
                  .FirstOrDefault();
            return Task.FromResult(Response.Ok<UserDto>("", false, result));
        }
    }

}
