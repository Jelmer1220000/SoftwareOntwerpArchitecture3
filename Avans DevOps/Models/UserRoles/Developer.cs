namespace Avans_DevOps.Models.UserRoles
{
    public class Developer : User
    {
        public Developer(string name) : base(name)
        {
        }

        public override void ItemUpdate(string text)
        {
            base.Update(text);
        }
    }
}
