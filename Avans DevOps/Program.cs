using Avans_DevOps;
using Avans_DevOps.Items;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using Avans_DevOps.Notifications.NotificationServices;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseActions;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseComponents;
using Avans_DevOps.Pipelines.PipelineActions.BuildComponents;
using Avans_DevOps.Pipelines.PipelineActions.DeployComponents;
using Avans_DevOps.Pipelines.PipelineActions.SourceActions;
using Avans_DevOps.Pipelines.PipelineActions.SourceComponents;
using Avans_DevOps.Pipelines.PipelineActions.TestActions;
using Avans_DevOps.Pipelines.PipelineActions.TestComponents;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Pipelines.PipelineComponents.AnalyseComponents.SonarQubeActions;
using Avans_DevOps.Pipelines.PipelineComponents.PackageComponents;
using Avans_DevOps.Pipelines.PipelineComponents.UtilityComponents;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.VersionControl;
using Avans_DevOps.VersionControl.Factory;
using Microsoft.Extensions.DependencyInjection;
using System.Security;


IServiceProvider serviceProvider = AvansDevOpsServiceCollection.BuildServiceProvider();

////// Pipeline demo ////
var pipeline = new Pipeline("Pipeline");

//Source
var source = new SourceContainer("SourceContainer");
var azureSource = new SourceAzure("SourceAzure");
source.AddComponent(azureSource);
pipeline.AddComponent(source);
//Package
var package = new Package("Package");
pipeline.AddComponent(package);
//Build
var build = new BuildContainer("BuildContainer");
var mavenBuild = new BuildMaven("BuildMaven");
var jenkinsBuild = new BuildJenkins("BuildJenkins");
build.AddComponent(jenkinsBuild);
build.AddComponent(mavenBuild);
pipeline.AddComponent(build);
//Testing
var testContainer = new TestContainer("TestContainer");
var seleniumTest = new SeleniumTests("SeleniumTests");
testContainer.AddComponent(seleniumTest);
pipeline.AddComponent(testContainer);
//Analyse
var analyseContainer = new AnalyseContainer("analyseContainer");
var sonarQube = new AnalyseSonarQube("SonarQube");
var sonarQubeExe = new SonarQubeExecute("SonarQube exe");
var sonarQubeReport = new SonarQubeReporting("SonarQubeReport");
analyseContainer.AddComponent(sonarQube);
sonarQube.AddComponent(sonarQubeExe);
sonarQube.AddComponent(sonarQubeReport);
pipeline.AddComponent(analyseContainer);
// Utility
var utility = new Utility("Utility");
var commando = new Action(() => Console.WriteLine("Doing something after"));
var commando2 = new Action(() => Console.WriteLine("Doing something after 2"));
var commando3 = new Action(() => Console.WriteLine("Doing something after 3"));
utility.AddAction(commando);
utility.AddAction(commando2);
utility.AddAction(commando3);
pipeline.AddComponent(utility);

var productOwner = new User("ProductOwner");
var tester = new User("Tester1");
var scrumMaster = new User("Scrum Master");

//productOwner.AddNotificationPreference(new SlackNotificationsService());
//productOwner.AddNotificationPreference(new MailNotificationsService());

//scrumMaster.AddNotificationPreference(new MailNotificationsService());

//tester.AddNotificationPreference(new SlackNotificationsService());
//tester.AddNotificationPreference(new MailNotificationsService());

var sprintFactory = serviceProvider.GetService<ISprintFactory>();
var versionControlFactory = serviceProvider.GetService<IVersionControlFactory>();
var project = new Project("Kramse", productOwner, sprintFactory, VersionControlTypes.Git, versionControlFactory);
var versionController = project.GetVersionController();
project.AddTester(tester);
project.SetScrumMaster(scrumMaster);
project.CreateSprint(SprintType.ReleaseSprint, "Sprint 1", new DateOnly(2024, 1, 10), new DateOnly(2024, 1, 24), pipeline);

var sprint1 = project.GetSprintByName("Sprint 1");
project.AddItemToProjectBackLog("userinterface", "Test item1");
project.AddItemToProjectBackLog("authentication", "Test item2");
project.AddItemToProjectBackLog("logic", "Test item3");
var projectBacklog = project.GetBacklog();
var item1 = projectBacklog[0];
var item2 = projectBacklog[1];
var item3 = projectBacklog[2];

Activity activity = new Activity();
item1.AddActivity(activity);


sprint1.AddItemToSprintBacklog(item1, true);
sprint1.AddItemToSprintBacklog(item2, false);

versionController.CheckOut("feature-userinterface".ToLower());
versionController.Commit("Small button added");
versionController.Commit("Large button added");
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Local);
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);
versionController.Push();
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);

sprint1.NextSprintState();
//sprint1.AddItemToSprintBacklog(item3, true);

//Naar doing.
item1.ToDoingState();

//Notificatie naar testers
item1.ToReadyForTestingState();

item1.ToDoneState();

//Bij release Pipeline wordt gestart zodra sprint state naar release gaat.
sprint1.NextSprintState();

//Notificatie naar scrum master en product owner omdat sprint naar done gaat.
sprint1.NextSprintState();

