using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications
{
    public class MailNotificationsService : INotificationService<string>
    {
        public void SendNotification(string value)
        {
            Console.WriteLine($"Email send to: {value}");
        }
    }
}
