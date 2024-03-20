namespace Avans_DevOps.Sprints.SprintFactory
{
    public class SprintFactory
    {

        // Factory pattern om op basis van enum de gewenste sprint aan te maken.
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate)
        {
            switch (type)
            {
                case SprintType.ReleaseSprint:
                    return new ReleaseSprint(name, startDate, endDate);
                case SprintType.ReviewSprint:
                    return new ReviewSprint(name, startDate, endDate); ;
                default:
                    throw new InvalidOperationException($"SprintFactory heeft geen implementatie voor type: '{type}'.");
            }
        }
    }
}
