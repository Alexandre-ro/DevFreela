using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailViewModel>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDetailViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project == null) return null;

            var projectViewModel = new ProjectDetailViewModel(
                                    project.Id,
                                    project.Title,
                                    project.Description,
                                    project.StartedAt,
                                    project.FinishedAt,
                                    project.Client.FullName,
                                    project.Freelancer.FullName);

            return projectViewModel;

        }
    }
}
