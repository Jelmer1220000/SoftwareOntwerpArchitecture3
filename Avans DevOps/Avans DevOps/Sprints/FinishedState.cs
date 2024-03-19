using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public class FinishedState : ISprintState
    {

        private readonly Sprint _context;

        public FinishedState(Sprint context)
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
            Console.WriteLine("3");
        }

        public void NextState()
        {
            throw new NotImplementedException();
        }
    }
}
