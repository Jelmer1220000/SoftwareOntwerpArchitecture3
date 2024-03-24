namespace Avans_DevOps.Forums
{
    public class AForum
    {
        public Guid Id { get; set; }

        public IList<AThread> Threads { get; set; }


        public AForum()
        {
            Threads = [];
        }

        public void AddThread(AThread thread)
        {
            Threads.Add(thread);
        }

        public IList<AThread> GetAllThreads()
        {
            return Threads.ToList();
        }
    }
}
