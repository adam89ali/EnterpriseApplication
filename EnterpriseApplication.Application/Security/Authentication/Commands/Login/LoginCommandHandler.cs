using EnterpriseApplication.Application.Security.Authentication.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IAuthenticationRepository _applicationUserService;
        public LoginCommandHandler(IAuthenticationRepository applicationUserService)
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
