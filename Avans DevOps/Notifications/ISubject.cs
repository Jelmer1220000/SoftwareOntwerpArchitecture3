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
        public void AddSubscriber(User member);

        public void RemoveSubscriber(User member);

        public void SendNotifications(string text);
    }
}
