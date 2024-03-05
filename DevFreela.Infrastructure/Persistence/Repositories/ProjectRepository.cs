using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
       

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }


        public async Task<Project> GetByIdAsync(int id) 
        {
            var project = await _context.Projects
                                  .Include(p => p.Client)
                                  .Include(p => p.Freelancer)
                                  .SingleOrDefaultAsync(p => p.Id == id);

            return project;

        }

        public async Task<int> CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task<int> UpdateProjectAsync(Project project)
        {
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task CancelProjectAsync(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
            await _context.SaveChangesAsync();
        }

        public async Task<Project> StartProjectAsync(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
           
            project.Start();

            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> FinishProjectAsync(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Finish();

            await _context.SaveChangesAsync();

            return project;
        }
    }
}
