using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
             _repository.DeleteUser(request);
            return Task.FromResult(Response.Ok<bool>("Deleted Successfully", false, true));

        }
    }
}
