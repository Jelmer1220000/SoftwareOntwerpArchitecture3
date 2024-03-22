using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineActions.AnalyseActions
{
    public class AnalyseContainer : PipelineCompositeComponent
    {
        public AnalyseContainer(string name) : base(name)
        {

        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }

    }
}
