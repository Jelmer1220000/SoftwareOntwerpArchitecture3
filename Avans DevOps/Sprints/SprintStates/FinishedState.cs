<<<<<<< Updated upstream
using Avans_DevOps.Sprints;
=======
﻿using Avans_DevOps.Notifications;
>>>>>>> Stashed changes
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class FinishedState : SprintState
    {

        private readonly Sprint _context;

        public FinishedState(Sprint context)
        {
            _context = context;
        }

        public override void NextState()
        {
            ISprintVisitor visitor = new SprintVisitor();
            _context.AcceptVisitor(visitor);
        }
    }
}
