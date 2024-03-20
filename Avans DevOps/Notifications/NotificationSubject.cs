using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications
{
    public class NotificationSubject : ISubject
    {
        private IList<ISubscriber> _subscribers = [];
        public void AddSubscriber(TeamMember member)
        {
            _subscribers.Add(member);
        }

        public void RemoveSubscriber(TeamMember member)
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
