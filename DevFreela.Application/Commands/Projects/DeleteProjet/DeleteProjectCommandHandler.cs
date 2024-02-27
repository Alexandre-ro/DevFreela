using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProjet
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;

        public DeleteProjectCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Cancel();
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
