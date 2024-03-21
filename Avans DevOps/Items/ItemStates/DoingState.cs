namespace Avans_DevOps.Items.ItemStates
{
    public class DoingState : ItemState
    {
        private readonly Item _context;

        public DoingState(Item context)
        {
            _context = context;
            this.OnEnter(_context);
        }

        public override void ToReadyForTesting()
        {
            _context.ToReadyForTestingState();
        }
    }
}
