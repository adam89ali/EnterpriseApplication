using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Common.Constant;
using EnterpriseApplication.Application.Security.ManageRoles.Commands.AddRole;
using EnterpriseApplication.Application.Security.ManageRoles.Commands.DeleteRole;
using EnterpriseApplication.Application.Security.ManageRoles.Commands.EditRole;
using EnterpriseApplication.Application.Security.ManageRoles.Queries.GetRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApplication.UI.Controllers.Security.Role
{
    [Authorize]
    public class RoleController : AbstractController
    {
        [HttpGet]
        public IActionResult ManageRoles()
        {
            //var Roles = await Mediator.Send(new ListAllRolesQuery());
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetRoles(GetRoleQuery query)
        {
            var result = await Mediator.Send(query);
            return Json(result.Data);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            ViewBag.accessMode = AccessMode.ADD;
            return PartialView("AddorEditRole");
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            ViewBag.accessMode = AccessMode.EDIT;
            var result = await Mediator.Send(new GetRoleByIdQuery { roleId = id });
            return PartialView("AddorEditRole", result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            ViewBag.accessMode = AccessMode.DELETE;
            var result = await Mediator.Send(new GetRoleByIdQuery { roleId = id });
            return PartialView("AddorEditRole", result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(DeleteRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
    }
}