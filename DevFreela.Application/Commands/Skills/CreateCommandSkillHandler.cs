using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Skills
{
    public class CreateCommandSkillHandler : IRequestHandler<CreateSkillCommand, int>
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
