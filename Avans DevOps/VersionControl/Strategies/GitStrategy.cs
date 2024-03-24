namespace Avans_DevOps.VersionControl.Strategies
{
    public class GitStrategy : IVersionControlStrategy
    {
        public Dictionary<string, List<string>> _localRepository = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> _remoteRepository = new Dictionary<string, List<string>>();
        private string _currentBranch;

        public GitStrategy(string mainBranch = "main")
        {
            _currentBranch = mainBranch;
            _localRepository.Add("main", new List<string>());
            _remoteRepository.Add("main", new List<string>());
        }

        //Wisselen van branch
        public void Checkout(string branchName)
        {
            if (!_localRepository.ContainsKey(branchName))
            {
                Console.WriteLine($"GIT: Branch '{branchName}' doesn't exist in the local repository. Create or pull it from the remote first.");
                return;
            }

            _currentBranch = branchName;
            Console.WriteLine($"GIT: Switched to branch '{branchName}'.");
        }

        //Aanmaken van branch
        public void Branch(string branchName)
        {
            if (!_localRepository.ContainsKey(branchName))
            {
                _localRepository[branchName] = new List<string>();
                Console.WriteLine($"GIT: Created new branch '{branchName}' in local repository.");
            }
        }

        //Commit code changes naar huidige branch
        public void Commit(string changes)
        {
            if (string.IsNullOrEmpty(_currentBranch))
            {
                Console.WriteLine("GIT: No branch selected. Please select a branch using Checkout.");
                return;
            }

            if (!_localRepository.ContainsKey(_currentBranch))
                _localRepository[_currentBranch] = new List<string>();

            _localRepository[_currentBranch].Add(changes);
            Console.WriteLine($"GIT: Committed changes '{changes}' to branch '{_currentBranch}' in local repository.");
        }

        //Push branch naar de remote repo
        public void Push()
        {
            if (!_localRepository.ContainsKey(_currentBranch))
            {
                Console.WriteLine($"GIT: Branch '{_currentBranch}' doesn't exist in the local repository.");
                return;
            }

            if (!_remoteRepository.ContainsKey(_currentBranch))
            {
                _remoteRepository[_currentBranch] = new List<string>();
            }

            _remoteRepository[_currentBranch].AddRange(_localRepository[_currentBranch]);
            Console.WriteLine($"GIT: Pushed changes from branch '{_currentBranch}' in local repository to remote repository.");
        }

        //Haal branch op van de remote repo.
        public void Pull(string branchName)
        {
            if (!_remoteRepository.ContainsKey(branchName))
            {
                Console.WriteLine($"GIT: Branch '{branchName}' doesn't exist in the remote repository.");
                return;
            }

            if (!_localRepository.ContainsKey(branchName))
                _localRepository[branchName] = [];

            _localRepository[branchName].AddRange(_remoteRepository[branchName]);
            Console.WriteLine($"GIT: Pulled changes from remote repository to branch '{branchName}' in local repository.");
        }


        //Laat commits zien van branch en specifieke repo.
        public void ListCommitsForRepository(string branchName, RepoTypes repositoryType)
        {
            var repository = repositoryType == RepoTypes.Local ? _localRepository : _remoteRepository;

            if (!repository.ContainsKey(branchName))
            {
                Console.WriteLine($"GIT: No {repositoryType} repository found for branch '{branchName}'.");
                return;
            }
            Console.WriteLine($"GIT: ({repositoryType} repository) Commits in branch '{branchName}' ");
            if (repository[branchName].Count == 0)
            {
                Console.WriteLine($"GIT: No commits in the {repositoryType} repository.");
            }
            else
            {
                foreach (var commit in repository[branchName])
                {
                    Console.WriteLine($"GIT: - {commit}");
                }
            }
        }

        // merge twee branches (lokaal)
        public void Merge(string sourceBranch, string destinationBranch)
        {
            if (!_localRepository.ContainsKey(sourceBranch))
            {
                Console.WriteLine($"GIT: Source branch '{sourceBranch}' doesn't exist in the local repository.");
                return;
            }

            if (!_localRepository.ContainsKey(destinationBranch))
            {
                Console.WriteLine($"GIT: Destination branch '{destinationBranch}' doesn't exist in the local repository.");
                return;
            }

            Console.WriteLine($"GIT: Merging changes from branch '{sourceBranch}' into branch '{destinationBranch}'");

            // Merge changes from source branch to destination branch
            _localRepository[destinationBranch].AddRange(_localRepository[sourceBranch]);

            Console.WriteLine($"GIT: Merge successful. Changes from branch '{sourceBranch}' merged into branch '{destinationBranch}'.");
        }
    }
}
