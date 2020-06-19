using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseApplication.Application.Security.Commands.Login;
using EnterpriseApplication.Application.Security.Commands.Logout;
using EnterpriseApplication.UI.Models.AccountSecurity;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApplication.UI.Controllers
{
    [Authorize]
    public class AccountSecurityController : AbstractController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginCommand command)
        {           
                var result = await Mediator.Send(command);
                if (result)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return View(command);                 
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logout()
        {
             Mediator.Send(new LogOutCommand());
            return RedirectToAction("Login", "AccountSecurity");
        }
    }
}