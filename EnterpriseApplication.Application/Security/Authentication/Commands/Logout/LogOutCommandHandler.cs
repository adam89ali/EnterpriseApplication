using EnterpriseApplication.Application.Security.Authentication.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Authentication.Commands.Logout
{
    public class LogOutCommand : IRequest<bool> { };
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, bool>
    {
        private readonly IAuthenticationRepository _applicationUserService;
        public LogOutCommandHandler(IAuthenticationRepository applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public  Task<bool> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_applicationUserService.LogOut());
        }
    }
}
