using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications
{
    public interface ISubject
    {
        public void AddSubscriber(TeamMember member);

        public void RemoveSubscriber(TeamMember member);

        public void SendNotifications();
    }
}
