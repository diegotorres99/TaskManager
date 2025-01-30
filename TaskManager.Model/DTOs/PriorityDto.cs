namespace TaskManager.Model.DTOs
{
    public class PriorityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public PriorityDto()
        {
            Id = 0;
            Name = "";
        }
        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
