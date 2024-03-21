using Avans_DevOps.Pipelines.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents
{
    public class Pipeline : PipelineCompositeComponent
    {
        public Pipeline(string name) : base(name)
        {
        }
        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
