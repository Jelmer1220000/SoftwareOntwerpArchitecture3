using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class DoneState : IItemState
    {
        private readonly Item _context;

        public DoneState(Item context)
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
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }

        public void OnEnter()
        {
            throw new InvalidOperationException("Niet mogelijk vanuit deze fase");
        }
    }
}
