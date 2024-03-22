using Avans_DevOps.Items;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ClosedState : SprintState
    {

        private readonly Sprint _context;
        private NotificationSubject _notificationSubject = new NotificationSubject();

        public ClosedState(Sprint sprint)
        {
            _context = sprint;

            _notificationSubject.AddSubscriber(_context.GetProject().GetScrumMaster());
            _notificationSubject.AddSubscriber(_context.GetProject().GetProductOwner());
        }


        public override void OnEnter()
        {
            Console.WriteLine("Sprint closed");

            _notificationSubject.SendNotifications($"Sprint: '{_context.Name}' is closed");
        }
    }
}
