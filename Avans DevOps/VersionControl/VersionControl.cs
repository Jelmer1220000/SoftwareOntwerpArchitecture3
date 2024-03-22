using Avans_DevOps.VersionControl.Strategies;

namespace Avans_DevOps.VersionControl
{
    public class VersionControl
    {
        private IVersionControlStrategy _versionController;

        public VersionControl(IVersionControlStrategy versionControl)
        {
            _versionController = versionControl;
        }

        public void Commit(string changes)
        {
            _versionController.Commit(changes);
        }

        public void Push(string branchName)
        {
            _versionController.Push(branchName);
        }

        public void Pull(string branchName)
        {
            _versionController.Pull(branchName);
        }

        public void Branch(string branchName)
        {
            _versionController.Branch(branchName);
        }

        public void CheckOut(string branchName)
        {
            _versionController.Checkout(branchName);
        }

        public void ListCommitsForRepository(string branchName, RepoTypes repoType)
        {
            _versionController.ListCommitsForRepository(branchName, repoType);
        }

        public void Merge(string from, string to)
        {
            _versionController.Merge(from, to);
        }
    }
}
