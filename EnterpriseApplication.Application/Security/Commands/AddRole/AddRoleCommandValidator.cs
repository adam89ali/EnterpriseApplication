using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.AddRole
{
    public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator()
        {
            RuleFor(r => r.role).NotEmpty();
        }
    }
}
