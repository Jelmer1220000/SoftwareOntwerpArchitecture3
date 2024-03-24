using Avans_DevOps.Visitor;

namespace Avans_DevOps.Pipelines
{
    public abstract class PipelineCompositeComponent : PipelineComponent
    {
        private IList<PipelineComponent> _pipelineComponents = [];

        protected PipelineCompositeComponent(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            foreach (var comp in _pipelineComponents)
            {
                comp.AcceptVisitor(visitor);
            }
        }

        public virtual string Execute()
        {
            return $"Container running: {GetType().Name}";
        }


        public void AddComponent(PipelineComponent component)
        {
            _pipelineComponents.Add(component);
        }

        public void RemoveComponent(PipelineComponent component)
        {
            _pipelineComponents.Remove(component);
        }
    }
}
