﻿using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

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
                                    .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                                    .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            var projectViewModel = new ProjectDetailViewModel(
                                    project.Id,
                                    project.Title,
                                    project.Description,
                                    project.StartedAt,
                                    project.FinishedAt);

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

            return project.Id;
        }


        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCoast);
        }

        public void Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
        }

        public void CreateComment(CreateCommentInputModel inputViewModel)
        {
            var comment = new ProjectComment(inputViewModel.Content,
                                             inputViewModel.IdUser,
                                             inputViewModel.IdProject);

            _context.Comments.Add(comment);
        }

        public void Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
        }

        public void Finish(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
        }
    }
}
