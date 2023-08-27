using AutoMapper;
using GMS.Application.Services.Group.Command.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GMS.Domain.Entites.Group, UpdateGroupCommandResponse>().ReverseMap();
        }
    }
}
