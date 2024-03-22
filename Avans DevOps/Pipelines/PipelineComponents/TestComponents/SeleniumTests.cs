using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineActions.TestComponents
{
    public class SeleniumTests : PipelineComponent
    {
        public SeleniumTests(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
