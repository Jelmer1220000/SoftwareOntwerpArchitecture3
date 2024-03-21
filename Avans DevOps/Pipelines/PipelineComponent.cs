using Avans_DevOps.Pipelines.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return $"{GetType().Name: Running}";
        }

        public abstract void AcceptVisitor(IPipelineVisitor visitor);
    }
}
