using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints.SprintStates;

namespace Avans_DevOps.Items
{
    public class Item
    {

        private ItemState ItemState { get; set; }
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

        //Veranderd de state van de huidige context naar aangegeven context.
        public void ToTodoState()
        {
            ItemState = new TodoState(this);
        }

        public void ToDoingState()
        {
           ItemState = new DoingState(this);
        }

        public void ToReadyForTestingState()
        {
            //Notificatie naar testers


           ItemState = new ReadyForTestingState(this);
        }

        public void ToTestingState()
        {
          ItemState = new TestingState(this);
        }

        public void ToTestedState()
        {
            ItemState = new TestedState(this); 
        }

        public void ToDoneState()
        {
          ItemState = new DoneState(this);
        }

        public ItemState GetItemState() { return this.ItemState; }

    }
}
