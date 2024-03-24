using Avans_DevOps.Models;
using Avans_DevOps.Sprints;

namespace Avans_DevOps.Rapport.Document.Parts
{
    public class Body
    {
        public IList<User> Users;
        public IList<Sprint> Sprints;

        public Body()
        {
            Users = [];
            Sprints = [];
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddSprint(Sprint sprint)
        {
            Sprints.Add(sprint);
        }
    }
}
