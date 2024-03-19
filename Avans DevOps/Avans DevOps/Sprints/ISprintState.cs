using Avans_DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public interface ISprintState
    {
        public void AddItem(Item item);
        public void RemoveItem(Item item);

        public void EnterState();
        public void NextState();
    }
}
