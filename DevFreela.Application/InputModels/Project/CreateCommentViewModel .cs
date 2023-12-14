namespace DevFreela.Application.InputModels.Project
{
    public class CreateCommentViewModel
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }        
    }
}
