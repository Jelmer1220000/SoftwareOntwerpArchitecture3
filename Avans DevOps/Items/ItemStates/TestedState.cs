using Avans_DevOps.Forums;
using Avans_DevOps.Models;

namespace Avans_DevOps.Items.ItemStates
{
    public class TestedState : ItemState
    {

        private readonly Item _context;
        public TestedState(Item context)
        {
            _context = context;
            this.OnEnter(_context);
        }

        public override void ToTesting()
        {
            _context.ToTestingState();
        }

        public override void ToDone(User user)
        {
            if (user.CanMoveBacklogItemFromTested()) _context.ToDoneState();
        }

        public override void StartThread(string title, string description, User user)
        {
            _context.Thread = new AThread(title, description, _context, _context.Forum, user);
        }
    }
}
