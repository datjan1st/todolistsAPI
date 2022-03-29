using System.ComponentModel.DataAnnotations;

namespace todolistsAPI.Database
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<TodoList> todoLists { get; set; }
    }
}
