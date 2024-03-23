
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl;
using Avans_DevOps.VersionControl.Factory;
using Avans_DevOps.VersionControl.Strategies;
using Microsoft.Extensions.DependencyInjection;
namespace Avans_DevOps

{
    public class AvansDevOpsServiceCollection
    {

        public static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISprintFactory, SprintFactory>();
            serviceCollection.AddSingleton<VersionControl.IVersionControl, VersionControl.VersionControl>();
            serviceCollection.AddSingleton<IVersionControlFactory, VersionControlFactory>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
