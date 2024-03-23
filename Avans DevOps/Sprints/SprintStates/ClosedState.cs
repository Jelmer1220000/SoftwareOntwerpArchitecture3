using Avans_DevOps.Items;
using Avans_DevOps.Notifications;
using Avans_DevOps.Sprints;

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
            foreach (var item in _context._sprintBackLog) if (item.Thread != null) item.ArchiveThread();
            _notificationSubject.SendNotifications($"Sprint: '{_context.Name}' is closed");
        }
    }
}
