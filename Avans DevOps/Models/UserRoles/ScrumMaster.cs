namespace Avans_DevOps.Models.UserRoles
{
    public class ScrumMaster : User
    {
        public ScrumMaster(string name) : base(name)
        {
        }

        public override bool CanUploadReview()
        {
            return true;
        }
    }
}
