using GMS.Application.Services.Group.Command.Create;
using GMS.Application.Services.Group.Command.Remove;
using GMS.Application.Services.Group.Command.Update;
using GMS.Application.Services.Group.Queries.Get;
using GMS.Application.Services.Group.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllGroupsQueryRequest();

            var group = await _mediator.Send(query);

            return Ok(group);
        }

        [HttpPost]
        [Route("GetByName")]
        public async Task<IActionResult> GetGroupByName(GetGroupQueryRequest request)
        {
            var query = new GetGroupQueryRequest(request.name);

            var group = await _mediator.Send(query);

            return Ok(group);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateGroup(CreateGroupCommandRequest request)
        {
            var command = new CreateGroupCommandRequest(request.Name, request.Capacity);
            
            await _mediator.Send(command);

            return CreatedAtAction("GetGroupByName", new { Name = request.Name, Capacity = request.Capacity});
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateGroup(UpdateGroupCommandRequest request)
        {

            var command = new UpdateGroupCommandRequest(request.name, request.NewName, request.newCapacity);

            var group = await _mediator.Send(command);

            return Ok(group);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> RemoveGroup(RemoveGroupCommandRequest request)
        {
            var command = new RemoveGroupCommandRequest(request.name);

            await _mediator.Send(command);

            return Ok();
        }

    }
}
