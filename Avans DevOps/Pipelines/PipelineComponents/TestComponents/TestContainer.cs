using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineActions.TestActions
{
    public class TestContainer : PipelineCompositeComponent
    {
        public TestContainer(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
