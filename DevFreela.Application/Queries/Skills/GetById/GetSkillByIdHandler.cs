using DevFreela.Application.ViewModels.Project;
using DevFreela.CORE.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
    {
        private readonly ISkillRepository _repository;

        public GetSkillByIdHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetByIdAsync(request.Id);

            if (skill == null) return null;

            var skillViewModel = new SkillViewModel(skill.Id, skill.Description);

            return skillViewModel;
        }
    }
}
