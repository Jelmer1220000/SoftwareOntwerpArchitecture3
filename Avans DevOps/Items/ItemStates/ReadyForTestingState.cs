using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Items.ItemStates
{
    public class ReadyForTestingState : ItemState
    {
        private readonly Item _context;
        private NotificationSubject _notificationSubject = new NotificationSubject();
        
        public ReadyForTestingState(Item context)
        {
            _context = context;

            foreach (var tester in _context.GetTesters())
            {
                _notificationSubject.AddSubscriber(tester);
            }

            this.OnEnter(_context);
        }

        public override void OnEnter(Item item)
        {
            _notificationSubject.SendNotifications($"{item.Name} is ready for testing");
        }

        public override void ToTesting()
        {
            _context.ToTestingState();
        }
    }
}
