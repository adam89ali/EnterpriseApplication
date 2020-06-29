using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Common.Constant;
using EnterpriseApplication.Application.Security.Commands.AddUser;
using EnterpriseApplication.Application.Security.Commands.DeleteUser;
using EnterpriseApplication.Application.Security.Commands.Login;
using EnterpriseApplication.Application.Security.Commands.Logout;
using EnterpriseApplication.Application.Security.Commands.EditUser;
using EnterpriseApplication.Application.Security.Queries.GetUsers;
using EnterpriseApplication.UI.Models.AccountSecurity;
using EnterpriseApplication.UI.Utilities.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System.Security.Authentication;

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
        public async Task<IActionResult> Login(LoginCommand command)
        {           
                await Mediator.Send(command);
                return Json(new { url = Url.Action("index", "home") });  
                // return RedirectToAction("index", "home");             
                // ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                //return View(command);                 
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logout()
        {
             Mediator.Send(new LogOutCommand());
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
            return Json(result);
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
            return Ok("Added Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(Guid id)
        {
            ViewBag.accessMode = AccessMode.EDIT;
            var result = await Mediator.Send(new GetUserByIdQuery { userId = id });
            return PartialView("AddorEditUser",result);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok("Updated Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            ViewBag.accessMode = AccessMode.DELETE;
            var result = await Mediator.Send(new GetUserByIdQuery { userId = id });
            return PartialView("AddorEditUser", result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok("Deleted Successfully");
        }

    }
}