using MediatR;

namespace DevFreela.Application.Commands.Skills
{
    public class CreateSkillCommand : IRequest<int>
    {      
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
