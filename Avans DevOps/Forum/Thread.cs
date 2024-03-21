using Avans_DevOps.Items;

namespace Avans_DevOps.Forum
{
    public class Thread
    {
        public string Title;
        public string Description;
        public Item BacklogItem;
        public IList<Comment> Comments;

        public Thread(string title, string description, Item backlogItem)
        {
            Title = title;
            Description = description;
            BacklogItem = backlogItem;
            Comments = [];
        }

        public void ReactToThread(Comment reaction)
        {
            Comments.Add(reaction);
        }

        public IList<Comment> GetAllComments(){
            return Comments.ToList();
        }
    }
}
