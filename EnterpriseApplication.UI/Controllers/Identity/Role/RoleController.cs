using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Common.Entities;
using EnterpriseApplication.Application.Identity;
using EnterpriseApplication.UI.Constants;
using EnterpriseApplication.Application.Identity.Services.Roles.Add;
using EnterpriseApplication.Application.Identity.Services.Roles.Edit;
using EnterpriseApplication.Application.Identity.Services.Roles.Get;
using EnterpriseApplication.Application.Identity.Services.Roles.Remove;
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
            ViewBag.InterfaceType = InterfaceType.ADD;
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
            ViewBag.InterfaceType = InterfaceType.EDIT;
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
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            ViewBag.InterfaceType = InterfaceType.REMOVE;
            var result = await Mediator.Send(new GetRoleByIdQuery { roleId = id });
            return PartialView("AddorEditRole", result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(RemoveRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
    }
}