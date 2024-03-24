using Avans_DevOps.Forums;
using Avans_DevOps.Items;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl;
using Avans_DevOps.VersionControl.Factory;
using Avans_DevOps.VersionControl.Strategies;

namespace Avans_DevOps.Models
{
    public class Project
    {
        public string _Name;
        private readonly ProductOwner _productOwner;
        private ScrumMaster? _scrumMaster;
        private LeadDeveloper _leadDeveloper;
        private IList<Developer> _developers;
        private IList<Tester> _testers;
        private IList<Sprint> _sprints;
        private ISprintFactory _sprintFactory;
        private IVersionControlFactory _versionControlFactory;
        private IVersionControl _versionControl;
        private IList<Item> _projectBacklog;
        private AForum _forum;


        public Project(string name, ProductOwner productOwner, ISprintFactory sprintFactory, VersionControlTypes type, IVersionControlFactory versionControlFactory)
        {
            _Name = name;
            _productOwner = productOwner;
            _developers = [];
            _sprints = [];
            _testers = [];
            _projectBacklog = [];
            _sprintFactory = sprintFactory;
            _versionControlFactory = versionControlFactory;
            _versionControl = _versionControlFactory.CreateVersionControl(type);
            _forum = new AForum();
        }



        //Maakt een item aan voegt deze toe aan de backlog van het project.
        public void AddItemToProjectBackLog(string name, string desciption)
        {
            var item = new Item(name, desciption, this, _forum);
            _projectBacklog.Add(item);
        }

        public void SetLeadDeveloper(LeadDeveloper developer)
        {
            _leadDeveloper = developer;
        }

        public LeadDeveloper GetLeadDeveloper()
        {
            return this._leadDeveloper;
        }

        public AForum GetForum()
        {
            return this._forum;
        }

        public IList<Item> GetBacklog()
        {
            return _projectBacklog;
        }

        public IVersionControl GetVersionController()
        {
            return _versionControl;
        }

        public void AddDeveloper(ProductOwner owner, Developer userToAdd)
        {
            if (owner != null) _developers.Add(userToAdd);
        }

        public IList<Developer> GetDevelopers()
        {
            return this._developers;
        }

        public void AddTester(Tester tester)
        {
            _testers.Add(tester);
        }

        public void SetScrumMaster(ScrumMaster scrumMaster)
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

        public IList<Tester> GetTesters()
        {
            return _testers;
        }

        public void CreateSprint(SprintType type, string name, DateOnly startDate, DateOnly endDate, Pipeline pipeline, AForum forum)
        {
            var newSprint = _sprintFactory.CreateSprint(type, name, startDate, endDate, this, pipeline, _versionControl, _scrumMaster, forum);
            _sprints.Add(newSprint);
        }

        public Sprint? GetSprintByName(string name)
        {
            var sprint = _sprints.Where(s => s.Name == name).FirstOrDefault();
            return sprint;
        } 
    }
}
