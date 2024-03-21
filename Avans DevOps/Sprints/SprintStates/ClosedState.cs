using Avans_DevOps.Items;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ClosedState : SprintState
    {

        private readonly Sprint _context;

        public ClosedState(Sprint sprint)
        {
            _context = sprint;
        }


        public override void OnEnter()
        {
            Console.WriteLine("Sprint closed");
        }
    }
}
