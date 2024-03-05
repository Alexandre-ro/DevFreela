﻿using DevFreela.Core.Entities;
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

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }


        public async Task<Project> GetById(int id) 
        {
            var project = await _context.Projects
                                  .Include(p => p.Client)
                                  .Include(p => p.Freelancer)
                                  .SingleOrDefaultAsync(p => p.Id == id);

            return project;

        }
    }
}
