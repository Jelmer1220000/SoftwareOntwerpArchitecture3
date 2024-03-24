using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Notifications;

namespace Avans_Devops_Tests
{
    public class ItemTests
    {
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
        }

        [Fact]
        public void Als_project_lid_wil_ik_mezelf_kunnen_toewijzen_aan_een_item()
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
            var item1 = project.GetBacklog()[0];

            item1.ToDoingState(developer);
            //Assert
            Assert.Equal(developer, item1.User);
        }

        [Fact]
        public void Er_kan_maximaal_een_persoon_aan_een_item_gekoppeld_worden()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            var developer2 = new Developer("Extra_Quincy");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.AddDeveloper(productOwner, developer);
            project.AddItemToProjectBackLog("Item1", "Testing item creation");
            var item1 = project.GetBacklog()[0];

            item1.ToDoingState(developer);
            item1.ToDoingState(developer2);
            //Assert
            Assert.Equal(developer, item1.User);
        }

        [Fact]
        public void Als_project_lid_wil_ik_de_fase_van_een_item_kunnen_wijzigen()
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
            var item1 = project.GetBacklog()[0];

            item1.ToDoingState(developer);
            //Assert
            Assert.IsType<DoingState>(item1._itemState);
        }

        [Fact]
        public void Een_item_mag_alleen_naar_done_als_subtaken_af_zijn()
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
            var item1 = project.GetBacklog()[0];

            item1.ToDoingState(developer);

            item1.AddActivity(new Activity("Subtaak", "Niet af"));
            item1.ToDoneState();
            //Assert
            Assert.IsType<DoingState>(item1._itemState);
        }

        [Fact]
        public void Item_moet_terug_naar_todo_als_er_een_fout_is_met_notificatie_naar_Scrummaster()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");

            var notifications = new Mock<ISubject>();
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.AddDeveloper(productOwner, developer);
            project.AddItemToProjectBackLog("Item1", "Testing item creation");
            var item1 = project.GetBacklog()[0];

            item1.InjectNotificationsService(notifications.Object);

            item1.ToTestingState();
            item1._itemState.ToTodo();
            //Assert
            notifications.Verify(s => s.SendScrumMasterUpdate(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void LeadDeveloper_kan_een_getest_item_naar_done_verplaatsen()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var leaddeveloper = new LeadDeveloper("Quincy");
            ;
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.SetLeadDeveloper(leaddeveloper);
            project.AddItemToProjectBackLog("Item1", "Testing item creation");
            var item1 = project.GetBacklog()[0];

            item1.ToTestedState();
            item1._itemState.ToDone(project.GetLeadDeveloper());
            //Assert
            Assert.IsType<DoneState>(item1._itemState);
        }

    }
}
