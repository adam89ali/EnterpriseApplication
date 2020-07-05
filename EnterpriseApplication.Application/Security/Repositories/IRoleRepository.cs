using EnterpriseApplication.Application.Security.Commands.AddRole;
using EnterpriseApplication.Application.Security.Commands.DeleteRole;
using EnterpriseApplication.Application.Security.Commands.EditRole;
using EnterpriseApplication.Application.Security.Queries.GetRoles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Repositories
{
    public interface IRoleRepository
    {
        public IList<RoleDto> GetRoles(GetRoleQuery query);
        public RoleDto GetRoleById(GetRoleByIdQuery query);
        public Task<Guid> AddRole(AddRoleCommand command);
        public Task<bool> EditRole(EditRoleCommand command);
        public Task<bool> DeleteRole(DeleteRoleCommand command);
    }
}
