using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageRoles.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageRoles.Commands.AddRole
{
    class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Response<Guid>>
    {
        private readonly IRoleRepository _repository;
        public AddRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Guid>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.AddRole(request);
            return Response.Ok<Guid>("Saved Successfully", false, result);
        }
    }
}
