namespace Avans_DevOps.Sprints.SprintFactory
{
    public interface ISprintFactory
    {
        public Sprint CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate);
    }
}
