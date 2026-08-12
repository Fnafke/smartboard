using System.ComponentModel.DataAnnotations;

namespace SmartboardApi.Controllers.DTO
{
    public class CreateUserDTO
    {
        [Required, MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(10)]
        public string Password { get; set; } = string.Empty;
    }
}
