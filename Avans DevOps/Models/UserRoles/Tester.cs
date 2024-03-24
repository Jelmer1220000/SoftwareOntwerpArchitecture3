using Avans_DevOps.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Models.UserRoles
{
    public class Tester : User
    {
        public Tester(string name) : base(name)
        {
        }

        public override void TestersUpdate(string text)
        {
            base.Update(text);
        }
    }
}
