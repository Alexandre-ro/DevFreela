using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {

        private readonly DevFreelaDbContext _context;

        public SkillService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _context.Skills;

            var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description))
                                        .ToList();

            return skillsViewModel;
        }
    }
}
