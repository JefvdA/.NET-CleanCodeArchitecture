using Application.CQRS.Query.TodoItem;
using Application.Interfaces;
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
        
        private readonly ITodoItemService _todoItemService;
        private readonly IMediator _mediator;

        public TodoItemController(ITodoItemService todoItemService, IMediator mediator)
        {
            _todoItemService = todoItemService;
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
            try
            {
                var result = await _todoItemService.GetById(id);
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult CreateTodoItem(TodoItem item)
        {
            _todoItemService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                await _todoItemService.Update(item);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodoItem(int id, [FromHeader(Name = "X-AccessKey")] string key)
        {
            if (key != DeleteKey)
                return Unauthorized();

            try
            {
                await _todoItemService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}
