using Avans_DevOps.Forums;
using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Notifications;
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

        public Pipeline Pipeline;
        private Project _project;

        private IVersionControl _versionControl;
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        private bool _isLocked;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        private ISubject _notificationService;

        private ScrumMaster _scrumMaster;
        private AForum _forum;

        public Sprint(string name, DateOnly startDate, DateOnly endDate, Project project, Pipeline pipeline, IVersionControl versionControl, ScrumMaster scrumMaster, AForum forum)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            _isLocked = false;
            Id = Guid.NewGuid();
            _versionControl = versionControl;

            _scrumMaster = scrumMaster;
            _project = project;
            Pipeline = pipeline;
            _sprintBackLog = [];
            _sprintState = new PlanningState(this);
            _forum = forum;
            _notificationService = new NotificationSubject();
        }

        public void InjectNotificationService(ISubject notificationService)
        {
            _notificationService = notificationService;
        }

        //Veranderd de state van de huidige context.
        public void ChangeState(SprintState state)
        {
            if (!_isLocked)
            {
                _sprintState = state;
                _sprintState.OnEnter();
            }
        }

        public void ChangeProperties(string name, DateOnly startDate, DateOnly endDate)
        {
            this._sprintState.ChangeProperties(name, startDate, endDate);
        }

        public Project GetProject()
        {
            return _project;
        }

        //Gaat naar de volgende state.
        public abstract void NextSprintState();

        //Staat een visitor toe vanuit de states (voor Review/Release sprint)
        internal abstract void AcceptVisitor(ISprintVisitor visitor);

        public void AddItemToSprintBacklog(Item item, int storyPoints, bool withBranch)
        {
            item.SetStoryPoints(storyPoints);
            _sprintState.AddItem(item);
            if (withBranch)
            {
                _versionControl.Branch($"feature-{item.Name.ToLower()}");
                _versionControl.CheckOut($"feature-{item.Name.ToLower()}");
                _versionControl.Push();
                _versionControl.CheckOut($"main");
            }
        }

        public void UploadReview(User user, byte[] review)
        {
            _sprintState.UploadReview(user, review);
        }

        public void AddSubscriber(User user)
        {
            _notificationService.AddSubscriber(user);
        }

        public void RemoveSubscriber(User user)
        {
            _notificationService.RemoveSubscriber(user);
        }

        public void UpdateProductOwner(string text)
        {
            _notificationService.SendProductOwnerUpdate(text);
        }

        public void UpdateScrumMaster(string text)
        {
            _notificationService.SendScrumMasterUpdate(text);
        }

        public void UpdateSprint(string text)
        {
            _notificationService.SendSprintUpdate(text);
        }

        public void RunPipeline(User user, bool fail)
        {
            _sprintState.RunPipeline(user, fail);
        }
    }
}
