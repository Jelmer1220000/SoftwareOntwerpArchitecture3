using Avans_DevOps.Forums;

namespace Avans_DevOps.Forum.ThreadStates
{
    public class ArchiveState : ThreadCurrentState
    {
        private readonly AThread _context;

        public ArchiveState(AThread context)
        {
            _context = context;
            OnEnter();
        }

        public override void OnEnter()
        {
            Console.WriteLine($"Thread: '{_context.Title}' afgesloten en in Forum geplaatst.");
            _context.AddThreadToForum();
        }
    }
}
