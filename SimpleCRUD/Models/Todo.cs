namespace SimpleCRUD.Models
{
	public class Todo
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdateAt { get; set; }
	}
}
