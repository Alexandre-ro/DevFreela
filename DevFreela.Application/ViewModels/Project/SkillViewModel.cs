namespace DevFreela.Application.ViewModels.Project
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
