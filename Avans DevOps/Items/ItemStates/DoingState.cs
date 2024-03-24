using Avans_DevOps.Forums;
using Avans_DevOps.Models;

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

        public override void StartThread(string title, string description, User user)
        {
            _context.Thread = new AThread(title, description, _context, _context.Forum, user);
        }
    }
}
