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

        public void SendThreadUpdate(string text);

        public void SendItemUpdate(string text);

        public void SendProductOwnerUpdate(string text);

        public void SendScrumMasterUpdate(string text);
        public void SendTestersUpdate(string text);

        public void SendSprintUpdate(string text);
    }
}
