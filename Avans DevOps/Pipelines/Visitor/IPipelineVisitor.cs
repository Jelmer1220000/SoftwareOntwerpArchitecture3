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

namespace Avans_DevOps.Pipelines.Visitor
{
    public interface IPipelineVisitor
    {
        void Visit(Pipeline component);
        void Visit(AnalyseSonarQube sonarQube);
        void Visit(AnalyseContainer container);
        void Visit(Execute execute);
        void Visit(Preperation preperation);
        void Visit(Reporting reporting);
        void Visit(BuildContainer buildContainer);
        void Visit(BuildAnt buildAnt);
        void Visit(BuildJenkins buildJenkins);
        void Visit(BuildMaven buildMaven);
        void Visit(DeployContainer deployContainer);
        void Visit(DeployAzure deployAzure);
        void Visit(DeployAWS deployAWS);
        void Visit(SourceContainer sourceContainer);
        void Visit(SourceAzure sourceAzure);
        void Visit(SourceGithub sourceGithub);
        void Visit(TestContainer testContainer);
        void Visit(SeleniumTests seleniumTests);
        void Visit(NUnitTests nUnitTests);
    }
}
