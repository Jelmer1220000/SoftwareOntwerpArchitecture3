using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints.SprintStates;
using Avans_DevOps.VersionControl;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints
{
    public abstract class Sprint
    {

        protected SprintState _sprintState;
        public IList<Item> _sprintBackLog;

        private Pipeline _pipeline;
        private Project _project;

        private IVersionControl _versionControl;
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        private bool _isLocked;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Sprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            _isLocked = false;
            Id = Guid.NewGuid();
            _versionControl = versionControl;

            _project = project;
            _pipeline = pipeline;
            _sprintBackLog = [];
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

        public void AddItemToSprintBacklog(Item item, bool withBranch)
        {
            _sprintState.AddItem(item);
            if (withBranch)
            {
                _versionControl.Branch($"feature-{item.Name.ToLower()}");
                _versionControl.CheckOut($"feature-{item.Name.ToLower()}");
                _versionControl.Push();
                _versionControl.CheckOut($"main");
            }
        }
    }
}
