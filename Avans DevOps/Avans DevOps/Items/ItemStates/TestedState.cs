namespace Avans_DevOps.Items.ItemStates
{
    public class TestedState : ItemState
    {

        private readonly Item _context;
        public TestedState(Item context)
        {
            _context = context;
        }

        public override void ToTesting()
        {
            //(lead) developer via de definition of done of het echt naar de done toestand mag. Mocht dat niet zo zijn, dan gaat het item eerst terug naar ready for testing
            _context.ToTestingState();
        }

        public override void ToDone()
        {
            _context.ToDoneState();
        }
    }
}
