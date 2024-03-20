using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Notifications
{
    public interface INotificationService<T>
    {
        public void SendNotification(T value);
    }
}
