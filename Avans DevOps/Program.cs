using Avans_DevOps;
using Avans_DevOps.Forums;
using Avans_DevOps.Models;
using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Notifications.NotificationServices;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseActions;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseComponents;
using Avans_DevOps.Pipelines.PipelineActions.BuildComponents;
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

IServiceProvider serviceProvider = AvansDevOpsServiceCollection.BuildServiceProvider();


//----------------Pipeline------------------
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

//----------------Pipeline-----------------------

//----------------Project gebruikers-------------
var productOwner = new ProductOwner("ProductOwner");
var tester = new Tester("Tester1");
var scrumMaster = new ScrumMaster("Scrum Master");
var developer1 = new Developer("Developer1");
//----------------Project gebruikers-------------

//----------------Notificaties-------------------

// Product owner notificaties
//productOwner.AddNotificationPreference(new SlackNotificationsService());
//productOwner.AddNotificationPreference(new MailNotificationsService());

// Notificaties voor scrumMaster op gebied van Items en voor Threads
//scrumMaster.AddNotificationPreference(new MailNotificationsService());
//developer1.AddNotificationPreference(new MailNotificationsService());

// Notificaties voor testers wanneer item in ReadyForTesting komt
//tester.AddNotificationPreference(new SlackNotificationsService());
//tester.AddNotificationPreference(new MailNotificationsService());

//----------------Notificaties-------------------

//--------------Factories dependency injection---
var sprintFactory = serviceProvider.GetService<ISprintFactory>();
var versionControlFactory = serviceProvider.GetService<IVersionControlFactory>();
//--------------Factories dependency injection---

//----------------Project opzet------------------
var project = new Project("Kramse", productOwner, sprintFactory, VersionControlTypes.Git, versionControlFactory);
var versionController = project.GetVersionController();
project.AddTester(tester);
project.AddDeveloper(developer1);
project.SetScrumMaster(scrumMaster);
//----------------Project opzet------------------

var forum = project.GetForum();
project.CreateSprint(SprintType.ReviewSprint, "Sprint 1", new DateOnly(2024, 1, 10), new DateOnly(2024, 1, 24), pipeline, forum);

//----------------Sprint opzet-------------------
var sprint1 = project.GetSprintByName("Sprint 1");
project.AddItemToProjectBackLog("userinterface", "Test item1");
project.AddItemToProjectBackLog("authentication", "Test item2");
project.AddItemToProjectBackLog("logic", "Test item3");
var projectBacklog = project.GetBacklog();
var item1 = projectBacklog[0];
var item2 = projectBacklog[1];
var item3 = projectBacklog[2];
//----------------Sprint opzet-------------------



//------------------Threads----------------------
item1.StartThread("Interface", "Interface heeft geen API call", developer1);
var thread = item1.GetThread();

item2.StartThread("Authenticatie", "Authenticatie werkt niet!", scrumMaster);
var thread2 = item2.GetThread();

//Comments op beide threads
var comment = new Comment(scrumMaster, "API call bestaat maar valt onder security");
var comment2 = new Comment(developer1, "Authenticatie moet nog aangepast worden naar de nieuwe versie");

//Reacties op de comments
var reaction = new Comment(developer1, "OK");
var reaction2 = new Comment(productOwner, "Leg hier even prioriteit op a.u.b");

thread.ReactToThread(comment);
thread.ReactOnComment(comment, reaction);

thread2.ReactToThread(comment2);
thread2.ReactOnComment(comment2, reaction2);

//------------------Threads----------------------

//------------------Activities-------------------
Activity activity = new Activity();
item1.AddActivity(activity);
//------------------Activities-------------------

//--------------------Items----------------------
sprint1.AddItemToSprintBacklog(item1, true);
sprint1.AddItemToSprintBacklog(item2, false);
//--------------------Items----------------------


//---------------------Git-----------------------
versionController.CheckOut("feature-userinterface".ToLower());
versionController.Commit("Small button added");
versionController.Commit("Large button added");
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Local);
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);
versionController.Push();
versionController.ListCommitsForRepository("feature-userinterface".ToLower(), RepoTypes.Remote);
//---------------------Git-----------------------

//-------------------Sprint----------------------
sprint1.NextSprintState();
//sprint1.AddItemToSprintBacklog(item3, true);

//Naar doing.
item1.ToDoingState(developer1);

//Notificatie naar testers
item1.ToReadyForTestingState();

item1.ToDoneState();

//Bij release Pipeline wordt gestart zodra sprint state naar release gaat, bij review wordt een file verwacht.
sprint1.NextSprintState();
sprint1.NextSprintState();

var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
sprint1.UploadReview(scrumMaster, sevenItems);
//-------------------Sprint----------------------

//----------------Thread test--------------------
foreach (var Thread in forum.GetAllThreads())
{
    Console.WriteLine($"Thread in forum: {Thread.Title}");
}
//----------------Thread test--------------------

