using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.VersionControl;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public ReleaseSprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl) : base(name, startDate, endDate, project, pipeline, versionControl)
        {
        }

        internal override void AcceptVisitor(ISprintVisitor visitor)
        {
            visitor.AcceptRelease(this);
        }

        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
