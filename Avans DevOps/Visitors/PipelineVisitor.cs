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

namespace Avans_DevOps.Visitor
{
    public class PipelineVisitor : IPipelineVisitor
    {
        public void Visit(Pipeline component)
        {
            Console.WriteLine(component.Execute());
        }

        public void Visit(AnalyseSonarQube sonarQube)
        {
            Console.WriteLine(sonarQube.Execute());
        }

        public void Visit(AnalyseContainer container)
        {
            Console.WriteLine(container.Execute());
        }

        public void Visit(SonarQubeExecute execute)
        {
            Console.WriteLine(execute.Execute());
        }

        public void Visit(SonarCubePreparation preperation)
        {
            Console.WriteLine(preperation.Execute());
        }

        public void Visit(SonarQubeReporting reporting)
        {
            Console.WriteLine(reporting.Execute());
        }

        public void Visit(BuildContainer buildContainer)
        {
            Console.WriteLine(buildContainer.Execute());
        }

        public void Visit(BuildAnt buildAnt)
        {
            Console.WriteLine(buildAnt.Execute());
        }

        public void Visit(BuildJenkins buildJenkins)
        {
            Console.WriteLine(buildJenkins.Execute());
        }

        public void Visit(BuildMaven buildMaven)
        {
            Console.WriteLine(buildMaven.Execute());
        }

        public void Visit(DeployContainer deployContainer)
        {
            Console.WriteLine(deployContainer.Execute());
        }

        public void Visit(DeployAzure deployAzure)
        {
            Console.WriteLine(deployAzure.Execute());
        }

        public void Visit(DeployAWS deployAWS)
        {
            Console.WriteLine(deployAWS.Execute());
        }

        public void Visit(SourceContainer sourceContainer)
        {
            Console.WriteLine(sourceContainer.Execute());
        }

        public void Visit(SourceAzure sourceAzure)
        {
            //TEST PIPELINE FAIL
            //throw new InvalidOperationException("Azure not found");
            Console.WriteLine(sourceAzure.Execute());
        }

        public void Visit(SourceGithub sourceGithub)
        {
            Console.WriteLine(sourceGithub.Execute());
        }

        public void Visit(TestContainer testContainer)
        {
            Console.WriteLine(testContainer.Execute());
        }

        public void Visit(SeleniumTests seleniumTests)
        {
            Console.WriteLine(seleniumTests.Execute());
        }

        public void Visit(NUnitTests nUnitTests)
        {
            Console.WriteLine(nUnitTests.Execute());
        }

        public void Visit(Package package)
        {
            Console.WriteLine(package.Execute());
        }

        public void Visit(Utility utility)
        {
            Console.WriteLine(utility.Execute());
            foreach (var action in utility.actionList)
            {
                action.Invoke();
            }
        }
    }
}
