using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public override void NextSprintState()
        {
            this._sprintState.NextState();
        }
    }
}
