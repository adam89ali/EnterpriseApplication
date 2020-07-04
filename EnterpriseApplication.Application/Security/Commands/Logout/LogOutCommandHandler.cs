using EnterpriseApplication.Application.Security.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.Logout
{
    public class LogOutCommand : IRequest<bool> { };
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, bool>
    {
        private readonly IApplicationUserService _applicationUserService;
        public LogOutCommandHandler(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public  Task<bool> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_applicationUserService.LogOut());
        }
    }
}
