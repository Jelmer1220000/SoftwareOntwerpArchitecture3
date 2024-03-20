using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReleaseState : SprintState
    {
        public Sprint _context;

        public ReleaseState(Sprint sprint)
        {
            _context = sprint;
        }

        public override void NextState()
        {
            _context.ChangeState(new ClosedState(_context));
        }

        public override void OnEnter()
        {
            //TODO
           // Run pipeline
        }
    }
}
