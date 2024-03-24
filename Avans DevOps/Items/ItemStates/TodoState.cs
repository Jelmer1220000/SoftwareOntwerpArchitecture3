using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class TodoState : ItemState
    {

        private readonly Item _context;

        public TodoState(Item context)
        {
            _context = context;
            this.OnEnter(_context);
        }

        public override void ToDoing(User user)
        {
            _context.ToDoingState(user);
        }

        public override void StartThread(string title, string description, User user)
        {
            _context.Thread = new AThread(title, description, _context, _context.Forum, user);
        }

        public override void OnEnter(Item item)
        {
            base.OnEnter(item);

            if (_context.Thread != null) _context.OpenThread();
        }
    }
}
