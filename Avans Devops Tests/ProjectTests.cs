using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl.Factory;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Avans_Devops_Tests
{
    public class ProjectTests
    {
        [Fact]
        public void Als_gebruiker_wil_ik_een_project_kunnen_aanmaken()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            //Assert

            Assert.Equal(productOwner, project.GetProductOwner());
            Assert.Equal("Kramse", project._Name);
        }

        [Fact]
        public void Als_product_owner_wil_ik_leden_kunnen_toevoegen()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.AddDeveloper(productOwner, developer);
            //Assert
            Assert.Single(project.GetDevelopers());
        }

        [Fact]
        public void Als_project_lid_wil_ik_een_item_kunnen_toevoegen_aan_product_backlog()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.AddDeveloper(productOwner, developer);

            project.AddItemToProjectBackLog("Item1", "Testing item creation");
            //Assert
            Assert.Single(project.GetBacklog());
            //TEST STORYPOINTS
            //Assert.Equal(5, project.GetBacklog()[0].StoryPoints);
        }
    }
}