namespace Avans_DevOps.Models.UserRoles
{
    public class ProductOwner : User
    {
        public ProductOwner(string name) : base(name)
        {
        }

        public void SprintUpdates(string text)
        {
            base.Update(text);
        }

        public override void ProductOwnerUpdate(string text)
        {
            base.Update(text);
        }
    }
}
