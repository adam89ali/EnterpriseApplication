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

namespace EnterpriseApplication.Application.Identity.Services.Users.Edit
{
    public class EditUserCommand : IRequest<Response<bool>>
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.userName).NotEmpty();
            RuleFor(r => r.password).NotEmpty().Length(4);
            RuleFor(r => r.email).NotEmpty().EmailAddress();
        }
    }

    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Response<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EditUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var existingUser = await _userManager.FindByIdAsync(request.userId.ToString());
            existingUser.UserName = request.userName;
            existingUser.NormalizedUserName = request.userName.ToUpper();
            existingUser.Email = request.email;
            existingUser.NormalizedEmail = request.email.ToUpper();
            existingUser.PasswordHash = hasher.HashPassword(null, request.password);
            var result = await _userManager.UpdateAsync(existingUser);
            return Response.Ok<bool>("Updated Successfully", false, true);

        }
    }
}
