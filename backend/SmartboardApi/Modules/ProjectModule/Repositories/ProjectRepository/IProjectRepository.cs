using SmartboardApi.Modules.ProjectModule.Models;

namespace SmartboardApi.Modules.ProjectModule.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<Project?> GetProjectByIdAsync(Guid id);
        Task<Project> CreateProjectAsync(Project project);
    }
}
