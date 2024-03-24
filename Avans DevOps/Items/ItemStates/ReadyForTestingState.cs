using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

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
            _context.UpdateTesters($"{item.Name} is ready for testing");
        }

        public override void StartThread(string title, string description, User user)
        {
            _context.Thread = new AThread(title, description, _context, _context.Forum, user);
        }

        public override void ToTesting()
        {
            _context.ToTestingState();
        }
    }
}
