using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl;
using Avans_DevOps.VersionControl.Factory;
using Avans_DevOps.VersionControl.Strategies;
using Moq;
using Avans_DevOps.Items;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints;

namespace Avans_Devops_Tests
{
    public class VersionManagementTests
    {
        [Fact]
        public void Als_gebruiker_wil_ik_versiebeheer_kunnen_gebruiken()
        {
            GitStrategy strategy = new GitStrategy();
            VersionControl versionController = new VersionControl(strategy);


            versionController.CheckOut("feature-userinterface".ToLower());
            versionController.Commit("Small button added");
            versionController.Commit("Large button added");
            versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Local);
            versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);
            versionController.Push();
            versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);
        
            Assert.NotEmpty(strategy._localRepository.Values);
            Assert.NotEmpty(strategy._remoteRepository.Values);

        }

        [Fact]
        public void Als_gebruiker_wil_ik_een_branch_kunnen_aanmaken_bij_een_backlog_item()
        {
            IVersionControlFactory versionControlFactory = new VersionControlFactory();
            GitStrategy strategy = new GitStrategy();
            var sprintFactory = new Mock<ISprintFactory>();
            var pipeline = new Pipeline("Pipeline 1");
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            var scrumMaster = new ScrumMaster("Test");
            var dateStart = DateOnly.Parse("23-03-2024");
            var dateEnd = DateOnly.Parse("24-03-2024");

            //Act & Assert
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory);
            project.AddDeveloper(productOwner, developer);
            var sprint = new ReleaseSprint("ReleaseTest", dateStart, dateEnd, project, pipeline, project.GetVersionController(), scrumMaster, project.GetForum());

            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.AddItemToProjectBackLog("Item1", "Beschrijving");
            
            //Create branch with item
            project.GetSprintByName("ReleaseTest")!.AddItemToSprintBacklog(project.GetBacklog()[0], 1, true);

            //Throw error because branch exists
            //Assert
            Assert.NotEmpty(strategy._localRepository.Values);
        }
    }
}
