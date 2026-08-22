using SmartboardApi.Models;
using SmartboardApi.Models.ProjectModule;

namespace SmartboardApi.Repositories.ProjectModule.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<Project?> GetProjectByIdAsync(Guid id);
        Task<Project> CreateProjectAsync(Project project);
    }
}
