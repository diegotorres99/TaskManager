using System;

namespace TaskManager.View.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public int PriorityId { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Username { get; set; }
        public string? StateName { get; set; }
        public string? PriorityName { get; set; }
    }
}
