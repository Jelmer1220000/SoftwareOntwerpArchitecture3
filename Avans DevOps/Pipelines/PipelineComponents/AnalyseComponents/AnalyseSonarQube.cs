using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineActions.AnalyseComponents
{
    public class AnalyseSonarQube : PipelineCompositeComponent
    {
        public AnalyseSonarQube(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
