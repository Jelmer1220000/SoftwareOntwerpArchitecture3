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

            //Act
            pipeline.AddComponent(deployContainer);
            deployContainer.AddComponent(deployAzure);
            var pipelineVisitor = new Mock<IPipelineVisitor>();
            pipeline.AcceptVisitor(pipelineVisitor.Object);
            //Assert
            pipelineVisitor.Verify(x => x.Visit(It.IsAny<DeployAzure>()), Times.AtLeastOnce);
        }
    }
}
