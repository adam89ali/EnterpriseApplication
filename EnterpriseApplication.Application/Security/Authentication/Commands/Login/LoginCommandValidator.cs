using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Authentication.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.userName).NotEmpty();
            RuleFor(r => r.password).NotEmpty();
        }
    }
}
