using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todolistsAPI.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public List<TodoList> TodoLists { get; set; }
    }
}
