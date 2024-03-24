using Avans_DevOps.Items.ItemStates;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Forums;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Items
{
    public class Item
    {
        public ItemState _itemState { get; set; }

        private Project _project;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StoryPoints { get; set; }
        public string Description { get; set; }
        public IList<Activity> Activities { get; set; }
        public User? User { get; set; }

        private ISubject _notificationSubject { get; set; }

        public AThread? Thread;
        public readonly AForum Forum;

        public Item(string name, string description, Project project, AForum forum)
        {
            Name = name;
            Description = description;
            this._itemState = new TodoState(this);
            Activities = [];
            _project = project;
            Forum = forum;
            _notificationSubject = new NotificationSubject();
        }
        public void SetStoryPoints(int points)
        {
            if (points > 0)
            {
                StoryPoints = points;
            } else
            {
                throw new Exception("storypoints kunnen niet negatief zijn");
            }
        }
        public void InjectNotificationsService(ISubject notificationService)
        {
            _notificationSubject = notificationService;
        }

        public Project GetProject()
        {
            return _project;
        }

        public void StartThread(string title, string description, User user)
        {
            _itemState.StartThread(title, description, user);
        }

        public IList<Tester> GetTesters()
        {
            return GetProject().GetTesters();
        }
        //Thread functies
        public void CloseThread()
        {
            Thread.CloseThread();
        }

        public void OpenThread()
        {
            Thread.OpenThread();
        }

        public AThread GetThread()
        {
            return Thread;
        }

        public void ArchiveThread()
        {
            Thread.ArchiveThread();
        }
        // Einde thread functies

        public void AddSubscriber(User user)
        {
            _notificationSubject.AddSubscriber(user);
        }

        public void UpdateTesters(string text)
        {
            _notificationSubject.SendTestersUpdate(text);
        }

        public void UpdateScrumMaster(string text)
        {
            _notificationSubject.SendScrumMasterUpdate(text);
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

        public void ToDoingState(User user)
        {
            if (this.User == null)  this.User = user;

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
          if (!AreAllActivitiesDone()) Console.WriteLine("Error: Niet alle activiteiten zijn klaar!");
          else this._itemState = new DoneState(this);
        }

        private bool AreAllActivitiesDone()
        {
            foreach (var activity in Activities)
            {
                if (!activity.isActivityDone()) return false;
            }
            return true;
        }

    }
}
