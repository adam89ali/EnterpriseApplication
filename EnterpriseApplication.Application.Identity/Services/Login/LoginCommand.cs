using EnterpriseApplication.Application.Identity.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Login
{
    public class LoginCommand : IRequest<bool>
    {
        public string userName { get; set; }

        public string password { get; set; }

        public bool rememberMe { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.userName).NotEmpty();
            RuleFor(r => r.password).NotEmpty();
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var result =  await _signInManager.PasswordSignInAsync(request.userName, request.password, request.rememberMe, false);
            if (!result.Succeeded) { throw new AuthenticationException("Invalid UserName and Password"); }
            return true;   
        }
    }
}
