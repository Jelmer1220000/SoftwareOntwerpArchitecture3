using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints;

ReleaseSprint sprint = new ReleaseSprint();
Activity activity = new Activity();
Item item = new Item("Item1", "Test item");
Item item2 = new Item("Item2", "Test item");
item.AddActivity(activity);

sprint.AddItemToSprintBacklog(item);
sprint.AddItemToSprintBacklog(item2);

sprint.NextSprintState();
sprint.NextSprintState();

foreach (var i in sprint._sprintBackLog.GetItems())
{
    Console.WriteLine(i.Name + " " + i.Description);
}

item.GetItemState().ToDoing();



