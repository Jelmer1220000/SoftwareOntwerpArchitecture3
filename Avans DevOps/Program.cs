using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Sprints.SprintFactory;









var productOwner = new TeamMember("Jelmer");
var project = new Project("Kramse", productOwner);

project.CreateSprint(SprintType.ReviewSprint, "Sprint 1", new DateOnly(2024, 1, 10), new DateOnly(2024, 1, 24));

var sprint1 = project.GetSprintByName("Sprint 1");

Item item = new Item("Item1", "Test item");
Item item2 = new Item("Item2", "Test item");
Activity activity = new Activity();
item.AddActivity(activity);

sprint1.AddItemToSprintBacklog(item);
sprint1.AddItemToSprintBacklog(item2);

sprint1.NextSprintState();
sprint1.NextSprintState();



item.ToDoingState();
