using DevFreela.Application.ViewModels.Project;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailViewModel>
    {
        public int Id { get; private set; }

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
