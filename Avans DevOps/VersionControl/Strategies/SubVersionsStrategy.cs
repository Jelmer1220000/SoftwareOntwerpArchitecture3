namespace Avans_DevOps.VersionControl.Strategies
{
    public class SubVersionsStrategy : IVersionControlStrategy
    {
        // Subversion logic here.
        public void Branch(string branchName)
        {
            throw new NotImplementedException();
        }

        public void Checkout(string branchName)
        {
            throw new NotImplementedException();
        }

        public void Commit(string changes)
        {
            throw new NotImplementedException();
        }

        public void ListCommitsForRepository(string branchName, RepoTypes repositoryType)
        {
            throw new NotImplementedException();
        }

        public void Merge(string fromBranch, string toBranch)
        {
            throw new NotImplementedException();
        }

        public void Pull(string branchName)
        {
            throw new NotImplementedException();
        }

        public void Push()
        {
            throw new NotImplementedException();
        }
    }
}
