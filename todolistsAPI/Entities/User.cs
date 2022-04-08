using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todolistsAPI.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        
        [JsonIgnore]
        public List<TodoList> TodoLists { get; set; }
    }
}
