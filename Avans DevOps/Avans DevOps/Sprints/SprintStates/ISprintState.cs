using Avans_DevOps.Items;

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
