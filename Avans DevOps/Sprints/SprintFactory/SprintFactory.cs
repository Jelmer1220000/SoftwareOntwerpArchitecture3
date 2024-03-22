
using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;

namespace Avans_DevOps.Sprints.SprintFactory
{
    public class SprintFactory : ISprintFactory
    {
        public SprintFactory()
        {

        }

        // Factory pattern om op basis van enum de gewenste sprint aan te maken.
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline)
        {
            switch (type)
            {
                case SprintType.ReleaseSprint:
                    return new ReleaseSprint(name, startDate, endDate, project, pipeline);
                case SprintType.ReviewSprint:
                    return new ReviewSprint(name, startDate, endDate, project, pipeline);
                default:
                    throw new InvalidOperationException($"SprintFactory heeft geen implementatie voor type: '{type}'.");
            }
        }
    }
}
