using Avans_DevOps.VersionControl.Strategies;

namespace Avans_DevOps.VersionControl.Factory
{
    public class VersionControlFactory : IVersionControlFactory
    {
        public IVersionControl CreateVersionControl(VersionControlTypes type)
        {

            switch (type)
            {
                case VersionControlTypes.Git:
                    return new VersionControl(new GitStrategy());
                case VersionControlTypes.SubVersion:
                    return new VersionControl(new SubVersionsStrategy());
                default:
                    throw new InvalidOperationException($"VersionControlStrategy heeft geen implementatie voor type: '{type}'.");
            }
        }
    }
}
