using DevFreela.Application.Commands.Skills;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.Skills
{
    public class CreateCommandSkillHandler
    {
        public readonly DevFreelaDbContext _context;

        public CreateCommandSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

    }
}
