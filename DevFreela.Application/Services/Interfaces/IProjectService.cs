using DevFreela.Application.InputModels.Project;
using DevFreela.Application.ViewModels.Project;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailViewModel GetById(int id);
        int Create(NewProjectInputModel inputViewModel);
        void Update(UpdateProjectInputModel inpytViewModel);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel createCommentViewModel);
        void Start(int id);
        void Finish(int id);
    }
}
