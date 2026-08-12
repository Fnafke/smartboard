namespace SmartboardApi.Controllers.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserDTO(Guid id, string username, string email, DateTime createdAt)
        {
            Id = id;
            Username = username;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}
