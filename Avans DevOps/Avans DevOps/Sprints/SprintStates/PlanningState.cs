using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class PlanningState : ISprintState
    {

        public Sprint _context;

        public PlanningState(Sprint sprint)
        {
            _context = sprint;
        }

        public void AddItem(Item item)
        {
            _context._sprintBackLog.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _context._sprintBackLog.Remove(item);
        }

        public void NextState()
        {
            _context.ChangeState(new RunningState(_context));
        }

        public void OnEnter()
        {
            // niks doen
        }
    }
}
