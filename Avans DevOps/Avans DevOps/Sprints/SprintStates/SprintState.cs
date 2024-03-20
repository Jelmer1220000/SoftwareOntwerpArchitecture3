using Avans_DevOps.Items;

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

        public virtual void NextState()
        {
           throw new InvalidOperationException("Het is niet mogelijk om naar de volgende fase van de sprint te gaan.");
        }

        public virtual void OnEnter()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
}
