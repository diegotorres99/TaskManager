﻿namespace TaskManager.View.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public string? Priority { get; set; } 
        public DateTime DueDate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
