using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Persistance;
using GMS.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Command.Create
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, CreateGroupCommandResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public CreateGroupCommandHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(_groupRepository.GetGroupByName(request.Name) is not null)
            {
                 throw new DuplicateGroupException();
            }

            Domain.Entites.Group group = new Domain.Entites.Group()
            {
                Name = request.Name,
                Capacity = request.Capacity,
            };

            _groupRepository.AddGroup(group);

            return new CreateGroupCommandResponse();
        }


    }
}
