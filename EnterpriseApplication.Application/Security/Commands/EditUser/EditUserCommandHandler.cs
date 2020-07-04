using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Response<bool>>
    {
        private readonly IUserRepository _repository;
        public EditUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
             _repository.EditUser(request);
            return Task.FromResult(Response.Ok<bool>("Updated Successfully", false, true));
        }
    }
}
