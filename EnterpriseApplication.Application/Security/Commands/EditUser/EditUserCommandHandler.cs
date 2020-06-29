using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        public EditUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            return _repository.EditUser(request);
        }
    }
}
