using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ClosedState : ISprintState
    {

        public Sprint _context;

        public ClosedState(Sprint sprint)
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
            throw new InvalidOperationException("De sprint bevind zich in de 'ClosedState' welke geen volgende state heeft.");
        }

        public void OnEnter()
        {
            Console.WriteLine("Sprint closed");
        }
    }
}
