using Application.CQRS.Command.TodoItems;
using Application.CQRS.Query.TodoItems;
using Microsoft.AspNetCore.Mvc;

using Domain.Models;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private const string DeleteKey = "123456789";
        
        private readonly IMediator _mediator;

        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetAllTodoItemsQuery() { PageNr = pageNr, PageSize = pageSize});

            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTodoItemByIdQuery() { Id = id });
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody]CreateTodoItemCommand newTodoItem)
        {
            return Created("", await _mediator.Send(newTodoItem));
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateTodoItem([FromBody]UpdateTodoItemCommand updatedTodoItem)
        {
            await _mediator.Send(updatedTodoItem);
            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodoItem(int id, [FromHeader(Name = "X-AccessKey")] string key)
        {
            if (key != DeleteKey)
                return Unauthorized();
            
            await _mediator.Send(new DeleteTodoItemCommand() { Id = id });
            return NoContent();
        }
    }
}
