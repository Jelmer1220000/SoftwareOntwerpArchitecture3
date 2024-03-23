using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class TestingState : ItemState
    {
        private readonly Item _context;
        private NotificationSubject _notificationSubject = new NotificationSubject();

        public TestingState(Item context)
        {
            _context = context;

            _notificationSubject.AddSubscriber(_context.GetScrumMaster());
            this.OnEnter(_context);
        }

        public override void ToTodo()
        {
            _context.ToTodoState();

            _notificationSubject.SendNotifications($"{_context.Name} is back to TODO");
        }

        public override void StartThread(string title, string description, User user)
        {
            _context.Thread = new AThread(title, description, _context, _context.Forum, user);
        }

        public override void ToTested()
        {
           _context.ToTestedState();
        }
    }
}
