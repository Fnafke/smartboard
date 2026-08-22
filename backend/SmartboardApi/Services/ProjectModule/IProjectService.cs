using SmartboardApi.Models.ProjectModule;

namespace SmartboardApi.Services.ProjectModule
{
    public interface IProjectService
    {
        /// <summary>
        /// Fetches a project by the project id.
        /// </summary>
        /// <param name="id">The GUID of the project.</param>
        /// <returns>The Project</returns>
        Task<Project> GetProjectByIdAsync(Guid id);

        /// <summary>
        /// Fetches the project of a user.
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>A Collection of the user's projects.</returns>
        Task<ICollection<Project>> GetUserProjectsAsync(string username);

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="name">The name of the project</param>
        /// <param name="description">The description of the project</param>
        /// <param name="username">The username of the project's owner</param>
        /// <returns>The new project object.</returns>
        Task<Project> CreateProjectAsync(string name, string description, string username);
    }
}
