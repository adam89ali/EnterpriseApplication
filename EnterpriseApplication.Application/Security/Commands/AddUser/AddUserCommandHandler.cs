using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _repository;
        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<Guid>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.AddUser(request).Result;
            return Task.FromResult(Response.Ok<Guid>("Saved Successfully", false, result));
        }
    }
}
