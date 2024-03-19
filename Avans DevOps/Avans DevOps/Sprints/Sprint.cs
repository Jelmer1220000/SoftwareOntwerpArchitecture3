using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Sprints
{
    public abstract class Sprint
    {

        protected ISprintState _sprintState;

        public string Name { get; set; } = "";
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Sprint()
        {
          _sprintState = new PlanningState(this);
        }

        public void AdvanceState(ISprintState state)
        {
            this._sprintState = state;
        }

        public abstract void NextSprintState();
    }
}
