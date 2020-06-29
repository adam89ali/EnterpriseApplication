using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserDto>>
    {
        private readonly IUserRepository _repository;
        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<IList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _repository.GetUsers(request);
            //var users = new List<UserDto>();
            //users.Add(new UserDto { UserName = "adam", Email = "test@gmail.com", Password = "12345" });
            return Task.FromResult(users);
        }
    }
}
