namespace DevFreela.Application.ViewModels.Project
{
    public class ProjectDetailViewModel
    {
        public ProjectDetailViewModel(int id, string title, string description, DateTime? startedAt, DateTime? finishedAt)
        {
            Id          = id;
            Title       = title;
            Description = description;
            StartedAt   = startedAt;
            FinishedAt  = finishedAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
    }
}
