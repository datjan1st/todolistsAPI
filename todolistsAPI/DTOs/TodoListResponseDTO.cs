namespace todolistsAPI.DTOs
{
    public class TodoListResponseDTO
    {
        public int UserId { get; set; }
        public int Number { get; set; }

        public int TodoListId { get; set; }

        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
