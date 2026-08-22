using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartboardApi.Modules.ProjectModule.Controllers.DTO;
using SmartboardApi.Modules.ProjectModule.Models;
using SmartboardApi.Modules.ProjectModule.Services.ProjectService;
using System.Security.Authentication;
using System.Security.Claims;

namespace SmartboardApi.Modules.ProjectModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController: ControllerBase
{
    private IProjectService _projectService;

    public ProjectsController(IProjectService projectService) {  _projectService = projectService; }

    // GET ENDPOINTS
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<ICollection<Project>>> GetUserProjectsAsync()
    {
        try
        {
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (username == null)
            {
                throw new AuthenticationException("Token is invalid.");
            }

            return Ok(await _projectService.GetUserProjectsAsync(username));

        } catch (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("{id:guid}", Name = "GetProjectByIdAsync")]
    public async Task<ActionResult<Project>> GetProjectByIdAsync(Guid id)
    {
        try
        {
            Project project = await _projectService.GetProjectByIdAsync(id);

            return Ok(project);

        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST ENDPOINTS
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProjectAsync(CreateProjectDTO dto)
    {
        try
        {
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (username == null)
            {
                throw new AuthenticationException("Token is invalid.");
            }

            Project project = await _projectService.CreateProjectAsync(dto.Name, dto.Description, username);
            return CreatedAtRoute(nameof(GetProjectByIdAsync), new { id = project.Id }, project);
        } catch  (AuthenticationException ex)
        {
            return Unauthorized(ex.Message);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
