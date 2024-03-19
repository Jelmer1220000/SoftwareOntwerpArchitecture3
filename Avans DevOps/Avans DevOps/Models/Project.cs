namespace Avans_DevOps.Models
{
    public class Project
    {
        public string _Name;

        private readonly TeamMember _productOwner;
        private TeamMember? _scrumMaster;
        private IList<TeamMember> _developers;



        public Project(string name, TeamMember productOwner)
        {
            _Name = name;
            _productOwner = productOwner;
            _developers = [];
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
    }
}
