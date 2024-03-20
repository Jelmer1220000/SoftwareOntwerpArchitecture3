using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class PlanningState : SprintState
    {

        public Sprint _context;

        public PlanningState(Sprint sprint)
        {
            _context = sprint;
        }

        public override void AddItem(Item item)
        {
            _context._sprintBackLog.Add(item);
        }

        public override void RemoveItem(Item item)
        {
            _context._sprintBackLog.Remove(item);
        }

        public override void NextState()
        {
            _context.ChangeState(new RunningState(_context));
        }

    }
}
