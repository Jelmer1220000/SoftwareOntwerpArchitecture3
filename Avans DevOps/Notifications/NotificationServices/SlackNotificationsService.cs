using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications.NotificationServices
{
    public class SlackNotificationsService : INotificationService<string>
    {
        public void SendNotification(string value, string name)
        {
            Console.WriteLine($"Slack: '{value}' send to: {name}");
        }
    }
}
