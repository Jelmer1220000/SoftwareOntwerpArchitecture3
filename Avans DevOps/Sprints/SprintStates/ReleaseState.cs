﻿using Avans_DevOps.Notifications;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReleaseState : SprintState
    {
        private readonly Sprint _context;
        private NotificationSubject _notificationSubject = new NotificationSubject();

        public ReleaseState(Sprint sprint)
        {
            _context = sprint;
            _notificationSubject.AddSubscriber(_context.GetProject().GetScrumMaster());
        }

        public override void NextState()
        {
            _context.ChangeState(new ClosedState(_context));
        }

        public override void OnEnter()
        {
            Console.WriteLine("Sprint entered: " + this.GetType().Name);

            try
            {
                _context.RunPipeline();
                NextState();
            } catch (Exception e)
            {
                _notificationSubject.SendNotifications($"Pipeline for sprint: '{_context.Name}' failed on: {e.Message}");

                //TRY AGAIN OR CANCEL PIPELINE
                Console.WriteLine("Try again? Yes/No");
                string tryAgain = Console.ReadLine()!;

                if (tryAgain == "Yes") OnEnter();
            }
        }
    }
}
