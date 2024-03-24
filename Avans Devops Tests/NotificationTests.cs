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
            var developer = new Developer("Quincy");
            var preference = new SlackNotificationsService();
            var preference2 = new MailNotificationsService();
            //Act
            productOwner.AddNotificationPreference(preference);
            productOwner.AddNotificationPreference(preference2);

            //Assert
            Assert.Equal(preference, productOwner._preferences[0]);
            Assert.Equal(preference2, productOwner._preferences[1]);
        }
    }
}
