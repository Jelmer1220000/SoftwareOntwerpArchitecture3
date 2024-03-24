using Avans_DevOps.Items;
using Avans_DevOps.Sprints;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;

namespace Avans_DevOps.Sprints.SprintStates
{
    public class ReviewState : SprintState
    {

        private readonly ReviewSprint _context;

        public ReviewState(ReviewSprint sprint)
        {
            _context = sprint;
        }

        public override void NextState()
        {
            _context.ChangeState(new ClosedState(_context));
        }


        public override void OnEnter()
        {
            Console.WriteLine("Sprint entered: " + this.GetType().Name);
            Console.WriteLine("Upload a review file");
        }

        public override void UploadReview(User user, byte[] review)
        {

            if (user.CanUploadReview())
            {
                _context.reviewFile = review;
                NextState();
            }
        }
    }
}
