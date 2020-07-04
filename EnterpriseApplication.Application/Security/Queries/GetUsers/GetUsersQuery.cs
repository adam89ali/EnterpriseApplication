using EnterpriseApplication.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<Response<IList<UserDto>>>
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }

    }
}
