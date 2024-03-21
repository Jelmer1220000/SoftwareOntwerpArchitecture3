using Avans_DevOps.Models;

namespace Avans_DevOps.Notifications
{
    public class NotificationSubject : ISubject
    {
        private IList<ISubscriber> _subscribers = [];
        public void AddSubscriber(User member)
        {
            _subscribers.Add(member);
        }

        public void RemoveSubscriber(User member)
        {
            _subscribers.Remove(member);
        }

        public void SendNotifications()
        {
            foreach (var member in _subscribers)
            {
                member.Update();
            }
        }
    }
}
