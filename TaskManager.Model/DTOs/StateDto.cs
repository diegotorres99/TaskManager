namespace TaskManager.Model.DTOs
{
    public class StateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public StateDto()
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
