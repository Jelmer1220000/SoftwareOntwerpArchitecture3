using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Items
{
    public class Item
    {
        protected ItemState _itemState { get; set; }

        private Project _project;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Activity> Activities { get; set; }



        public Item(string name, string description, Project project)
        {
            Name = name;
            Description = description;
            this._itemState = new TodoState(this);
            Activities = [];
            _project = project;
        }


        public Project GetProject()
        {
            return _project;
        }

        public IList<User> GetTesters()
        {
            return GetProject().GetTesters();
        }

        public User GetScrumMaster()
        {
            return GetProject().GetScrumMaster();
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
            this._itemState = new TodoState(this);
        }

        public void ToDoingState()
        {
           this._itemState = new DoingState(this);
        }

        public void ToReadyForTestingState()
        {
           this._itemState = new ReadyForTestingState(this);
        }

        public void ToTestingState()
        {
          this._itemState = new TestingState(this);
        }

        public void ToTestedState()
        {
            this._itemState = new TestedState(this); 
        }

        public void ToDoneState()
        {
          this._itemState = new DoneState(this);
        }

    }
}
