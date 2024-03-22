using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints;
using Avans_DevOps.Sprints.SprintFactory;

namespace Avans_DevOps.Models
{
    public class Project
    {
        public string _Name;

        private readonly User _productOwner;
        private User? _scrumMaster;
        private IList<User> _developers;
        private IList<User> _testers;
        private IList<Sprint> _sprints;
        private ISprintFactory _sprintFactory;


        public Project(string name, User productOwner, ISprintFactory sprintFactory)
        {
            _Name = name;
            _productOwner = productOwner;
            _developers = [];
            _sprints = [];
            _testers = [];
            _sprintFactory = sprintFactory;
        }


        public void AddDeveloper(User developer)
        {
            _developers.Add(developer);
        }

        public void AddTester(User tester)
        {
            _testers.Add(tester);
        }

        public void SetScrumMaster(User scrumMaster)
        {
            _scrumMaster = scrumMaster;
        }

        public User GetScrumMaster()
        {
            return _scrumMaster!;
        }

        public User GetProductOwner()
        {
            return _productOwner;
        }

        public IList<User> GetTesters()
        {
            return _testers;
        }

        public void CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Pipeline pipeline)
        {
            var newSprint = _sprintFactory.CreateSprint(type, name, startDate, endDate, this, pipeline);
            _sprints.Add(newSprint);
        }

        public Sprint? GetSprintByName(string name)
        {
            var sprint = _sprints.Where(s => s.Name == name).FirstOrDefault();
            return sprint;
        } 
    }
}
