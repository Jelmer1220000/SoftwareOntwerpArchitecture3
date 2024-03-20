
namespace Avans_DevOps.Sprints
{
    public class ReviewSprint : Sprint
    {
        public ReviewSprint(string name, DateOnly startDate, DateOnly endDate) : base(name, startDate, endDate)
        {
        }

        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
