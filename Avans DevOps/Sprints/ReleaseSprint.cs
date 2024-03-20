using Avans_DevOps.Sprints.Visitor;

namespace Avans_DevOps.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public ReleaseSprint(string name, DateOnly startDate, DateOnly endDate) : base(name, startDate, endDate)
        {
        }

        public override void AcceptVisitor(ISprintVisitor visitor)
        {
            visitor.AcceptRelease(this);
        }

        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
