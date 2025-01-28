namespace TaskManager.Model.DTOs
{
    public class TaskResponseDto
    {
        public List<TaskDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
