using Avans_DevOps.Forums;

namespace Avans_DevOps.Forum.ThreadStates
{
    public class ClosedState : ThreadCurrentState
    {
        private readonly AThread _context;

        public ClosedState(AThread context)
        {
            _context = context;
        }

        public override void OpenThread()
        {
            _context.OpenThread();
        }

        public override void ArchiveThread()
        {
            _context.ArchiveThread();
        }
    }
}
