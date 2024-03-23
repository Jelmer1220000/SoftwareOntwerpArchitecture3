using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.VersionControl;

namespace Avans_DevOps.Sprints.SprintFactory
{
    public interface ISprintFactory
    {
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl);
    }
}
