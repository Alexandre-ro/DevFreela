using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Projeto de Gestão Financeira", "Projeto de Gestão Financeira", 1,1,1000),
                new Project("Projeto de Freelancers", "Projeto de Freelancers", 1,1,2000),
                new Project("Projeto de Controle de Estoque", "Projeto de Controle de Estoque", 1,1,3000)
            };

            Users = new List<User>
            {
                new User("Alexandre R Oliveira", "alexandre.ri.oliveira@gmail.com", new DateTime(1984,04,09)),
                new User("Daniel Laurusso", "larusso@gmail.com", new DateTime(1994,04,09)),
                new User("Jhonny" , "jhonny@gmail.com", new DateTime(1974,04,09))
            };

            Skills = new List<Skill>
            {
                new Skill("Outsystems"),
                new Skill("DotNet"),
                new Skill("PHP"),
                new Skill("SQL"),
                new Skill("Javascript"),
                new Skill("Scrum")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> Comments{ get; set; }
    }
}
