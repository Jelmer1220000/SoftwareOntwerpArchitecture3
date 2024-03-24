using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Sprints.SprintStates
{
    public abstract class SprintState
    {

        public virtual void AddItem(Item item)
        {
            throw new InvalidOperationException("Het is niet mogelijk items toe te voegen in deze fase van de sprint.");
        }

        public virtual void RemoveItem(Item item)
        {
            throw new InvalidOperationException("Het is niet mogelijk items te verwijderen in deze fase van de sprint.");
        }

        public virtual void ChangeProperties(string name, DateOnly startDate, DateOnly endDate)
        {
            throw new InvalidOperationException("Het is niet mogelijk een sprint aan te passen in deze fase van de sprint.");
        }

        public virtual void UploadReview(User user, byte[] review)
        {
            throw new InvalidOperationException("Het is niet mogelijk een review te uploaden in deze fase.");
        }

        public virtual void RunPipeline(User user, bool fail)
        {
            throw new InvalidOperationException("Het is niet mogelijk een pipeline te runnen in deze fase.");
        }

        public virtual void NextState()
        {
            throw new InvalidOperationException("Het is niet mogelijk om naar de volgende fase van de sprint te gaan.");
        }

        public virtual void OnEnter()
        {
            Console.WriteLine("Sprint entered: " + GetType().Name);
        }
    }
}
