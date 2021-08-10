using Microsoft.EntityFrameworkCore;

namespace Todo.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } = default!;

        public DbSet<Author> Authors { get; set; } = default!;

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;
    }
}
