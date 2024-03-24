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
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Forums;
using Avans_DevOps.VersionControl;
using Avans_DevOps.Sprints;
using Avans_DevOps.Notifications;
using Avans_DevOps.Visitor;

namespace Avans_Devops_Tests
{
    public class SprintTests
    {
        [Fact]
       public void Als_product_owner_wil_ik_een_sprint_kunnen_aanmaken()
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

            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.SetScrumMaster(scrumMaster);

            //Assert
            Console.WriteLine(project.GetSprintByName("ReleaseTest"));
            Assert.NotNull(project.GetSprintByName("ReleaseTest"));
            Assert.Equal(dateStart, project.GetSprintByName("ReleaseTest")!.StartDate);
            Assert.Equal(dateEnd, project.GetSprintByName("ReleaseTest")!.EndDate);
            Assert.Equal("ReleaseTest", project.GetSprintByName("ReleaseTest")!.Name);
            Assert.Equal(scrumMaster, project.GetScrumMaster());
        }

        [Fact]
        public void Als_project_lid_wil_ik_een_item_kunnen_toevoegen_aan_sprint_backlog()
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

            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.AddItemToProjectBackLog("Item1", "Test item");
            var item = project.GetBacklog()[0];
            sprint.AddItemToSprintBacklog(item, false);
            //Assert

            Assert.Single(sprint._sprintBackLog);
            Assert.Equal("Item1", sprint._sprintBackLog[0].Name);
        }

        [Fact]
        public void Item_kan_niet_worden_toegevoegd_als_sprint_niet_in_planning_fase_zit()
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

            //Act & Assert
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            
            sprint.NextSprintState();
            project.AddItemToProjectBackLog("Item1", "Test item");
            var item = project.GetBacklog()[0];

            var exception = Assert.Throws<InvalidOperationException>(() => sprint.AddItemToSprintBacklog(item, false));
            //Assert

            Assert.NotNull(exception);
            Assert.Equal("Het is niet mogelijk items toe te voegen in deze fase van de sprint.", exception.Message);
        }

        [Fact]
        public void Sprint_mag_alleen_worden_gewijzigd_in_planning_fase()
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

            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            sprint.ChangeProperties("TestRelease", dateStart.AddDays(3), dateEnd.AddDays(4));
            //Assert

            Assert.Equal(dateStart.AddDays(3), sprint.StartDate);
            Assert.Equal(dateEnd.AddDays(4), sprint.EndDate);
            Assert.Equal("TestRelease", sprint.Name);
        }

        [Fact]
        public void Sprint_mag_niet_worden_gewijzigd_wanneer_deze_zich_niet_in_planning_fase_bevindt()
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

            //Act & Assert
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());

            sprint.NextSprintState();
            project.AddItemToProjectBackLog("Item1", "Test item");
            var item = project.GetBacklog()[0];

            sprint.NextSprintState();

            var exception = Assert.Throws<InvalidOperationException>(() => sprint.ChangeProperties("TestRelease", dateStart.AddDays(3), dateEnd.AddDays(4)));
            //Assert
            Assert.NotNull(exception);
            Assert.Equal("Het is niet mogelijk een sprint aan te passen in deze fase van de sprint.", exception.Message);
        }

        [Fact]
        public void Review_sprint_verwacht_een_review_voor_deze_naar_closed_gaat()
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
            var sprint = new ReviewSprint("ReleaseTest", dateStart, dateEnd, project, pipeline, project.GetVersionController(), scrumMaster, project.GetForum());
            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReviewSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReviewSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.SetScrumMaster(scrumMaster);

            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.NextSprintState();

            byte[] review = { 0x20, 0x20, 0x20, 0x20 };
            sprint.UploadReview(scrumMaster, review);

            //Assert
            Assert.Equal(sprint.reviewFile, review);
          
        }

        [Fact]
        public void Pipeline_wordt_gerunt_zodra_releaseSprint_naar_finished_gaat()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var pipeline = new Mock<Pipeline>("Pipeline 1");
            var productOwner = new ProductOwner("Jelmer");
            var scrumMaster = new ScrumMaster("Quincy");
            var dateStart = DateOnly.Parse("23-03-2024");
            var dateEnd = DateOnly.Parse("24-03-2024");
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            var sprint = new ReleaseSprint("ReleaseTest", dateStart, dateEnd, project, pipeline.Object, project.GetVersionController(), scrumMaster, project.GetForum());
            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline.Object, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);
            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline.Object, project.GetForum());
            project.SetScrumMaster(scrumMaster);

            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.NextSprintState();

            sprint.RunPipeline(scrumMaster, false);

            //Assert
            Assert.NotNull(sprint.Pipeline);
           
            pipeline.Verify(p => p.AcceptVisitor(It.IsAny<PipelineVisitor>()), Times.Once);
        }

        [Fact]
        public void ScrumMaster_krijgt_notificatie_zodra_pipeline_faalt()
        {
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var notificationMock = new Mock<ISubject>();
            var pipeline = new Pipeline("Pipeline1");
            var productOwner = new ProductOwner("Jelmer");
            var scrumMaster = new ScrumMaster("Quincy");
            var dateStart = DateOnly.Parse("23-03-2024");
            var dateEnd = DateOnly.Parse("24-03-2024");
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            var sprint = new ReleaseSprint("ReleaseTest", dateStart, dateEnd, project, pipeline, project.GetVersionController(), scrumMaster, project.GetForum());
            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);

            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.SetScrumMaster(scrumMaster);

            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.InjectNotificationService(notificationMock.Object);
            sprint.AddSubscriber(scrumMaster);
            sprint.RunPipeline(scrumMaster, true);
            
            //Assert
            notificationMock.Verify(x => x.SendScrumMasterUpdate(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ScrumMaster_en_productOwner_krijgen_notificatie_als_sprint_sluit()
        {
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var notificationMock = new Mock<ISubject>();
            var pipeline = new Pipeline("Pipeline1");
            var productOwner = new ProductOwner("Jelmer");
            var scrumMaster = new ScrumMaster("Quincy");

            var dateStart = DateOnly.Parse("23-03-2024");
            var dateEnd = DateOnly.Parse("24-03-2024");
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            var sprint = new ReleaseSprint("ReleaseTest", dateStart, dateEnd, project, pipeline, project.GetVersionController(), scrumMaster, project.GetForum());
            //Act
            sprintFactory.Setup(s => s.CreateSprint(SprintType.ReleaseSprint, It.IsAny<string>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), project, pipeline, It.IsAny<IVersionControl>(), It.IsAny<ScrumMaster>(), project.GetForum())).Returns(sprint);

            project.CreateSprint(SprintType.ReleaseSprint, "ReleaseTest", dateStart, dateEnd, pipeline, project.GetForum());
            project.SetScrumMaster(scrumMaster);

            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.NextSprintState();
            sprint.InjectNotificationService(notificationMock.Object);
            sprint.AddSubscriber(scrumMaster);
            
            sprint.RunPipeline(scrumMaster, false);

            //Assert
            notificationMock.Verify(x => x.SendSprintUpdate(It.IsAny<string>()), Times.Once);
        }
    }
}
