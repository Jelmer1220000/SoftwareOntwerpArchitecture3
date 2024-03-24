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

        public TestingState(Item context)
        {
            _context = context;

            this.OnEnter(_context);
        }

        public override void ToTodo()
        {
           _context.UpdateScrumMaster($"{_context.Name} is back to TODO");
           _context.ToTodoState();
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
