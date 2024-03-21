using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using Avans_DevOps.Sprints.SprintStates;
using Avans_DevOps.Sprints.Visitor;

namespace Avans_DevOps.Sprints
{
    public abstract class Sprint
    {

        protected SprintState _sprintState;
        public Backlog _sprintBackLog;

        private readonly NotificationSubject _notificationSubject = new NotificationSubject();

        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Sprint(string name, DateOnly startDate, DateOnly endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Id = Guid.NewGuid();

            _sprintBackLog = new Backlog();
            _sprintState = new PlanningState(this);
        }

        //Veranderd de state van de huidige context.
        public void ChangeState(SprintState state)
        {
            this._sprintState = state;
            this._sprintState.OnEnter();
        }

        //Gaat naar de volgende state.
        public abstract void NextSprintState();

        //Staat een visitor toe vanuit de states (voor Review/Release sprint)
        internal abstract void AcceptVisitor(ISprintVisitor visitor);

        public void AddItemToSprintBacklog(Item item)
        {
            _sprintBackLog.Add(item);
        }

        //Voegt Listener toe voor notificaties
        public void AddSubscriber(User member)
        {
            _notificationSubject.AddSubscriber(member);
        }

        public void RemoveSubscriber(User member)
        {
            _notificationSubject.RemoveSubscriber(member);
        }

        //Verstuurd notificatie naar alle Listeners
        public void NotifySubscribers()
        {
            _notificationSubject.SendNotifications();
        }

    }
}
