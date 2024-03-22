using Avans_DevOps.Sprints;
using Avans_DevOps.Sprints.SprintStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Visitor
{
    public class SprintVisitor : ISprintVisitor
    {
        public void AcceptRelease(ReleaseSprint sprint)
        {
            sprint.ChangeState(new ReleaseState(sprint));
        }

        public void AcceptReview(ReviewSprint sprint)
        {
            sprint.ChangeState(new ReviewState(sprint));
        }
    }
}
