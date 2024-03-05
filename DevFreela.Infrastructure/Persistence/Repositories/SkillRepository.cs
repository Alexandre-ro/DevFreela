using DevFreela.Core.Entities;
using DevFreela.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(s => s.Id == id);

            return skill;
        }
    }
}
