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
            _context.ToTodoState();

            //TODO
            //Notificatie naar Scrum Master.
        }

        public override void ToTested()
        {
           _context.ToTestedState();
        }
    }
}
