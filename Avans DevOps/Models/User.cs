using Avans_DevOps.Notifications;

namespace Avans_DevOps.Models
{
    public class User : ISubscriber
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

        public void Update()
        {
            foreach (var preference in  _preferences)
            {
                preference.SendNotification(GetName());
            }
        }

        public void AddNotificationPreference(INotificationService<string> notification)
        {
            _preferences.Add(notification);
        }
    }
}
