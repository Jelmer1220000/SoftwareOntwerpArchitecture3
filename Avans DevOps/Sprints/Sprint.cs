using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints.SprintStates;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints
{
    public abstract class Sprint
    {

        protected SprintState _sprintState;
        public Backlog _sprintBackLog;

        private Pipeline _pipeline;
        private Project _project;

        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        private bool _isLocked;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Sprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            _isLocked = false;
            Id = Guid.NewGuid();

            this._project = project;
            _pipeline = pipeline;
            _sprintBackLog = new Backlog(this);
            _sprintState = new PlanningState(this);
        }

        //Veranderd de state van de huidige context.
        public void ChangeState(SprintState state)
        {
            if (!_isLocked)
            {
                this._sprintState = state;
                this._sprintState.OnEnter();
            }
        }

        public void RunPipeline()
        {
            _pipeline.AcceptVisitor(new PipelineVisitor());
        }

        public Project GetProject()
        {
            return this._project;
        }

        //Gaat naar de volgende state.
        public abstract void NextSprintState();

        //Staat een visitor toe vanuit de states (voor Review/Release sprint)
        internal abstract void AcceptVisitor(ISprintVisitor visitor);

        public void AddItemToSprintBacklog(Item item)
        {
            _sprintBackLog.Add(item);
        }
    }
}
