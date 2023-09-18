namespace SimpleCRUD.Models.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		private TodoDBContext todoDBContext;

		public TodoRepository(TodoDBContext todoDBContext)
		{
			this.todoDBContext = todoDBContext;
		}

		public Todo AddTodo(Todo todo)
		{
			this.todoDBContext.Add(todo);
			this.todoDBContext.SaveChanges();
			return todo;
		}

		public void DeleteTodo(Guid id)
		{
			var todo = this.todoDBContext.Todo.Find(id);

			if (todo == null)
			{
				Console.WriteLine("Nothing to delete, id is null here in the DeleteTodo()");
				return;
			}

			this.todoDBContext.Todo.Remove(todo);
			this.todoDBContext.SaveChanges();
		}

		public void EditTodo(Todo todo)
		{
			var existingTodo = this.todoDBContext.Todo.Find(todo.Id);

			existingTodo.Title = todo.Title;
			existingTodo.Content = todo.Content;
			existingTodo.UpdateAt = DateTime.Now;
			this.todoDBContext.SaveChanges();
		}

		public IEnumerable<Todo> GetAllTodos()
		{
			return todoDBContext.Todo.ToList();
		}

		public Todo GetTodo(Guid id)
		{
			return todoDBContext.Todo.Find(id);
		}
	}
}
