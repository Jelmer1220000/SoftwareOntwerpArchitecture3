namespace Avans_DevOps.VersionControl
{
    public  interface IVersionControl
    {
        public void Commit(string changes);

        public void Push();

        public void Pull(string branchName);

        public void Branch(string branchName);

        public void CheckOut(string branchName);

        public void ListCommitsForRepository(string branchName, RepoTypes repoType);

        public void Merge(string from, string to);
    }
}
