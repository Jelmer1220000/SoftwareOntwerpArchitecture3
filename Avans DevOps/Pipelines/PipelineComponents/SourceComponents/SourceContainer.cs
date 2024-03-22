using Avans_DevOps.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Pipelines.PipelineActions.SourceActions
{
    public class SourceContainer : PipelineCompositeComponent
    {
        public SourceContainer(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
            visitor.Visit(this);
            base.AcceptVisitor(visitor);
        }
    }
}
