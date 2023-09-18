using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.Models.Repositories;

namespace SimpleCRUD.Controllers
{
	public class TodoController : Controller
	{
		private readonly ITodoRepository todoRepository;

		public TodoController(ITodoRepository todoRepository)
		{
			this.todoRepository = todoRepository;
		}
		public IActionResult Index()
		{
			var todos = this.todoRepository.GetAllTodos();
			return View(todos);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Todo todo)
		{
			todo.CreatedAt = DateTime.Now;
			todo.UpdateAt = DateTime.Now;
			var createdTodo = this.todoRepository.AddTodo(todo);
			return RedirectToAction("Index");
		}

		public IActionResult Remove(Guid id)
		{
			this.todoRepository.DeleteTodo(id);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			var todo = this.todoRepository.GetTodo(id);
			return View(todo);
		}

		[HttpPost]
		public IActionResult Edit(Todo todo)
		{

			this.todoRepository.EditTodo(todo);

			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			var todo = this.todoRepository.GetTodo(id);
			return View(todo);
		}

	}
}
