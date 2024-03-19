using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class ReadyForTestingState : IItemState
    {
        private readonly Item _context;

        public ReadyForTestingState(Item context)
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
            _context.ChangeState(new TestingState(_context));
        }

        public void OnEnter()
        {
            //Notificatie naar testers

        }
    }
}
