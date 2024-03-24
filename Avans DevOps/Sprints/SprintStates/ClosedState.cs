using Avans_DevOps.Items;
using Avans_DevOps.Notifications;
using Avans_DevOps.Sprints;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ClosedState : SprintState
    {

        private readonly Sprint _context;

        public ClosedState(Sprint sprint)
        {
            _context = sprint;
        }


        public override void OnEnter()
        {
            Console.WriteLine("Sprint closed");
            foreach (var item in _context._sprintBackLog) if (item.Thread != null) item.ArchiveThread();
            _context.UpdateSprint($"Sprint: '{_context.Name}' is closed");
        }
    }
}
