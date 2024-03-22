namespace Avans_DevOps.VersionControl.Factory
{
    public interface IVersionControlFactory
    {
        IVersionControl CreateVersionControl(VersionControlTypes type);
    }
}
