using EnterpriseApplication.Application.Security.ManageUsers.Commands.AddUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.DeleteUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.EditUser;
using EnterpriseApplication.Application.Security.ManageUsers.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageUsers.Repositories
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
