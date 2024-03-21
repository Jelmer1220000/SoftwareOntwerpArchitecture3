using Avans_DevOps.Pipelines.Visitor;

namespace Avans_DevOps.Pipelines
{
    public abstract class PipelineComponent
    {
        public string Name;

        public PipelineComponent(string name)
        {
            Name = name;
        }

        public virtual string Execute()
        {
            return $"{GetType().Name}: Running";
        }

        public abstract void AcceptVisitor(IPipelineVisitor visitor);
    }
}
