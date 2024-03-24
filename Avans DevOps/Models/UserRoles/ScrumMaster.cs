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

        public override bool CanManagePipeline()
        {
            return true;
        }

        public override void ScrumMasterUpdate(string text)
        {
            base.Update(text);
        }

        public override void SprintUpdate(string text)
        {
            base.Update(text);
        }
    }
}
