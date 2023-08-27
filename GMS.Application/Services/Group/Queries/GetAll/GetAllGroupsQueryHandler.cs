using AutoMapper;
using GMS.Application.Common.Interfaces.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Queries.GetAll
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQueryRequest, GetAllGroupsQueryResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetAllGroupsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetAllGroupsQueryResponse> Handle(GetAllGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var groups = _groupRepository.GetAll();
            
            //List<GroupResponsee> result = new List<GroupResponsee>();
            //foreach (var group in groups)
            //{
            //    var item = new GroupResponsee(group);                 // Manual Mapping
            //    result.Add(item);
            //}

            //Mapping using AutoMapper
            //var result = _mapper.Map<List<UpdateGroupCommandResponse>>(groups);

            return new GetAllGroupsQueryResponse(groups.ToList());

        }
    }
}
