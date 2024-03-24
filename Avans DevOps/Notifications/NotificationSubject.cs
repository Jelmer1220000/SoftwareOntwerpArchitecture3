using Avans_DevOps.Models;

namespace Avans_DevOps.Notifications
{
    public class NotificationSubject : ISubject
    {
        private IList<Subscriber> _subscribers = [];

        public void AddSubscriber(User member)
        {
            _subscribers.Add(member);
        }

        public void RemoveSubscriber(User member)
        {
            _subscribers.Remove(member);
        }

        public void SendItemUpdate(string text)
        {
            foreach(var member in _subscribers) member.ItemUpdate(text);
        }

        public void SendThreadUpdate(string text)
        {
            foreach (var member in _subscribers) member.ThreadUpdate(text);
        }

        public void SendSprintUpdate(string text)
        {
            foreach (var member in _subscribers) member.SprintUpdate(text);
        }

        public void SendProductOwnerUpdate(string text)
        {
            foreach (var member in _subscribers) member.ProductOwnerUpdate(text);
        }

        public void SendScrumMasterUpdate(string text)
        {
            foreach (var member in _subscribers) member.ScrumMasterUpdate(text);
        }

        public void SendTestersUpdate(string text)
        {
            foreach (var member in _subscribers) member.TestersUpdate(text);
        }
    }
}
