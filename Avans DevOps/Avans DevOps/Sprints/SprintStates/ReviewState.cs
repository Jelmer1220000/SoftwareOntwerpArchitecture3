using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReviewState : SprintState
    {

        public Sprint _context;

        public ReviewState(Sprint sprint)
        {
            _context = sprint;
        }

        public override void NextState()
        {
            _context.ChangeState(new ClosedState(_context));
        }
    }
}
