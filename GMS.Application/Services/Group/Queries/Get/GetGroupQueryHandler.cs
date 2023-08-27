using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Queries.Get
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQueryRequest, GetGroupQueryResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupQueryHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<GetGroupQueryResponse> Handle(GetGroupQueryRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var group = _groupRepository.GetGroupByName(request.name);

            if (group is null)
            {
                throw new GroupDoesntExistException();
            }

            return new GetGroupQueryResponse(group);
        }
    }
}
