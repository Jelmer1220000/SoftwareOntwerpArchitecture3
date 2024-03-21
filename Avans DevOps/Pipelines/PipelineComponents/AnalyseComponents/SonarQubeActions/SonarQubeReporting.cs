using Avans_DevOps.Pipelines.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents.AnalyseComponents.SonarQubeActions
{
    public class SonarQubeReporting : PipelineComponent
    {
        public SonarQubeReporting(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
