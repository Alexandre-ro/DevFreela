using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public GetProjectByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectDetailViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                                    .Include(p => p.Client)
                                    .Include(p => p.Freelancer)
                                    .SingleOrDefaultAsync(p => p.Id == request.Id);

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
