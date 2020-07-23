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

namespace EnterpriseApplication.Application.Identity.Services.Users.Add
{
    public class AddUserCommand : IRequest<Response<Guid>>
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(r => r.userName).NotEmpty();
            RuleFor(r => r.password).NotEmpty().Length(4);
            RuleFor(r => r.email).NotEmpty().EmailAddress();
        }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response<Guid>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AddUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<Guid>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();
            var newUser = new ApplicationUser
            {
                Id = userId,
                UserName = request.userName,
                NormalizedUserName = request.userName.ToUpper(),
                Email = request.email,
                NormalizedEmail = request.email.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            var result = await _userManager.CreateAsync(newUser, request.password);
            return Response.Ok<Guid>("Saved Successfully", false, userId);
        }
    }
}
