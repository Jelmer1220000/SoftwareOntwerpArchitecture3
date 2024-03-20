using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class FinishedState : SprintState
    {

        private readonly Sprint _context;

        public FinishedState(Sprint context)
        {
            _context = context;
        }

        public override void NextState()
        {
            var contextType = _context.GetType();
            if (contextType == typeof(ReleaseSprint))
            {
                _context.ChangeState(new ReleaseState(_context));
                return;
            }

            if (contextType == typeof(ReviewSprint))
            {
                _context.ChangeState(new ReviewState(_context));
                return;
            }

            throw new NotImplementedException($"De state van {contextType} na state 'finished' is niet geïmplementeerd.");
        }
    }
}
