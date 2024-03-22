using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents
{
    public class Pipeline : PipelineCompositeComponent
    {
        public Pipeline(string name) : base(name)
        {
        }

        public override string Execute()
        {
            return $"Starting pipeline: {Name}";
        }
        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
