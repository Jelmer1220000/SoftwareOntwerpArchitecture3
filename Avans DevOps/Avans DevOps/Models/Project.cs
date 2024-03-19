using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Models
{
    public class Project
    {
        public string _Name;

        private readonly TeamMembers _ProductOwner;
        private TeamMembers? _ScrumMaster;
        private IList<TeamMembers>? _Developers = [];



        public Project(string name, TeamMembers productOwner)
        {
            _Name = name;
            _ProductOwner = productOwner;
        }


        public void AddDeveloper(TeamMembers developer)
        {
            _Developers.Add(developer);
        }

        public void SetScrumMaster(TeamMembers scrumMaster)
        {
            _ScrumMaster = scrumMaster;
        }

        public TeamMembers GetScrumMaster()
        {
            return _ScrumMaster!;
        }
    }
}
