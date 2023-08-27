using GMS.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Queries.Get
{
    public record GetGroupQueryRequest(string name) : IRequest<GetGroupQueryResponse>;
}
