using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageUsers.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageUsers.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _repository;
        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Guid>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.AddUser(request);
            return Response.Ok<Guid>("Saved Successfully", false, result);
        }
    }
}
