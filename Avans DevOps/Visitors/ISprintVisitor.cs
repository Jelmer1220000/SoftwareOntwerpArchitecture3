using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_DevOps.Sprints;

namespace Avans_DevOps.Visitor
{
    public interface ISprintVisitor
    {
        public void AcceptReview(ReviewSprint sprint);

        public void AcceptRelease(ReleaseSprint sprint);
    }
}
