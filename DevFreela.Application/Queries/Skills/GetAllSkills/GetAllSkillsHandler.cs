using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _context.Skills;

            var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description))
                                        .ToList();

            return skillsViewModel;
        }
    }
}
