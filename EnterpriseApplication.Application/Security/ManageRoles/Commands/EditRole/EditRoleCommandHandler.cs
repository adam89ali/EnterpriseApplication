using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageRoles.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageRoles.Commands.EditRole
{
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, Response<bool>>
    {
        private readonly IRoleRepository _repository;
        public EditRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditRole(request);
            return Response.Ok<bool>("Updated Successfully", false, true);
        }
    }
}
