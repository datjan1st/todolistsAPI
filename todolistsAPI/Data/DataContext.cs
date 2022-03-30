using Microsoft.EntityFrameworkCore;
using todolistsAPI.Entities;

namespace todolistsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
