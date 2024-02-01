using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _context.Projects;

            var projectsViewModel = projects
                                    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                                    .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _context.Projects
                                    .Include(p => p.Client)
                                    .Include(p => p.Freelancer)
                                    .SingleOrDefault(p => p.Id == id);

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


        public int Create(NewProjectInputModel inputViewModel)
        {
            var project = new Project(inputViewModel.Title,
                                      inputViewModel.Description,
                                      inputViewModel.IdClient,
                                      inputViewModel.IdFreelancer,
                                      inputViewModel.TotalCoast);

            _context.Projects.Add(project);
            _context.SaveChanges();

            return project.Id;
        }


        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCoast);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
            _context.SaveChanges();
        }

        public void CreateComment(CreateCommentInputModel inputViewModel)
        {
            var comment = new ProjectComment(inputViewModel.Content,
                                             inputViewModel.IdUser,
                                             inputViewModel.IdProject);

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
            _context.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
            _context.SaveChanges();
        }
    }
}
