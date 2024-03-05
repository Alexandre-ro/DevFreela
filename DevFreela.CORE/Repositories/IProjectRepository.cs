using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<int> CreateProjectAsync(Project project);
        Task<int> UpdateProjectAsync(Project project);
        Task CancelProjectAsync(int id);
        Task<Project> StartProjectAsync(int id);
        Task<Project> FinishProjectAsync(int id);
    }
}
