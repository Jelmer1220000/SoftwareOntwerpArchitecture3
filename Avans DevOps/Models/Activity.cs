namespace Avans_DevOps.Models
{
    public class Activity
    {
        private bool _isDone = false;

        

        public bool SetActivityState(bool  isDone)
        {
           return _isDone = isDone;
        }

        public bool isActivityDone()
        {
            return _isDone;
        }
    }
}
