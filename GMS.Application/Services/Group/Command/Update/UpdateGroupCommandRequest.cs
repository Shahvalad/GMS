using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Group.Command.Update
{
    public record UpdateGroupCommandRequest(string name, string NewName, int newCapacity) : IRequest<UpdateGroupCommandResponse>;
}
