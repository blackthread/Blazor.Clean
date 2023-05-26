
using Blazor.Clean.Application.Features.LeaveType.Command.CreateToDoItem;
using Blazor.Clean.Application.Features.LeaveType.Command.DeleteToDoItem;
using Blazor.Clean.Application.Features.LeaveType.Commands.UpdateToDoItem;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blazor.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ToDoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoItemsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<ToDoItemsController>
        [HttpGet]
        public async Task<List<ToDoItemDto>> Get()
        {
            var toDoItems = await _mediator.Send(new GetToDoItemsQuery());
            return toDoItems;
        }

        // GET api/<ToDoItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDto>> Get(int id)
        {
            var toDoItem = await _mediator.Send(new GetToDoItemDetailsQuery(id));
            return Ok(toDoItem);
        }

        // POST api/<ToDoItemsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateToDoItemCommand toDoItem)
        {
            var response = await _mediator.Send(toDoItem);
            return CreatedAtAction(nameof(Get), new {id = response});
        }

        // PUT api/<ToDoItemsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateToDoItemCommand toDoItem)
        {
            await _mediator.Send(toDoItem);
            return NoContent();
        }

        // DELETE api/<ToDoItemsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteToDoItemCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
