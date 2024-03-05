using DevFreela.Core.Entities;

namespace DevFreela.CORE.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(int id);
    }
}
