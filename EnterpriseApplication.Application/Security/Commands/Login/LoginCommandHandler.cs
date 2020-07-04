using EnterpriseApplication.Application.Security.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IApplicationUserService _applicationUserService;
        public LoginCommandHandler(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var issLoggedIn =  _applicationUserService.Login(request.userName, request.password, request.rememberMe);
            if (!issLoggedIn) { throw new AuthenticationException("Invalid UserName and Password"); }
            return Task.FromResult(issLoggedIn);
        }
    }
}
