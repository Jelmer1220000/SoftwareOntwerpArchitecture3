using Avans_DevOps.Forums;
using Avans_DevOps.Items;
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

namespace Avans_Devops_Tests
{
    public class ThreadTests
    {
        [Fact]
        public void Als_gebruiker_wil_ik_een_discussie_kunnen_starten()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);

            var Item = new Item("Item1", "Beschrijving", project, project.GetForum());

            var Thread = new AThread("Nieuwe Thread", "Beschrijving", Item, project.GetForum(), developer);

            //Assert
            Assert.Equal("Nieuwe Thread", Thread.Title);
            Assert.Empty(Thread.Comments);
        }

        [Fact]
        public void Een_item_op_done_mag_geen_thread_comments_meer_krijgen()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            //Act & Assert
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);

            var Item = new Item("Item1", "Beschrijving", project, project.GetForum());

            Item.StartThread("Nieuwe Thread", "Beschrijving", developer);

            Item.ToDoneState();
            var exception = Assert.Throws<InvalidOperationException>(() => Item.Thread._threadState.AddComment(new Comment(developer, "Testing")));
            //Assert

            Assert.Equal("Het is niet mogelijk om een comment toe te voegen aan deze thread", exception.Message);
        }

        [Fact]
        public void Als_gebruiker_wil_ik_kunnen_reageren_op_een_discussie()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            var developer2 = new Developer("Jelmero");
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);

            var Item = new Item("Item1", "Beschrijving", project, project.GetForum());

            var Comment = new Comment(developer, "Reactie1");
            var Comment2 = new Comment(developer2, "comment op comment");

            Item.StartThread("Nieuwe Thread", "Beschrijving", developer);
            Item.Thread.ReactToThread(Comment);
            Item.Thread!.ReactOnComment(Comment, Comment2);
            
            //Assert
            Assert.NotEmpty(Item.Thread.Comments);
            Assert.NotEmpty(Item.Thread.Comments[0].Comments);
        }


    }
}
