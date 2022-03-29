using Microsoft.EntityFrameworkCore;
using todolistsAPI.Database;

namespace todolistsAPI.DataCntxt
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {

        }
        public DbSet<Users> user { get; set; }
        public DbSet<TodoList> todoList { get; set; }
        public DbSet<Category> category { get; set; }
    }
}
