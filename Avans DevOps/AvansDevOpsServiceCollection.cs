
using Avans_DevOps.Sprints.SprintFactory;
using Microsoft.Extensions.DependencyInjection;
namespace Avans_DevOps

{
    public class AvansDevOpsServiceCollection
    {

        public static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISprintFactory, SprintFactory>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
