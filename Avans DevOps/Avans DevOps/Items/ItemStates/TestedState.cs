namespace Avans_DevOps.Items.ItemStates
{
    public class TestedState : IItemState
    {

        private readonly Item _context;
        public TestedState(Item context)
        {
            _context = context;
        }
        public void BackToStart()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public void BackToTesting()
        {
            //(lead) developer via de definition of done of het echt naar de done toestand mag. Mocht dat niet zo zijn, dan gaat het item eerst terug naar ready for testing
            _context.ChangeState(new ReadyForTestingState(_context));
        }

        public void NextState()
        {
            _context.ChangeState(new DoneState(_context));
        }

        public void OnEnter()
        {
            // Niks doen
        }
    }
}
