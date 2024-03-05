using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommandHandller : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectCommandHandller(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _repository.GetByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.TotalCoast);

            int idProject  = await _repository.UpdateProjectAsync(project);

            return idProject;
        }
    }
}
