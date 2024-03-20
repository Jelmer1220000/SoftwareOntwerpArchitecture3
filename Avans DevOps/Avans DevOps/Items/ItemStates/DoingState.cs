using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class DoingState : ItemState
    {
        private readonly Item _context;

        public DoingState(Item context)
        {
            _context = context;
        }

        public override void ToReadyForTesting()
        {
            _context.ToReadyForTestingState();
        }
    }
}
