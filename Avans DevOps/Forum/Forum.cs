namespace Avans_DevOps.Forum
{
    public class Forum
    {
        public Guid Id { get; set; }

        public IList<Thread> Threads { get; set; }


        public Forum()
        {
            Threads = [];
        }

        public void AddThread(Thread thread)
        {
            Threads.Add(thread);
        }

        public void Remove(Thread thread)
        {
            Threads.Remove(thread);
        }

        public IList<Thread> GetAllThreads()
        {
            return Threads.ToList();
        }
    }
}
