using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Queries.GetUsers
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid userId { get; set; }
    }
}
