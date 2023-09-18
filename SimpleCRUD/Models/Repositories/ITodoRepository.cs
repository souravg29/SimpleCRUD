namespace SimpleCRUD.Models.Repositories
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> GetAllTodos();
		Todo GetTodo(Guid id);
		Todo AddTodo(Todo todo);
		void EditTodo(Todo todo);
		void DeleteTodo(Guid id);

	}
}
