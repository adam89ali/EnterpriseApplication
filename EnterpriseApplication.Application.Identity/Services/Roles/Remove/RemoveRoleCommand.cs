using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Roles.Remove
{
    public class RemoveRoleCommand : IRequest<Response<bool>>
    {
        public Guid roleId { get; set; }
    }

    public class DeleteRoleCommandHandler : IRequestHandler<RemoveRoleCommand, Response<bool>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public DeleteRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Response<bool>> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var existingRole = await _roleManager.FindByIdAsync(request.roleId.ToString());
            var result = await _roleManager.DeleteAsync(existingRole);
            return Response.Ok<bool>("Deleted Successfully", false, result.Succeeded);
        }
    }

}
