using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Users.Remove
{
    public class RemoveUserCommand : IRequest<Response<bool>>
    {
        public Guid userId { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<RemoveUserCommand, Response<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<bool>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByIdAsync(request.userId.ToString());
            var result = await _userManager.DeleteAsync(existingUser);
            return Response.Ok<bool>("Deleted Successfully", false, result.Succeeded);
        }
    }

}
