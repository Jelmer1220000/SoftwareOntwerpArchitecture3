using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class RunningState : ISprintState
    {
        public Sprint _context;

        public RunningState(Sprint context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            Console.WriteLine("Het is niet mogelijk om items toe te voegen in deze fase van de sprint");
            throw new InvalidOperationException();
        }

        public void RemoveItem(Item item)
        {
            Console.WriteLine("Het is niet mogelijk om items te verwijderen in deze fase van de sprint");
            throw new InvalidOperationException();
        }

        public void NextState()
        {
            _context.ChangeState(new FinishedState(_context));
        }

        public void OnEnter()
        {
            // niks doen
        }
    }
}
