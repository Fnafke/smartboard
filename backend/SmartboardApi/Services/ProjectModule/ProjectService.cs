using SmartboardApi.Models;
using SmartboardApi.Models.ProjectModule;
using SmartboardApi.Repositories.ProjectModule.ProjectRepository;
using SmartboardApi.Services.UserService;

namespace SmartboardApi.Services.ProjectModule
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserService _userService;

        public ProjectService(IProjectRepository projectRepository, IUserService userService) { 
            _projectRepository = projectRepository;
            _userService = userService;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            Project project = await _projectRepository.GetProjectByIdAsync(id);

            if (project == null)
            {
                throw new InvalidOperationException("A project with this ID does not exist.");
            }

            return project;
        }

        public async Task<ICollection<Project>> GetUserProjectsAsync(string username)
        {
            User user = await _userService.GetUserByUsernameAsync(username);

            return user.Projects;
        }

        public async Task<Project> CreateProjectAsync(string name, string description, string username)
        {
            if (name == null) { throw new ArgumentNullException("Project name should not be empty."); }
            if (description == null) { throw new ArgumentNullException("Project description should not be empty."); }

            User user = await _userService.GetUserByUsernameAsync(username);

            Project project = new Project(name, description, user);

            return await _projectRepository.CreateProjectAsync(project);
        }
    }
}
