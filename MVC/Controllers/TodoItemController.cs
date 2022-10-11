using Application.CQRS.Query.TodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly IMediator _mediator;

        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: TodoItem
        public async Task<ActionResult> Index()
        {
            ViewBag.TodoItems = await _mediator.Send(new GetAllTodoItemsQuery() { PageNr = 1, PageSize = 10});

            return View();
        }
    }
}