using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Identity.Services.UserRole.GetRoles;
using EnterpriseApplication.Application.Identity.Services.UserRole.GetUsers;
using EnterpriseApplication.Application.Identity.Services.UserRole.Grant;
using EnterpriseApplication.Application.Identity.Services.UserRole.Revoke;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApplication.UI.Controllers.Security.UserRolePermission
{
    [Authorize]
    public class UserRolePermissionController : AbstractController
    {
        [HttpGet]
        public IActionResult RoleWisePermission()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await Mediator.Send(new GetRolesQuery());
            return Json(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetGrantedUsers(GetGrantedUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return Json(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetUnGrantedUsers(GetUnGrantedUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return Json(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> GrantRoleToUsers(GrantRoleToUsersCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> RevokeRoleFromUsers(RevokeRoleFromUsersCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
    }
}