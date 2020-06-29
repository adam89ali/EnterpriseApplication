using EnterpriseApplication.Application.Security.Commands.AddUser;
using EnterpriseApplication.Application.Security.Commands.DeleteUser;
using EnterpriseApplication.Application.Security.Commands.EditUser;
using EnterpriseApplication.Application.Security.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Repositories
{
    public interface IUserRepository
    {
        public IList<UserDto> GetUsers(GetUsersQuery query);
        public UserDto GetUserById(GetUserByIdQuery query);
        public Task<Guid> AddUser(AddUserCommand command);
        public Task<bool> EditUser(EditUserCommand command);
        public Task<bool> DeleteUser(DeleteUserCommand command);
    }
}
