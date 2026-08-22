namespace SmartboardApi.Controllers.DTO
{
    public class ProjectDTO
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

        public ProjectDTO(Guid id, string name, string description, DateTime createdAt, Guid userId)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UserId = userId;
        }
    }
}
