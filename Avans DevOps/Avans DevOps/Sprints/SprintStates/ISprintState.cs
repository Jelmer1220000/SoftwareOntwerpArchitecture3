using Avans_DevOps.Models;

namespace Avans_DevOps.Sprints.SprintStates
{
    public interface ISprintState
    {
        public void AddItem(Item item);
        public void RemoveItem(Item item);
        public void NextState();
        public void OnEnter();
    }
}
