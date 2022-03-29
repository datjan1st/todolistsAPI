using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todolistsAPI.Database
{
    public class TodoList
    {
        public int UserId { get; set; }
        [Key]
        public int number { get; set; }
        public int TodoListId { get; set; }
        public int TaskId { get; set; }
        [JsonIgnore]
        public string CategoryName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public Users User { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; }
    }
}
