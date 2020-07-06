using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageUsers.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(r => r.userName).NotEmpty();
            RuleFor(r => r.password).NotEmpty().Length(4);
            RuleFor(r => r.email).NotEmpty().EmailAddress();
        }
    }
}
