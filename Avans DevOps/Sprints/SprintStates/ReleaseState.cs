using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReleaseState : SprintState
    {
        private readonly Sprint _context;

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
            Console.WriteLine("Sprint entered: " + this.GetType().Name);
            //TODO
            // Run pipeline
        }
    }
}
