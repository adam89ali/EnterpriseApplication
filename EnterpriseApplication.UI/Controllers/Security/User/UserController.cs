using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Common.Constant;
using EnterpriseApplication.UI.Models.AccountSecurity;
using EnterpriseApplication.UI.Utilities.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System.Security.Authentication;
using EnterpriseApplication.Application.Security.ManageUsers.Queries.GetUsers;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.AddUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.EditUser;
using EnterpriseApplication.Application.Security.ManageUsers.Commands.DeleteUser;
using EnterpriseApplication.Application.Security.Authentication.Commands.Login;
using EnterpriseApplication.Application.Security.Authentication.Commands.Logout;

namespace EnterpriseApplication.UI.Controllers
{
    [Authorize]
    public class UserController : AbstractController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async  Task<IActionResult> Login(LoginCommand command)
        {           
                await Mediator.Send(command);
                return Json(new { url = Url.Action("index", "home") });  
                // return RedirectToAction("index", "home");             
                // ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                //return View(command);                 
        }
        [AllowAnonymous]
        [HttpPost]
        public async  Task<IActionResult> Logout()
        {
            await Mediator.Send(new LogOutCommand());
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult ManageUsers()
        {
            //var users = await Mediator.Send(new ListAllUsersQuery());
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetUsers(GetUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return Json(result.Data);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.accessMode = AccessMode.ADD;
            return PartialView("AddorEditUser");
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(Guid id)
        {
            ViewBag.accessMode = AccessMode.EDIT;
            var result = await Mediator.Send(new GetUserByIdQuery { userId = id });
            return PartialView("AddorEditUser",result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            ViewBag.accessMode = AccessMode.DELETE;
            var result = await Mediator.Send(new GetUserByIdQuery { userId = id });
            return PartialView("AddorEditUser", result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }

    }
}