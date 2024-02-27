using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Skills.GetById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public GetSkillByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }       

        public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(s => s.Id == request.Id);

            if (skill == null) return null;

            var skillViewModel = new SkillViewModel(skill.Id, skill.Description);

            return skillViewModel;
        }
    }
}
