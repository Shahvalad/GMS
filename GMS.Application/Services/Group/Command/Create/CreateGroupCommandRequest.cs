using MediatR;

namespace GMS.Application.Services.Group.Command.Create
{
    public record CreateGroupCommandRequest(string Name, int Capacity) : IRequest<CreateGroupCommandResponse>;

}
