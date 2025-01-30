namespace TaskManager.Model.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserDto()
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
