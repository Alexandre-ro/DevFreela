namespace DevFreela.Application.InputModels.Project
{
    public class NewProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCoast { get; set; }
    }
}
