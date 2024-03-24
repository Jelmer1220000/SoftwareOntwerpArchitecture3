namespace Avans_DevOps.Sprints.SprintStates
{
    public class RunningState : SprintState
    {
        private readonly Sprint _context;

        public RunningState(Sprint context)
        {
            _context = context;
        }

        public override void NextState()
        {
            _context.ChangeState(new FinishedState(_context));
        }
    }
}
