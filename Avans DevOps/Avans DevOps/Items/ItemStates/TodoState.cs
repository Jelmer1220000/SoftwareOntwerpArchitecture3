using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class TodoState : IItemState
    {

        private readonly Item _context;

        public TodoState(Item context)
        {
            _context = context;
        }

        public void BackToStart()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public void BackToTesting()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public void NextState()
        {
            _context.ChangeState(new DoingState(_context));
        }

        public void OnEnter()
        {
            // Niks doen
        }
    }
}
