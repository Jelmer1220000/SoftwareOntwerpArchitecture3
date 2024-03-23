using Avans_DevOps.Notifications;
using Avans_DevOps.Notifications.NotificationServices;

namespace Avans_DevOps.Models
{
    public abstract class User : ISubscriber
    {
        private string Name { get; set; } = "";
        private IList<INotificationService<string>> _preferences;

        public User(string name) 
        {
            Name = name;
            _preferences = [];
        }

        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName() { return Name; }

        public void Update(string text)
        {
            foreach (var preference in  _preferences)
            {
                preference.SendNotification(text, GetName());
            }
        }

        public void AddNotificationPreference(INotificationService<string> notification)
        {
            _preferences.Add(notification);
        }

        //Business Rules
        public virtual bool CanManagePipeline()
        {
            Console.WriteLine("ERROR: Je hebt geen toestemming om de pipeline aan te passen.");
            return false;
        }

        public virtual bool CanMoveBacklogItemFromTested()
        {
            Console.WriteLine("ERROR: Je hebt geen toestemming om items naar done te slepen.");
            return false;
        }

        public virtual bool CanUploadReview()
        {
            Console.WriteLine("ERROR: Je hebt geen toestemming om een Review te uploaden.");
            return false;
        }

        public virtual bool CanCancelSprint()
        {
            Console.WriteLine("ERROR: Je hebt geen toestemming om een sprint te cancellen.");
            return false;
        }
    }
}
