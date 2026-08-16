using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartboardApi.Controllers.DTO;
using SmartboardApi.Models;
using SmartboardApi.Services.TokenService;
using SmartboardApi.Services.UserService;
using System.Security.Authentication;
using System.Security.Claims;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET ENDPOINTS

    [Authorize]
    [HttpGet("{id:guid}", Name = "GetUserByIdAsync")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(Guid id)
    {
        try
        {
            User user = await _userService.GetUserByIdAsync(id);

            UserDTO response = new UserDTO(user.Id, user.Username, user.Email, user.CreatedAt);

            return Ok(response);
        
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<UserDTO>> GetCurrentUserAsync()
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (userId == null || username == null)
            {
                throw new AuthenticationException("Token is invalid.");
            }

            return Ok(new CurrentUserDto(Guid.Parse(userId), username));
        } catch (Exception ex)
        {
            return Unauthorized(ex);
        }
    }

    // POST ENDPOINTS

    [HttpPost("signup")]
    public async Task<ActionResult<AuthenticationResponse>> CreateUserAsync(CreateUserDTO dto)
    {
        try
        {
            User user = await _userService.CreateUserAsync(dto.Username, dto.Email, dto.Password);

            AuthenticationResponse response = await _userService.AuthenticateUser(dto.Username, dto.Password);

            Response.Cookies.Append("loggedInUser", response.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(8)
            });

            return CreatedAtRoute(nameof(GetUserByIdAsync), new { id = user.Id }, response);
        } catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        } catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest dto)
    {
        try
        {
            AuthenticationResponse authResponse = await _userService.AuthenticateUser(dto.Email, dto.Password);

            Response.Cookies.Append("loggedInUser", authResponse.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(8)
            });

            return Ok(authResponse);
        } catch (AuthenticationException ex)
        {
            return Unauthorized(ex);
        }
    }
}
