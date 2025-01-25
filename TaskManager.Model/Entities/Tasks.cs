namespace TaskManager.Model.Entities
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
