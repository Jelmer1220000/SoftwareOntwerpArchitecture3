using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public class PlanningState : ISprintState
    {

        public Sprint _context;

        public PlanningState(Sprint sprint)
        {
            _context = sprint;
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
            Console.WriteLine("1");
        }

        public void NextState()
        {
            _context.AdvanceState(new RunningState(_context));   
        }


    }
}
