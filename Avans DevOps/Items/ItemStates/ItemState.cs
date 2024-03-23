using Avans_DevOps.Forums;
using Avans_DevOps.Models;

namespace Avans_DevOps.Items.ItemStates
{
    public abstract class ItemState
    {
        private const string EXCEPTION = "Niet mogelijk vanuit deze fase.";
        public virtual void OnEnter(Item item)
        {
            Console.WriteLine($"{item.Name} bevindt zich nu in fase {this.GetType().Name}");
        }

        public virtual void StartThread(string title, string description, User user)
        {
            throw new InvalidOperationException(EXCEPTION);
        }
        public virtual void ToTodo()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void CloseThread()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void OpenThread()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void ToDoing(User user)
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void ToReadyForTesting()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void ToTesting()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void ToTested()
        {
            throw new InvalidOperationException(EXCEPTION);
        }

        public virtual void ToDone(User user)
        {
            throw new InvalidOperationException(EXCEPTION);
        }
    }
}
