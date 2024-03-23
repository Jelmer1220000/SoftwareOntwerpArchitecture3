using Avans_DevOps.Forums;
using Avans_DevOps.Notifications;
using System.Xml.Linq;

namespace Avans_DevOps.Forum.ThreadStates
{
    public class OpenState : ThreadCurrentState
    {
        private readonly AThread _context;
        private NotificationSubject _notificationSubject = new NotificationSubject();

        public OpenState(AThread context)
        {
            _context = context;
            _notificationSubject.AddSubscriber(context.User);
        }

        public override void AddComment(Comment comment)
        {
            Console.WriteLine($"Comment: {comment.Content} geplaatst");
            _context.Comments.Add(comment);
            _notificationSubject.SendNotifications($"'{comment.User.GetName()}' reacted on '{_context.Title}'");
        }

        public override void ReactOnComment(Comment comment, Comment commentToPlace)
        {
            foreach (var com in _context.Comments)
            {
                if (com.Id == comment.Id)
                {
                    comment.ReactToComment(commentToPlace);
                    Console.WriteLine($"Comment: '{commentToPlace.Content}' geplaatst op '{comment.Content}'");
                    _notificationSubject.SendNotifications($"'{commentToPlace.User.GetName()}' reacted on '{comment.User.GetName()}'");
                }
            }
        }

        public override void CloseThread()
        {
            _context.CloseThread();
        }

        public override void ArchiveThread()
        {
            _context.ArchiveThread();
        }
    }
}
