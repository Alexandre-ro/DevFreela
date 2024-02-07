using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandller : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _context;

        public UpdateProjectCommandHandller(DevFreelaDbContext context)
        {
            _context = context;
        }       

        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCoast);

            await _context.SaveChangesAsync();

            return project.Id;
        }
    }
}
