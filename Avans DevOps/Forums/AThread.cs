using Avans_DevOps.Forum.ThreadStates;
using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Forums
{
    public class AThread
    {
        private ThreadCurrentState _threadState;

        public string Title;
        public string Description;
        public Item BacklogItem;
        public IList<Comment> Comments;
        public User User;
        private AForum _forum;
        private ISubject _notificationService;

        public AThread(string title, string description, Item backlogItem, AForum forum, User user)
        {
            Title = title;
            Description = description;
            BacklogItem = backlogItem;
            Comments = [];
            _forum = forum;
            User = user;
            _threadState = new OpenState(this);
            _notificationService = new NotificationSubject();
        }

        public void InjectNotificationService(ISubject notificationService)
        {
            _notificationService = notificationService;
        }

        public void CloseThread()
        {
            _threadState = new ClosedState(this);
        }

        public void OpenThread()
        {
            _threadState = new OpenState(this);
        }

        public void ArchiveThread()
        {
            _threadState = new ArchiveState(this);
        }

        public void AddThreadToForum()
        {
            _forum.AddThread(this);
        }

        public void AddSubscriber(User user)
        {
            _notificationService.AddSubscriber(user);
        }

        public void SendThreatUpdate(string text)
        {
            _notificationService.SendThreadUpdate(text);
        }

        public void ReactToThread(Comment reaction)
        {
            _threadState.AddComment(reaction);
        }

        public void ReactOnComment(Comment comment, Comment commentToPlace)
        {
            _threadState.ReactOnComment(comment, commentToPlace);
        }
    }
}
