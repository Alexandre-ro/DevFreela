using MediatR;

namespace DevFreela.Application.Commands.Skills
{
    public class CreateSkillCommand : IRequest<int>
    {      
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
