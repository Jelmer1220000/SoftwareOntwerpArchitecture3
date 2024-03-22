using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints
{
    public class ReviewSprint : Sprint
    {
        public ReviewSprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline) : base(name, startDate, endDate, project, pipeline)
        {
        }

        internal override void AcceptVisitor(ISprintVisitor visitor)
        {
            visitor.AcceptReview(this);
        }

        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
