namespace todolistsAPI.DTOs
{
    public class ReadDataDTO
    {
        public string CategoryName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int TodoListId { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
