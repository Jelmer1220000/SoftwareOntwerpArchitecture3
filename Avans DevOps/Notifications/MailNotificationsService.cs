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
