using Avans_DevOps.Forums;

namespace Avans_DevOps.Forum.ThreadStates
{
    public abstract class ThreadCurrentState
    {
        public virtual void OnEnter()
        {
            Console.WriteLine("Thread entered: " + this.GetType().Name);
        }

        public virtual void AddComment(Comment comment)
        {
            throw new InvalidOperationException("Het is niet mogelijk om een comment toe te voegen aan deze thread");
        }

        public virtual void ReactOnComment(Comment comment, Comment commentToPlace)
        {
            throw new InvalidOperationException("Het is niet mogelijk om een reactie toe te voegen op deze comment");
        }
        public virtual void RemoveComment(Comment comment)
        {
            throw new InvalidOperationException("Het is niet mogelijk om een comment te verwijderen van deze thread");
        }

        public virtual void OpenThread()
        {
            throw new InvalidOperationException("Het is niet mogelijk de thread te openen vanuit deze fase.");
        }

        public virtual void CloseThread()
        {
            throw new InvalidOperationException("Het is niet mogelijk de thread te sluiten vanuit deze fase.");
        }

        public virtual void ArchiveThread()
        {
            throw new InvalidOperationException("Het is niet mogelijk de thread in het Forum te plaatsen vanuit deze fase.");
        }
    }
}
