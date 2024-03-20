using Avans_DevOps.Sprints;
using Avans_DevOps.Sprints.SprintFactory;

namespace Avans_DevOps.Models
{
    public class Project
    {
        public string _Name;

        private readonly TeamMember _productOwner;
        private TeamMember? _scrumMaster;
        private IList<TeamMember> _developers;
        private SprintFactory _sprintFactory;
        private IList<Sprint> _sprints;



        public Project(string name, TeamMember productOwner)
        {
            _Name = name;
            _productOwner = productOwner;
            _developers = [];
            _sprints = [];

            // Dependency Injection?
            _sprintFactory = new SprintFactory();
        }


        public void AddDeveloper(TeamMember developer)
        {
            _developers.Add(developer);
        }

        public void SetScrumMaster(TeamMember scrumMaster)
        {
            _scrumMaster = scrumMaster;
        }

        public TeamMember GetScrumMaster()
        {
            return _scrumMaster!;
        }

        public void CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate)
        {
            var newSprint = _sprintFactory.CreateSprint(type, name, startDate, endDate);
            _sprints.Add(newSprint);
        }

        public Sprint? GetSprintByName(string name)
        {
            var sprint = _sprints.Where(s => s.Name == name).FirstOrDefault();
            return sprint;
        } 
    }
}
