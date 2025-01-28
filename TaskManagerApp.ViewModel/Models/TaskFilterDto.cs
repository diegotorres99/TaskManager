namespace TaskManager.ViewModels.Models
{
    public class TaskFilterDto
    {
        public int? UserId { get; set; } 
        public int? StateId { get; set; } 
        public int PriorityId { get; set; } 
        public DateTime? DueDateStart { get; set; } 
        public DateTime? DueDateEnd { get; set; } 
        public int Skip { get; set; } = 0; 
        public int Take { get; set; } = 20; 
        public string SortField { get; set; } = "Id"; 
        public bool SortAscending { get; set; } = true; 
    }
}
