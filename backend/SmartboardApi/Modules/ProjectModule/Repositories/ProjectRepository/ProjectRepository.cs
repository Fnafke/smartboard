using SmartboardApi.Data;
using SmartboardApi.Modules.ProjectModule.Models;

namespace SmartboardApi.Modules.ProjectModule.Repositories.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SmartboardDBContext _dbcontext;

        public ProjectRepository(SmartboardDBContext dbcontext) { _dbcontext = dbcontext; }

        public async Task<Project?> GetProjectByIdAsync(Guid id)
        {
            return await _dbcontext.Projects.FindAsync(id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            _dbcontext.Projects.Add(project);
            await _dbcontext.SaveChangesAsync();
            return project;
        }
    }
}
