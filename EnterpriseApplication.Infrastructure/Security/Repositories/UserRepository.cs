using AutoMapper.QueryableExtensions;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.AddUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.DeleteUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.EditUser;
using EnterpriseApplication.Application.Security.ManageUsers.Queries.GetUsers;
using EnterpriseApplication.Application.Security.ManageUsers.Repositories;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Infrastructure.Security.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IList<UserDto> GetUsers(GetUsersQuery query)
        {
            var result = _userManager.Users
                  .Where(x => (query.userId == Guid.Empty || x.Id == query.userId) &&
                  (String.IsNullOrEmpty(query.userName) || x.UserName == query.userName) &&
                  String.IsNullOrEmpty(query.email) || x.Email == query.email)
                  .Select(p => new UserDto { userId = p.Id, userName = p.UserName, email = p.Email})
                  .ToList();
            
            return result;
        }
        public UserDto GetUserById(GetUserByIdQuery query)
        {
            var result = _userManager.Users
                  .Where(x => x.Id == query.userId)
                  .Select(p => new UserDto { userId = p.Id, userName = p.UserName, email = p.Email })
                  .FirstOrDefault();

            return result;
        }
        public async Task<Guid> AddUser(AddUserCommand command)
        {
            var userId = Guid.NewGuid();
            var newUser = new ApplicationUser { Id = userId, UserName = command.userName,NormalizedUserName = command.userName.ToUpper(), Email = command.email, NormalizedEmail = command.email.ToUpper(), 
                EmailConfirmed = true,SecurityStamp = string.Empty};
           var result =  await _userManager.CreateAsync(newUser, command.password);    
            return userId;
        }
        public async Task<bool> DeleteUser(DeleteUserCommand command)
        {
            var existingUser = await _userManager.FindByIdAsync(command.userId.ToString());
            var result = await _userManager.DeleteAsync(existingUser);
            return result.Succeeded;
        }
        public async Task<bool> EditUser(EditUserCommand command)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var existingUser = await _userManager.FindByIdAsync(command.userId.ToString());
            existingUser.UserName = command.userName;
            existingUser.NormalizedUserName = command.userName.ToUpper();
            existingUser.Email = command.email;
            existingUser.NormalizedEmail = command.email.ToUpper();
            existingUser.PasswordHash = hasher.HashPassword(null, command.password);
            var result = await _userManager.UpdateAsync(existingUser);
            return result.Succeeded;
        }
    }
}
