using EnterpriseApplication.Application.Common;
using EnterpriseApplication.Application.Security.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseApplication.Application.Security.Queries.GetRoles
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Response<IList<RoleDto>>>
    {
        private readonly IRoleRepository _repository;
        public GetRoleQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public Task<Response<IList<RoleDto>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = _repository.GetRoles(request);
            return Task.FromResult(Response.Ok<IList<RoleDto>>("", false, roles));
        }
    }
}
