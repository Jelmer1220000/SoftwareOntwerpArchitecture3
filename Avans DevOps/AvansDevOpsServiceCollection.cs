<<<<<<< Updated upstream
using Avans_DevOps.Rapport.RapportFactory;
=======
﻿
using Avans_DevOps.Notifications;
>>>>>>> Stashed changes
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl.Factory;
using Microsoft.Extensions.DependencyInjection;
namespace Avans_DevOps

{
    public class AvansDevOpsServiceCollection
    {

        public static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISprintFactory, SprintFactory>();
<<<<<<< Updated upstream
            serviceCollection.AddSingleton<IRapportFactory, RapportFactory>();
=======
            serviceCollection.AddSingleton<ISubject, NotificationSubject>();
>>>>>>> Stashed changes
            serviceCollection.AddSingleton<VersionControl.IVersionControl, VersionControl.VersionControl>();
            serviceCollection.AddSingleton<IVersionControlFactory, VersionControlFactory>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
