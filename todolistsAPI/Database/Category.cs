using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todolistsAPI.Database
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        [JsonIgnore]
        public List<TodoList> TodoList { get; set; }
    }
}
