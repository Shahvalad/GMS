using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Queries.GetAll
{
    public record GetAllGroupsQueryRequest() : IRequest<GetAllGroupsQueryResponse>;
}
