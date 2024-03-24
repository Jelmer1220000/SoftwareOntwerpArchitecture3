using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Items.ItemStates
{
    public class DoneState : ItemState
    {
        private readonly Item _context;

        public DoneState(Item context)
        {
            _context = context;
            OnEnter(context);
        }

        public override void OnEnter(Item item)
        {
            base.OnEnter(item);
            if (_context.Thread != null) _context.CloseThread();
        }
    }
}
