using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public class RunningState : ISprintState
    {
        public Sprint _context;

        public RunningState(Sprint context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void EnterState()
        {
            Console.WriteLine("2");
        }

        public void NextState()
        {
            _context.AdvanceState(new FinishedState(_context));
        }
    }
}
