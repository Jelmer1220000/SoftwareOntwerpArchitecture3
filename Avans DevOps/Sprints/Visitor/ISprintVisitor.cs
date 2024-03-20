using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints.Visitor
{
    public interface ISprintVisitor
    {
        public void AcceptReview(ReviewSprint sprint);

        public void AcceptRelease(ReleaseSprint sprint);
    }
}
