namespace SmartboardApi.Modules.AuthModule.Controllers.DTO
{
    public class CurrentUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public CurrentUserDto(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
