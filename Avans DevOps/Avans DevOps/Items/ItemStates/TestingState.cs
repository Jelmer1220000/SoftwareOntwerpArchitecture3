using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class TestingState : IItemState
    {
        private readonly Item _context;

        public TestingState(Item context)
        {
            _context = context;
        }

        public void BackToStart()
        {
            _context.ChangeState(new TodoState(_context));
            //Notificatie naar Scrum Master.
        }

        public void BackToTesting()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public void NextState()
        {
           _context.ChangeState(new TestedState(_context));
        }

        public void OnEnter()
        {
            //Niks doen
        }
    }
}
