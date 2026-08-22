using System.ComponentModel.DataAnnotations;

namespace SmartboardApi.Models.ProjectModule;

public class Project
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(30)]
    public string Name { get; set; }

    [Required, MaxLength(255)]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid UserId { get; set; }
    public User User { get; set; }

    protected Project() {}

    public Project(string name, string description, User user)
    {
        Name = name;
        Description = description;
        UserId = user.Id;
        User = user;
    }
}
