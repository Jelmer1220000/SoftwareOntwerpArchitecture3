using Avans_DevOps.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Models.UserRoles
{
    public class LeadDeveloper : User
    {
        public LeadDeveloper(string name) : base(name)
        {
        }

        public override bool CanMoveBacklogItemFromTested()
        {
            return true;
        }
    }
}
