using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.UI.Constants;
using EnterpriseApplication.UI.Models.AccountSecurity;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System.Security.Authentication;
using EnterpriseApplication.Application.Identity.Services.Login;
using EnterpriseApplication.Application.Identity.Services.Logout;
using EnterpriseApplication.Application.Identity.Services.Users.Get;
using EnterpriseApplication.Application.Identity.Services.Users.Add;
using EnterpriseApplication.Application.Identity.Services.Users.Edit;
using EnterpriseApplication.Application.Identity.Services.Users.Remove;

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
            ViewBag.InterfaceType = InterfaceType.ADD;
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
            ViewBag.InterfaceType = InterfaceType.EDIT;
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
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            ViewBag.InterfaceType = InterfaceType.REMOVE;
            var result = await Mediator.Send(new GetUserByIdQuery { userId = id });
            return PartialView("AddorEditUser", result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUser(RemoveUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result.Message);
        }

    }
}