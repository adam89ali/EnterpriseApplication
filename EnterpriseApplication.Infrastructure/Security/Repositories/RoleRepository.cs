using EnterpriseApplication.Application.Security.Commands.AddRole;
using EnterpriseApplication.Application.Security.Commands.DeleteRole;
using EnterpriseApplication.Application.Security.Commands.EditRole;
using EnterpriseApplication.Application.Security.Queries.GetRoles;
using EnterpriseApplication.Application.Security.Repositories;
using EnterpriseApplication.Infrastructure.Security.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Infrastructure.Security.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Guid> AddRole(AddRoleCommand command)
        {
            var roleId = Guid.NewGuid();
            var newRole = new ApplicationRole
            {
                Id = roleId,
                Name = command.role,
                NormalizedName = command.role.ToUpper()
            };
            var result = await _roleManager.CreateAsync(newRole);
            return roleId;
        }

        public async Task<bool> DeleteRole(DeleteRoleCommand command)
        {
            var existingRole = await _roleManager.FindByIdAsync(command.roleId.ToString());
            var result = await _roleManager.DeleteAsync(existingRole);
            return result.Succeeded;
        }

        public async Task<bool> EditRole(EditRoleCommand command)
        {
            var existingRole = await _roleManager.FindByIdAsync(command.roleId.ToString());
            existingRole.Name = command.role;
            existingRole.NormalizedName = command.role.ToUpper();
            var result = await _roleManager.UpdateAsync(existingRole);
            return result.Succeeded;
        }

        public RoleDto GetRoleById(GetRoleByIdQuery query)
        {
            var result = _roleManager.Roles
                .Where(x => x.Id == query.roleId)
                .Select(p => new RoleDto { roleId = p.Id, role = p.Name })
                .FirstOrDefault();
            return result;
        }

        public IList<RoleDto> GetRoles(GetRoleQuery query)
        {
            var result = _roleManager.Roles
                .Where(x => (query.roleId == Guid.Empty || x.Id == query.roleId) &&
                  (String.IsNullOrEmpty(query.role) || x.Name == query.role))
                .Select(p => new RoleDto { roleId = p.Id,role = p.Name })    
                .ToList();
            return result;
        }
    }
}
