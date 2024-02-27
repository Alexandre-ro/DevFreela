using DevFreela.Application.ViewModels.Project;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetById
{
    public class GetSkillByIdQuery : IRequest<SkillViewModel>
    {
        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
