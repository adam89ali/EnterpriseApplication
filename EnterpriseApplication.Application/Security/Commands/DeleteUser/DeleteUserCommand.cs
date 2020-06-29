using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid userId { get; set; }
    }
}
