namespace SmartboardApi.Modules.AuthModule.Controllers.DTO
{
    public class AuthenticationResponse
    {
        public string Token {  get; set; }
        public string Username { get; set; }
        public string Message { get; set; } = "Successfully authenticated! Welcome!";

        public AuthenticationResponse(string token, string username)
        {
            Token = token;
            Username = username;
        }
    }
}
