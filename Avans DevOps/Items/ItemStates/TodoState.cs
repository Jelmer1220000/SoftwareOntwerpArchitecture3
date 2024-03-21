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

        public override void ToDoing()
        {
            _context.ToDoingState();
        }
    }
}
