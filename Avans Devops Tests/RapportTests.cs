using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Rapport.Document.Document;
using Avans_DevOps.Rapport.Document.Parts;
using Avans_DevOps.Rapport.RapportFactory;
using Avans_DevOps.Sprints;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl.Factory;
using Moq;
using Avans_DevOps.VersionControl;
using Avans_DevOps.VersionControl.Strategies;

namespace Avans_Devops_Tests
{
    public class RapportTests
    {
        [Fact]
        public void Als_gebruiker_wil_ik_een_rapport_kunnen_genereren()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var pipeline = new Pipeline("Pipeline1");
            var productOwner = new ProductOwner("Jelmer");
            var scrumMaster = new ScrumMaster("Quincy");
            var dateStart = DateOnly.Parse("23-03-2024");
            var dateEnd = DateOnly.Parse("24-03-2024");
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            var sprint = new ReleaseSprint("ReleaseTest", dateStart, dateEnd, project, pipeline, project.GetVersionController(), scrumMaster, project.GetForum());
            var rapportFactory = new RapportFactory();

            //Act
            var footer = new Footer("<>< Fish", "Progres rapport", "Kramse", "1.0", new DateOnly(2024, 1, 24));
            var header = new Header("<>< Fish", "Progres rapport", "Kramse", "1.0", new DateOnly(2024, 1, 24));
            var body = new Body();
            body.AddSprint(sprint);

            string pdfRapport = rapportFactory.CreateRapport(footer, header, body, RapportTypes.PDF);

            //Assert
            Assert.IsType<string>(pdfRapport);
        }

        [Fact]
        public void GitStrategy_methods_kunnen_gecalled_worden()
        {
            //Arrange
            var gitStrategy = new GitStrategy();

            //Act
            gitStrategy.Branch("New branch");
            gitStrategy.Branch("New branch");
            gitStrategy.Pull("New branch");
            gitStrategy.Branch("Second branch");
            gitStrategy.Push();
            gitStrategy.Checkout("New branch");
            gitStrategy.Commit("New changes");
            gitStrategy.ListCommitsForRepository("New branch", RepoTypes.Local);

            //Assert
            Assert.NotEmpty(gitStrategy._remoteRepository.Values);
        }


    }
}
