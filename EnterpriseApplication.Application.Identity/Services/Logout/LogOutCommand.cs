using EnterpriseApplication.Application.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Identity.Services.Logout
{
    public class LogOutCommand : IRequest<bool> { };

    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, bool>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LogOutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
           await _signInManager.SignOutAsync();
            return true;
        }
    }

}
