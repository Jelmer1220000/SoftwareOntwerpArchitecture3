using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents.AnalyseComponents.SonarQubeActions
{
    public class SonarCubePreparation : PipelineComponent
    {
        public SonarCubePreparation(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
