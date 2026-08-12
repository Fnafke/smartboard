using SmartboardApi.Models;

namespace SmartboardApi.Controllers.DTO
{
    public class AuthenticationResponse
    {
        public string Token {  get; set; }
        public string Username { get; set; }

        public AuthenticationResponse(string token, string username)
        {
            Token = token;
            Username = username;
        }
    }
}
