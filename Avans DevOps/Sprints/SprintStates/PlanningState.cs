<<<<<<< Updated upstream
using Avans_DevOps.Items;
using Avans_DevOps.Sprints;
=======
﻿using Avans_DevOps.Items;
using Avans_DevOps.Notifications;
>>>>>>> Stashed changes

namespace Avans_DevOps.Sprints.SprintStates
{
    public class PlanningState : SprintState
    {

        private readonly Sprint _context;

        public PlanningState(Sprint sprint)
        {
            _context = sprint;
        }

        public override void AddItem(Item item)
        {
            _context._sprintBackLog.Add(item);
        }

        public override void RemoveItem(Item item)
        {
            _context._sprintBackLog.Remove(item);
        }

        public override void ChangeProperties(string name, DateOnly startDate, DateOnly endDate)
        {
            _context.Name = name;
            _context.StartDate = startDate;
            _context.EndDate = endDate;
        }

        public override void NextState()
        {
            _context.ChangeState(new RunningState(_context));
        }

    }
}
