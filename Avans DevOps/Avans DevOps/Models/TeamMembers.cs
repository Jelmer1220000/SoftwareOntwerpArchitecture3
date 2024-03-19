using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Models
{
    public class TeamMembers
    {
        private string Name { get; set; } = "";


        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName() { return Name; }
    }
}
