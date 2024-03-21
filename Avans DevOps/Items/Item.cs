using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Items
{
    public class Item
    {
        private NotificationSubject _notificationSubject = new NotificationSubject();
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

        public void AddSubscriber(User member)
        {
            _notificationSubject.AddSubscriber(member);
        }

        public void RemoveSubscriber(User member) 
        {  
            _notificationSubject.RemoveSubscriber(member); 
        }

        public void SendNotifications()
        {
            _notificationSubject.SendNotifications();
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
            //TODO
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

    }
}
