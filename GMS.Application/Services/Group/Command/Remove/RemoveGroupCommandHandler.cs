using GMS.Application.Common.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Command.Remove
{
    public class RemoveGroupCommandHandler : IRequestHandler<RemoveGroupCommandRequest, RemoveGroupCommandResponse>
    {
        private readonly IGroupRepository _groupRepository;
        public RemoveGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<RemoveGroupCommandResponse> Handle(RemoveGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _groupRepository.RemoveGroup(request.name);
            return new RemoveGroupCommandResponse();
        }
    }
}
