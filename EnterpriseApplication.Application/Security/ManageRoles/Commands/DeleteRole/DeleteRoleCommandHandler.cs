using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageRoles.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageRoles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<bool>>
    {
        private readonly IRoleRepository _repository;
        public DeleteRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteRole(request);
            return Response.Ok<bool>("Deleted Successfully", false, true);
        }
    }
}
