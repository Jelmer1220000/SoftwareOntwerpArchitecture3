using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;

namespace Avans_DevOps.Sprints.SprintFactory
{
    public interface ISprintFactory
    {
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline);
    }
}
