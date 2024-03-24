namespace Avans_DevOps.VersionControl.Strategies
{
    public interface IVersionControlStrategy
    {
        void Commit(string changes);
        void Push();
        void Pull(string branchName);
        void Branch(string branchName);
        void Checkout(string branchName);
        void Merge(string fromBranch, string toBranch);
        void ListCommitsForRepository(string branchName, RepoTypes repositoryType);
    }
}
