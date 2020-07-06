using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.ManageRoles.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.ManageRoles.Queries.GetRoles
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Response<RoleDto>>
    {
        private readonly IRoleRepository _repository;
        public GetRoleByIdQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = _repository.GetRoleById(request);
            return Task.FromResult(Response.Ok<RoleDto>("", false, role));
        }
    }
}
