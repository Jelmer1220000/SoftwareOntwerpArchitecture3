namespace Avans_DevOps.Notifications.NotificationServices
{
    public class MailNotificationsService : INotificationService<string>
    {
        public void SendNotification(string value, string name)
        {
            Console.WriteLine($"Email: '{value}' send to: {name}");
        }
    }
}
