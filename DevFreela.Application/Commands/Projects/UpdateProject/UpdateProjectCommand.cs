using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCoast { get; set; }
    }
}
