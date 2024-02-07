using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllProjectsHandler(DevFreelaDbContext context)
        {
            _context = context; 
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _context.Projects;

            var projectsViewModel = await projects
                                    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                                    .ToListAsync();

            return projectsViewModel;
        }
    }
}
