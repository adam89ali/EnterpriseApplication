using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Security.ManageUsers.Queries.GetUsers
{
    public class UserDto
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
    }
}
