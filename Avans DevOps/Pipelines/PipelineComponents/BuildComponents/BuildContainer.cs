using Avans_DevOps.Pipelines.Visitor;

namespace Avans_DevOps.Pipelines.PipelineActions.BuildComponents
{
    public class BuildContainer : PipelineCompositeComponent
    {
        public BuildContainer(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
