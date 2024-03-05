using DevFreela.Application.ViewModels.Project;
using DevFreela.CORE.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _repository;

        public GetAllSkillsHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll();

            var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description))
                                        .ToList();

            return skillsViewModel;
        }
    }
}
