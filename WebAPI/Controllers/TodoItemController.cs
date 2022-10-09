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
        
        private readonly CleanCodeArchitectureDbContext _context;

        public TodoItemController(CleanCodeArchitectureDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.TodoItems;
            
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateTodoId(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
        
        [HttpPut]
        public IActionResult UpdateTodoId(TodoItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTodoId(int id, [FromHeader(Name = "X-AccessKey")] string key)
        {
            if (key != DeleteKey)
                return Unauthorized();
            
            TodoItem todoItem = new() { Id = id };
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
