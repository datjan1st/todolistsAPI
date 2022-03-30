using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todolistsAPI.Entities
{
    public class TodoList
    {
        public int UserId { get; set; }

        [Key]
        public int Number { get; set; }

        public int TodoListId { get; set; }

        public int TaskId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public List<Category> Categories { get; set; }
    }
}
