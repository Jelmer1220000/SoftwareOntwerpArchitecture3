namespace Avans_DevOps.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Activity> Activities { get; set; }

        public Item()
        {
            Activities = new List<Activity>();
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            Activities.Remove(activity);
        }
    }
}
