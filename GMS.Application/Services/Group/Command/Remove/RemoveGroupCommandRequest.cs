using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Command.Remove
{
    public record RemoveGroupCommandRequest(string name) : IRequest<RemoveGroupCommandResponse>;
}
