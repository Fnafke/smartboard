using System.ComponentModel.DataAnnotations;

namespace SmartboardApi.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(30)]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required, MinLength(10)]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}