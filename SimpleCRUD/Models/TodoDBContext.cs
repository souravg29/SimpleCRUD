using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD.Models
{
	public class TodoDBContext : DbContext
	{
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
