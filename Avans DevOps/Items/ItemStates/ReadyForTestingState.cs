namespace Avans_DevOps.Items.ItemStates
{
    public class ReadyForTestingState : ItemState
    {
        private readonly Item _context;

        public ReadyForTestingState(Item context)
        {
            _context = context;
            this.OnEnter(_context);
        }

        public override void OnEnter(Item item)
        {
            _context.SendNotifications();
        }

        public override void ToTesting()
        {
            _context.ToTestingState();
        }
    }
}
