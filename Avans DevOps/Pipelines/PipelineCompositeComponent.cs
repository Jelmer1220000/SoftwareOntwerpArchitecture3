using Avans_DevOps.Pipelines.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
