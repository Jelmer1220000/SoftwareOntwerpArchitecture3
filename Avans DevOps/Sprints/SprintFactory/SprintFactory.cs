
using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints;
using Avans_DevOps.VersionControl;

namespace Avans_DevOps.Sprints.SprintFactory
{
    public class SprintFactory : ISprintFactory
    {
        public SprintFactory()
        {

        }

        // Factory pattern om op basis van enum de gewenste sprint aan te maken.
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl, ScrumMaster scrumMaster, AForum forum)
        {
            switch (type)
            {
                case SprintType.ReleaseSprint:
                    return new ReleaseSprint(name, startDate, endDate, project, pipeline, versionControl, scrumMaster, forum);
                case SprintType.ReviewSprint:
                    return new ReviewSprint(name, startDate, endDate, project, pipeline, versionControl, scrumMaster, forum);
                default:
                    throw new InvalidOperationException($"SprintFactory heeft geen implementatie voor type: '{type}'.");
            }
        }
    }
}
