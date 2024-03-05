using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProjet
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _repository.CancelProjectAsync(request.Id);

            return Unit.Value;
        }
    }
}
