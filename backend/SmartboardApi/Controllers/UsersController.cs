using Microsoft.AspNetCore.Mvc;
using SmartboardApi.Controllers.DTO;
using SmartboardApi.Models;
using SmartboardApi.Services.UserService;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }


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

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUserAsync(CreateUserDTO dto)
    {
        try
        {
            User user = await _userService.CreateUserAsync(dto.Username, dto.Email, dto.Password);

            UserDTO response = new UserDTO(user.Id, user.Username, user.Email, user.CreatedAt);

            return CreatedAtRoute(nameof(GetUserByIdAsync), new {id = response.Id}, response);
        } catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
