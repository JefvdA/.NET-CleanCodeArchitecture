using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Contexts;
using Domain.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private const string DeleteKey = "123456789";
        
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            var result = _todoItemService.GetAll(pageNr, pageSize);
            
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
