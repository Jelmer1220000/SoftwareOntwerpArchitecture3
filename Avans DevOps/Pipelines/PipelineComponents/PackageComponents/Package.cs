using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines.PipelineComponents.PackageComponents
{
    public class Package : PipelineComponent
    {
        public Package(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
