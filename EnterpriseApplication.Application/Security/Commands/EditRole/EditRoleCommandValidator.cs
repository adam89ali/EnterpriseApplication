using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.EditRole
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.role).NotEmpty();
        }
    }
}
