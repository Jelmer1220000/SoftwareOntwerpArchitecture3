using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints.SprintStates;

namespace Avans_DevOps.Items
{
    public class Item
    {

        private IItemState ItemState { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Activity> Activities { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            ItemState = new TodoState(this);
            Activities = [];
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            Activities.Remove(activity);
        }

        //Veranderd de state van de huidige context.
        public void ChangeState(IItemState state)
        {
            this.ItemState = state;
            this.ItemState.OnEnter();
        }

        public IItemState GetItemState() { return this.ItemState; }

    }
}
