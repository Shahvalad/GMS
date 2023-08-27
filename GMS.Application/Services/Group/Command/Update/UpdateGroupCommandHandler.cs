using AutoMapper;
using GMS.Application.Common.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Command.Update
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommandRequest, UpdateGroupCommandResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public UpdateGroupCommandHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGroupCommandResponse> Handle(UpdateGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var updatedGroup = _groupRepository.UpdateGroup(request.name, request.NewName, request.newCapacity);

            return new UpdateGroupCommandResponse();
        }
    }
}
