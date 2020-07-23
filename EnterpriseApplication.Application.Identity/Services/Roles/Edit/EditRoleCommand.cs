using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Roles.Edit
{
    public class EditRoleCommand : IRequest<Response<bool>>
    {
        public Guid roleId { get; set; }
        public string role { get; set; }
    }

    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.role).NotEmpty();
        }
    }

    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, Response<bool>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public EditRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Response<bool>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var existingRole = await _roleManager.FindByIdAsync(request.roleId.ToString());
            existingRole.Name = request.role;
            existingRole.NormalizedName = request.role.ToUpper();
            var result = await _roleManager.UpdateAsync(existingRole);
            return Response.Ok<bool>("Updated Successfully", false, result.Succeeded);
        }
    }

}
