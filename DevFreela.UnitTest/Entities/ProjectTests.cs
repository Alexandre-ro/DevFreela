using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTest.Entities
{
    public class ProjectTests
    {

        [Fact]
        public void TestProjectsStartsWorks() 
        {
            var project = new Project("Teste Unitário","Desc teste",1,1,10000);

            //Testa o status antes de startar o projeto
            Assert.Equal(ProjectStatusEnum.Created, project.Status);

            //Testa a data antes de startar o projeto
            Assert.NotNull(project.Description);
            Assert.NotNull(project.Title);
            Assert.Null(project.StartedAt);

            //Starta o projeto
            project.Start();

            //Testa o status após startar
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status );
            
            //Testa a data após startar
            Assert.NotNull(project.StartedAt);
        }

    }
}
