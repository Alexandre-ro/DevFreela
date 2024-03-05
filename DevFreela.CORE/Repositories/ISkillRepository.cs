using DevFreela.Core.Entities;

namespace DevFreela.CORE.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll();
        Task<Skill> GetById(int id);
    }
}
