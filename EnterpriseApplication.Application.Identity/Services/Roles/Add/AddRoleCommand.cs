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

namespace EnterpriseApplication.Application.Identity.Services.Roles.Add
{
    public class AddRoleCommand : IRequest<Response<Guid>>
    {
        public string role { get; set; }
    }

    public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator()
        {
            RuleFor(r => r.role).NotEmpty();
        }
    }

    class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Response<Guid>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AddRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Response<Guid>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var roleId = Guid.NewGuid();
            var newRole = new ApplicationRole
            {
                Id = roleId,
                Name = request.role,
                NormalizedName = request.role.ToUpper()
            };
            var result = await _roleManager.CreateAsync(newRole);
            return Response.Ok<Guid>("Saved Successfully", false, roleId);
        }
    }

}
