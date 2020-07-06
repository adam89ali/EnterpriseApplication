using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageUsers.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageUsers.Queries.GetUsers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _repository.GetUserById(request);
            return Task.FromResult(Response.Ok<UserDto>("", false, user));

        }
    }
}
