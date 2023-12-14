using DevFreela.Application.InputModels.Project;
using DevFreela.Application.ViewModels.Project;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailViewModel GetById(int id);
        int Create(NewProjectViewModel inputViewModel);
        void Update(UpdateProjectViewModel inpytViewModel);
        void Delete(int id);
        void CreateComment(CreateCommentViewModel createCommentViewModel);
        void Start(int id);
        void Finish(int id);
    }
}
