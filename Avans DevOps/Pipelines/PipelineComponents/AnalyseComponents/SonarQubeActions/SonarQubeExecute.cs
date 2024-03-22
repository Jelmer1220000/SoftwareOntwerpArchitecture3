using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents.AnalyseComponents.SonarQubeActions
{
    public class SonarQubeExecute : PipelineComponent
    {
        public SonarQubeExecute(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
