namespace Avans_DevOps.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
