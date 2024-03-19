using Avans_DevOps.Models;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReviewState : ISprintState
    {

        public Sprint _context;

        public ReviewState(Sprint sprint)
        {
            _context = sprint;
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
            _context.ChangeState(new ClosedState(_context));
        }

        public void OnEnter()
        {
            // niks doen
        }
    }
}
