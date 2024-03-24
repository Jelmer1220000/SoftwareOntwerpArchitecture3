using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using Avans_DevOps.Sprints;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Visitor;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReleaseState : SprintState
    {
        private readonly Sprint _context;

        public ReleaseState(Sprint sprint)
        {
            _context = sprint;
        }

        public override void NextState()
        {
            _context.ChangeState(new ClosedState(_context));
        }

        public override void RunPipeline(User user, bool fail)
        {
            if (!fail) { 
                _context.Pipeline.AcceptVisitor(new PipelineVisitor());
                NextState();
            } else
            {
                _context.UpdateScrumMaster($"Pipeline for sprint: '{_context.Name}' failed");

                //TRY AGAIN OR CANCEL PIPELINE
                Console.WriteLine("Try again? Yes/No");

                //string tryAgain = Console.ReadLine()!;
                //if (tryAgain == "Yes") RunPipeline(user, false);
            }
        }
    }
}
