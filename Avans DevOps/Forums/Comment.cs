using Avans_DevOps.Models;

namespace Avans_DevOps.Forums
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public User User { get; set; }
        public IList<Comment> Comments { get; set; }

        public Comment(User user, string content)
        {
            User = user;
            Content = content;
            Comments = [];
            Id = Guid.NewGuid();
        }

        public void ReactToComment(Comment comment)
        {
            Comments.Add(comment);
        }

    }
}
