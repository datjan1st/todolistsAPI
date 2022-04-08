namespace todolistsAPI.DTOs
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public List<TodoListResponseDTO> TodoListDTOs { get; set; }
        
    }
}
