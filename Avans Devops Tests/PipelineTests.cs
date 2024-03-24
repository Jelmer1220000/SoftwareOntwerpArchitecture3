using Avans_DevOps.Models.UserRoles;
using Avans_DevOps.Models;
using Avans_DevOps.Notifications;
using Avans_DevOps.Pipelines.PipelineComponents;
using Avans_DevOps.Sprints.SprintFactory;
using Avans_DevOps.Sprints;
using Avans_DevOps.VersionControl.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_DevOps.Visitor;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseActions;
using Avans_DevOps.Pipelines.PipelineActions.AnalyseComponents;
using Avans_DevOps.Pipelines.PipelineActions.SourceActions;
using Avans_DevOps.Pipelines.PipelineActions.SourceComponents;
using Avans_DevOps.Pipelines;
using Avans_DevOps.Pipelines.PipelineComponents.UtilityComponents;
using Avans_DevOps.Pipelines.PipelineComponents.AnalyseComponents.SonarQubeActions;
using Avans_DevOps.Pipelines.PipelineActions.DeployComponents;
using Avans_DevOps.Pipelines.PipelineActions.BuildComponents;
using Avans_DevOps.Pipelines.PipelineActions.TestActions;
using Avans_DevOps.Pipelines.PipelineActions.TestComponents;
using Avans_DevOps.Pipelines.PipelineComponents.PackageComponents;

namespace Avans_Devops_Tests
{
    public class PipelineTests
    {
        [Fact]
        public void Pipeline_can_be_run_until_source()
        {
            //Arrange
            var pipeline = new Pipeline("Pipeline 1");
            var source = new SourceContainer("source");
            var azure = new SourceAzure("azure");
            var pipelineVisitor = new Mock<IPipelineVisitor>();

            pipeline.AddComponent(source);
            source.AddComponent(azure);
            
            //Act
            pipeline.AcceptVisitor(pipelineVisitor.Object);
            //Assert
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<SourceAzure>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Pipeline_can_be_run_until_analyse()
        {
            //Arrange
            var pipeline = new Pipeline("Pipeline 1");
            var analyse = new AnalyseSonarQube("qube");
            var anal = new AnalyseContainer("analyse");
            var execute = new SonarQubeExecute("exec");
            var pipelineVisitor = new Mock<IPipelineVisitor>();

            //Act
            pipeline.AddComponent(anal);
            anal.AddComponent(analyse);
            analyse.AddComponent(execute);

            pipeline.AcceptVisitor(pipelineVisitor.Object);
            //Assert
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<SonarQubeExecute>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Pipeline_can_be_run_until_action_commands()
        {
            //Arrange
            var pipeline = new Pipeline("Pipeline 1");
            var util = new Utility("util");
            var commando = new Action(() => Console.WriteLine("Doing something after"));
            var pipelineVisitor = new Mock<IPipelineVisitor>();

            //Act
            pipeline.AddComponent(util);
            util.AddAction(commando);
            pipeline.AcceptVisitor(pipelineVisitor.Object);

            //Assert
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<Utility>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Pipeline_can_run_until_deploy()
        {
            //Arrange
            var pipeline = new Pipeline("Pipeline 1");
            var deployContainer = new DeployContainer("container");
            var deployAzure = new DeployAzure("azure");
            var pipelineVisitor = new Mock<IPipelineVisitor>();

            //Act
            pipeline.AddComponent(deployContainer);
            deployContainer.AddComponent(deployAzure);
            pipeline.AcceptVisitor(pipelineVisitor.Object);
            //Assert
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<DeployAzure>()), Times.AtLeastOnce);
        }

        [Fact]
        public void can_run_full_pipeline()
        {
            //Arrange
            var pipelineVisitor = new Mock<IPipelineVisitor>();
            var pipeline = new Pipeline("Pipeline");

                //Act

            //Source
            var source = new SourceContainer("SourceContainer");
            var azureSource = new SourceAzure("SourceAzure");
            var githubSource = new SourceGithub("githubSource");
            source.AddComponent(azureSource);
            pipeline.AddComponent(source);
            source.AddComponent(githubSource);
            //Package
            var package = new Package("Package");
            pipeline.AddComponent(package);
            //Build
            var build = new BuildContainer("BuildContainer");
            var mavenBuild = new BuildMaven("BuildMaven");
            var jenkinsBuild = new BuildJenkins("BuildJenkins");
            var buildAnt = new BuildAnt("ant");
            build.AddComponent(jenkinsBuild);
            build.AddComponent(mavenBuild);
            build.AddComponent(buildAnt);
            pipeline.AddComponent(build);
            //Testing
            var testContainer = new TestContainer("TestContainer");
            var seleniumTest = new SeleniumTests("SeleniumTests");
            var nUnitTest = new NUnitTests("Nunit");
            testContainer.AddComponent(seleniumTest);
            testContainer.AddComponent(nUnitTest);
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

            //Deploy
            var deployContainer = new DeployContainer("deploy");
            var deployAzure = new DeployAzure("azure");
            var deployAWS = new DeployAWS("aws");
            pipeline.AddComponent(deployContainer);
            deployContainer.AddComponent(deployAzure);
            deployContainer.AddComponent(deployAWS);

            // Utility
            var utility = new Utility("Utility");
            var commando = new Action(() => Console.WriteLine("Doing something after"));
            var commando2 = new Action(() => Console.WriteLine("Doing something after 2"));
            var commando3 = new Action(() => Console.WriteLine("Doing something after 3"));
            utility.AddAction(commando);
            utility.AddAction(commando2);
            utility.AddAction(commando3);
            pipeline.AddComponent(utility);

            //Assert
            pipeline.AcceptVisitor(pipelineVisitor.Object);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<DeployAzure>()), Times.AtLeastOnce);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<Utility>()), Times.AtLeastOnce);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<SonarQubeReporting>()), Times.AtLeastOnce);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<BuildJenkins>()), Times.AtLeastOnce);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<Package>()), Times.AtLeastOnce);
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<Pipeline>()), Times.AtLeastOnce);
        }

        [Fact]
        public void can_run_full_pipelinevisitor()
        {
            //Arrange
            var pipelineVisitor = new PipelineVisitor();
            var pipeline = new Pipeline("Pipeline");

            //Act

            //Source
            var source = new SourceContainer("SourceContainer");
            var azureSource = new SourceAzure("SourceAzure");
            var githubSource = new SourceGithub("githubSource");
            source.AddComponent(azureSource);
            pipeline.AddComponent(source);
            source.AddComponent(githubSource);
            //Package
            var package = new Package("Package");
            pipeline.AddComponent(package);
            //Build
            var build = new BuildContainer("BuildContainer");
            var mavenBuild = new BuildMaven("BuildMaven");
            var jenkinsBuild = new BuildJenkins("BuildJenkins");
            var buildAnt = new BuildAnt("ant");
            build.AddComponent(jenkinsBuild);
            build.AddComponent(mavenBuild);
            build.AddComponent(buildAnt);
            pipeline.AddComponent(build);
            //Testing
            var testContainer = new TestContainer("TestContainer");
            var seleniumTest = new SeleniumTests("SeleniumTests");
            var nUnitTest = new NUnitTests("Nunit");
            testContainer.AddComponent(seleniumTest);
            testContainer.AddComponent(nUnitTest);
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

            //Deploy
            var deployContainer = new DeployContainer("deploy");
            var deployAzure = new DeployAzure("azure");
            var deployAWS = new DeployAWS("aws");
            pipeline.AddComponent(deployContainer);
            deployContainer.AddComponent(deployAzure);
            deployContainer.AddComponent(deployAWS);

            // Utility
            var utility = new Utility("Utility");
            var commando = new Action(() => Console.WriteLine("Doing something after"));
            var commando2 = new Action(() => Console.WriteLine("Doing something after 2"));
            var commando3 = new Action(() => Console.WriteLine("Doing something after 3"));
            utility.AddAction(commando);
            utility.AddAction(commando2);
            utility.AddAction(commando3);
            pipeline.AddComponent(utility);

            //Assert
            pipeline.AcceptVisitor(pipelineVisitor);

            Assert.True(true);
        }
    }
}
