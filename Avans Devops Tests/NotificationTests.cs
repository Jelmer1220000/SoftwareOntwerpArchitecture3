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
using Avans_DevOps.Notifications.NotificationServices;
using Avans_DevOps.Notifications;

namespace Avans_Devops_Tests
{
    public class NotificationTests
    {
        [Fact]
        public void Als_project_lid_wil_ik_notificatie_voorkeur_kunnen_opgeven()
        {
            //Arrange
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            var preference = new SlackNotificationsService();
            //Act
            productOwner.AddNotificationPreference(preference);

            //Assert
            Assert.Equal(preference, productOwner._preferences[0]);
        }

        [Fact]
        public void Als_project_lid_wil_ik_notificaties_via_slack_en_mail_kunnen_ontvangen()
        {
            //Arrange
            var productOwner = new ProductOwner("Jelmer");
            var preference = new SlackNotificationsService();
            var preference2 = new MailNotificationsService();
            //Act
            productOwner.AddNotificationPreference(preference);
            productOwner.AddNotificationPreference(preference2);

            //Assert
            Assert.Equal(preference, productOwner._preferences[0]);
            Assert.Equal(preference2, productOwner._preferences[1]);
        }

        [Fact]
        public void Testers_krijgen_notificatie_als_item_naar_ready_for_testing_gaat()
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

            item1.ToReadyForTestingState();
            //Assert
            notifications.Verify(s => s.SendTestersUpdate(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Test_Mail_notification_service()
        {
            //Arrange
            var versionControlFactory = new Mock<IVersionControlFactory>();
            var sprintFactory = new Mock<ISprintFactory>();
            var productOwner = new ProductOwner("Jelmer");
            var developer = new Developer("Quincy");
            var scrumMater = new ScrumMaster("Test");
            var tester = new Tester("Tester");

            var notifications = new NotificationSubject();
            //Act
            var project = new Project("Kramse", productOwner, sprintFactory.Object, VersionControlTypes.Git, versionControlFactory.Object);
            project.AddDeveloper(productOwner, developer);
            project.AddItemToProjectBackLog("Item1", "Testing item creation");
            var item1 = project.GetBacklog()[0];

            var email = new MailNotificationsService();

            developer.AddNotificationPreference(email);
            scrumMater.AddNotificationPreference(new SlackNotificationsService());
            tester.AddNotificationPreference(email);
            project.AddTester(tester);

            item1.InjectNotificationsService(notifications);

            item1.UpdateScrumMaster("Test");
            item1.UpdateTesters("test");

            item1.ToReadyForTestingState();
            //Assert
            Assert.Equal(developer._preferences[0], email);
        }
    }
}
