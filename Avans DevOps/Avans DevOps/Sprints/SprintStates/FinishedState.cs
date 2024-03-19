using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class FinishedState : ISprintState
    {

        private readonly Sprint _context;

        public FinishedState(Sprint context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            throw new InvalidOperationException("Het is niet mogelijk items toe te voegen in deze fase van de sprint.");
        }

        public void RemoveItem(Item item)
        {
            throw new InvalidOperationException("Het is niet mogelijk items te verwijderen in deze fase van de sprint.");
        }

        public void NextState()
        {
            var contextType = _context.GetType();
            if (contextType == typeof(ReleaseSprint))
            {
                _context.ChangeState(new ReleaseState(_context));
                return;
            }

            if (contextType == typeof(ReviewState))
            {
                _context.ChangeState(new ReviewState(_context));
                return;
            }

            throw new NotImplementedException($"De state van {contextType} na state 'finished' is niet geïmplementeerd.");
        }

        public void OnEnter()
        {
            // niks doen
        }
    }
}
