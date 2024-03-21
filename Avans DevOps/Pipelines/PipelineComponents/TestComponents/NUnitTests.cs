using Avans_DevOps.Pipelines.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Pipelines.PipelineActions.TestComponents
{
    public class NUnitTests : PipelineComponent
    {
        public NUnitTests(string name) : base(name)
        {
        }

        public override void AcceptVisitor(IPipelineVisitor visitor)
        {
           visitor.Visit(this);
        }
    }
}
